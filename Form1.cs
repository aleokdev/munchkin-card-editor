using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Utf8Json;

namespace munchkin_card_editor
{
    public partial class MainForm : Form
    {
        string cardpackPath = null;
        CardpackData data = new CardpackData();
        Card[] _cardsEditing;
        Card[] cardsEditing
        {
            get => _cardsEditing;
            set
            {
                if (_cardsEditing != null)
                    foreach(Card card in _cardsEditing)
                        UpdateCardMembers(card);
                _cardsEditing = value;
                UpdateCardDisplayedData();
            }
        }
        Card cardEditing
        {
            get
            {
                if (_cardsEditing == null || _cardsEditing.Length == 0)
                    return null;
                else
                    return _cardsEditing[0];
            }
        }

        public MainForm()
        {
            InitializeComponent();

            displayerStopwatch.Start();
            cardDisplayTimer.Tick += (object o, EventArgs e) => UpdateDisplayedImage();
            cardDisplayTimer.Start();

            foreach (Type style in from type in Assembly.GetExecutingAssembly().GetTypes()
                                   where type != typeof(ICardStyle) && typeof(ICardStyle).IsAssignableFrom(type)
                                   select type)
            {
                cardStyleComboBox.Items.Add(new EncapsulatedCardStyleType(style));
            }

            RefreshListbox();
        }

        private void RefreshListbox()
        {
            cardListBox.DataSource = null;
            cardListBox.DataSource = data.Cards;
        }

        private void addCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Card card = new Card { Title = "New card", Description = "This is a description" };
            data.Cards.Add(card);
            RefreshListbox();
        }

        private void cardListBoxContextStrip_Opening(object sender, CancelEventArgs e)
        {
            deleteCardCtxItem.Enabled = cardListBox.SelectedItem != null;
        }

        const string multiValueSelectionIndicator = "<Different values>";

        private void UpdateCardMembers(Card card)
        {
            Console.WriteLine("Updated members of " + card.ToString());
            if (card == null) return;

            if (cardTitleTextBox.Text != multiValueSelectionIndicator)
                card.Title = cardTitleTextBox.Text;
            if (cardDescriptionTextBox.Text != multiValueSelectionIndicator)
                card.Description = cardDescriptionTextBox.Text;
            if (cardScriptComboBox.Text != multiValueSelectionIndicator)
                card.ScriptPath = cardScriptComboBox.Text;
            if (cardStyleComboBox.SelectedItem != null)
                card.Style = (ICardStyle)Activator.CreateInstance(((EncapsulatedCardStyleType)cardStyleComboBox.SelectedItem).Type);
        }

        private void UpdateDisplayedImage()
        {
            Card card = cardEditing;
            if (card == null) return;

            if (card.Title != cardTitleTextBox.Text || card.Description != cardDescriptionTextBox.Text)
            {
                Console.WriteLine("NOT THE SAME; Updating preview");
                Card preview = new Card
                {
                    Title = cardTitleTextBox.Text,
                    Description = cardDescriptionTextBox.Text
                };

                cardPictureBox.Image?.Dispose();
                cardPictureBox.Image = preview.EditedImage;
            }
        }

        private void UpdateCardDisplayedData()
        {
            if (cardsEditing == null) return;

            Console.WriteLine("Changed!");
            if (cardsEditing.Length == 1)
            {
                Card card = cardEditing;
                if (card == null) return;

                cardTitleTextBox.Text = card.Title;
                cardDescriptionTextBox.Text = card.Description;
                cardScriptComboBox.Text = card.ScriptPath;
                cardPictureBox.Image?.Dispose();
                cardPictureBox.Image = card.EditedImage;

                foreach (var t in cardStyleComboBox.Items.Cast<EncapsulatedCardStyleType>())
                    if (t.Type.Equals(card.Style.GetType()))
                    {
                        cardStyleComboBox.SelectedItem = t;
                        break;
                    }
            }
            else if (cardsEditing.Length > 1)
            {
                string commonTitle = cardEditing.Title;
                foreach (Card card in cardsEditing)
                {
                    if (commonTitle != card.Title)
                        commonTitle = multiValueSelectionIndicator;
                }
                cardTitleTextBox.Text = commonTitle;

                string commonDescription = cardEditing.Description;
                foreach (Card card in cardsEditing)
                {
                    if (commonDescription != card.Description)
                        commonDescription = multiValueSelectionIndicator;
                }
                cardDescriptionTextBox.Text = commonDescription;

                string commonScript = cardEditing.ScriptPath;
                foreach (Card card in cardsEditing)
                {
                    if (commonScript != card.ScriptPath)
                        commonScript = multiValueSelectionIndicator;
                }
                cardScriptComboBox.Text = commonScript;
            }
        }

        private static string GetRelativePath(string filespec, string folder)
        {
            Uri pathUri = new Uri(filespec);
            // Folders must end in a slash
            if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                folder += Path.DirectorySeparatorChar;
            }
            Uri folderUri = new Uri(folder);
            return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }

        private void UpdateScriptPaths()
        {
            cardScriptComboBox.Items.Clear();
            cardScriptComboBox.Items.AddRange(
                (from t in Directory.EnumerateFiles(Path.Combine(cardpackPath, "scripts"), "*.lua", SearchOption.AllDirectories)
                 select GetRelativePath(t, cardpackPath)).ToArray()
                );
        }

        Stopwatch displayerStopwatch = new Stopwatch();

        private void cardListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Card[] newCards = new Card[cardListBox.SelectedIndices.Count];
            cardListBox.SelectedItems.CopyTo(newCards, 0);
            cardsEditing = newCards;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection"
            dialog.ValidateNames = false;
            dialog.CheckFileExists = false;
            dialog.CheckPathExists = true;
            // Always default to Folder Selection.
            dialog.FileName = "Cardpack folder";
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            string cardsJsonPath = Path.Combine(Path.GetDirectoryName(dialog.FileName), "cards.json");
            if (!File.Exists(cardsJsonPath))
            {
                MessageBox.Show("The directory inputted is not a valid cardpack. Valid cardpacks must contain a cards.json file.", "Invalid cardpack", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<Dictionary<string, object>> json;
            using (var stream = new FileStream(cardsJsonPath, FileMode.Open))
                json = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(stream);

            data.Cards.Clear();
            foreach (Dictionary<string, object> cardJson in json)
            {
                Card parsedCard = new Card();
                if (cardJson.TryGetValue("style", out object style))
                    parsedCard.SetStyleFromString((string)style);

                parsedCard.SetDataFromDict(cardJson);
                data.Cards.Add(parsedCard);
            }

            cardpackPath = Path.GetDirectoryName(dialog.FileName);
            UpdateScriptPaths();
            RefreshListbox();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pBarText.Visible = true;
            pBar.Visible = true;
            pBar.Minimum = 0;
            pBar.Value = 0;
            pBar.Step = 1;

            if (cardpackPath == null)
            {
                OpenFileDialog dialog = new OpenFileDialog
                {
                    // Set validate names and check file exists to false otherwise windows will
                    // not let you select "Folder Selection"
                    ValidateNames = false,
                    CheckFileExists = false,
                    CheckPathExists = true,
                    // Always default to Folder Selection.
                    FileName = "Cardpack folder"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                    cardpackPath = Path.GetDirectoryName(dialog.FileName);
                else
                    return;
            }

            // TODO: Set cardpack back texture from somewhere in the application
            string styleFilename = new string((from c in data.Cards[0].Style.GetType().Name where !Path.GetInvalidFileNameChars().Contains(c) select c).ToArray()).ToLower();
            const string backTextureFilename = "textures/dungeon-back.png";
            if (!File.Exists(Path.Combine(cardpackPath, backTextureFilename)))
            {
                using (var f = new FileStream(Path.Combine(cardpackPath, backTextureFilename), FileMode.Create))
                {
                    data.Cards[0].Style.GetBaseBackImage().Save(f, ImageFormat.Png);
                }
            }

            string textureCacheDir = Path.Combine(cardpackPath, "textures/cache/");
            if (!Directory.Exists(textureCacheDir))
                Directory.CreateDirectory(textureCacheDir);

            // Delete old textures
            foreach (string path in Directory.EnumerateFiles(textureCacheDir, "*.png", SearchOption.TopDirectoryOnly))
            {
                File.Delete(path);
            }

            // Save textures
            pBarText.Text = "Saving textures...";
            pBar.Maximum = data.Cards.Count;
            Dictionary<Card, string> texturePaths = new Dictionary<Card, string>();
            uint uid = 0;
            foreach (Card card in data.Cards)
            {
                string titleFilename = new string((from c in card.Title.Replace(" ", "_") where !Path.GetInvalidFileNameChars().Contains(c) select c).ToArray()).ToLower();
                string textureFilename = textureCacheDir + (++uid).ToString() + "_" + titleFilename + ".png";
                using (var f = new FileStream(textureFilename, FileMode.CreateNew))
                {
                    using (Bitmap img = card.EditedImage)
                        img.Save(f, ImageFormat.Png);
                }

                texturePaths.Add(card, textureFilename);
                pBar.PerformStep();
            }

            pBarText.Text = "Creating cards.json...";
            pBar.Value = 0;
            List<Dictionary<string, object>> cardJsonList = new List<Dictionary<string, object>>();
            foreach (Card card in data.Cards)
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("name", card.Title);
                data.Add("description", card.Description);
                data.Add("category", card.Category == CardCategory.Dungeon ? "dungeon" : "treasure");
                data.Add("style", card.Style.GetType().Name);
                data.Add("script", card.ScriptPath);
                data.Add("front_texture", texturePaths[card]);
                pBar.PerformStep();
                cardJsonList.Add(data);
            }

            pBarText.Text = "Saving cards.json...";
            using (var f = new FileStream(Path.Combine(cardpackPath, "cards.json"), FileMode.Create))
            {
                byte[] bytes = JsonSerializer.Serialize(cardJsonList);
                f.Write(bytes, 0, bytes.Length);
            }

            pBar.Visible = false;
            pBarText.Visible = false;
        }

        private void deleteCardCtxItem_Click(object sender, EventArgs e)
        {
            if (cardListBox.SelectedItem == null)
                return;
            int offset = 0;
            foreach (int index in cardListBox.SelectedIndices)
            {
                data.Cards.RemoveAt(index - offset);
                offset++;
            }
            RefreshListbox();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utf8Json;
using System.IO;

using System.Diagnostics;

namespace munchkin_card_editor
{
    public partial class MainForm : Form
    {
        string cardpackPath = null;

        public MainForm()
        {
            InitializeComponent();

            displayerStopwatch.Start();
            cardDisplayTimer.Tick += (object o, EventArgs e) => UpdateCardDisplayer();
            cardDisplayTimer.Start();
        }

        private void addCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Card card = new Card { Title = "New card", Description = "This is a description" };
            card.UpdateImage();
            cardListBox.Items.Add(card);
        }

        private void cardListBoxContextStrip_Opening(object sender, CancelEventArgs e)
        {
            deleteCardCtxItem.Enabled = cardListBox.SelectedItem != null;
        }

        private void UpdateCardDisplayer()
        {
            Card card = (Card)cardListBox.SelectedItem;
            if (card == null) return;

            if (card.Title != cardTitleTextBox.Text || card.Description != cardDescriptionTextBox.Text)
            {
                card.Title = cardTitleTextBox.Text;
                card.Description = cardDescriptionTextBox.Text;
                card.UpdateImage();
                cardPictureBox.Image = card.EditedImage;
            }
        }

        private void UpdateCardFields()
        {
            Card card = (Card)cardListBox.SelectedItem;
            if (card == null) return;

            Console.WriteLine("Changed!");
            if (card.EditedImage == null) card.UpdateImage();
            cardPictureBox.Image = card.EditedImage;
            cardTitleTextBox.Text = card.Title;
            cardDescriptionTextBox.Text = card.Description;
        }

        Stopwatch displayerStopwatch = new Stopwatch();

        private void cardListBox_SelectedValueChanged(object sender, EventArgs e) => UpdateCardFields();

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
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string cardsJsonPath = Path.Combine(Path.GetDirectoryName(dialog.FileName), "cards.json");
                if (!File.Exists(cardsJsonPath))
                {
                    MessageBox.Show("The directory inputted is not a valid cardpack. Valid cardpacks must contain a cards.json file.", "Invalid cardpack", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                List<Dictionary<string, object>> json;
                using(var stream = new FileStream(cardsJsonPath, FileMode.Open))
                    json = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(stream);

                cardListBox.Items.Clear();
                foreach(Dictionary<string, object> cardJson in json)
                {
                    Card parsedCard = new Card();
                    if (cardJson.TryGetValue("style", out object style))
                        parsedCard.SetStyleFromString((string)style);

                    parsedCard.SetDataFromDict(cardJson);
                    cardListBox.Items.Add(parsedCard);
                }

                cardpackPath = Path.GetDirectoryName(dialog.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pBarText.Visible = true;
            pBar.Visible = true;
            pBar.Minimum = 0;
            pBar.Value = 0;
            pBar.Step = 1;

            if(cardpackPath == null)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                // Set validate names and check file exists to false otherwise windows will
                // not let you select "Folder Selection"
                dialog.ValidateNames = false;
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;
                // Always default to Folder Selection.
                dialog.FileName = "Cardpack folder";
                if (dialog.ShowDialog() == DialogResult.OK)
                    cardpackPath = Path.GetDirectoryName(dialog.FileName);
                else
                    return;
            }

            // TODO: Set cardpack back texture from somewhere in the application
            string styleFilename = new string((from c in ((Card)cardListBox.Items[0]).Style.GetType().Name where !Path.GetInvalidFileNameChars().Contains(c) select c).ToArray()).ToLower();
            string backTextureFilename = "textures/" + "back_" + styleFilename + ".png";
            if (!File.Exists(Path.Combine(cardpackPath, "textures/dungeon_back.png")))
            {
                using (var f = new FileStream(Path.Combine(cardpackPath, backTextureFilename), FileMode.Create))
                {
                    ((Card)cardListBox.Items[0]).Style.GetBaseBackImage().Save(f, ImageFormat.Png);
                }
            }

            // Save textures
            pBarText.Text = "Saving textures...";
            pBar.Maximum = cardListBox.Items.Count;
            Dictionary<Card, string> texturePaths = new Dictionary<Card, string>();
            uint uid = 0;
            foreach (Card card in cardListBox.Items)
            {
                card.UpdateImage();

                string titleFilename = new string((from c in card.Title.Replace(" ", "_") where !Path.GetInvalidFileNameChars().Contains(c) select c).ToArray()).ToLower();
                string textureFilename = "textures/" + (++uid).ToString() + "_" + titleFilename + ".png";
                using(var f = new FileStream(Path.Combine(cardpackPath, textureFilename), FileMode.Create))
                {
                    card.EditedImage.Save(f, ImageFormat.Png);
                }
                
                texturePaths.Add(card, textureFilename);
                pBar.PerformStep();
            }

            pBarText.Text = "Creating cards.json...";
            pBar.Value = 0;
            List<Dictionary<string, object>> cardJsonList = new List<Dictionary<string, object>>();
            foreach(Card card in cardListBox.Items)
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("name", card.Title);
                data.Add("description", card.Description);
                data.Add("category", card.Category == CardCategory.Dungeon ? "dungeon" : "treasure");
                data.Add("style", card.Style.GetType().Name);
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
    }
}

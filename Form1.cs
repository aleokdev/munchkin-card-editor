using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

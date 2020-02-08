using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace munchkin_card_editor
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();

            displayerStopwatch.Start();
            cardDisplayTimer.Tick += (object o, EventArgs e)=>UpdateCardDisplayer();
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

            if(card.Title != cardTitleTextBox.Text || card.Description != cardDescriptionTextBox.Text)
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

            cardPictureBox.Image = card.EditedImage;
            cardTitleTextBox.Text = card.Title;
            cardDescriptionTextBox.Text = card.Description;
        }

        Stopwatch displayerStopwatch = new Stopwatch();

        private void cardListBox_SelectedValueChanged(object sender, EventArgs e) => UpdateCardFields();
    }
}

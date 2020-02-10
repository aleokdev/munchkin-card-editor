﻿namespace munchkin_card_editor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            this.cardListBox = new System.Windows.Forms.ListBox();
            this.cardListBoxContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCardCtxItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCardCtxItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cardPictureBox = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cardStyleComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cardDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.cardTitleTextBox = new System.Windows.Forms.TextBox();
            this.cardDisplayTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.cardListBoxContextStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(38, 373);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 13);
            label1.TabIndex = 1;
            label1.Text = "Card Title";
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(5, 402);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(85, 13);
            label2.TabIndex = 3;
            label2.Text = "Card Description";
            // 
            // cardListBox
            // 
            this.cardListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardListBox.ContextMenuStrip = this.cardListBoxContextStrip;
            this.cardListBox.FormattingEnabled = true;
            this.cardListBox.Location = new System.Drawing.Point(5, 4);
            this.cardListBox.Name = "cardListBox";
            this.cardListBox.Size = new System.Drawing.Size(462, 524);
            this.cardListBox.TabIndex = 0;
            this.cardListBox.SelectedValueChanged += new System.EventHandler(this.cardListBox_SelectedValueChanged);
            // 
            // cardListBoxContextStrip
            // 
            this.cardListBoxContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCardCtxItem,
            this.deleteCardCtxItem});
            this.cardListBoxContextStrip.Name = "cardListBoxContextStrip";
            this.cardListBoxContextStrip.Size = new System.Drawing.Size(125, 48);
            this.cardListBoxContextStrip.Opening += new System.ComponentModel.CancelEventHandler(this.cardListBoxContextStrip_Opening);
            // 
            // addCardCtxItem
            // 
            this.addCardCtxItem.Name = "addCardCtxItem";
            this.addCardCtxItem.Size = new System.Drawing.Size(124, 22);
            this.addCardCtxItem.Text = "Add Card";
            this.addCardCtxItem.Click += new System.EventHandler(this.addCardToolStripMenuItem_Click);
            // 
            // deleteCardCtxItem
            // 
            this.deleteCardCtxItem.Name = "deleteCardCtxItem";
            this.deleteCardCtxItem.Size = new System.Drawing.Size(124, 22);
            this.deleteCardCtxItem.Text = "Delete";
            // 
            // cardPictureBox
            // 
            this.cardPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardPictureBox.Location = new System.Drawing.Point(3, 4);
            this.cardPictureBox.Name = "cardPictureBox";
            this.cardPictureBox.Size = new System.Drawing.Size(296, 344);
            this.cardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cardPictureBox.TabIndex = 0;
            this.cardPictureBox.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cardListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(label4);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel2.Controls.Add(this.cardStyleComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.cardDescriptionTextBox);
            this.splitContainer1.Panel2.Controls.Add(label2);
            this.splitContainer1.Panel2.Controls.Add(this.cardTitleTextBox);
            this.splitContainer1.Panel2.Controls.Add(label1);
            this.splitContainer1.Panel2.Controls.Add(this.cardPictureBox);
            this.splitContainer1.Size = new System.Drawing.Size(776, 548);
            this.splitContainer1.SplitterDistance = 470;
            this.splitContainer1.TabIndex = 1;
            // 
            // cardStyleComboBox
            // 
            this.cardStyleComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cardStyleComboBox.FormattingEnabled = true;
            this.cardStyleComboBox.Location = new System.Drawing.Point(96, 482);
            this.cardStyleComboBox.Name = "cardStyleComboBox";
            this.cardStyleComboBox.Size = new System.Drawing.Size(203, 21);
            this.cardStyleComboBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 485);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Card Style";
            // 
            // cardDescriptionTextBox
            // 
            this.cardDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cardDescriptionTextBox.Location = new System.Drawing.Point(96, 399);
            this.cardDescriptionTextBox.Multiline = true;
            this.cardDescriptionTextBox.Name = "cardDescriptionTextBox";
            this.cardDescriptionTextBox.Size = new System.Drawing.Size(203, 76);
            this.cardDescriptionTextBox.TabIndex = 4;
            // 
            // cardTitleTextBox
            // 
            this.cardTitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cardTitleTextBox.Location = new System.Drawing.Point(96, 370);
            this.cardTitleTextBox.Name = "cardTitleTextBox";
            this.cardTitleTextBox.Size = new System.Drawing.Size(203, 20);
            this.cardTitleTextBox.TabIndex = 2;
            // 
            // cardDisplayTimer
            // 
            this.cardDisplayTimer.Interval = 500;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(96, 510);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(203, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(31, 513);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(59, 13);
            label4.TabIndex = 8;
            label4.Text = "Card Script";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 580);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Card Editor";
            this.cardListBoxContextStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox cardListBox;
        private System.Windows.Forms.PictureBox cardPictureBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox cardTitleTextBox;
        private System.Windows.Forms.TextBox cardDescriptionTextBox;
        private System.Windows.Forms.ComboBox cardStyleComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cardListBoxContextStrip;
        private System.Windows.Forms.ToolStripMenuItem addCardCtxItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCardCtxItem;
        private System.Windows.Forms.Timer cardDisplayTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}


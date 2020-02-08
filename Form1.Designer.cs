namespace munchkin_card_editor
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
            this.cardListBox = new System.Windows.Forms.ListBox();
            this.cardPictureBox = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cardTitleTextBox = new System.Windows.Forms.TextBox();
            this.cardDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cardStyleComboBox = new System.Windows.Forms.ComboBox();
            this.cardListBoxContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCardCtxItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCardCtxItem = new System.Windows.Forms.ToolStripMenuItem();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cardListBoxContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardListBox
            // 
            this.cardListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardListBox.FormattingEnabled = true;
            this.cardListBox.Location = new System.Drawing.Point(5, 4);
            this.cardListBox.Name = "cardListBox";
            this.cardListBox.Size = new System.Drawing.Size(462, 550);
            this.cardListBox.TabIndex = 0;
            this.cardListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cardListBox_MouseClick);
            // 
            // cardPictureBox
            // 
            this.cardPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardPictureBox.Location = new System.Drawing.Point(3, 4);
            this.cardPictureBox.Name = "cardPictureBox";
            this.cardPictureBox.Size = new System.Drawing.Size(296, 359);
            this.cardPictureBox.TabIndex = 0;
            this.cardPictureBox.TabStop = false;
            this.cardPictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cardListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cardStyleComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.cardDescriptionTextBox);
            this.splitContainer1.Panel2.Controls.Add(label2);
            this.splitContainer1.Panel2.Controls.Add(this.cardTitleTextBox);
            this.splitContainer1.Panel2.Controls.Add(label1);
            this.splitContainer1.Panel2.Controls.Add(this.cardPictureBox);
            this.splitContainer1.Size = new System.Drawing.Size(776, 563);
            this.splitContainer1.SplitterDistance = 470;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(5, 373);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 13);
            label1.TabIndex = 1;
            label1.Text = "Card Title";
            // 
            // cardTitleTextBox
            // 
            this.cardTitleTextBox.Location = new System.Drawing.Point(63, 370);
            this.cardTitleTextBox.Name = "cardTitleTextBox";
            this.cardTitleTextBox.Size = new System.Drawing.Size(236, 20);
            this.cardTitleTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(5, 402);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(85, 13);
            label2.TabIndex = 3;
            label2.Text = "Card Description";
            // 
            // cardDescriptionTextBox
            // 
            this.cardDescriptionTextBox.Location = new System.Drawing.Point(96, 399);
            this.cardDescriptionTextBox.Multiline = true;
            this.cardDescriptionTextBox.Name = "cardDescriptionTextBox";
            this.cardDescriptionTextBox.Size = new System.Drawing.Size(203, 76);
            this.cardDescriptionTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 485);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Card Style";
            // 
            // cardStyleComboBox
            // 
            this.cardStyleComboBox.FormattingEnabled = true;
            this.cardStyleComboBox.Location = new System.Drawing.Point(63, 482);
            this.cardStyleComboBox.Name = "cardStyleComboBox";
            this.cardStyleComboBox.Size = new System.Drawing.Size(236, 21);
            this.cardStyleComboBox.TabIndex = 6;
            // 
            // cardListBoxContextStrip
            // 
            this.cardListBoxContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCardCtxItem,
            this.deleteCardCtxItem});
            this.cardListBoxContextStrip.Name = "cardListBoxContextStrip";
            this.cardListBoxContextStrip.Size = new System.Drawing.Size(181, 70);
            this.cardListBoxContextStrip.Opening += new System.ComponentModel.CancelEventHandler(this.cardListBoxContextStrip_Opening);
            // 
            // addCardCtxItem
            // 
            this.addCardCtxItem.Name = "addCardCtxItem";
            this.addCardCtxItem.Size = new System.Drawing.Size(180, 22);
            this.addCardCtxItem.Text = "Add Card";
            this.addCardCtxItem.Click += new System.EventHandler(this.addCardToolStripMenuItem_Click);
            // 
            // deleteCardCtxItem
            // 
            this.deleteCardCtxItem.Name = "deleteCardCtxItem";
            this.deleteCardCtxItem.Size = new System.Drawing.Size(180, 22);
            this.deleteCardCtxItem.Text = "Delete";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 580);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Card Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cardListBoxContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}


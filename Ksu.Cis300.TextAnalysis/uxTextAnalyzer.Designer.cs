namespace Ksu.Cis300.TextAnalysis
{
    partial class uxTextAnalyzer
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
            this.uxThresholdText = new System.Windows.Forms.TextBox();
            this.uxListView = new System.Windows.Forms.ListView();
            this.uxFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxVocabulary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxDiffrence = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxWordsUsed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.uxThresholdButton = new System.Windows.Forms.ToolStripMenuItem();
            this.uxMenuStrip = new System.Windows.Forms.MenuStrip();
            this.uxFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.uxMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxThresholdText
            // 
            this.uxThresholdText.Enabled = false;
            this.uxThresholdText.Location = new System.Drawing.Point(244, 0);
            this.uxThresholdText.Name = "uxThresholdText";
            this.uxThresholdText.ReadOnly = true;
            this.uxThresholdText.Size = new System.Drawing.Size(100, 26);
            this.uxThresholdText.TabIndex = 2;
            this.uxThresholdText.TextChanged += new System.EventHandler(this.uxThresholdText_TextChanged);
            // 
            // uxListView
            // 
            this.uxListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uxFileName,
            this.uxVocabulary,
            this.uxDiffrence,
            this.uxWordsUsed});
            this.uxListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxListView.GridLines = true;
            this.uxListView.HideSelection = false;
            this.uxListView.Location = new System.Drawing.Point(0, 36);
            this.uxListView.MultiSelect = false;
            this.uxListView.Name = "uxListView";
            this.uxListView.Size = new System.Drawing.Size(800, 414);
            this.uxListView.TabIndex = 3;
            this.uxListView.UseCompatibleStateImageBehavior = false;
            this.uxListView.View = System.Windows.Forms.View.Details;
            this.uxListView.SelectedIndexChanged += new System.EventHandler(this.uxListView_SelectedIndexChanged);
            // 
            // uxFileName
            // 
            this.uxFileName.Text = "File Name";
            this.uxFileName.Width = 240;
            // 
            // uxVocabulary
            // 
            this.uxVocabulary.Text = "Vocabulary";
            this.uxVocabulary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxVocabulary.Width = 120;
            // 
            // uxDiffrence
            // 
            this.uxDiffrence.Text = "Diffrence";
            this.uxDiffrence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxDiffrence.Width = 120;
            // 
            // uxWordsUsed
            // 
            this.uxWordsUsed.Text = "Words Used";
            this.uxWordsUsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxWordsUsed.Width = 120;
            // 
            // uxOpenFolder
            // 
            this.uxOpenFolder.Name = "uxOpenFolder";
            this.uxOpenFolder.Size = new System.Drawing.Size(127, 32);
            this.uxOpenFolder.Text = "Open Folder";
            this.uxOpenFolder.Click += new System.EventHandler(this.uxOpenFolder_Click);
            // 
            // uxThresholdButton
            // 
            this.uxThresholdButton.Name = "uxThresholdButton";
            this.uxThresholdButton.Size = new System.Drawing.Size(110, 32);
            this.uxThresholdButton.Text = "Threshold:";
            this.uxThresholdButton.Click += new System.EventHandler(this.uxThresholdButton_Click);
            // 
            // uxMenuStrip
            // 
            this.uxMenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.uxMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxOpenFolder,
            this.uxThresholdButton});
            this.uxMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.uxMenuStrip.Name = "uxMenuStrip";
            this.uxMenuStrip.Size = new System.Drawing.Size(800, 36);
            this.uxMenuStrip.TabIndex = 1;
            this.uxMenuStrip.Text = "menuStrip2";
            // 
            // uxTextAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uxListView);
            this.Controls.Add(this.uxThresholdText);
            this.Controls.Add(this.uxMenuStrip);
            this.Name = "uxTextAnalyzer";
            this.Text = "Text Analyzer";
            this.uxMenuStrip.ResumeLayout(false);
            this.uxMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox uxThresholdText;
        private System.Windows.Forms.ListView uxListView;
        private System.Windows.Forms.ColumnHeader uxDiffrence;
        private System.Windows.Forms.ColumnHeader uxWordsUsed;
        private System.Windows.Forms.ColumnHeader uxVocabulary;
        private System.Windows.Forms.ColumnHeader uxFileName;
        private System.Windows.Forms.ToolStripMenuItem uxOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem uxThresholdButton;
        private System.Windows.Forms.MenuStrip uxMenuStrip;
        private System.Windows.Forms.FolderBrowserDialog uxFolderBrowserDialog;
    }
}


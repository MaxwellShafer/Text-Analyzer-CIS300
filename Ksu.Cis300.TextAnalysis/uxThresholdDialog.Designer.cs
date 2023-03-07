namespace Ksu.Cis300.TextAnalysis
{
    partial class uxThresholdDialog
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
            this.uxFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.uxThresholdCounter = new System.Windows.Forms.NumericUpDown();
            this.uxButton = new System.Windows.Forms.Button();
            this.uxFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxThresholdCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // uxFlowLayoutPanel
            // 
            this.uxFlowLayoutPanel.AutoSize = true;
            this.uxFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uxFlowLayoutPanel.Controls.Add(this.uxThresholdCounter);
            this.uxFlowLayoutPanel.Controls.Add(this.uxButton);
            this.uxFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.uxFlowLayoutPanel.Location = new System.Drawing.Point(13, 34);
            this.uxFlowLayoutPanel.Name = "uxFlowLayoutPanel";
            this.uxFlowLayoutPanel.Size = new System.Drawing.Size(126, 64);
            this.uxFlowLayoutPanel.TabIndex = 0;
            this.uxFlowLayoutPanel.WrapContents = false;
            // 
            // uxThresholdCounter
            // 
            this.uxThresholdCounter.DecimalPlaces = 5;
            this.uxThresholdCounter.Increment = new decimal(new int[] {
            100,
            0,
            0,
            327680});
            this.uxThresholdCounter.Location = new System.Drawing.Point(3, 3);
            this.uxThresholdCounter.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxThresholdCounter.Name = "uxThresholdCounter";
            this.uxThresholdCounter.Size = new System.Drawing.Size(120, 26);
            this.uxThresholdCounter.TabIndex = 0;
            this.uxThresholdCounter.Value = new decimal(new int[] {
            400,
            0,
            0,
            327680});
            // 
            // uxButton
            // 
            this.uxButton.Location = new System.Drawing.Point(3, 35);
            this.uxButton.Name = "uxButton";
            this.uxButton.Size = new System.Drawing.Size(75, 26);
            this.uxButton.TabIndex = 1;
            this.uxButton.Text = "OK";
            this.uxButton.UseVisualStyleBackColor = true;
            this.uxButton.Click += new System.EventHandler(this.uxButton_Click);
            // 
            // uxThresholdDialog
            // 
            this.AcceptButton = this.uxButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uxFlowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "uxThresholdDialog";
            this.Load += new System.EventHandler(this.uxThresholdDialog_Load);
            this.uxFlowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxThresholdCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel uxFlowLayoutPanel;
        private System.Windows.Forms.NumericUpDown uxThresholdCounter;
        private System.Windows.Forms.Button uxButton;
    }
}
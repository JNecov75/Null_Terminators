namespace ICC
{
    partial class importFilesForm
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
            this.fileNameTb = new System.Windows.Forms.TextBox();
            this.openPathButton = new System.Windows.Forms.Button();
            this.citiesFileRadio = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.importButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileNameTb
            // 
            this.fileNameTb.Location = new System.Drawing.Point(52, 102);
            this.fileNameTb.Name = "fileNameTb";
            this.fileNameTb.ReadOnly = true;
            this.fileNameTb.Size = new System.Drawing.Size(100, 20);
            this.fileNameTb.TabIndex = 0;
            // 
            // openPathButton
            // 
            this.openPathButton.Location = new System.Drawing.Point(158, 100);
            this.openPathButton.Name = "openPathButton";
            this.openPathButton.Size = new System.Drawing.Size(75, 23);
            this.openPathButton.TabIndex = 1;
            this.openPathButton.Text = "Open";
            this.openPathButton.UseVisualStyleBackColor = true;
            this.openPathButton.Click += new System.EventHandler(this.openPathButton_Click);
            // 
            // citiesFileRadio
            // 
            this.citiesFileRadio.AutoSize = true;
            this.citiesFileRadio.Location = new System.Drawing.Point(52, 128);
            this.citiesFileRadio.Name = "citiesFileRadio";
            this.citiesFileRadio.Size = new System.Drawing.Size(66, 17);
            this.citiesFileRadio.TabIndex = 2;
            this.citiesFileRadio.TabStop = true;
            this.citiesFileRadio.Text = "Cities file";
            this.citiesFileRadio.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(52, 151);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(52, 233);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 4;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // importFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 365);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.citiesFileRadio);
            this.Controls.Add(this.openPathButton);
            this.Controls.Add(this.fileNameTb);
            this.Name = "importFilesForm";
            this.Text = "importFilesForm";
            this.Load += new System.EventHandler(this.importFilesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileNameTb;
        private System.Windows.Forms.Button openPathButton;
        private System.Windows.Forms.RadioButton citiesFileRadio;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button importButton;
    }
}
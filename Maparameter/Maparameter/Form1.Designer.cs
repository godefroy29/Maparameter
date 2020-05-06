namespace Maparameter
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.OfdPic = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenPic = new System.Windows.Forms.Button();
            this.NudBlockSize = new System.Windows.Forms.NumericUpDown();
            this.PbPic = new System.Windows.Forms.PictureBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.BtnSaveLevel = new System.Windows.Forms.Button();
            this.RtbLevel = new System.Windows.Forms.RichTextBox();
            this.BtnWrite = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NudBlockSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbPic)).BeginInit();
            this.SuspendLayout();
            // 
            // OfdPic
            // 
            this.OfdPic.FileName = "openFileDialog1";
            // 
            // btnOpenPic
            // 
            this.btnOpenPic.Location = new System.Drawing.Point(12, 9);
            this.btnOpenPic.Name = "btnOpenPic";
            this.btnOpenPic.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPic.TabIndex = 0;
            this.btnOpenPic.Text = "Open File";
            this.btnOpenPic.UseVisualStyleBackColor = true;
            this.btnOpenPic.Click += new System.EventHandler(this.btnOpenPic_Click);
            // 
            // NudBlockSize
            // 
            this.NudBlockSize.Location = new System.Drawing.Point(304, 12);
            this.NudBlockSize.Name = "NudBlockSize";
            this.NudBlockSize.Size = new System.Drawing.Size(55, 20);
            this.NudBlockSize.TabIndex = 1;
            this.NudBlockSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // PbPic
            // 
            this.PbPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbPic.Location = new System.Drawing.Point(133, 38);
            this.PbPic.Name = "PbPic";
            this.PbPic.Size = new System.Drawing.Size(912, 523);
            this.PbPic.TabIndex = 2;
            this.PbPic.TabStop = false;
            this.PbPic.Click += new System.EventHandler(this.PbPic_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(93, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(205, 20);
            this.txtPath.TabIndex = 4;
            // 
            // BtnSaveLevel
            // 
            this.BtnSaveLevel.Location = new System.Drawing.Point(365, 10);
            this.BtnSaveLevel.Name = "BtnSaveLevel";
            this.BtnSaveLevel.Size = new System.Drawing.Size(75, 23);
            this.BtnSaveLevel.TabIndex = 5;
            this.BtnSaveLevel.Text = "Save";
            this.BtnSaveLevel.UseVisualStyleBackColor = true;
            this.BtnSaveLevel.Click += new System.EventHandler(this.BtnSaveLevel_Click);
            // 
            // RtbLevel
            // 
            this.RtbLevel.Location = new System.Drawing.Point(12, 38);
            this.RtbLevel.Name = "RtbLevel";
            this.RtbLevel.Size = new System.Drawing.Size(105, 523);
            this.RtbLevel.TabIndex = 6;
            this.RtbLevel.Text = "";
            // 
            // BtnWrite
            // 
            this.BtnWrite.Location = new System.Drawing.Point(446, 10);
            this.BtnWrite.Name = "BtnWrite";
            this.BtnWrite.Size = new System.Drawing.Size(75, 23);
            this.BtnWrite.TabIndex = 7;
            this.BtnWrite.Text = "Write";
            this.BtnWrite.UseVisualStyleBackColor = true;
            this.BtnWrite.Click += new System.EventHandler(this.BtnWrite_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1057, 573);
            this.Controls.Add(this.BtnWrite);
            this.Controls.Add(this.RtbLevel);
            this.Controls.Add(this.BtnSaveLevel);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.PbPic);
            this.Controls.Add(this.NudBlockSize);
            this.Controls.Add(this.btnOpenPic);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NudBlockSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OfdPic;
        private System.Windows.Forms.Button btnOpenPic;
        private System.Windows.Forms.NumericUpDown NudBlockSize;
        private System.Windows.Forms.PictureBox PbPic;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button BtnSaveLevel;
        private System.Windows.Forms.RichTextBox RtbLevel;
        private System.Windows.Forms.Button BtnWrite;
    }
}


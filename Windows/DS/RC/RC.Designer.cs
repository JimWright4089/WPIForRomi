namespace RC
{
    partial class RC
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
            this.tDisplay = new System.Windows.Forms.Timer(this.components);
            this.lCount = new System.Windows.Forms.Label();
            this.lDataLength = new System.Windows.Forms.Label();
            this.lMesssage = new System.Windows.Forms.Label();
            this.lStatus = new System.Windows.Forms.Label();
            this.lTime = new System.Windows.Forms.Label();
            this.lSequence = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tDisplay
            // 
            this.tDisplay.Tick += new System.EventHandler(this.tDisplay_Tick);
            // 
            // lCount
            // 
            this.lCount.AutoSize = true;
            this.lCount.Location = new System.Drawing.Point(237, 9);
            this.lCount.Name = "lCount";
            this.lCount.Size = new System.Drawing.Size(35, 13);
            this.lCount.TabIndex = 0;
            this.lCount.Text = "label1";
            // 
            // lDataLength
            // 
            this.lDataLength.AutoSize = true;
            this.lDataLength.Location = new System.Drawing.Point(237, 41);
            this.lDataLength.Name = "lDataLength";
            this.lDataLength.Size = new System.Drawing.Size(35, 13);
            this.lDataLength.TabIndex = 1;
            this.lDataLength.Text = "label1";
            // 
            // lMesssage
            // 
            this.lMesssage.Location = new System.Drawing.Point(12, 177);
            this.lMesssage.Name = "lMesssage";
            this.lMesssage.Size = new System.Drawing.Size(260, 76);
            this.lMesssage.TabIndex = 2;
            this.lMesssage.Text = "label1";
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(237, 68);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(35, 13);
            this.lStatus.TabIndex = 3;
            this.lStatus.Text = "label1";
            // 
            // lTime
            // 
            this.lTime.AutoSize = true;
            this.lTime.Location = new System.Drawing.Point(237, 96);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(35, 13);
            this.lTime.TabIndex = 4;
            this.lTime.Text = "label1";
            // 
            // lSequence
            // 
            this.lSequence.AutoSize = true;
            this.lSequence.Location = new System.Drawing.Point(237, 131);
            this.lSequence.Name = "lSequence";
            this.lSequence.Size = new System.Drawing.Size(35, 13);
            this.lSequence.TabIndex = 5;
            this.lSequence.Text = "label1";
            // 
            // RC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lSequence);
            this.Controls.Add(this.lTime);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.lMesssage);
            this.Controls.Add(this.lDataLength);
            this.Controls.Add(this.lCount);
            this.Name = "RC";
            this.Text = "RC";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RC_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tDisplay;
        private System.Windows.Forms.Label lCount;
        private System.Windows.Forms.Label lDataLength;
        private System.Windows.Forms.Label lMesssage;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Label lTime;
        internal System.Windows.Forms.Label lSequence;
    }
}


namespace ServerCSharpTest
{
    partial class ServerCSharpTest
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
            this.lSin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tDisplay
            // 
            this.tDisplay.Interval = 50;
            this.tDisplay.Tick += new System.EventHandler(this.tDisplay_Tick);
            // 
            // lSin
            // 
            this.lSin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSin.Location = new System.Drawing.Point(12, 24);
            this.lSin.Name = "lSin";
            this.lSin.Size = new System.Drawing.Size(260, 23);
            this.lSin.TabIndex = 0;
            this.lSin.Text = "label1";
            this.lSin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServerCSharpTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lSin);
            this.Name = "ServerCSharpTest";
            this.Text = "Server CSharp Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tDisplay;
        private System.Windows.Forms.Label lSin;
    }
}


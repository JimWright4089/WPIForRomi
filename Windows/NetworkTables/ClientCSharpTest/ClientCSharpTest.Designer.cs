namespace ClientCSharpTest
{
    partial class ClientCSharpTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientCSharpTest));
            this.lDouble = new System.Windows.Forms.Label();
            this.tDisplay = new System.Windows.Forms.Timer(this.components);
            this.lTime = new System.Windows.Forms.Label();
            this.lBool = new System.Windows.Forms.Label();
            this.lString = new System.Windows.Forms.Label();
            this.lDouble2 = new System.Windows.Forms.Label();
            this.lLastTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lDouble
            // 
            this.lDouble.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDouble.Location = new System.Drawing.Point(12, 29);
            this.lDouble.Name = "lDouble";
            this.lDouble.Size = new System.Drawing.Size(260, 23);
            this.lDouble.TabIndex = 0;
            this.lDouble.Text = "label1";
            this.lDouble.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tDisplay
            // 
            this.tDisplay.Interval = 20;
            this.tDisplay.Tick += new System.EventHandler(this.tDisplay_Tick);
            // 
            // lTime
            // 
            this.lTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTime.Location = new System.Drawing.Point(12, 230);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(260, 23);
            this.lTime.TabIndex = 1;
            this.lTime.Text = "label1";
            this.lTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lBool
            // 
            this.lBool.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBool.Location = new System.Drawing.Point(12, 75);
            this.lBool.Name = "lBool";
            this.lBool.Size = new System.Drawing.Size(260, 23);
            this.lBool.TabIndex = 2;
            this.lBool.Text = "label1";
            this.lBool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lString
            // 
            this.lString.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lString.Location = new System.Drawing.Point(12, 52);
            this.lString.Name = "lString";
            this.lString.Size = new System.Drawing.Size(260, 23);
            this.lString.TabIndex = 3;
            this.lString.Text = "label1";
            this.lString.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lDouble2
            // 
            this.lDouble2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDouble2.Location = new System.Drawing.Point(12, 98);
            this.lDouble2.Name = "lDouble2";
            this.lDouble2.Size = new System.Drawing.Size(260, 23);
            this.lDouble2.TabIndex = 4;
            this.lDouble2.Text = "label1";
            this.lDouble2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lLastTime
            // 
            this.lLastTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLastTime.Location = new System.Drawing.Point(12, 207);
            this.lLastTime.Name = "lLastTime";
            this.lLastTime.Size = new System.Drawing.Size(260, 23);
            this.lLastTime.TabIndex = 5;
            this.lLastTime.Text = "label1";
            this.lLastTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClientCSharpTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lLastTime);
            this.Controls.Add(this.lDouble2);
            this.Controls.Add(this.lString);
            this.Controls.Add(this.lBool);
            this.Controls.Add(this.lTime);
            this.Controls.Add(this.lDouble);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientCSharpTest";
            this.Text = "Client CSharp Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lDouble;
        private System.Windows.Forms.Timer tDisplay;
        private System.Windows.Forms.Label lTime;
        private System.Windows.Forms.Label lBool;
        private System.Windows.Forms.Label lString;
        private System.Windows.Forms.Label lDouble2;
        private System.Windows.Forms.Label lLastTime;
    }
}


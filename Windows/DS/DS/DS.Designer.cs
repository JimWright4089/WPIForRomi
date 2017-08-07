namespace DS
{
    partial class DS
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
            this.bA = new System.Windows.Forms.Button();
            this.bTel = new System.Windows.Forms.Button();
            this.bTest = new System.Windows.Forms.Button();
            this.tDisplay = new System.Windows.Forms.Timer(this.components);
            this.lCount = new System.Windows.Forms.Label();
            this.bTestStuff = new System.Windows.Forms.Button();
            this.lStatus = new System.Windows.Forms.Label();
            this.lTime = new System.Windows.Forms.Label();
            this.lSequence = new System.Windows.Forms.Label();
            this.lLength = new System.Windows.Forms.Label();
            this.lRCStatus = new System.Windows.Forms.Label();
            this.lRCTime = new System.Windows.Forms.Label();
            this.lRCSequence = new System.Windows.Forms.Label();
            this.lMessage = new System.Windows.Forms.Label();
            this.cbButton1 = new System.Windows.Forms.CheckBox();
            this.cbButton3 = new System.Windows.Forms.CheckBox();
            this.cbButton0 = new System.Windows.Forms.CheckBox();
            this.cbButton2 = new System.Windows.Forms.CheckBox();
            this.lControl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bA
            // 
            this.bA.Location = new System.Drawing.Point(12, 169);
            this.bA.Name = "bA";
            this.bA.Size = new System.Drawing.Size(75, 23);
            this.bA.TabIndex = 0;
            this.bA.Text = "A";
            this.bA.UseVisualStyleBackColor = true;
            this.bA.Click += new System.EventHandler(this.bA_Click);
            // 
            // bTel
            // 
            this.bTel.Location = new System.Drawing.Point(12, 198);
            this.bTel.Name = "bTel";
            this.bTel.Size = new System.Drawing.Size(75, 23);
            this.bTel.TabIndex = 1;
            this.bTel.Text = "Tel";
            this.bTel.UseVisualStyleBackColor = true;
            this.bTel.Click += new System.EventHandler(this.bTel_Click);
            // 
            // bTest
            // 
            this.bTest.Location = new System.Drawing.Point(12, 227);
            this.bTest.Name = "bTest";
            this.bTest.Size = new System.Drawing.Size(75, 23);
            this.bTest.TabIndex = 2;
            this.bTest.Text = "Test";
            this.bTest.UseVisualStyleBackColor = true;
            this.bTest.Click += new System.EventHandler(this.bTest_Click);
            // 
            // tDisplay
            // 
            this.tDisplay.Interval = 50;
            this.tDisplay.Tick += new System.EventHandler(this.tDisplay_Tick);
            // 
            // lCount
            // 
            this.lCount.AutoSize = true;
            this.lCount.Location = new System.Drawing.Point(237, 9);
            this.lCount.Name = "lCount";
            this.lCount.Size = new System.Drawing.Size(35, 13);
            this.lCount.TabIndex = 3;
            this.lCount.Text = "label1";
            // 
            // bTestStuff
            // 
            this.bTestStuff.Location = new System.Drawing.Point(197, 227);
            this.bTestStuff.Name = "bTestStuff";
            this.bTestStuff.Size = new System.Drawing.Size(75, 23);
            this.bTestStuff.TabIndex = 4;
            this.bTestStuff.Text = "test stuff";
            this.bTestStuff.UseVisualStyleBackColor = true;
            this.bTestStuff.Click += new System.EventHandler(this.bTestStuff_Click);
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(237, 31);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(35, 13);
            this.lStatus.TabIndex = 5;
            this.lStatus.Text = "label1";
            // 
            // lTime
            // 
            this.lTime.AutoSize = true;
            this.lTime.Location = new System.Drawing.Point(237, 58);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(35, 13);
            this.lTime.TabIndex = 6;
            this.lTime.Text = "label1";
            // 
            // lSequence
            // 
            this.lSequence.AutoSize = true;
            this.lSequence.Location = new System.Drawing.Point(237, 84);
            this.lSequence.Name = "lSequence";
            this.lSequence.Size = new System.Drawing.Size(35, 13);
            this.lSequence.TabIndex = 7;
            this.lSequence.Text = "label1";
            // 
            // lLength
            // 
            this.lLength.AutoSize = true;
            this.lLength.Location = new System.Drawing.Point(237, 108);
            this.lLength.Name = "lLength";
            this.lLength.Size = new System.Drawing.Size(35, 13);
            this.lLength.TabIndex = 8;
            this.lLength.Text = "label1";
            // 
            // lRCStatus
            // 
            this.lRCStatus.AutoSize = true;
            this.lRCStatus.Location = new System.Drawing.Point(9, 9);
            this.lRCStatus.Name = "lRCStatus";
            this.lRCStatus.Size = new System.Drawing.Size(35, 13);
            this.lRCStatus.TabIndex = 9;
            this.lRCStatus.Text = "label1";
            // 
            // lRCTime
            // 
            this.lRCTime.AutoSize = true;
            this.lRCTime.Location = new System.Drawing.Point(9, 31);
            this.lRCTime.Name = "lRCTime";
            this.lRCTime.Size = new System.Drawing.Size(35, 13);
            this.lRCTime.TabIndex = 10;
            this.lRCTime.Text = "label2";
            // 
            // lRCSequence
            // 
            this.lRCSequence.AutoSize = true;
            this.lRCSequence.Location = new System.Drawing.Point(12, 58);
            this.lRCSequence.Name = "lRCSequence";
            this.lRCSequence.Size = new System.Drawing.Size(35, 13);
            this.lRCSequence.TabIndex = 11;
            this.lRCSequence.Text = "label1";
            // 
            // lMessage
            // 
            this.lMessage.Location = new System.Drawing.Point(12, 271);
            this.lMessage.Name = "lMessage";
            this.lMessage.Size = new System.Drawing.Size(260, 144);
            this.lMessage.TabIndex = 12;
            this.lMessage.Text = "label1";
            // 
            // cbButton1
            // 
            this.cbButton1.AutoSize = true;
            this.cbButton1.Location = new System.Drawing.Point(106, 192);
            this.cbButton1.Name = "cbButton1";
            this.cbButton1.Size = new System.Drawing.Size(66, 17);
            this.cbButton1.TabIndex = 15;
            this.cbButton1.Text = "Button 1";
            this.cbButton1.UseVisualStyleBackColor = true;
            // 
            // cbButton3
            // 
            this.cbButton3.AutoSize = true;
            this.cbButton3.Location = new System.Drawing.Point(192, 192);
            this.cbButton3.Name = "cbButton3";
            this.cbButton3.Size = new System.Drawing.Size(66, 17);
            this.cbButton3.TabIndex = 16;
            this.cbButton3.Text = "Button 3";
            this.cbButton3.UseVisualStyleBackColor = true;
            // 
            // cbButton0
            // 
            this.cbButton0.AutoSize = true;
            this.cbButton0.Location = new System.Drawing.Point(106, 169);
            this.cbButton0.Name = "cbButton0";
            this.cbButton0.Size = new System.Drawing.Size(66, 17);
            this.cbButton0.TabIndex = 17;
            this.cbButton0.Text = "Button 0";
            this.cbButton0.UseVisualStyleBackColor = true;
            // 
            // cbButton2
            // 
            this.cbButton2.AutoSize = true;
            this.cbButton2.Location = new System.Drawing.Point(192, 169);
            this.cbButton2.Name = "cbButton2";
            this.cbButton2.Size = new System.Drawing.Size(66, 17);
            this.cbButton2.TabIndex = 18;
            this.cbButton2.Text = "Button 2";
            this.cbButton2.UseVisualStyleBackColor = true;
            // 
            // lControl
            // 
            this.lControl.AutoSize = true;
            this.lControl.Location = new System.Drawing.Point(103, 232);
            this.lControl.Name = "lControl";
            this.lControl.Size = new System.Drawing.Size(35, 13);
            this.lControl.TabIndex = 19;
            this.lControl.Text = "label1";
            // 
            // DS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 424);
            this.Controls.Add(this.lControl);
            this.Controls.Add(this.cbButton2);
            this.Controls.Add(this.cbButton0);
            this.Controls.Add(this.cbButton3);
            this.Controls.Add(this.cbButton1);
            this.Controls.Add(this.lMessage);
            this.Controls.Add(this.lRCSequence);
            this.Controls.Add(this.lRCTime);
            this.Controls.Add(this.lRCStatus);
            this.Controls.Add(this.lLength);
            this.Controls.Add(this.lSequence);
            this.Controls.Add(this.lTime);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.bTestStuff);
            this.Controls.Add(this.lCount);
            this.Controls.Add(this.bTest);
            this.Controls.Add(this.bTel);
            this.Controls.Add(this.bA);
            this.Name = "DS";
            this.Text = "DS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DS_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bA;
        private System.Windows.Forms.Button bTel;
        private System.Windows.Forms.Button bTest;
        private System.Windows.Forms.Timer tDisplay;
        private System.Windows.Forms.Label lCount;
        private System.Windows.Forms.Button bTestStuff;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Label lTime;
        private System.Windows.Forms.Label lSequence;
        private System.Windows.Forms.Label lLength;
        private System.Windows.Forms.Label lRCStatus;
        private System.Windows.Forms.Label lRCTime;
        private System.Windows.Forms.Label lRCSequence;
        private System.Windows.Forms.Label lMessage;
        private System.Windows.Forms.CheckBox cbButton1;
        private System.Windows.Forms.CheckBox cbButton3;
        private System.Windows.Forms.CheckBox cbButton0;
        private System.Windows.Forms.CheckBox cbButton2;
        private System.Windows.Forms.Label lControl;
    }
}


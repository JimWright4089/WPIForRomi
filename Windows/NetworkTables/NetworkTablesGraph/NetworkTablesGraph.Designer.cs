namespace NetworkTablesGraph
{
    partial class NetworkTablesGraph
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
            this.lvChannels = new ListViewNF();
            this.chKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbOffset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbCurValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMean = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbLastUpdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bAdd = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.tbMult = new System.Windows.Forms.TextBox();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.lKey = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lMult = new System.Windows.Forms.Label();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOffset = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tDisplay
            // 
            this.tDisplay.Interval = 5;
            this.tDisplay.Tick += new System.EventHandler(this.tDisplay_Tick);
            // 
            // lvChannels
            // 
            this.lvChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lvChannels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chKey,
            this.chColor,
            this.chMult,
            this.cbOffset,
            this.cbCurValue,
            this.chMin,
            this.chMean,
            this.chMax,
            this.cbLastUpdate});
            this.lvChannels.FullRowSelect = true;
            this.lvChannels.Location = new System.Drawing.Point(12, 470);
            this.lvChannels.Name = "lvChannels";
            this.lvChannels.Size = new System.Drawing.Size(843, 159);
            this.lvChannels.TabIndex = 6;
            this.lvChannels.UseCompatibleStateImageBehavior = false;
            this.lvChannels.View = System.Windows.Forms.View.Details;
            this.lvChannels.SelectedIndexChanged += new System.EventHandler(this.lvChannels_SelectedIndexChanged);
            // 
            // chKey
            // 
            this.chKey.Text = "Key";
            this.chKey.Width = 250;
            // 
            // chColor
            // 
            this.chColor.Text = "Color";
            this.chColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chColor.Width = 80;
            // 
            // chMult
            // 
            this.chMult.Text = "Mult";
            this.chMult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chMult.Width = 70;
            // 
            // cbOffset
            // 
            this.cbOffset.Text = "Offset";
            this.cbOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cbOffset.Width = 70;
            // 
            // cbCurValue
            // 
            this.cbCurValue.Text = "Cur Value";
            this.cbCurValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cbCurValue.Width = 70;
            // 
            // chMin
            // 
            this.chMin.Text = "Min";
            this.chMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chMin.Width = 70;
            // 
            // chMean
            // 
            this.chMean.Text = "Mean";
            this.chMean.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chMean.Width = 70;
            // 
            // chMax
            // 
            this.chMax.Text = "Max";
            this.chMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chMax.Width = 70;
            // 
            // cbLastUpdate
            // 
            this.cbLastUpdate.Text = "LastUpdate";
            this.cbLastUpdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cbLastUpdate.Width = 70;
            // 
            // bAdd
            // 
            this.bAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bAdd.Location = new System.Drawing.Point(695, 436);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(75, 23);
            this.bAdd.TabIndex = 4;
            this.bAdd.Text = "Add";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bDelete
            // 
            this.bDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bDelete.Location = new System.Drawing.Point(776, 436);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(75, 23);
            this.bDelete.TabIndex = 5;
            this.bDelete.Text = "Delete";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // tbMult
            // 
            this.tbMult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbMult.Location = new System.Drawing.Point(476, 439);
            this.tbMult.Name = "tbMult";
            this.tbMult.Size = new System.Drawing.Size(78, 20);
            this.tbMult.TabIndex = 2;
            // 
            // tbKey
            // 
            this.tbKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbKey.Location = new System.Drawing.Point(55, 439);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(212, 20);
            this.tbKey.TabIndex = 0;
            // 
            // lKey
            // 
            this.lKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lKey.AutoSize = true;
            this.lKey.Location = new System.Drawing.Point(14, 442);
            this.lKey.Name = "lKey";
            this.lKey.Size = new System.Drawing.Size(28, 13);
            this.lKey.TabIndex = 6;
            this.lKey.Text = "Key:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 442);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Color:";
            // 
            // lMult
            // 
            this.lMult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lMult.AutoSize = true;
            this.lMult.Location = new System.Drawing.Point(449, 442);
            this.lMult.Name = "lMult";
            this.lMult.Size = new System.Drawing.Size(30, 13);
            this.lMult.TabIndex = 8;
            this.lMult.Text = "Mult:";
            // 
            // cbColor
            // 
            this.cbColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(313, 439);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(130, 21);
            this.cbColor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(560, 442);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Offset:";
            // 
            // tbOffset
            // 
            this.tbOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbOffset.Location = new System.Drawing.Point(599, 439);
            this.tbOffset.Name = "tbOffset";
            this.tbOffset.Size = new System.Drawing.Size(78, 20);
            this.tbOffset.TabIndex = 3;
            // 
            // NetworkTablesGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 642);
            this.Controls.Add(this.tbOffset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.lMult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lKey);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.tbMult);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.lvChannels);
            this.DoubleBuffered = true;
            this.Name = "NetworkTablesGraph";
            this.Text = "Graph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetworkTablesGraph_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NetworkTablesGraph_Paint);
            this.Resize += new System.EventHandler(this.NetworkTablesGraph_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tDisplay;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.TextBox tbMult;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label lKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lMult;
        private System.Windows.Forms.ColumnHeader chKey;
        private System.Windows.Forms.ColumnHeader chColor;
        private System.Windows.Forms.ColumnHeader chMult;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOffset;
        private System.Windows.Forms.ColumnHeader cbOffset;
        private System.Windows.Forms.ColumnHeader cbLastUpdate;
        private ListViewNF lvChannels;
        private System.Windows.Forms.ColumnHeader cbCurValue;
        private System.Windows.Forms.ColumnHeader chMin;
        private System.Windows.Forms.ColumnHeader chMean;
        private System.Windows.Forms.ColumnHeader chMax;
    }
}


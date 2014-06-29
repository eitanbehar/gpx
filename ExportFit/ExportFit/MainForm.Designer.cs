namespace ExportFit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxDistance = new System.Windows.Forms.TextBox();
            this.labelDistance = new System.Windows.Forms.Label();
            this.buttonBrowseTcxFilename = new System.Windows.Forms.Button();
            this.textBoxTcxFilename = new System.Windows.Forms.TextBox();
            this.labelTcxFilename = new System.Windows.Forms.Label();
            this.buttonBrowseFitFilename = new System.Windows.Forms.Button();
            this.textBoxFitFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxVirtualRoute = new System.Windows.Forms.CheckBox();
            this.groupBoxVirtualRoute = new System.Windows.Forms.GroupBox();
            this.textBoxLongitude = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLatitude = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxVirtualRoute.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBoxVirtualRoute);
            this.groupBox1.Controls.Add(this.checkBoxVirtualRoute);
            this.groupBox1.Controls.Add(this.textBoxDistance);
            this.groupBox1.Controls.Add(this.labelDistance);
            this.groupBox1.Controls.Add(this.buttonBrowseTcxFilename);
            this.groupBox1.Controls.Add(this.textBoxTcxFilename);
            this.groupBox1.Controls.Add(this.labelTcxFilename);
            this.groupBox1.Controls.Add(this.buttonBrowseFitFilename);
            this.groupBox1.Controls.Add(this.textBoxFitFilename);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // textBoxDistance
            // 
            this.textBoxDistance.BackColor = System.Drawing.Color.LightYellow;
            this.textBoxDistance.Location = new System.Drawing.Point(92, 109);
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.Size = new System.Drawing.Size(92, 20);
            this.textBoxDistance.TabIndex = 8;
            this.textBoxDistance.Text = "4000";
            this.textBoxDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(7, 109);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(66, 13);
            this.labelDistance.TabIndex = 7;
            this.labelDistance.Text = "Distance (m)";
            // 
            // buttonBrowseTcxFilename
            // 
            this.buttonBrowseTcxFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseTcxFilename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseTcxFilename.Location = new System.Drawing.Point(519, 62);
            this.buttonBrowseTcxFilename.Name = "buttonBrowseTcxFilename";
            this.buttonBrowseTcxFilename.Size = new System.Drawing.Size(32, 23);
            this.buttonBrowseTcxFilename.TabIndex = 6;
            this.buttonBrowseTcxFilename.Text = "...";
            this.buttonBrowseTcxFilename.UseVisualStyleBackColor = true;
            this.buttonBrowseTcxFilename.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textBoxTcxFilename
            // 
            this.textBoxTcxFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTcxFilename.BackColor = System.Drawing.Color.LightYellow;
            this.textBoxTcxFilename.Location = new System.Drawing.Point(92, 62);
            this.textBoxTcxFilename.Name = "textBoxTcxFilename";
            this.textBoxTcxFilename.Size = new System.Drawing.Size(421, 20);
            this.textBoxTcxFilename.TabIndex = 5;
            // 
            // labelTcxFilename
            // 
            this.labelTcxFilename.AutoSize = true;
            this.labelTcxFilename.Location = new System.Drawing.Point(7, 62);
            this.labelTcxFilename.Name = "labelTcxFilename";
            this.labelTcxFilename.Size = new System.Drawing.Size(73, 13);
            this.labelTcxFilename.TabIndex = 4;
            this.labelTcxFilename.Text = "TCX Filename";
            // 
            // buttonBrowseFitFilename
            // 
            this.buttonBrowseFitFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseFitFilename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseFitFilename.Location = new System.Drawing.Point(519, 20);
            this.buttonBrowseFitFilename.Name = "buttonBrowseFitFilename";
            this.buttonBrowseFitFilename.Size = new System.Drawing.Size(32, 23);
            this.buttonBrowseFitFilename.TabIndex = 3;
            this.buttonBrowseFitFilename.Text = "...";
            this.buttonBrowseFitFilename.UseVisualStyleBackColor = true;
            this.buttonBrowseFitFilename.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textBoxFitFilename
            // 
            this.textBoxFitFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFitFilename.BackColor = System.Drawing.Color.LightYellow;
            this.textBoxFitFilename.Location = new System.Drawing.Point(92, 20);
            this.textBoxFitFilename.Name = "textBoxFitFilename";
            this.textBoxFitFilename.Size = new System.Drawing.Size(421, 20);
            this.textBoxFitFilename.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FIT Filename";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(495, 319);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(13, 319);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxVirtualRoute
            // 
            this.checkBoxVirtualRoute.AutoSize = true;
            this.checkBoxVirtualRoute.Checked = true;
            this.checkBoxVirtualRoute.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVirtualRoute.Location = new System.Drawing.Point(10, 151);
            this.checkBoxVirtualRoute.Name = "checkBoxVirtualRoute";
            this.checkBoxVirtualRoute.Size = new System.Drawing.Size(134, 17);
            this.checkBoxVirtualRoute.TabIndex = 9;
            this.checkBoxVirtualRoute.Text = "Generate Virtual Route";
            this.checkBoxVirtualRoute.UseVisualStyleBackColor = true;
            this.checkBoxVirtualRoute.CheckedChanged += new System.EventHandler(this.checkBoxVirtualRoute_CheckedChanged);
            // 
            // groupBoxVirtualRoute
            // 
            this.groupBoxVirtualRoute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxVirtualRoute.Controls.Add(this.textBoxLongitude);
            this.groupBoxVirtualRoute.Controls.Add(this.label3);
            this.groupBoxVirtualRoute.Controls.Add(this.textBoxLatitude);
            this.groupBoxVirtualRoute.Controls.Add(this.label2);
            this.groupBoxVirtualRoute.Location = new System.Drawing.Point(10, 189);
            this.groupBoxVirtualRoute.Name = "groupBoxVirtualRoute";
            this.groupBoxVirtualRoute.Size = new System.Drawing.Size(529, 79);
            this.groupBoxVirtualRoute.TabIndex = 14;
            this.groupBoxVirtualRoute.TabStop = false;
            this.groupBoxVirtualRoute.Text = "Starting Point (Degrees)";
            // 
            // textBoxLongitude
            // 
            this.textBoxLongitude.BackColor = System.Drawing.Color.LightYellow;
            this.textBoxLongitude.Location = new System.Drawing.Point(232, 28);
            this.textBoxLongitude.Name = "textBoxLongitude";
            this.textBoxLongitude.Size = new System.Drawing.Size(89, 20);
            this.textBoxLongitude.TabIndex = 17;
            this.textBoxLongitude.Text = "34.812100";
            this.textBoxLongitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Longitude";
            // 
            // textBoxLatitude
            // 
            this.textBoxLatitude.BackColor = System.Drawing.Color.LightYellow;
            this.textBoxLatitude.Location = new System.Drawing.Point(70, 28);
            this.textBoxLatitude.Name = "textBoxLatitude";
            this.textBoxLatitude.Size = new System.Drawing.Size(89, 20);
            this.textBoxLatitude.TabIndex = 15;
            this.textBoxLatitude.Text = "31.245080";
            this.textBoxLatitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Latitude";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 354);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export FIT to TCX";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxVirtualRoute.ResumeLayout(false);
            this.groupBoxVirtualRoute.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBrowseFitFilename;
        private System.Windows.Forms.TextBox textBoxFitFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDistance;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.Button buttonBrowseTcxFilename;
        private System.Windows.Forms.TextBox textBoxTcxFilename;
        private System.Windows.Forms.Label labelTcxFilename;
        private System.Windows.Forms.GroupBox groupBoxVirtualRoute;
        private System.Windows.Forms.TextBox textBoxLongitude;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLatitude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxVirtualRoute;
    }
}


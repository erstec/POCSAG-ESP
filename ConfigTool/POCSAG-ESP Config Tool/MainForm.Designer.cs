
namespace POCSAG_ESP_Config_Tool
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
            this.bGet = new System.Windows.Forms.Button();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lFreq = new System.Windows.Forms.Label();
            this.tbFreq = new System.Windows.Forms.TextBox();
            this.lFreqMHz = new System.Windows.Forms.Label();
            this.lBaud = new System.Windows.Forms.Label();
            this.nudCode = new System.Windows.Forms.NumericUpDown();
            this.lCode = new System.Windows.Forms.Label();
            this.lFilterID = new System.Windows.Forms.Label();
            this.cbBaudrate = new System.Windows.Forms.ComboBox();
            this.lBaudrateBps = new System.Windows.Forms.Label();
            this.cbxFilterID = new System.Windows.Forms.CheckBox();
            this.lVersion = new System.Windows.Forms.Label();
            this.lBuild = new System.Windows.Forms.Label();
            this.bSend = new System.Windows.Forms.Button();
            this.gbSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCode)).BeginInit();
            this.SuspendLayout();
            // 
            // bGet
            // 
            this.bGet.Enabled = false;
            this.bGet.Location = new System.Drawing.Point(193, 10);
            this.bGet.Name = "bGet";
            this.bGet.Size = new System.Drawing.Size(75, 23);
            this.bGet.TabIndex = 0;
            this.bGet.Text = "Read";
            this.bGet.UseVisualStyleBackColor = true;
            this.bGet.Click += new System.EventHandler(this.bGet_Click);
            // 
            // cbPorts
            // 
            this.cbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(12, 12);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(121, 21);
            this.cbPorts.TabIndex = 1;
            this.cbPorts.DropDown += new System.EventHandler(this.cbPorts_DropDown);
            this.cbPorts.SelectedIndexChanged += new System.EventHandler(this.cbPorts_SelectedIndexChanged);
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.tableLayoutPanel1);
            this.gbSettings.Location = new System.Drawing.Point(12, 55);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(363, 183);
            this.gbSettings.TabIndex = 2;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lBaudrateBps, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lFilterID, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lBaud, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lFreq, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbFreq, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lFreqMHz, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lCode, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudCode, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbBaudrate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxFilterID, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(341, 129);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lFreq
            // 
            this.lFreq.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lFreq.AutoSize = true;
            this.lFreq.Location = new System.Drawing.Point(3, 6);
            this.lFreq.Name = "lFreq";
            this.lFreq.Size = new System.Drawing.Size(57, 13);
            this.lFreq.TabIndex = 0;
            this.lFreq.Text = "Frequency";
            // 
            // tbFreq
            // 
            this.tbFreq.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbFreq.Location = new System.Drawing.Point(66, 3);
            this.tbFreq.Name = "tbFreq";
            this.tbFreq.Size = new System.Drawing.Size(100, 20);
            this.tbFreq.TabIndex = 1;
            // 
            // lFreqMHz
            // 
            this.lFreqMHz.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lFreqMHz.AutoSize = true;
            this.lFreqMHz.Location = new System.Drawing.Point(172, 6);
            this.lFreqMHz.Name = "lFreqMHz";
            this.lFreqMHz.Size = new System.Drawing.Size(29, 13);
            this.lFreqMHz.TabIndex = 2;
            this.lFreqMHz.Text = "MHz";
            // 
            // lBaud
            // 
            this.lBaud.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lBaud.AutoSize = true;
            this.lBaud.Location = new System.Drawing.Point(3, 33);
            this.lBaud.Name = "lBaud";
            this.lBaud.Size = new System.Drawing.Size(50, 13);
            this.lBaud.TabIndex = 3;
            this.lBaud.Text = "Baudrate";
            // 
            // nudCode
            // 
            this.nudCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudCode.Location = new System.Drawing.Point(66, 56);
            this.nudCode.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.nudCode.Name = "nudCode";
            this.nudCode.Size = new System.Drawing.Size(100, 20);
            this.nudCode.TabIndex = 4;
            // 
            // lCode
            // 
            this.lCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lCode.AutoSize = true;
            this.lCode.Location = new System.Drawing.Point(3, 59);
            this.lCode.Name = "lCode";
            this.lCode.Size = new System.Drawing.Size(32, 13);
            this.lCode.TabIndex = 5;
            this.lCode.Text = "Code";
            // 
            // lFilterID
            // 
            this.lFilterID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lFilterID.AutoSize = true;
            this.lFilterID.Location = new System.Drawing.Point(3, 97);
            this.lFilterID.Name = "lFilterID";
            this.lFilterID.Size = new System.Drawing.Size(57, 13);
            this.lFilterID.TabIndex = 6;
            this.lFilterID.Text = "Filter by ID";
            // 
            // cbBaudrate
            // 
            this.cbBaudrate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudrate.FormattingEnabled = true;
            this.cbBaudrate.Items.AddRange(new object[] {
            "1200"});
            this.cbBaudrate.Location = new System.Drawing.Point(66, 29);
            this.cbBaudrate.Name = "cbBaudrate";
            this.cbBaudrate.Size = new System.Drawing.Size(100, 21);
            this.cbBaudrate.TabIndex = 7;
            // 
            // lBaudrateBps
            // 
            this.lBaudrateBps.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lBaudrateBps.AutoSize = true;
            this.lBaudrateBps.Location = new System.Drawing.Point(172, 33);
            this.lBaudrateBps.Name = "lBaudrateBps";
            this.lBaudrateBps.Size = new System.Drawing.Size(24, 13);
            this.lBaudrateBps.TabIndex = 8;
            this.lBaudrateBps.Text = "bps";
            // 
            // cbxFilterID
            // 
            this.cbxFilterID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxFilterID.AutoSize = true;
            this.cbxFilterID.Location = new System.Drawing.Point(66, 97);
            this.cbxFilterID.Name = "cbxFilterID";
            this.cbxFilterID.Size = new System.Drawing.Size(15, 14);
            this.cbxFilterID.TabIndex = 9;
            this.cbxFilterID.UseVisualStyleBackColor = true;
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Location = new System.Drawing.Point(28, 255);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(65, 13);
            this.lVersion.TabIndex = 3;
            this.lVersion.Text = "VersionHere";
            // 
            // lBuild
            // 
            this.lBuild.AutoSize = true;
            this.lBuild.Location = new System.Drawing.Point(28, 278);
            this.lBuild.Name = "lBuild";
            this.lBuild.Size = new System.Drawing.Size(53, 13);
            this.lBuild.TabIndex = 4;
            this.lBuild.Text = "BuildHere";
            // 
            // bSend
            // 
            this.bSend.Enabled = false;
            this.bSend.Location = new System.Drawing.Point(284, 10);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(75, 23);
            this.bSend.TabIndex = 5;
            this.bSend.Text = "Write";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 439);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.lBuild);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.cbPorts);
            this.Controls.Add(this.bGet);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bGet;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lBaudrateBps;
        private System.Windows.Forms.Label lFilterID;
        private System.Windows.Forms.Label lBaud;
        private System.Windows.Forms.Label lFreq;
        private System.Windows.Forms.TextBox tbFreq;
        private System.Windows.Forms.Label lFreqMHz;
        private System.Windows.Forms.Label lCode;
        private System.Windows.Forms.NumericUpDown nudCode;
        private System.Windows.Forms.ComboBox cbBaudrate;
        private System.Windows.Forms.CheckBox cbxFilterID;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.Label lBuild;
        private System.Windows.Forms.Button bSend;
    }
}


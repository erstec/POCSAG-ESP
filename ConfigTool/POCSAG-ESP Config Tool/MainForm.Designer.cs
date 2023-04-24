
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
            this.lUTCOffset = new System.Windows.Forms.Label();
            this.lBaudrateBps = new System.Windows.Forms.Label();
            this.lFilterID = new System.Windows.Forms.Label();
            this.lBaud = new System.Windows.Forms.Label();
            this.lFreq = new System.Windows.Forms.Label();
            this.tbFreq = new System.Windows.Forms.TextBox();
            this.lFreqMHz = new System.Windows.Forms.Label();
            this.lCode = new System.Windows.Forms.Label();
            this.nudCode = new System.Windows.Forms.NumericUpDown();
            this.cbBaudrate = new System.Windows.Forms.ComboBox();
            this.cbxFilterID = new System.Windows.Forms.CheckBox();
            this.nudUTCOffset = new System.Windows.Forms.NumericUpDown();
            this.lUTCOffsetH = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.lBuild = new System.Windows.Forms.Label();
            this.bSend = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.bRestart = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lDim = new System.Windows.Forms.Label();
            this.cbxDim = new System.Windows.Forms.CheckBox();
            this.gbSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUTCOffset)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // bGet
            // 
            this.bGet.Enabled = false;
            this.bGet.Location = new System.Drawing.Point(130, 3);
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
            this.cbPorts.Location = new System.Drawing.Point(3, 3);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(121, 21);
            this.cbPorts.TabIndex = 1;
            this.cbPorts.DropDown += new System.EventHandler(this.cbPorts_DropDown);
            this.cbPorts.SelectedIndexChanged += new System.EventHandler(this.cbPorts_SelectedIndexChanged);
            // 
            // gbSettings
            // 
            this.gbSettings.AutoSize = true;
            this.gbSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbSettings.Controls.Add(this.tableLayoutPanel1);
            this.gbSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSettings.Location = new System.Drawing.Point(3, 38);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(378, 164);
            this.gbSettings.TabIndex = 2;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lDim, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lUTCOffset, 0, 4);
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
            this.tableLayoutPanel1.Controls.Add(this.nudUTCOffset, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lUTCOffsetH, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxDim, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(372, 145);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lUTCOffset
            // 
            this.lUTCOffset.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lUTCOffset.AutoSize = true;
            this.lUTCOffset.Location = new System.Drawing.Point(3, 105);
            this.lUTCOffset.Name = "lUTCOffset";
            this.lUTCOffset.Size = new System.Drawing.Size(60, 13);
            this.lUTCOffset.TabIndex = 10;
            this.lUTCOffset.Text = "UTC Offset";
            // 
            // lBaudrateBps
            // 
            this.lBaudrateBps.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lBaudrateBps.AutoSize = true;
            this.lBaudrateBps.Location = new System.Drawing.Point(175, 33);
            this.lBaudrateBps.Name = "lBaudrateBps";
            this.lBaudrateBps.Size = new System.Drawing.Size(24, 13);
            this.lBaudrateBps.TabIndex = 8;
            this.lBaudrateBps.Text = "bps";
            // 
            // lFilterID
            // 
            this.lFilterID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lFilterID.AutoSize = true;
            this.lFilterID.Location = new System.Drawing.Point(3, 82);
            this.lFilterID.Name = "lFilterID";
            this.lFilterID.Size = new System.Drawing.Size(57, 13);
            this.lFilterID.TabIndex = 6;
            this.lFilterID.Text = "Filter by ID";
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
            this.tbFreq.Location = new System.Drawing.Point(69, 3);
            this.tbFreq.Name = "tbFreq";
            this.tbFreq.Size = new System.Drawing.Size(100, 20);
            this.tbFreq.TabIndex = 1;
            // 
            // lFreqMHz
            // 
            this.lFreqMHz.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lFreqMHz.AutoSize = true;
            this.lFreqMHz.Location = new System.Drawing.Point(175, 6);
            this.lFreqMHz.Name = "lFreqMHz";
            this.lFreqMHz.Size = new System.Drawing.Size(29, 13);
            this.lFreqMHz.TabIndex = 2;
            this.lFreqMHz.Text = "MHz";
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
            // nudCode
            // 
            this.nudCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudCode.Location = new System.Drawing.Point(69, 56);
            this.nudCode.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.nudCode.Name = "nudCode";
            this.nudCode.Size = new System.Drawing.Size(100, 20);
            this.nudCode.TabIndex = 4;
            // 
            // cbBaudrate
            // 
            this.cbBaudrate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudrate.FormattingEnabled = true;
            this.cbBaudrate.Items.AddRange(new object[] {
            "1200"});
            this.cbBaudrate.Location = new System.Drawing.Point(69, 29);
            this.cbBaudrate.Name = "cbBaudrate";
            this.cbBaudrate.Size = new System.Drawing.Size(100, 21);
            this.cbBaudrate.TabIndex = 7;
            // 
            // cbxFilterID
            // 
            this.cbxFilterID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxFilterID.AutoSize = true;
            this.cbxFilterID.Location = new System.Drawing.Point(69, 82);
            this.cbxFilterID.Name = "cbxFilterID";
            this.cbxFilterID.Size = new System.Drawing.Size(15, 14);
            this.cbxFilterID.TabIndex = 9;
            this.cbxFilterID.UseVisualStyleBackColor = true;
            // 
            // nudUTCOffset
            // 
            this.nudUTCOffset.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudUTCOffset.Location = new System.Drawing.Point(69, 102);
            this.nudUTCOffset.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudUTCOffset.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            -2147483648});
            this.nudUTCOffset.Name = "nudUTCOffset";
            this.nudUTCOffset.Size = new System.Drawing.Size(100, 20);
            this.nudUTCOffset.TabIndex = 11;
            // 
            // lUTCOffsetH
            // 
            this.lUTCOffsetH.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lUTCOffsetH.AutoSize = true;
            this.lUTCOffsetH.Location = new System.Drawing.Point(175, 105);
            this.lUTCOffsetH.Name = "lUTCOffsetH";
            this.lUTCOffsetH.Size = new System.Drawing.Size(13, 13);
            this.lUTCOffsetH.TabIndex = 12;
            this.lUTCOffsetH.Text = "h";
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Location = new System.Drawing.Point(3, 0);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(62, 13);
            this.lVersion.TabIndex = 3;
            this.lVersion.Text = "Version n/a";
            // 
            // lBuild
            // 
            this.lBuild.AutoSize = true;
            this.lBuild.Location = new System.Drawing.Point(71, 0);
            this.lBuild.Name = "lBuild";
            this.lBuild.Size = new System.Drawing.Size(50, 13);
            this.lBuild.TabIndex = 4;
            this.lBuild.Text = "Build n/a";
            // 
            // bSend
            // 
            this.bSend.Enabled = false;
            this.bSend.Location = new System.Drawing.Point(211, 3);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(75, 23);
            this.bSend.TabIndex = 5;
            this.bSend.Text = "Write";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.gbSettings, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(384, 234);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel3.Controls.Add(this.bRestart, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbPorts, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.bSend, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.bGet, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(378, 29);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // bRestart
            // 
            this.bRestart.BackColor = System.Drawing.SystemColors.Control;
            this.bRestart.Enabled = false;
            this.bRestart.Location = new System.Drawing.Point(292, 3);
            this.bRestart.Name = "bRestart";
            this.bRestart.Size = new System.Drawing.Size(75, 23);
            this.bRestart.TabIndex = 6;
            this.bRestart.Text = "Restart";
            this.bRestart.UseVisualStyleBackColor = false;
            this.bRestart.Click += new System.EventHandler(this.bRestart_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.lVersion, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lBuild, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 208);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(378, 23);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // lDim
            // 
            this.lDim.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lDim.AutoSize = true;
            this.lDim.Location = new System.Drawing.Point(3, 128);
            this.lDim.Name = "lDim";
            this.lDim.Size = new System.Drawing.Size(60, 13);
            this.lDim.TabIndex = 13;
            this.lDim.Text = "Dim display";
            // 
            // cbxDim
            // 
            this.cbxDim.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxDim.AutoSize = true;
            this.cbxDim.Location = new System.Drawing.Point(69, 128);
            this.cbxDim.Name = "cbxDim";
            this.cbxDim.Size = new System.Drawing.Size(15, 14);
            this.cbxDim.TabIndex = 14;
            this.cbxDim.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(384, 234);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(400, 39);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUTCOffset)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button bRestart;
        private System.Windows.Forms.Label lUTCOffset;
        private System.Windows.Forms.NumericUpDown nudUTCOffset;
        private System.Windows.Forms.Label lUTCOffsetH;
        private System.Windows.Forms.Label lDim;
        private System.Windows.Forms.CheckBox cbxDim;
    }
}


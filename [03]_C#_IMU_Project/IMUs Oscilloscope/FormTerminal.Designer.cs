namespace IMUs_Oscilloscope
{
    partial class FormTerminal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTerminal));
            this.groupBoxSensorA = new System.Windows.Forms.GroupBox();
            this.groupBox_Calibration = new System.Windows.Forms.GroupBox();
            this.checkBox_Calibrate = new System.Windows.Forms.CheckBox();
            this.button_Calibration = new System.Windows.Forms.Button();
            this.progressBar_RomoveBias = new System.Windows.Forms.ProgressBar();
            this.groupBoxAHRS = new System.Windows.Forms.GroupBox();
            this.radioButton_Kalman = new System.Windows.Forms.RadioButton();
            this.radioButton_Complementary = new System.Windows.Forms.RadioButton();
            this.radioButton_Mahony = new System.Windows.Forms.RadioButton();
            this.radioButton_Magdwick = new System.Windows.Forms.RadioButton();
            this.buttonConnectA = new System.Windows.Forms.Button();
            this.groupBoxScopeA = new System.Windows.Forms.GroupBox();
            this.checkBoxMusA = new System.Windows.Forms.CheckBox();
            this.checkBoxGyroA = new System.Windows.Forms.CheckBox();
            this.checkBoxAccA = new System.Windows.Forms.CheckBox();
            this.comboBoxBaudA = new System.Windows.Forms.ComboBox();
            this.labelBaudA = new System.Windows.Forms.Label();
            this.labelPortA = new System.Windows.Forms.Label();
            this.comboBoxPortA = new System.Windows.Forms.ComboBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.panel_IMU = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonFilePath = new System.Windows.Forms.Button();
            this.groupBoxSensorA.SuspendLayout();
            this.groupBox_Calibration.SuspendLayout();
            this.groupBoxAHRS.SuspendLayout();
            this.groupBoxScopeA.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSensorA
            // 
            this.groupBoxSensorA.Controls.Add(this.groupBox_Calibration);
            this.groupBoxSensorA.Controls.Add(this.groupBoxAHRS);
            this.groupBoxSensorA.Controls.Add(this.buttonConnectA);
            this.groupBoxSensorA.Controls.Add(this.groupBoxScopeA);
            this.groupBoxSensorA.Controls.Add(this.comboBoxBaudA);
            this.groupBoxSensorA.Controls.Add(this.labelBaudA);
            this.groupBoxSensorA.Controls.Add(this.labelPortA);
            this.groupBoxSensorA.Controls.Add(this.comboBoxPortA);
            this.groupBoxSensorA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxSensorA.Location = new System.Drawing.Point(12, 48);
            this.groupBoxSensorA.Name = "groupBoxSensorA";
            this.groupBoxSensorA.Size = new System.Drawing.Size(314, 478);
            this.groupBoxSensorA.TabIndex = 0;
            this.groupBoxSensorA.TabStop = false;
            this.groupBoxSensorA.Text = "Sensor Module";
            // 
            // groupBox_Calibration
            // 
            this.groupBox_Calibration.Controls.Add(this.checkBox_Calibrate);
            this.groupBox_Calibration.Controls.Add(this.button_Calibration);
            this.groupBox_Calibration.Controls.Add(this.progressBar_RomoveBias);
            this.groupBox_Calibration.Location = new System.Drawing.Point(6, 230);
            this.groupBox_Calibration.Name = "groupBox_Calibration";
            this.groupBox_Calibration.Size = new System.Drawing.Size(302, 103);
            this.groupBox_Calibration.TabIndex = 7;
            this.groupBox_Calibration.TabStop = false;
            this.groupBox_Calibration.Text = "Remove Bias (Horizontal Still)";
            // 
            // checkBox_Calibrate
            // 
            this.checkBox_Calibrate.AutoSize = true;
            this.checkBox_Calibrate.Location = new System.Drawing.Point(185, 68);
            this.checkBox_Calibrate.Name = "checkBox_Calibrate";
            this.checkBox_Calibrate.Size = new System.Drawing.Size(110, 19);
            this.checkBox_Calibrate.TabIndex = 14;
            this.checkBox_Calibrate.Text = "Calibrate";
            this.checkBox_Calibrate.UseVisualStyleBackColor = true;
            this.checkBox_Calibrate.CheckedChanged += new System.EventHandler(this.checkBox_Calibrate_CheckedChanged);
            // 
            // button_Calibration
            // 
            this.button_Calibration.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Calibration.Location = new System.Drawing.Point(7, 58);
            this.button_Calibration.Name = "button_Calibration";
            this.button_Calibration.Size = new System.Drawing.Size(132, 37);
            this.button_Calibration.TabIndex = 13;
            this.button_Calibration.Text = "Get Bias";
            this.button_Calibration.UseVisualStyleBackColor = true;
            this.button_Calibration.Click += new System.EventHandler(this.button_Calibration_Click);
            // 
            // progressBar_RomoveBias
            // 
            this.progressBar_RomoveBias.Location = new System.Drawing.Point(7, 24);
            this.progressBar_RomoveBias.Name = "progressBar_RomoveBias";
            this.progressBar_RomoveBias.Size = new System.Drawing.Size(288, 24);
            this.progressBar_RomoveBias.TabIndex = 1;
            // 
            // groupBoxAHRS
            // 
            this.groupBoxAHRS.Controls.Add(this.radioButton_Kalman);
            this.groupBoxAHRS.Controls.Add(this.radioButton_Complementary);
            this.groupBoxAHRS.Controls.Add(this.radioButton_Mahony);
            this.groupBoxAHRS.Controls.Add(this.radioButton_Magdwick);
            this.groupBoxAHRS.Location = new System.Drawing.Point(6, 341);
            this.groupBoxAHRS.Name = "groupBoxAHRS";
            this.groupBoxAHRS.Size = new System.Drawing.Size(302, 131);
            this.groupBoxAHRS.TabIndex = 6;
            this.groupBoxAHRS.TabStop = false;
            this.groupBoxAHRS.Text = "AHRS Method";
            // 
            // radioButton_Kalman
            // 
            this.radioButton_Kalman.AutoSize = true;
            this.radioButton_Kalman.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_Kalman.Location = new System.Drawing.Point(73, 100);
            this.radioButton_Kalman.Name = "radioButton_Kalman";
            this.radioButton_Kalman.Size = new System.Drawing.Size(132, 19);
            this.radioButton_Kalman.TabIndex = 4;
            this.radioButton_Kalman.Text = "Kalman Filter";
            this.radioButton_Kalman.UseVisualStyleBackColor = true;
            // 
            // radioButton_Complementary
            // 
            this.radioButton_Complementary.AutoSize = true;
            this.radioButton_Complementary.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_Complementary.Location = new System.Drawing.Point(73, 75);
            this.radioButton_Complementary.Name = "radioButton_Complementary";
            this.radioButton_Complementary.Size = new System.Drawing.Size(188, 19);
            this.radioButton_Complementary.TabIndex = 4;
            this.radioButton_Complementary.Text = "Complementary Filter";
            this.radioButton_Complementary.UseVisualStyleBackColor = true;
            // 
            // radioButton_Mahony
            // 
            this.radioButton_Mahony.AutoSize = true;
            this.radioButton_Mahony.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_Mahony.Location = new System.Drawing.Point(73, 50);
            this.radioButton_Mahony.Name = "radioButton_Mahony";
            this.radioButton_Mahony.Size = new System.Drawing.Size(116, 19);
            this.radioButton_Mahony.TabIndex = 4;
            this.radioButton_Mahony.Text = "Mahony AHRS";
            this.radioButton_Mahony.UseVisualStyleBackColor = true;
            this.radioButton_Mahony.CheckedChanged += new System.EventHandler(this.radioButton_Mahony_CheckedChanged);
            // 
            // radioButton_Magdwick
            // 
            this.radioButton_Magdwick.AutoSize = true;
            this.radioButton_Magdwick.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_Magdwick.Location = new System.Drawing.Point(73, 24);
            this.radioButton_Magdwick.Name = "radioButton_Magdwick";
            this.radioButton_Magdwick.Size = new System.Drawing.Size(132, 19);
            this.radioButton_Magdwick.TabIndex = 3;
            this.radioButton_Magdwick.Text = "Magdwick AHRS";
            this.radioButton_Magdwick.UseVisualStyleBackColor = true;
            this.radioButton_Magdwick.CheckedChanged += new System.EventHandler(this.radioButton_Magdwick_CheckedChanged);
            // 
            // buttonConnectA
            // 
            this.buttonConnectA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonConnectA.Location = new System.Drawing.Point(187, 91);
            this.buttonConnectA.Name = "buttonConnectA";
            this.buttonConnectA.Size = new System.Drawing.Size(121, 36);
            this.buttonConnectA.TabIndex = 5;
            this.buttonConnectA.Text = "Connect";
            this.buttonConnectA.UseVisualStyleBackColor = true;
            this.buttonConnectA.Click += new System.EventHandler(this.buttonConnectA_Click);
            // 
            // groupBoxScopeA
            // 
            this.groupBoxScopeA.Controls.Add(this.checkBoxMusA);
            this.groupBoxScopeA.Controls.Add(this.checkBoxGyroA);
            this.groupBoxScopeA.Controls.Add(this.checkBoxAccA);
            this.groupBoxScopeA.Enabled = false;
            this.groupBoxScopeA.Location = new System.Drawing.Point(6, 123);
            this.groupBoxScopeA.Name = "groupBoxScopeA";
            this.groupBoxScopeA.Size = new System.Drawing.Size(302, 104);
            this.groupBoxScopeA.TabIndex = 4;
            this.groupBoxScopeA.TabStop = false;
            this.groupBoxScopeA.Text = "Raw Data";
            // 
            // checkBoxMusA
            // 
            this.checkBoxMusA.AutoSize = true;
            this.checkBoxMusA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxMusA.Location = new System.Drawing.Point(71, 74);
            this.checkBoxMusA.Name = "checkBoxMusA";
            this.checkBoxMusA.Size = new System.Drawing.Size(221, 19);
            this.checkBoxMusA.TabIndex = 2;
            this.checkBoxMusA.Text = "Show Magnetometer Signal";
            this.checkBoxMusA.UseVisualStyleBackColor = true;
            this.checkBoxMusA.CheckedChanged += new System.EventHandler(this.checkBoxMusA_CheckedChanged);
            // 
            // checkBoxGyroA
            // 
            this.checkBoxGyroA.AutoSize = true;
            this.checkBoxGyroA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxGyroA.Location = new System.Drawing.Point(71, 49);
            this.checkBoxGyroA.Name = "checkBoxGyroA";
            this.checkBoxGyroA.Size = new System.Drawing.Size(197, 19);
            this.checkBoxGyroA.TabIndex = 1;
            this.checkBoxGyroA.Text = "Show Gyroscope Signal";
            this.checkBoxGyroA.UseVisualStyleBackColor = true;
            this.checkBoxGyroA.CheckedChanged += new System.EventHandler(this.checkBoxGyroA_CheckedChanged);
            // 
            // checkBoxAccA
            // 
            this.checkBoxAccA.AutoSize = true;
            this.checkBoxAccA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxAccA.Location = new System.Drawing.Point(71, 24);
            this.checkBoxAccA.Name = "checkBoxAccA";
            this.checkBoxAccA.Size = new System.Drawing.Size(213, 19);
            this.checkBoxAccA.TabIndex = 0;
            this.checkBoxAccA.Text = "Show Accelemeter Signal";
            this.checkBoxAccA.UseVisualStyleBackColor = true;
            this.checkBoxAccA.CheckedChanged += new System.EventHandler(this.checkBoxAccA_CheckedChanged);
            // 
            // comboBoxBaudA
            // 
            this.comboBoxBaudA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxBaudA.FormattingEnabled = true;
            this.comboBoxBaudA.Items.AddRange(new object[] {
            "115200"});
            this.comboBoxBaudA.Location = new System.Drawing.Point(187, 62);
            this.comboBoxBaudA.Name = "comboBoxBaudA";
            this.comboBoxBaudA.Size = new System.Drawing.Size(121, 23);
            this.comboBoxBaudA.TabIndex = 3;
            // 
            // labelBaudA
            // 
            this.labelBaudA.AutoSize = true;
            this.labelBaudA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBaudA.Location = new System.Drawing.Point(98, 64);
            this.labelBaudA.Name = "labelBaudA";
            this.labelBaudA.Size = new System.Drawing.Size(79, 15);
            this.labelBaudA.TabIndex = 2;
            this.labelBaudA.Text = "Baud Rate";
            // 
            // labelPortA
            // 
            this.labelPortA.AutoSize = true;
            this.labelPortA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPortA.Location = new System.Drawing.Point(83, 35);
            this.labelPortA.Name = "labelPortA";
            this.labelPortA.Size = new System.Drawing.Size(95, 15);
            this.labelPortA.TabIndex = 1;
            this.labelPortA.Text = "Serial Port";
            // 
            // comboBoxPortA
            // 
            this.comboBoxPortA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPortA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxPortA.FormattingEnabled = true;
            this.comboBoxPortA.Location = new System.Drawing.Point(187, 32);
            this.comboBoxPortA.Name = "comboBoxPortA";
            this.comboBoxPortA.Size = new System.Drawing.Size(121, 23);
            this.comboBoxPortA.TabIndex = 0;
            this.comboBoxPortA.SelectedIndexChanged += new System.EventHandler(this.comboBoxPortA_SelectedIndexChanged);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.Color.Red;
            this.labelTime.Location = new System.Drawing.Point(13, 13);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(177, 25);
            this.labelTime.TabIndex = 9;
            this.labelTime.Text = "Serial Port is closed!";
            // 
            // panel_IMU
            // 
            this.panel_IMU.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel_IMU.Location = new System.Drawing.Point(333, 57);
            this.panel_IMU.Name = "panel_IMU";
            this.panel_IMU.Size = new System.Drawing.Size(636, 512);
            this.panel_IMU.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSave.Location = new System.Drawing.Point(227, 526);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 42);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save File";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonFilePath
            // 
            this.buttonFilePath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonFilePath.Location = new System.Drawing.Point(12, 526);
            this.buttonFilePath.Name = "buttonFilePath";
            this.buttonFilePath.Size = new System.Drawing.Size(100, 42);
            this.buttonFilePath.TabIndex = 13;
            this.buttonFilePath.Text = "Set File Path";
            this.buttonFilePath.UseVisualStyleBackColor = true;
            this.buttonFilePath.Click += new System.EventHandler(this.buttonFilePath_Click);
            // 
            // FormTerminal
            // 
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(973, 576);
            this.Controls.Add(this.buttonFilePath);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.panel_IMU);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.groupBoxSensorA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTerminal";
            this.Text = "IMU Monitor (by M.Guo)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTerminal_FormClosed);
            this.Load += new System.EventHandler(this.FormTerminal_Load);
            this.groupBoxSensorA.ResumeLayout(false);
            this.groupBoxSensorA.PerformLayout();
            this.groupBox_Calibration.ResumeLayout(false);
            this.groupBox_Calibration.PerformLayout();
            this.groupBoxAHRS.ResumeLayout(false);
            this.groupBoxAHRS.PerformLayout();
            this.groupBoxScopeA.ResumeLayout(false);
            this.groupBoxScopeA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSensorA;
        private System.Windows.Forms.ComboBox comboBoxPortA;
        private System.Windows.Forms.Label labelPortA;
        private System.Windows.Forms.ComboBox comboBoxBaudA;
        private System.Windows.Forms.Label labelBaudA;
        private System.Windows.Forms.GroupBox groupBoxScopeA;
        private System.Windows.Forms.CheckBox checkBoxMusA;
        private System.Windows.Forms.CheckBox checkBoxGyroA;
        private System.Windows.Forms.CheckBox checkBoxAccA;
        private System.Windows.Forms.Button buttonConnectA;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.GroupBox groupBoxAHRS;
        private System.Windows.Forms.Panel panel_IMU;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton radioButton_Kalman;
        private System.Windows.Forms.RadioButton radioButton_Complementary;
        private System.Windows.Forms.RadioButton radioButton_Mahony;
        private System.Windows.Forms.RadioButton radioButton_Magdwick;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonFilePath;
        private System.Windows.Forms.GroupBox groupBox_Calibration;
        private System.Windows.Forms.Button button_Calibration;
        private System.Windows.Forms.ProgressBar progressBar_RomoveBias;
        private System.Windows.Forms.CheckBox checkBox_Calibrate;
    }
}


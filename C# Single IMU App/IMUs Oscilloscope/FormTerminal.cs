using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Globalization;
using Serial_Oscilloscope;
using x_IMU_API;
using System.Threading;
using x_IMU_IMU_and_AHRS_Algorithms;

namespace IMUs_Oscilloscope
{
    public partial class FormTerminal : Form
    {
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        //private Thread readThreadA = new Thread(OpenSerialPortA);
        
        ///
        #region Variables and objects
        private SerialPort serialPortA = new SerialPort();
        bool isSerialPortAConnected = false;
        //bool isMahony = false;
        //bool isMadgwick = false;
        //bool isComplementary = false;
        //bool isKalman = false;


        private xIMUserial xIMUserial;// = new xIMUserial();//通过串口号创建一个XIMUserial的实例

        //private System.Timers.ElapsedEventArgs signalTime = System.Timers.ElapsedEventArgs e;

        /// <summary>
        /// Private receive buffer.
        /// </summary>
        private byte[] receiveBuffer = new byte[256];//256

        /// <summary>
        /// Private receive buffer index.
        /// </summary>
        

        /// <summary>
        /// Gets the number of reception errors.
        /// </summary>
        public int ReceptionErrors { get; private set; }

        /// <summary>
        /// Gets the number of packets read.
        /// </summary>
        public PacketCount PacketsReadCounter { get; private set; }
        /// <summary>
        /// Sample counter to calculate performance statics.
        /// </summary>
        //private SampleCounter sampleCounter = new SampleCounter();
        
        /// <summary>
        /// Oscilloscope channel values decoded from serial stream.
        /// </summary>
        private static float[] channels = new float[9] { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
        private static float[] biasValue = new float[9] { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
        private static float biasNum = 1.0f;
        private static float weightCalibrated = 0.0f;


        /// <summary>
        /// Oscilloscope for channels 1, 2 and 3.
        /// </summary>
        private static Oscilloscope oscilloscope123A = Oscilloscope.CreateScope("Oscilloscope/Oscilloscope_settings.ini", "");
        private static Oscilloscope oscilloscope456A = Oscilloscope.CreateScope("Oscilloscope/Oscilloscope_settings.ini", "");
        private static Oscilloscope oscilloscope789A = Oscilloscope.CreateScope("Oscilloscope/Oscilloscope_settings.ini", "");

        private static Form_3Dcuboid form_3DcuboidB = new Form_3Dcuboid(new string[] {
            "Form_3Dcuboid/RightInv.png",
            "Form_3Dcuboid/LeftInv.png",
            "Form_3Dcuboid/BackInv.png",
            "Form_3Dcuboid/FrontInv.png",
            "Form_3Dcuboid/TopInv.png",
            "Form_3Dcuboid/BottomInv.png" });
        private static BackgroundWorker backgroundWorkerB = new BackgroundWorker();

        //private static AHRS.MadgwickAHRS AHRS = new AHRS.MadgwickAHRS(1f / 125f, 0.1f);//1f / 256f, 0.1f
        private static AHRS.MadgwickAHRS AHRS = new AHRS.MadgwickAHRS(1f / 182f, 0.1f);//1f / 256f, 0.1f
        //private static AHRS.MahonyAHRS AHRS = new AHRS.MahonyAHRS(1f / 182f, 1f);

        private static CsvFileWriter csvFileWriter = null;
        private static bool isSaving = false;
        #endregion
        /// <summary>
        /// Constructor.
        /// </summary>
        public FormTerminal()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        #region Form load and close
        private void FormTerminal_Load(object sender, EventArgs e)
        {
            /// Sensor-I Form Configuration
            /// 
            RefreshSerialPortAList();
            isSerialPortAConnected = false;
            comboBoxBaudA.SelectedItem = "115200";
            buttonConnectA.Text = "Connect";
            groupBoxScopeA.Enabled = false;
            groupBoxAHRS.Enabled = false;
            groupBox_Calibration.Enabled = false;
            buttonFilePath.Enabled = false;
            buttonSave.Enabled = false;

            oscilloscope123A.Caption = "Accelerometer [g]";
            oscilloscope456A.Caption = "Gyroscope [deg/s]";
            oscilloscope789A.Caption = "Magnetometer [G]";

            progressBar_RomoveBias.Enabled = false;
            progressBar_RomoveBias.Minimum = 0;
            progressBar_RomoveBias.Maximum = 50;// SampleTotal;


            radioButton_Magdwick.Checked = false;
            
            //
            form_3DcuboidB.TopLevel = false;
            form_3DcuboidB.Visible = true;

            //panel_IMU.Controls.Clear();
            this.Controls.Add(panel_IMU);
            panel_IMU.Controls.Add(form_3DcuboidB);
            //form_3DcuboidB.Show();
            form_3DcuboidB.FormBorderStyle = FormBorderStyle.None;
            form_3DcuboidB.Dock = System.Windows.Forms.DockStyle.Fill;
            form_3DcuboidB.Text += " B";
            backgroundWorkerB.DoWork += new DoWorkEventHandler(delegate { form_3DcuboidB.Show(); });
            backgroundWorkerB.RunWorkerAsync();


            

        }
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        static void xIMUserial_RotationMatrix(object sender, CalInertialAndMagneticData e)
        {
            form_3DcuboidB.RotationMatrix = (new QuaternionData(AHRS.Quaternion)).ConvertToConjugate().ConvertToRotationMatrix();
        }



        static void xIMUserial_CalInertialAndMagneticDataReceived_updateIMU(object sender, CalInertialAndMagneticData e)
        {
            AHRS.Update(deg2rad(e.Gyroscope[0] - weightCalibrated * biasValue[3]),
                deg2rad(e.Gyroscope[1] - weightCalibrated * biasValue[4]),
                deg2rad(e.Gyroscope[2] - weightCalibrated * biasValue[5]), 
                e.Accelerometer[0] - weightCalibrated * biasValue[0], 
                e.Accelerometer[1] - weightCalibrated * biasValue[1], 
                e.Accelerometer[2]);
        }

        /// <summary>
        /// xIMUserial CalInertialAndMagneticDataReceived event to update algorithm in AHRS mode.
        /// </summary>
        static void xIMUserial_CalInertialAndMagneticDataReceived_updateAHRS(object sender,CalInertialAndMagneticData e)
        {
            AHRS.Update(deg2rad(e.Gyroscope[0] - weightCalibrated * biasValue[3]), 
                deg2rad(e.Gyroscope[1] - weightCalibrated * biasValue[4]), 
                deg2rad(e.Gyroscope[2] - weightCalibrated * biasValue[5]), 
                e.Accelerometer[0] - weightCalibrated * biasValue[0], 
                e.Accelerometer[1] - weightCalibrated * biasValue[1], 
                e.Accelerometer[2], 
                e.Magnetometer[0] - weightCalibrated * biasValue[6], 
                e.Magnetometer[1] - weightCalibrated * biasValue[7], 
                e.Magnetometer[2] - weightCalibrated * biasValue[8]);
        }

        /// <summary>
        /// Mahony AHRS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void xIMUserial_Show_Oscilloscope(object sender, CalInertialAndMagneticData e)
        {
            oscilloscope123A.AddScopeData(e.Accelerometer[0] - weightCalibrated * biasValue[0], 
                                          e.Accelerometer[1] - weightCalibrated * biasValue[1], 
                                          e.Accelerometer[2]);
            oscilloscope456A.AddScopeData(e.Gyroscope[0] - weightCalibrated * biasValue[3], 
                                          e.Gyroscope[1] - weightCalibrated * biasValue[4], 
                                          e.Gyroscope[2] - weightCalibrated * biasValue[5]);
            oscilloscope789A.AddScopeData(e.Magnetometer[0] - 0f * weightCalibrated * biasValue[6],
                                          e.Magnetometer[1] - 0f* weightCalibrated * biasValue[7],
                                          e.Magnetometer[2] - 0f * weightCalibrated * biasValue[8]);
            //oscilloscope789A.AddScopeData(e.Magnetometer[0],
            //e.Magnetometer[1],
            //e.Magnetometer[2]);
        }

        static void xIMUserial_SaveFile(object sender, CalInertialAndMagneticData e)
        {            
            channels[0] = e.Accelerometer[0] ;
            channels[1] = e.Accelerometer[1];
            channels[2] = e.Accelerometer[2];
            channels[3] = e.Gyroscope[0];
            channels[4] = e.Gyroscope[1];
            channels[5] = e.Gyroscope[2];
            channels[6] = e.Magnetometer[0];
            channels[7] = e.Magnetometer[1];
            channels[8] = e.Magnetometer[2];

            if (csvFileWriter != null && isSaving)
            {
                csvFileWriter.WriteCSVline(channels);
            }
        }

        static void xIMUserial_RemoveBias(object sender, CalInertialAndMagneticData e)
        {
            // Recursive MEAN
            // Acc Bias:
            biasValue[0] = biasValue[0] - (biasValue[0] - e.Accelerometer[0]) / biasNum;
            biasValue[1] = biasValue[1] - (biasValue[1] - e.Accelerometer[1]) / biasNum;
            biasValue[2] = biasValue[2] - (biasValue[2] - e.Accelerometer[2]) / biasNum;
            // Gyr Bias:
            biasValue[3] = biasValue[3] - (biasValue[3] - e.Gyroscope[0]) / biasNum;
            biasValue[4] = biasValue[4] - (biasValue[4] - e.Gyroscope[1]) / biasNum;
            biasValue[5] = biasValue[5] - (biasValue[5] - e.Gyroscope[2]) / biasNum;
            // Mag Bias:
            biasValue[6] = biasValue[6] - (biasValue[6] - e.Magnetometer[0]) / biasNum;
            biasValue[7] = biasValue[7] - (biasValue[7] - e.Magnetometer[1]) / biasNum;
            biasValue[8] = biasValue[8] - (biasValue[8] - e.Magnetometer[2]) / biasNum;
            biasNum += 1.0f;
        }


        static float deg2rad(float degrees)
        {
            return (float)(Math.PI / 180) * degrees;
        }
        private void FormTerminal_FormClosed(object sender, FormClosedEventArgs e)
        {
            //CloseSerialPortA();
        }
        #endregion

        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        #region Serial port

        /// <summary>
        /// Updates toolStripMenuItemSerialPort DropDownItems to include all available serial port.
        /// </summary>
        private void RefreshSerialPortAList()
        {
            ComboBox.ObjectCollection comboBoxCollection = comboBoxPortA.Items;
            comboBoxCollection.Clear();
            comboBoxCollection.Add("Refresh List");
            foreach (string portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                comboBoxCollection.Add("COM" + Regex.Replace(portName.Substring("COM".Length, portName.Length - "COM".Length), "[^.0-9]", "\0"));
            }
        }
   



        #endregion

        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
       
        /// <summary>
        /// Sensor-I Forms Events:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPortA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPortA.Text == "Refresh List")
            {
                //CloseSerialPortA();
                RefreshSerialPortAList();
                return;
            }
        }

        private void buttonConnectA_Click(object sender, EventArgs e)
        {
            if(isSerialPortAConnected)//关闭串口
            {
                buttonConnectA.Text = "Disconnected";
                xIMUserial.Close();
                isSerialPortAConnected = false;
                //CloseSerialPortA();
                groupBoxScopeA.Enabled = false;
                groupBoxAHRS.Enabled = false;
                groupBox_Calibration.Enabled = false;
                buttonFilePath.Enabled = false;
                buttonSave.Enabled = false;
                progressBar_RomoveBias.Enabled = false;
                progressBar_RomoveBias.Value = 0;
                button_Calibration.Enabled = false;
                labelTime.ForeColor = Color.Red;
                //oscilloscope123A.HideScope();
                //oscilloscope456A.HideScope();
                //oscilloscope789A.HideScope();
            }
            else//打开串口
            {
                buttonConnectA.Text = "Connected";
                if(comboBoxPortA.Text==null)
                {
                    MessageBox.Show("Please choose Port Name firstly!!!");
                }
                else
                {
                    xIMUserial = new x_IMU_API.xIMUserial(comboBoxPortA.Text);
                    xIMUserial.Open();
                    isSerialPortAConnected = true;
                    xIMUserial.CalInertialAndMagneticDataReceived += 
                        new x_IMU_API.xIMUserial.onCalInertialAndMagneticDataReceived(xIMUserial_Show_Oscilloscope);

                    //xIMUserial.QuaternionDataReceived += new x_IMU_API.xIMUserial.onQuaternionDataReceived(delegate (object s, x_IMU_API.QuaternionData e) { form_3DcuboidA.RotationMatrix = e.ConvertToRotationMatrix(); });
                    xIMUserial.CalInertialAndMagneticDataReceived += 
                        new x_IMU_API.xIMUserial.onCalInertialAndMagneticDataReceived(xIMUserial_RotationMatrix);
                    
                    //xIMUserial.CalInertialAndMagneticDataReceived += new x_IMU_API.xIMUserial.onCalInertialAndMagneticDataReceived(xIMUserial_CalInertialAndMagneticDataReceived_updateAHRS);
                    
                    
                    
                    
                    groupBoxScopeA.Enabled = true;
                    groupBoxAHRS.Enabled = true;
                    groupBox_Calibration.Enabled = true;
                    buttonFilePath.Enabled = true;
                    buttonSave.Enabled = true;
                    labelTime.ForeColor = Color.Green;
                }

            }
        }

        private void checkBoxAccA_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxAccA.Checked)
            {
                oscilloscope123A.ShowScope();
            }
            else
            {
                oscilloscope123A.HideScope();
            }
        }

        private void checkBoxGyroA_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGyroA.Checked)
            {
                oscilloscope456A.ShowScope();
            }
            else
            {
                oscilloscope456A.HideScope();
            }
        }

        private void checkBoxMusA_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMusA.Checked)
            {
                oscilloscope789A.ShowScope();
            }
            else
            {
                oscilloscope789A.HideScope();
            }
        }

        private void buttonFilePath_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Select File Location";
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.OverwritePrompt = false;
            saveFileDialog.FileName = "LoggedData";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                csvFileWriter = new CsvFileWriter(saveFileDialog.FileName.ToString());
                //buttonSave.Enabled = true;
                //button_StartSaving.Enabled = true;
                //button_StopSaving.Enabled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (buttonSave.Text== "Save File")
            {
                buttonSave.Text = "Stop Save";
                xIMUserial.CalInertialAndMagneticDataReceived += 
                    new x_IMU_API.xIMUserial.onCalInertialAndMagneticDataReceived(xIMUserial_SaveFile);
                isSaving = true;
            }
            else
            {
                buttonSave.Text = "Save File";
                isSaving = false;
                if (csvFileWriter != null)
                {
                    csvFileWriter.CloseFile();
                    csvFileWriter = null;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isSerialPortAConnected)//串口打开时才工作
            {
                labelTime.Text = "Serial Port is open now! (" + DateTime.Now.ToString() + ")";
                if(progressBar_RomoveBias.Value <50 && progressBar_RomoveBias.Enabled)
                {
                    progressBar_RomoveBias.Value += 1;
                }
                else
                {
                    xIMUserial.CalInertialAndMagneticDataReceived -= 
                        new x_IMU_API.xIMUserial.onCalInertialAndMagneticDataReceived(xIMUserial_RemoveBias);
                    button_Calibration.Enabled = true;
                    progressBar_RomoveBias.Enabled = false;
                }
            }
            else
            {
                labelTime.Text = "Serial Port is closed!";

            }
        }

        private void radioButton_Magdwick_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Magdwick.Checked)
            {
                xIMUserial.CalInertialAndMagneticDataReceived += 
                    new x_IMU_API.xIMUserial.onCalInertialAndMagneticDataReceived(xIMUserial_CalInertialAndMagneticDataReceived_updateIMU);
            }
            else
            {
                try
                {
                    xIMUserial.CalInertialAndMagneticDataReceived -=
                    new x_IMU_API.xIMUserial.onCalInertialAndMagneticDataReceived(xIMUserial_CalInertialAndMagneticDataReceived_updateIMU);
                }
                finally
                {

                }
            }
        }

        private void radioButton_Mahony_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Mahony.Checked)
            {
                xIMUserial.CalInertialAndMagneticDataReceived +=
                    new xIMUserial.onCalInertialAndMagneticDataReceived(xIMUserial_CalInertialAndMagneticDataReceived_updateAHRS);
            }
            else
            {
                try
                {
                    xIMUserial.CalInertialAndMagneticDataReceived -=
                    new xIMUserial.onCalInertialAndMagneticDataReceived(xIMUserial_CalInertialAndMagneticDataReceived_updateAHRS);
                }
                finally
                {

                }
            }

        }

        private void button_Calibration_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <9; i++)
            {
                biasValue[i] = 0.0f;
            }
            biasNum = 1.0f;
            progressBar_RomoveBias.Value = 0;
            button_Calibration.Enabled = false;
            progressBar_RomoveBias.Enabled = true;
            xIMUserial.CalInertialAndMagneticDataReceived += 
                new x_IMU_API.xIMUserial.onCalInertialAndMagneticDataReceived(xIMUserial_RemoveBias);
        }

        private void checkBox_Calibrate_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_Calibrate.Checked)
            {
                weightCalibrated = 1.0f;
            }
            else
            {
                weightCalibrated = 0.0f;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POCSAG_ESP_Config_Tool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            string appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string appVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            appVersion = appVersion.Substring(0, appVersion.LastIndexOf('.'));
            Text = appName + " v" + appVersion + " by LY3PH";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbBaudrate.SelectedIndex = 0;
        }

        private void InitPortNames()
        {
            //string[] ports = SerialPort.GetPortNames();
            cbPorts.Items.Clear();
            //cbPorts.Items.AddRange(ports);

            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");

                string[] mainDevicesSortingOrder = { "ESP32_COM_", "others" };  // define device sorting order

                foreach (var device in mainDevicesSortingOrder)
                {

                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        if (queryObj["Caption"] != null)
                        {
                            if (queryObj["Caption"].ToString().Contains("(COM"))
                            {
                                string comPortName = Regex.Match(queryObj["Caption"].ToString(), @"\(COM([^)]*)\)").Groups[1].Value;
                                comPortName = "COM" + comPortName;  // add trimmed COM back

                                if (device != "others")
                                {

                                    if (queryObj["DeviceID"].ToString().Contains(device))
                                    {   //Checks if USB device has associated ATT device ID
                                        string pattern = device + @"(..+?)\\";
                                        string AttID = Regex.Match(queryObj["DeviceID"].ToString(), pattern).Groups[1].Value;
                                        if (AttID.EndsWith("B"))
                                            AttID = AttID + "_FM";
                                        cbPorts.Items.Add(comPortName + " - " + device + AttID);
                                    }
                                }
                                else if (queryObj["DeviceID"].ToString().Contains(mainDevicesSortingOrder[0]) || queryObj["DeviceID"].ToString().Contains(mainDevicesSortingOrder[1])) { }
                                else cbPorts.Items.Add(comPortName + " - " + queryObj["Description"]);
                            }
                        }
                    }
                }

            }
            catch (ManagementException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private string portName = "";

        private void cbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comPortName = Regex.Match(cbPorts.Text, @"COM([^ ]*) ").Groups[1].Value;   // from COM to 'space'
            comPortName = "COM" + comPortName;  // add trimmed COM back            

            portName = comPortName;
        }

        private void cbPorts_DropDown(object sender, EventArgs e)
        {
            InitPortNames();

            var senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;

            int vertScrollBarWidth = (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                    ? SystemInformation.VerticalScrollBarWidth : 0;

            var itemsList = senderComboBox.Items.Cast<object>().Select(item => item.ToString());

            foreach (string s in itemsList)
            {
                int newWidth = (int)g.MeasureString(s, font).Width + vertScrollBarWidth;

                if (width < newWidth)
                {
                    width = newWidth;
                }
            }

            senderComboBox.DropDownWidth = width;
        }

        private delegate void SetTextDelegate(object o, string objType, string text);

        private void si_DataReceived(object o, string objType, string data)
        {
            if (objType.Equals("l"))
            {
                Label l = (Label)o;
                l.Text = data.Trim();
            }
            else if (objType.Equals("nud"))
            {
                NumericUpDown n = (NumericUpDown)o;
                int numVal = Int32.Parse(data.Trim());
                n.Value = numVal;
            }
            else if (objType.Equals("cb"))
            {
                ComboBox c = (ComboBox)o;
                cbBaudrate.SelectedText = data.Trim();
            }
            else if (objType.Equals("cbx"))
            {
                CheckBox c = (CheckBox)o;
                c.Checked = data.Trim().Equals("1");
            }
            else if (objType.Equals("tb"))
            {
                TextBox t = (TextBox)o;
                t.Text = data.Trim();
            }
        }

        SerialPort _serialPort;

        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = "";
            while (_serialPort.BytesToRead > 0)
            {
                data = _serialPort.ReadLine();

                if (data.Contains("version"))
                {
                    data = _serialPort.ReadLine();
                    
                    data = _serialPort.ReadLine();
                    // POCSAG-ESP v0.1.1 by LY3PH
                    if (data.StartsWith("POCSAG-ESP"))
                    {
                        string version = data.Substring(12, data.IndexOf(" by") - 12);
                        //lVersion.Text = version;
                        BeginInvoke(new SetTextDelegate(si_DataReceived), new object[] { lVersion, "l", version });

                        data = _serialPort.ReadLine();
                        string build = data;
                        //lBuild.Text = build;
                        BeginInvoke(new SetTextDelegate(si_DataReceived), new object[] { lBuild, "l", build });
                    }
                }
                else if (data.Contains("get"))
                {
                    data = _serialPort.ReadLine();
                    
                    data = _serialPort.ReadLine();
                    string freq = data;
                    BeginInvoke(new SetTextDelegate(si_DataReceived), new object[] { tbFreq, "tb", freq });

                    data = _serialPort.ReadLine();
                    string baud = data;
                    BeginInvoke(new SetTextDelegate(si_DataReceived), new object[] { cbBaudrate, "cb", baud });

                    data = _serialPort.ReadLine();
                    string code = data;
                    BeginInvoke(new SetTextDelegate(si_DataReceived), new object[] { nudCode, "nud", code });

                    data = _serialPort.ReadLine();
                    string filter = data;
                    BeginInvoke(new SetTextDelegate(si_DataReceived), new object[] { cbxFilterID, "cbx", filter });

                }
            }
            
            _serialPort.Close();
            _serialPort.Dispose();
            _serialPort = null;
        }

        private void bGet_Click(object sender, EventArgs e)
        {
            _serialPort = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
            _serialPort.Handshake = Handshake.None;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            _serialPort.WriteTimeout = 500;
            try
            {
                _serialPort.Open();
                _serialPort.Write("version\r\nget\r\n");
            }
            catch (Exception ex)
            {
                //
            }
        }
    }
}

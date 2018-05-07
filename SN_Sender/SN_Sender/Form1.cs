using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace SN_Sender
{
    public partial class Form1 : Form
    {
        private string[] m_old_serialPortNames;
        private bool m_SerialPortOpened = false;
        private List<byte> m_buffer = new List<byte>();

        private const int HEAD = 0;
        private const int LEN = 1;
        private const int CMDTYPE = 2;
        private const int FRAME_ID = 3;
        private List<byte> m_SN_list = new List<byte>();

        //private struct SN_BITS
        //{
        //    public byte SN_BIT_0;
        //    public byte SN_BIT_1;
        //    public byte SN_BIT_2;
        //    public byte SN_BIT_3;
        //    public byte SN_BIT_4;
        //    public byte SN_BIT_5;
        //    public byte SN_BIT_6;
        //    public byte SN_BIT_7;
        //    public byte SN_BIT_8;
        //    public byte SN_BIT_9;
        //    public byte SN_BIT_10;
        //    public byte SN_BIT_11; 
        //    public byte SN_BIT_12; 
        //    public byte SN_BIT_13; 
        //}


        public Form1()
        {
            InitializeComponent();
        }

        private void Init_SerialPort()
        {
            string[] ports = SerialPort.GetPortNames();
           
            if (ports.Length != 0)
            {
                //Array.Sort(ports);
                Array.Sort(ports, (a, b) => Convert.ToInt32(((string)a).Substring(3)).CompareTo(Convert.ToInt32(((string)b).Substring(3))));
                m_old_serialPortNames = ports;
                this.comboBox_portName.Items.AddRange(ports);
                this.comboBox_portName.SelectedIndex = 0;
            }

            this.comboBox_baud.Text = "115200";
            this.comboBox_dataBits.Text = "8";
            this.comboBox_stopBit.Text = "one";
            this.comboBox_parity.Text = "none";
        }

        private void LoadPicture()
        {
            if (!m_SerialPortOpened)
            {
                this.pictureBox1.Load(Environment.CurrentDirectory + @"\" + "red.bmp");
            }
            else
            {
                this.pictureBox1.Load(Environment.CurrentDirectory + @"\" + "green.bmp");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPicture();
            Init_SerialPort();
        }

        private void button_serialPort_connect_Click(object sender, EventArgs e)
        {
            //pictureBox2.Load(Environment.CurrentDirectory + @"\" + "fail.bmp");
            m_SerialPortOpened = !m_SerialPortOpened;

            if (m_SerialPortOpened)
            {
                try
                {
                    this.serialPort1.Open();
                }
                catch (Exception ex)
                {
                    m_SerialPortOpened = false;
                    MessageBox.Show(ex.Message);
                    return;
                }
                this.button_serialPort_connect.Text = "Close";

                m_SerialPortOpened = true;
                this.comboBox_portName.Enabled = false;
                LoadPicture();

            }
            else
            {
                this.button_serialPort_connect.Text = "Connect";
                this.serialPort1.Close();
                m_SerialPortOpened = false;
                LoadPicture();
                this.comboBox_portName.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] names = SerialPort.GetPortNames();

            if (names.Length == 0)
            {
                return;
            }
            if (m_old_serialPortNames == null)
            {
                return;
            }
            //Array.Sort(names);
            Array.Sort(names, (a, b) => Convert.ToInt32(((string)a).Substring(3)).CompareTo(Convert.ToInt32(((string)b).Substring(3))));
            int nCount = 0;
            if (names.Length == m_old_serialPortNames.Length)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i] == m_old_serialPortNames[i])
                    {
                        nCount++;
                    }
                }
                if (nCount == names.Length)  //如果每个都相同
                {
                    return;
                }
                else
                {
                    m_old_serialPortNames = names;  //如果不匹配，将新的值赋给旧的值
                }
            }
            else
            {
                m_old_serialPortNames = names;
            }

            this.comboBox_portName.Items.Clear();

            Array.Sort(names, (a, b) => Convert.ToInt32(((string)a).Substring(3)).CompareTo(Convert.ToInt32(((string)b).Substring(3))));

            this.comboBox_portName.Items.AddRange(names);
            this.comboBox_portName.SelectedIndex = 0; 
        }

        private void ParseFrame0x40()
        {
            int len = m_buffer.Count;
            if (len != 14+4+2)
            {
                MessageBox.Show("下位机发送的SN不是14位!");
                return;
            }

            //将接收到的SN放入m_SN_list中
            for (int i = 4; i < len; i++)
            {
                m_SN_list[i - 4] = m_buffer[i];
            }

            textBox_SN_recv.Text = Convert.ToString(m_SN_list);
            if (textBox_SN_recv.Text == comboBox_SN_send.Text.Trim())
            {
                pictureBox2.Load(Environment.CurrentDirectory + @"\" + "pass.bmp");
                MessageBox.Show("Pass");
            }
            else
            {
                pictureBox2.Load(Environment.CurrentDirectory + @"\" + "fail.bmp");
                MessageBox.Show("Fail");
            }
        }

        private void ParseData2Lists()
        {
            //将数据解析挂入到3个链表中
            if (m_buffer[CMDTYPE] != 0x00)
            {
                return;
            }
            //根据帧类型来判断
            switch (m_buffer[FRAME_ID])
            {
                case 0x40:   //下位机返回0x40,携带SN
                    ParseFrame0x40();
                    break;
                default:
                    break;
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var nPendingRead = this.serialPort1.BytesToRead;
            byte[] tmp = new byte[nPendingRead];
            this.serialPort1.Read(tmp, 0, nPendingRead);

            //m_bRcvParamtersCompleted = false;
            lock (m_buffer)
            {
                m_buffer.AddRange(tmp);
                #region
                while (m_buffer.Count >= 4)
                {
                    if (m_buffer[HEAD] == 0xFF) //帧头
                    {
                        int len = Convert.ToInt32(m_buffer[LEN]); // 获取帧长度(不包含checksum1和checksum2)
                        if (m_buffer.Count < len + 2)  //数据没有接收完全，继续接收
                        {
                            break;
                        }
                        int checksum = 256 * Convert.ToInt32(m_buffer[len]) + Convert.ToInt32(m_buffer[len + 1]);
                        int sum = 0;
                        for (int i = 1; i < len; i++) //校验和不包含包头
                        {
                            sum += Convert.ToInt32(m_buffer[i]);
                        }
                        //MessageBox.Show(sum.ToString());
                        if (checksum == sum)
                        {
                            
                            ParseData2Lists();
                        }
                        else
                        {
                            //校验之后发现数据不对,清除该帧数据
                            m_buffer.RemoveRange(0, len + 2);
                            continue;
                        }
                        m_buffer.RemoveRange(0, len + 2);
                    }
                    else
                    {
                        m_buffer.RemoveAt(0); //清除帧头
                    }
                }
                #endregion
            }
        }

        private void button_SN_send_Click(object sender, EventArgs e)
        {
            string str_send = comboBox_SN_send.Text;
            //1.去除开头和结尾的空格字符
            str_send = str_send.Trim();
            //str_send = str_send.TrimStart();
            //str_send = str_send.TrimEnd();

            //MessageBox.Show(str_send);

            //2.检查SN是否每一位都是0-9
            foreach (var str in str_send)
            {
                if (Convert.ToInt32(str) >= 0 && Convert.ToInt32(str) <= 9)
                {
                    continue;
                }
                else
                {
                    MessageBox.Show("SN中不允许包含非法字符!");
                    return;
                }
            }

            //3. 检查SN的长度
            if (str_send.Length != 14)
            {
                MessageBox.Show("请检查SN的长度!");
                return;
            }


            if (!this.serialPort1.IsOpen)
            {
                MessageBox.Show("Please connect serial port first!");
                return;
            }

            //发送SN到下位机
            byte[] buffer = new byte[20];  //4+14+2
            buffer[HEAD] = 0xFF;
            buffer[LEN] = 0x12;   //4+14
            buffer[CMDTYPE] = 0x01;
            buffer[FRAME_ID] = 0x36;

            int sum = 0;
            for (int i = 1; i < Convert.ToInt32(buffer[LEN]); i++)
            {
                sum += buffer[i];
            }
            buffer[Convert.ToInt32(buffer[LEN])] = Convert.ToByte(sum / 256);   //checksum1
            buffer[Convert.ToInt32(buffer[LEN]) + 1] = Convert.ToByte(sum % 256); //checksum2
            this.serialPort1.Write(buffer, 0, Convert.ToInt32(buffer[LEN]) + 2);
        }
    }
}

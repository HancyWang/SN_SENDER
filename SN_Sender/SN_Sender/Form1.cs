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
        private ushort[] crc_table = new ushort[256] {
            0x0000, 0x1021, 0x2042, 0x3063, 0x4084, 0x50a5, 0x60c6, 0x70e7, 0x8108, 0x9129, 0xa14a, 0xb16b,
            0xc18c, 0xd1ad, 0xe1ce, 0xf1ef, 0x1231, 0x0210, 0x3273, 0x2252, 0x52b5, 0x4294, 0x72f7, 0x62d6,
            0x9339, 0x8318, 0xb37b, 0xa35a, 0xd3bd, 0xc39c, 0xf3ff, 0xe3de, 0x2462, 0x3443, 0x0420, 0x1401,
            0x64e6, 0x74c7, 0x44a4, 0x5485, 0xa56a, 0xb54b, 0x8528, 0x9509, 0xe5ee, 0xf5cf, 0xc5ac, 0xd58d,
            0x3653, 0x2672, 0x1611, 0x0630, 0x76d7, 0x66f6, 0x5695, 0x46b4, 0xb75b, 0xa77a, 0x9719, 0x8738,
            0xf7df, 0xe7fe, 0xd79d, 0xc7bc, 0x48c4, 0x58e5, 0x6886, 0x78a7, 0x0840, 0x1861, 0x2802, 0x3823,
            0xc9cc, 0xd9ed, 0xe98e, 0xf9af, 0x8948, 0x9969, 0xa90a, 0xb92b, 0x5af5, 0x4ad4, 0x7ab7, 0x6a96,
            0x1a71, 0x0a50, 0x3a33, 0x2a12, 0xdbfd, 0xcbdc, 0xfbbf, 0xeb9e, 0x9b79, 0x8b58, 0xbb3b, 0xab1a,
            0x6ca6, 0x7c87, 0x4ce4, 0x5cc5, 0x2c22, 0x3c03, 0x0c60, 0x1c41, 0xedae, 0xfd8f, 0xcdec, 0xddcd,
            0xad2a, 0xbd0b, 0x8d68, 0x9d49, 0x7e97, 0x6eb6, 0x5ed5, 0x4ef4, 0x3e13, 0x2e32, 0x1e51, 0x0e70,
            0xff9f, 0xefbe, 0xdfdd, 0xcffc, 0xbf1b, 0xaf3a, 0x9f59, 0x8f78, 0x9188, 0x81a9, 0xb1ca, 0xa1eb,
            0xd10c, 0xc12d, 0xf14e, 0xe16f, 0x1080, 0x00a1, 0x30c2, 0x20e3, 0x5004, 0x4025, 0x7046, 0x6067,
            0x83b9, 0x9398, 0xa3fb, 0xb3da, 0xc33d, 0xd31c, 0xe37f, 0xf35e, 0x02b1, 0x1290, 0x22f3, 0x32d2,
            0x4235, 0x5214, 0x6277, 0x7256, 0xb5ea, 0xa5cb, 0x95a8, 0x8589, 0xf56e, 0xe54f, 0xd52c, 0xc50d,
            0x34e2, 0x24c3, 0x14a0, 0x0481, 0x7466, 0x6447, 0x5424, 0x4405, 0xa7db, 0xb7fa, 0x8799, 0x97b8,
            0xe75f, 0xf77e, 0xc71d, 0xd73c, 0x26d3, 0x36f2, 0x0691, 0x16b0, 0x6657, 0x7676, 0x4615, 0x5634,
            0xd94c, 0xc96d, 0xf90e, 0xe92f, 0x99c8, 0x89e9, 0xb98a, 0xa9ab, 0x5844, 0x4865, 0x7806, 0x6827,
            0x18c0, 0x08e1, 0x3882, 0x28a3, 0xcb7d, 0xdb5c, 0xeb3f, 0xfb1e, 0x8bf9, 0x9bd8, 0xabbb, 0xbb9a,
            0x4a75, 0x5a54, 0x6a37, 0x7a16, 0x0af1, 0x1ad0, 0x2ab3, 0x3a92, 0xfd2e, 0xed0f, 0xdd6c, 0xcd4d,
            0xbdaa, 0xad8b, 0x9de8, 0x8dc9, 0x7c26, 0x6c07, 0x5c64, 0x4c45, 0x3ca2, 0x2c83, 0x1ce0, 0x0cc1,
            0xef1f, 0xff3e, 0xcf5d, 0xdf7c, 0xaf9b, 0xbfba, 0x8fd9, 0x9ff8, 0x6e17, 0x7e36, 0x4e55, 0x5e74,
            0x2e93, 0x3eb2, 0x0ed1, 0x1ef0
        };

        private string[] m_old_serialPortNames;
        private bool m_SerialPortOpened = false;
        private List<byte> m_buffer = new List<byte>();

        private const int INDEX_O2FLO_HEAD = 0;
        private const int INDEX_O2FLO_LEN = 1;
        private const int INDEX_O2FLO_CMDTYPE = 2;
        private const int INDEX_O2FLO_FRAME_ID = 3;
        private List<byte> m_SN_list = new List<byte>();


        private const int HEAD_MARK0 = 0xAA;
        private const int HEAD_MARK1 = 0x55;

        private const int INDEX_O2FLOPRO_HEAD0      = 0;
        private const int INDEX_O2FLOPRO_HEAD1      = 1;
        private const int INDEX_O2FLOPRO_LEN        = 2;
        private const int INDEX_O2FLOPRO_DEVICE_ID  = 3;
        private const int INDEX_O2FLOPRO_CMD_ID     = 4;

        public delegate void DLsetValue();

        //定义机器的类型
        private enum MACHINE_TYPE
        {
            MACHINE_O2FLO       =1,
            MACHINE_O2FLO_PRO   =2
        }
        private MACHINE_TYPE m_machineType = MACHINE_TYPE.MACHINE_O2FLO;

        private const string str_O2FLO = "O2FLO";
        private const string str_O2FLO_PRO = "O2FLO PRO";


        //public DLsetValue m_dl_stvalue;

        public void setValue()
        {
            if (m_SN_list.Count != 0)
            {
                textBox_SN_recv.Text = Convert.ToString(m_SN_list);
            }
        }

        
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

            this.comboBox_machineType.Text = str_O2FLO;

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
            ////指定不再捕获对错误线程的调用
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;  //调试的时候可以打开这条语句
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
                    MessageBox.Show("系统信息:"+ex.Message);
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
            if (m_machineType == MACHINE_TYPE.MACHINE_O2FLO)
            {
                if (len != 10 + 4 + 2)
                {
                    MessageBox.Show("下位机发送的SN不是10位!");
                    return;
                }

                //将接收到的SN放入m_SN_list中
                for (int i = 4; i < len - 2; i++)
                {
                    m_SN_list.Add(m_buffer[i]);
                }


            }
            else if (m_machineType == MACHINE_TYPE.MACHINE_O2FLO_PRO)
            {
                if (len != 10 + 5 + 2)
                {
                    MessageBox.Show("下位机发送的SN不是10位!");
                    return;
                }

                //将接收到的SN放入m_SN_list中
                for (int i = 5; i < len - 2; i++)
                {
                    m_SN_list.Add(m_buffer[i]);
                }

            }


            string str_recv = null;

            foreach (var ch in m_SN_list)
            {
                str_recv += Convert.ToChar(ch);
            }

            m_SN_list.Clear(); //接收完之后，清除m_SN_list，否则会叠加

            //MessageBox.Show(test);
            textBox_SN_recv.Text = str_recv;

            if (textBox_SN_recv.Text == comboBox_SN_send.Text.Trim())
            {
                pictureBox2.Load(Environment.CurrentDirectory + @"\" + "pass.bmp");
                //MessageBox.Show("Pass");
            }
            else
            {
                pictureBox2.Load(Environment.CurrentDirectory + @"\" + "fail.bmp");
                // MessageBox.Show("Fail");
            }

        }

        private void ParseData2Lists()
        {
            if (m_machineType == MACHINE_TYPE.MACHINE_O2FLO)
            {
                //将数据解析挂入到3个链表中
                if (m_buffer[INDEX_O2FLO_CMDTYPE] != 0x00)
                {
                    return;
                }
                //根据帧类型来判断
                switch (m_buffer[INDEX_O2FLO_FRAME_ID])
                {
                    case 0x40:   //下位机返回0x40,携带SN
                                 //MessageBox.Show(textBox_SN_recv.Text);
                                 //textBox_SN_recv.Clear();

                        ParseFrame0x40();
                        break;
                    case 0x41:
                        ParseSynRTCResult();
                        break;
                    case 0x42:
                        ParseRecoveryResult();
                        break;
                    default:
                        break;
                }
            }
            else if (m_machineType == MACHINE_TYPE.MACHINE_O2FLO_PRO)
            {
                //根据帧类型来判断
                switch (m_buffer[INDEX_O2FLOPRO_CMD_ID])
                {
                    case 0x40:   //下位机返回0x40,携带SN
                                 //MessageBox.Show(textBox_SN_recv.Text);
                                 //textBox_SN_recv.Clear();

                        ParseFrame0x40();
                        break;
                    case 0x41:
                        ParseSynRTCResult();
                        break;
                    case 0x42:
                        ParseRecoveryResult();
                        break;
                    default:
                        break;
                }
            }
            
        }

        private void ParseRecoveryResult()
        {
            int len = m_buffer.Count;

            int index_LEN = 0;
            if (m_machineType == MACHINE_TYPE.MACHINE_O2FLO)
            {
                index_LEN = INDEX_O2FLO_LEN;
            }
            else if (m_machineType == MACHINE_TYPE.MACHINE_O2FLO_PRO)
            {
                index_LEN = INDEX_O2FLOPRO_LEN;
            }

            if (m_buffer[m_buffer[index_LEN] - 1] == 1) //检测数据，1表示同步成功，0表示失败
            {
                label_recovery_result.Text = "成功";
                MessageBox.Show("恢复成功!");
            }
            else
            {
                label_recovery_result.Text = "失败";
                MessageBox.Show("恢复失败!");
            }
        }

        private void ParseSynRTCResult()
        {
            //throw new NotImplementedException();
            int len = m_buffer.Count;

            int index_LEN = 0; 
            if (m_machineType == MACHINE_TYPE.MACHINE_O2FLO)
            {
                index_LEN = INDEX_O2FLO_LEN;
            }
            else if (m_machineType == MACHINE_TYPE.MACHINE_O2FLO_PRO)
            {
                index_LEN = INDEX_O2FLOPRO_LEN;
            }

            if (m_buffer[m_buffer[index_LEN] - 1] == 1) //检测数据，1表示同步成功，0表示失败
            {
                label_syn_result.Text = "成功";
                MessageBox.Show("同步成功!");
            }
            else
            {
                label_syn_result.Text = "失败";
                MessageBox.Show("同步失败!");
            }

        }

        private bool IsCheckSumOK(byte[] p_Array, int len)
        {
            //crc校验 LEN+DEVICE ID+Command ID+Data  ,不包含头AA 55
            UInt16 result = 0;
            byte[] tempArray = p_Array.Skip(2).ToArray();
            result = crc_16(tempArray, (UInt16)(len - 4));
            if ((p_Array[len - 1] << 8) + p_Array[len - 2] == result)  //CheckSum的高位在后，低位在前
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int nPendingRead = this.serialPort1.BytesToRead;
            byte[] tmp = new byte[nPendingRead];
            this.serialPort1.Read(tmp, 0, nPendingRead);

            //m_bRcvParamtersCompleted = false;
            lock (m_buffer)
            {
                m_buffer.AddRange(tmp);
                #region
                while (m_buffer.Count >= 4)
                {
                    if (m_buffer[INDEX_O2FLO_HEAD] == 0xFF) //帧头
                    {
                        int len = Convert.ToInt32(m_buffer[INDEX_O2FLO_LEN]); // 获取帧长度(不包含checksum1和checksum2)
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
                    else if (m_buffer[INDEX_O2FLOPRO_HEAD0] == HEAD_MARK0
                        && m_buffer[INDEX_O2FLOPRO_HEAD1] == HEAD_MARK1)
                    {
                        int len = Convert.ToInt32(m_buffer[INDEX_O2FLOPRO_LEN]); // 获取帧长度(不包含checksum1和checksum2)
                        if (m_buffer.Count < len + 2)  //数据没有接收完全，继续接收
                        {
                            break;
                        }
                        byte[] tmp_buffer = m_buffer.ToArray();
                        if (IsCheckSumOK(tmp_buffer, len + 2))
                        {
                            ParseData2Lists();
                        }
                        //else
                        //{
                        //    //校验之后发现数据不对,清除该帧数据
                        //    m_buffer.RemoveRange(0, len + 2);
                        //    continue;
                        //}
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

        //获取CRC值
        private UInt16 crc_16(byte[] Cdata, UInt16 len)
        {
            UInt16 crc16 = 0;
            UInt16 crc_h8, crc_l8;
            byte index = 0;

            while (len-- > (UInt16)0)
            {
                crc_h8 = (UInt16)(crc16>>8);                                                                          //High byte		
                crc_l8 = (UInt16)(crc16 <<8);                                                                          //Low byte
                crc16 = (UInt16)(crc_l8 ^ crc_table[crc_h8 ^ Cdata[index]]);
                index++;
            }
            return crc16;
        }


        //给指定的Array填充checksum
        void set_checkSum(byte[] pArray)
        {
            if (pArray[0] == HEAD_MARK0 && pArray[1] == HEAD_MARK1)   //如果头是0xAA55
            {
                byte[] newArray=pArray.Skip(INDEX_O2FLOPRO_LEN).ToArray();

                UInt16 len = pArray[INDEX_O2FLOPRO_LEN];              //获取帧的长度
                UInt16 crc16 = (UInt16)(crc_16(newArray, (UInt16)(len - 2)));
                pArray[len] = (byte)(crc16 % 256);               //CheckSum1          
                pArray[len + 1] = (byte)(crc16 / 256);             //CheckSum2
            }
        }

        private void button_SN_send_Click(object sender, EventArgs e)
        {
            //textBox_SN_recv.Invoke(new DLsetValue(setValue));
            //textBox_SN_recv.BeginInvoke(m_dl_stvalue);
            //if (textBox_SN_recv.Text.Length != 0)
            //{
            //    //textBox_SN_recv.Text = "wwwwww";
            //    textBox_SN_recv.Clear();
            //}

            string str_send = comboBox_SN_send.Text;
            //1.去除开头和结尾的空格字符
            str_send = str_send.Trim();
            //str_send = str_send.TrimStart();
            //str_send = str_send.TrimEnd();

            //MessageBox.Show(str_send);

            //MessageBox.Show(Convert.ToString(Convert.ToInt32('1')));


            //2.检查SN是否每一位都是0-9
            foreach (var str in str_send)
            {
                //MessageBox.Show(Convert.ToString(Convert.ToInt32(str)));

                if ((Convert.ToInt32(str) >= Convert.ToInt32('0') && Convert.ToInt32(str) <= Convert.ToInt32('9')) ||
                    (Convert.ToInt32(str) >= Convert.ToInt32('a') && Convert.ToInt32(str) <= Convert.ToInt32('z') ||
                    (Convert.ToInt32(str) >= Convert.ToInt32('A') && Convert.ToInt32(str) <= Convert.ToInt32('Z'))))
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
            if (str_send.Length != 10)
            {
                MessageBox.Show("请检查SN的长度!");
                return;
            }

            if (!this.serialPort1.IsOpen)
            {
                MessageBox.Show("Please connect serial port first!");
                return;
            }


            //根据不同的型号发送不同的数据
            if (m_machineType == MACHINE_TYPE.MACHINE_O2FLO)
            {
                #region
                //发送SN到下位机
                byte[] buffer = new byte[4+10+2];  //4+10+2
                buffer[INDEX_O2FLO_HEAD] = 0xFF;
                buffer[INDEX_O2FLO_LEN] = 0x0E;   //4+10
                buffer[INDEX_O2FLO_CMDTYPE] = 0x01;
                buffer[INDEX_O2FLO_FRAME_ID] = 0x36;

                int sum = 0;
                //buffer[4] = 86;
                for (int i = 4; i < 18 - 4; i++)
                {
                    buffer[i] = Convert.ToByte(str_send[i - 4]);
                }

                for (int i = 1; i < Convert.ToInt32(buffer[INDEX_O2FLO_LEN]); i++)
                {
                    sum += buffer[i];
                }

                buffer[Convert.ToInt32(buffer[INDEX_O2FLO_LEN])] = Convert.ToByte(sum / 256);   //checksum1
                buffer[Convert.ToInt32(buffer[INDEX_O2FLO_LEN]) + 1] = Convert.ToByte(sum % 256); //checksum2
                this.serialPort1.Write(buffer, 0, Convert.ToInt32(buffer[INDEX_O2FLO_LEN]) + 2);
                #endregion
            }
            else if (m_machineType == MACHINE_TYPE.MACHINE_O2FLO_PRO)
            {
                //发送SN到下位机
                byte[] buffer = new byte[5 + 10 + 2];  //5+10+2
                buffer[INDEX_O2FLOPRO_HEAD0] = HEAD_MARK0;
                buffer[INDEX_O2FLOPRO_HEAD1] = HEAD_MARK1;
                buffer[INDEX_O2FLOPRO_LEN] = 5+10;   
                buffer[INDEX_O2FLOPRO_DEVICE_ID] = 0x00;         //0x00表示PC
                buffer[INDEX_O2FLOPRO_CMD_ID] = 0x36;

                for (int i = 5; i < 10+5; i++)
                {
                    buffer[i] = Convert.ToByte(str_send[i - 5]);
                }

                set_checkSum(buffer);
                this.serialPort1.Write(buffer, 0, Convert.ToInt32(buffer[INDEX_O2FLOPRO_LEN]) + 2);
            }
        }

        private void comboBox_portName_SelectedValueChanged(object sender, EventArgs e)
        {
            this.serialPort1.PortName = this.comboBox_portName.Text;
        }

        private void GetSystemDateTime()
        {
            textBox_dataTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            GetSystemDateTime();
        }

        private void button_syn_RTC_to_device_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("请先连接串口!");
                return;
            }

            label_syn_result.Text = ""; //清空上一次结果

            DateTime dt = DateTime.Now;
            Byte year1 = Convert.ToByte(dt.Year / 100);
            Byte year2 = Convert.ToByte(dt.Year % 100);
            Byte month = Convert.ToByte(dt.Month);
            Byte day = Convert.ToByte(dt.Day);
            Byte weekDay = Convert.ToByte(dt.DayOfWeek);
            Byte hour = Convert.ToByte(dt.Hour);
            Byte min = Convert.ToByte(dt.Minute);
            Byte sec = Convert.ToByte(dt.Second);


            if (m_machineType == MACHINE_TYPE.MACHINE_O2FLO)
            {
                byte[] buffer = new byte[4+8+2];
                buffer[INDEX_O2FLO_HEAD] = 0xFF;
                buffer[INDEX_O2FLO_LEN] = 12;
                buffer[INDEX_O2FLO_CMDTYPE] = 0x01;
                buffer[INDEX_O2FLO_FRAME_ID] = 0x38;

                buffer[4 + 0] = year1;
                buffer[4 + 1] = year2;
                buffer[4 + 2] = month;
                buffer[4 + 3] = day;
                buffer[4 + 4] = weekDay;
                buffer[4 + 5] = hour;
                buffer[4 + 6] = min;
                buffer[4 + 7] = sec;

                int sum = 0;
                for (int i = 1; i < Convert.ToInt32(buffer[INDEX_O2FLO_LEN]); i++)
                {
                    sum += buffer[i];
                }
                buffer[Convert.ToInt32(buffer[INDEX_O2FLO_LEN])] = Convert.ToByte(sum / 256);
                buffer[Convert.ToInt32(buffer[INDEX_O2FLO_LEN]) + 1] = Convert.ToByte(sum % 256);
                this.serialPort1.Write(buffer, 0, Convert.ToInt32(buffer[INDEX_O2FLO_LEN]) + 2);
            }
            else if (m_machineType == MACHINE_TYPE.MACHINE_O2FLO_PRO)
            {
                byte[] buffer = new byte[5+8+2];
                buffer[INDEX_O2FLOPRO_HEAD0] = HEAD_MARK0;
                buffer[INDEX_O2FLOPRO_HEAD1] = HEAD_MARK1;
                buffer[INDEX_O2FLOPRO_LEN] = 5+8;
                buffer[INDEX_O2FLOPRO_DEVICE_ID] = 0x00;
                buffer[INDEX_O2FLOPRO_CMD_ID] = 0x38;

                buffer[5 + 0] = year1;
                buffer[5 + 1] = year2;
                buffer[5 + 2] = month;
                buffer[5 + 3] = day;
                buffer[5 + 4] = weekDay;
                buffer[5 + 5] = hour;
                buffer[5 + 6] = min;
                buffer[5 + 7] = sec;

                set_checkSum(buffer);
                this.serialPort1.Write(buffer, 0, Convert.ToInt32(buffer[INDEX_O2FLOPRO_LEN]) + 2);
            }
            
        }

        private void button_recovery_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("请先连接串口!");
                return;
            }

            label_recovery_result.Text = ""; //清空上一次结果


            if (m_machineType == MACHINE_TYPE.MACHINE_O2FLO)
            {
                byte[] buffer = new byte[4+2];
                buffer[INDEX_O2FLO_HEAD] = 0xFF;
                buffer[INDEX_O2FLO_LEN] = 4;
                buffer[INDEX_O2FLO_CMDTYPE] = 0x01;
                buffer[INDEX_O2FLO_FRAME_ID] = 0x42;


                int sum = 0;
                for (int i = 1; i < Convert.ToInt32(buffer[INDEX_O2FLO_LEN]); i++)
                {
                    sum += buffer[i];
                }
                buffer[Convert.ToInt32(buffer[INDEX_O2FLO_LEN])] = Convert.ToByte(sum / 256);
                buffer[Convert.ToInt32(buffer[INDEX_O2FLO_LEN]) + 1] = Convert.ToByte(sum % 256);
                this.serialPort1.Write(buffer, 0, Convert.ToInt32(buffer[INDEX_O2FLO_LEN]) + 2);
            }
            else if (m_machineType == MACHINE_TYPE.MACHINE_O2FLO_PRO)
            {
                byte[] buffer = new byte[5+2];
                buffer[INDEX_O2FLOPRO_HEAD0] = HEAD_MARK0;
                buffer[INDEX_O2FLOPRO_HEAD1] = HEAD_MARK1;
                buffer[INDEX_O2FLOPRO_LEN] = 5 + 0;
                buffer[INDEX_O2FLOPRO_DEVICE_ID] = 0x00;         //0x00表示PC
                buffer[INDEX_O2FLOPRO_CMD_ID] = 0x42;

                set_checkSum(buffer);
                this.serialPort1.Write(buffer, 0, Convert.ToInt32(buffer[INDEX_O2FLOPRO_LEN]) + 2);
            }

           
        }

        private void comboBox_machineType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (m_machineType==MACHINE_TYPE.MACHINE_O2FLO)
            {
                this.comboBox_machineType.Text = str_O2FLO_PRO;
                m_machineType = MACHINE_TYPE.MACHINE_O2FLO_PRO;
            }
            else if (m_machineType == MACHINE_TYPE.MACHINE_O2FLO_PRO)
            {
                this.comboBox_machineType.Text = str_O2FLO;
                m_machineType = MACHINE_TYPE.MACHINE_O2FLO;
            }
            
        }
    }
}

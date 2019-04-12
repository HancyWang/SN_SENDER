namespace SN_Sender
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_parity = new System.Windows.Forms.ComboBox();
            this.comboBox_stopBit = new System.Windows.Forms.ComboBox();
            this.comboBox_dataBits = new System.Windows.Forms.ComboBox();
            this.comboBox_baud = new System.Windows.Forms.ComboBox();
            this.comboBox_portName = new System.Windows.Forms.ComboBox();
            this.button_serialPort_connect = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_SN_send = new System.Windows.Forms.ComboBox();
            this.button_SN_send = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_SN_recv = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label_syn_result = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button_syn_RTC_to_device = new System.Windows.Forms.Button();
            this.textBox_dataTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button_recovery = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label_recovery_result = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_parity);
            this.groupBox1.Controls.Add(this.comboBox_stopBit);
            this.groupBox1.Controls.Add(this.comboBox_dataBits);
            this.groupBox1.Controls.Add(this.comboBox_baud);
            this.groupBox1.Controls.Add(this.comboBox_portName);
            this.groupBox1.Controls.Add(this.button_serialPort_connect);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(276, 575);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port";
            // 
            // comboBox_parity
            // 
            this.comboBox_parity.FormattingEnabled = true;
            this.comboBox_parity.Location = new System.Drawing.Point(116, 265);
            this.comboBox_parity.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_parity.Name = "comboBox_parity";
            this.comboBox_parity.Size = new System.Drawing.Size(148, 23);
            this.comboBox_parity.TabIndex = 12;
            // 
            // comboBox_stopBit
            // 
            this.comboBox_stopBit.FormattingEnabled = true;
            this.comboBox_stopBit.Location = new System.Drawing.Point(119, 209);
            this.comboBox_stopBit.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_stopBit.Name = "comboBox_stopBit";
            this.comboBox_stopBit.Size = new System.Drawing.Size(148, 23);
            this.comboBox_stopBit.TabIndex = 11;
            // 
            // comboBox_dataBits
            // 
            this.comboBox_dataBits.FormattingEnabled = true;
            this.comboBox_dataBits.Location = new System.Drawing.Point(116, 155);
            this.comboBox_dataBits.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_dataBits.Name = "comboBox_dataBits";
            this.comboBox_dataBits.Size = new System.Drawing.Size(148, 23);
            this.comboBox_dataBits.TabIndex = 10;
            // 
            // comboBox_baud
            // 
            this.comboBox_baud.FormattingEnabled = true;
            this.comboBox_baud.Location = new System.Drawing.Point(119, 101);
            this.comboBox_baud.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_baud.Name = "comboBox_baud";
            this.comboBox_baud.Size = new System.Drawing.Size(148, 23);
            this.comboBox_baud.TabIndex = 9;
            // 
            // comboBox_portName
            // 
            this.comboBox_portName.FormattingEnabled = true;
            this.comboBox_portName.Location = new System.Drawing.Point(119, 55);
            this.comboBox_portName.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_portName.Name = "comboBox_portName";
            this.comboBox_portName.Size = new System.Drawing.Size(148, 23);
            this.comboBox_portName.TabIndex = 8;
            this.comboBox_portName.SelectedValueChanged += new System.EventHandler(this.comboBox_portName_SelectedValueChanged);
            // 
            // button_serialPort_connect
            // 
            this.button_serialPort_connect.Location = new System.Drawing.Point(119, 333);
            this.button_serialPort_connect.Margin = new System.Windows.Forms.Padding(4);
            this.button_serialPort_connect.Name = "button_serialPort_connect";
            this.button_serialPort_connect.Size = new System.Drawing.Size(100, 29);
            this.button_serialPort_connect.TabIndex = 7;
            this.button_serialPort_connect.Text = "Connect";
            this.button_serialPort_connect.UseVisualStyleBackColor = true;
            this.button_serialPort_connect.Click += new System.EventHandler(this.button_serialPort_connect_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(24, 333);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 265);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Parity:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 219);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Stop Bit:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Data Bits:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_SN_send);
            this.groupBox2.Controls.Add(this.button_SN_send);
            this.groupBox2.Location = new System.Drawing.Point(7, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(504, 52);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送到下位机";
            // 
            // comboBox_SN_send
            // 
            this.comboBox_SN_send.FormattingEnabled = true;
            this.comboBox_SN_send.Location = new System.Drawing.Point(27, 23);
            this.comboBox_SN_send.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_SN_send.Name = "comboBox_SN_send";
            this.comboBox_SN_send.Size = new System.Drawing.Size(313, 23);
            this.comboBox_SN_send.TabIndex = 13;
            // 
            // button_SN_send
            // 
            this.button_SN_send.Location = new System.Drawing.Point(375, 19);
            this.button_SN_send.Margin = new System.Windows.Forms.Padding(4);
            this.button_SN_send.Name = "button_SN_send";
            this.button_SN_send.Size = new System.Drawing.Size(100, 29);
            this.button_SN_send.TabIndex = 12;
            this.button_SN_send.Text = "发送";
            this.button_SN_send.UseVisualStyleBackColor = true;
            this.button_SN_send.Click += new System.EventHandler(this.button_SN_send_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_SN_recv);
            this.groupBox3.Location = new System.Drawing.Point(7, 78);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(504, 60);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "从下位机读取";
            // 
            // textBox_SN_recv
            // 
            this.textBox_SN_recv.Location = new System.Drawing.Point(27, 23);
            this.textBox_SN_recv.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_SN_recv.Name = "textBox_SN_recv";
            this.textBox_SN_recv.Size = new System.Drawing.Size(313, 25);
            this.textBox_SN_recv.TabIndex = 12;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Location = new System.Drawing.Point(7, 139);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(504, 102);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "结果";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(4, 22);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(496, 76);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Location = new System.Drawing.Point(300, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(731, 257);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "步骤1:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label_syn_result);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.button_syn_RTC_to_device);
            this.groupBox6.Controls.Add(this.textBox_dataTime);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Location = new System.Drawing.Point(301, 292);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(730, 143);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "步骤2:";
            // 
            // label_syn_result
            // 
            this.label_syn_result.AutoSize = true;
            this.label_syn_result.Location = new System.Drawing.Point(111, 87);
            this.label_syn_result.Name = "label_syn_result";
            this.label_syn_result.Size = new System.Drawing.Size(39, 15);
            this.label_syn_result.TabIndex = 4;
            this.label_syn_result.Text = "    ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "同步结果：";
            // 
            // button_syn_RTC_to_device
            // 
            this.button_syn_RTC_to_device.Location = new System.Drawing.Point(370, 41);
            this.button_syn_RTC_to_device.Name = "button_syn_RTC_to_device";
            this.button_syn_RTC_to_device.Size = new System.Drawing.Size(100, 31);
            this.button_syn_RTC_to_device.TabIndex = 2;
            this.button_syn_RTC_to_device.Text = "同步到设备";
            this.button_syn_RTC_to_device.UseVisualStyleBackColor = true;
            this.button_syn_RTC_to_device.Click += new System.EventHandler(this.button_syn_RTC_to_device_Click);
            // 
            // textBox_dataTime
            // 
            this.textBox_dataTime.Location = new System.Drawing.Point(10, 44);
            this.textBox_dataTime.Name = "textBox_dataTime";
            this.textBox_dataTime.Size = new System.Drawing.Size(336, 25);
            this.textBox_dataTime.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "当前系统时间：";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label_recovery_result);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.button_recovery);
            this.groupBox7.Location = new System.Drawing.Point(300, 460);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(731, 124);
            this.groupBox7.TabIndex = 19;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "步骤3:";
            // 
            // button_recovery
            // 
            this.button_recovery.Location = new System.Drawing.Point(11, 22);
            this.button_recovery.Name = "button_recovery";
            this.button_recovery.Size = new System.Drawing.Size(157, 37);
            this.button_recovery.TabIndex = 0;
            this.button_recovery.Text = "恢复默认信息";
            this.button_recovery.UseVisualStyleBackColor = true;
            this.button_recovery.Click += new System.EventHandler(this.button_recovery_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "恢复结果：";
            // 
            // label_recovery_result
            // 
            this.label_recovery_result.AutoSize = true;
            this.label_recovery_result.Location = new System.Drawing.Point(112, 77);
            this.label_recovery_result.Name = "label_recovery_result";
            this.label_recovery_result.Size = new System.Drawing.Size(39, 15);
            this.label_recovery_result.TabIndex = 5;
            this.label_recovery_result.Text = "    ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 604);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SN Sender";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_serialPort_connect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_SN_send;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_SN_recv;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox comboBox_parity;
        private System.Windows.Forms.ComboBox comboBox_stopBit;
        private System.Windows.Forms.ComboBox comboBox_dataBits;
        private System.Windows.Forms.ComboBox comboBox_baud;
        private System.Windows.Forms.ComboBox comboBox_portName;
        private System.Windows.Forms.ComboBox comboBox_SN_send;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label_syn_result;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_syn_RTC_to_device;
        private System.Windows.Forms.TextBox textBox_dataTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_recovery;
        private System.Windows.Forms.Label label_recovery_result;
    }
}


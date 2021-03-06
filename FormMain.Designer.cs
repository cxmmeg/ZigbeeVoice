﻿namespace ZigbeeVoice
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAutoGetSerialPortNames = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.comboBoxCOM = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labelSingal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelStatu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoSend = new System.Windows.Forms.CheckBox();
            this.checkBoxListenSelf = new System.Windows.Forms.CheckBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.trackBarVoiceVolumeSelf = new System.Windows.Forms.TrackBar();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteSent = new System.Windows.Forms.Button();
            this.buttonPlaySent = new System.Windows.Forms.Button();
            this.listBoxVoiceSend = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelVoiceTime = new System.Windows.Forms.Label();
            this.labelVoiceNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxAutoPlay = new System.Windows.Forms.CheckBox();
            this.checkBoxSaveVoice = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.checkBoxSlience = new System.Windows.Forms.CheckBox();
            this.trackBarVoiceVolume = new System.Windows.Forms.TrackBar();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.listBoxVoice = new System.Windows.Forms.ListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.timerFrazeSend = new System.Windows.Forms.Timer(this.components);
            this.timerSend = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVoiceVolumeSelf)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVoiceVolume)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAutoGetSerialPortNames);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Controls.Add(this.comboBoxCOM);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.labelSingal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelStatu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "系统状态";
            // 
            // buttonAutoGetSerialPortNames
            // 
            this.buttonAutoGetSerialPortNames.Location = new System.Drawing.Point(119, 20);
            this.buttonAutoGetSerialPortNames.Name = "buttonAutoGetSerialPortNames";
            this.buttonAutoGetSerialPortNames.Size = new System.Drawing.Size(75, 23);
            this.buttonAutoGetSerialPortNames.TabIndex = 5;
            this.buttonAutoGetSerialPortNames.Text = "自动获取";
            this.buttonAutoGetSerialPortNames.UseVisualStyleBackColor = true;
            this.buttonAutoGetSerialPortNames.Click += new System.EventHandler(this.buttonAutoGetSerialPortNames_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.Color.Red;
            this.buttonConnect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonConnect.Location = new System.Drawing.Point(119, 49);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.Text = "连接";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // comboBoxCOM
            // 
            this.comboBoxCOM.FormattingEnabled = true;
            this.comboBoxCOM.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20",
            "COM21",
            "COM22",
            "COM23",
            "COM24",
            "COM25",
            "COM26",
            "COM27",
            "COM28",
            "COM29",
            "COM30",
            "COM31",
            "COM32"});
            this.comboBoxCOM.Location = new System.Drawing.Point(15, 49);
            this.comboBoxCOM.Name = "comboBoxCOM";
            this.comboBoxCOM.Size = new System.Drawing.Size(96, 20);
            this.comboBoxCOM.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10F);
            this.label8.Location = new System.Drawing.Point(12, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 14);
            this.label8.TabIndex = 1;
            this.label8.Text = "请选择串口：";
            // 
            // labelSingal
            // 
            this.labelSingal.AutoSize = true;
            this.labelSingal.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSingal.ForeColor = System.Drawing.Color.Gray;
            this.labelSingal.Location = new System.Drawing.Point(163, 91);
            this.labelSingal.Name = "labelSingal";
            this.labelSingal.Size = new System.Drawing.Size(29, 20);
            this.labelSingal.TabIndex = 3;
            this.labelSingal.Text = "●";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "通信状态：";
            // 
            // labelStatu
            // 
            this.labelStatu.AutoSize = true;
            this.labelStatu.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStatu.ForeColor = System.Drawing.Color.Red;
            this.labelStatu.Location = new System.Drawing.Point(67, 91);
            this.labelStatu.Name = "labelStatu";
            this.labelStatu.Size = new System.Drawing.Size(29, 20);
            this.labelStatu.TabIndex = 1;
            this.labelStatu.Text = "●";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备连接：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxLog);
            this.groupBox3.Location = new System.Drawing.Point(12, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 279);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "系统日志";
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 12;
            this.listBoxLog.Location = new System.Drawing.Point(6, 14);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(188, 256);
            this.listBoxLog.TabIndex = 0;
            this.listBoxLog.SelectedIndexChanged += new System.EventHandler(this.listBoxLog_SelectedIndexChanged);
            this.listBoxLog.DoubleClick += new System.EventHandler(this.listBoxLog_DoubleClicked);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxAutoSend);
            this.groupBox4.Controls.Add(this.checkBoxListenSelf);
            this.groupBox4.Controls.Add(this.buttonSend);
            this.groupBox4.Controls.Add(this.groupBox9);
            this.groupBox4.Controls.Add(this.groupBox10);
            this.groupBox4.Location = new System.Drawing.Point(218, 183);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(427, 159);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "语音发送";
            // 
            // checkBoxAutoSend
            // 
            this.checkBoxAutoSend.AutoSize = true;
            this.checkBoxAutoSend.Enabled = false;
            this.checkBoxAutoSend.Location = new System.Drawing.Point(12, 127);
            this.checkBoxAutoSend.Name = "checkBoxAutoSend";
            this.checkBoxAutoSend.Size = new System.Drawing.Size(72, 16);
            this.checkBoxAutoSend.TabIndex = 18;
            this.checkBoxAutoSend.Text = "持续发送";
            this.checkBoxAutoSend.UseVisualStyleBackColor = true;
            this.checkBoxAutoSend.CheckedChanged += new System.EventHandler(this.checkBoxAutoSend_CheckedChanged);
            // 
            // checkBoxListenSelf
            // 
            this.checkBoxListenSelf.AutoSize = true;
            this.checkBoxListenSelf.Location = new System.Drawing.Point(96, 127);
            this.checkBoxListenSelf.Name = "checkBoxListenSelf";
            this.checkBoxListenSelf.Size = new System.Drawing.Size(48, 16);
            this.checkBoxListenSelf.TabIndex = 17;
            this.checkBoxListenSelf.Text = "测试";
            this.checkBoxListenSelf.UseVisualStyleBackColor = true;
            this.checkBoxListenSelf.CheckedChanged += new System.EventHandler(this.checkBoxListenSelf_CheckedChanged);
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(8, 28);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(137, 88);
            this.buttonSend.TabIndex = 16;
            this.buttonSend.Text = "按住发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonSend_MouseDown);
            this.buttonSend.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonSend_MouseUp);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.trackBarVoiceVolumeSelf);
            this.groupBox9.Location = new System.Drawing.Point(151, 19);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(55, 134);
            this.groupBox9.TabIndex = 11;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "音量";
            // 
            // trackBarVoiceVolumeSelf
            // 
            this.trackBarVoiceVolumeSelf.Location = new System.Drawing.Point(6, 12);
            this.trackBarVoiceVolumeSelf.Maximum = 100;
            this.trackBarVoiceVolumeSelf.Name = "trackBarVoiceVolumeSelf";
            this.trackBarVoiceVolumeSelf.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVoiceVolumeSelf.Size = new System.Drawing.Size(45, 116);
            this.trackBarVoiceVolumeSelf.TabIndex = 3;
            this.trackBarVoiceVolumeSelf.Value = 80;
            this.trackBarVoiceVolumeSelf.Scroll += new System.EventHandler(this.trackBarVoiceValueSelf_Scroll);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.buttonDeleteSent);
            this.groupBox10.Controls.Add(this.buttonPlaySent);
            this.groupBox10.Controls.Add(this.listBoxVoiceSend);
            this.groupBox10.Location = new System.Drawing.Point(205, 19);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(212, 134);
            this.groupBox10.TabIndex = 10;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "发送历史";
            // 
            // buttonDeleteSent
            // 
            this.buttonDeleteSent.Location = new System.Drawing.Point(185, 19);
            this.buttonDeleteSent.Name = "buttonDeleteSent";
            this.buttonDeleteSent.Size = new System.Drawing.Size(21, 42);
            this.buttonDeleteSent.TabIndex = 7;
            this.buttonDeleteSent.Text = "删除";
            this.buttonDeleteSent.UseVisualStyleBackColor = true;
            this.buttonDeleteSent.Click += new System.EventHandler(this.buttonDeleteSent_Click);
            // 
            // buttonPlaySent
            // 
            this.buttonPlaySent.Location = new System.Drawing.Point(185, 67);
            this.buttonPlaySent.Name = "buttonPlaySent";
            this.buttonPlaySent.Size = new System.Drawing.Size(21, 61);
            this.buttonPlaySent.TabIndex = 6;
            this.buttonPlaySent.Text = "播  放";
            this.buttonPlaySent.UseVisualStyleBackColor = true;
            this.buttonPlaySent.Click += new System.EventHandler(this.buttonPlaySent_Click);
            // 
            // listBoxVoiceSend
            // 
            this.listBoxVoiceSend.FormattingEnabled = true;
            this.listBoxVoiceSend.ItemHeight = 12;
            this.listBoxVoiceSend.Location = new System.Drawing.Point(6, 15);
            this.listBoxVoiceSend.Name = "listBoxVoiceSend";
            this.listBoxVoiceSend.Size = new System.Drawing.Size(173, 112);
            this.listBoxVoiceSend.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelVoiceTime);
            this.groupBox5.Controls.Add(this.labelVoiceNo);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.checkBoxAutoPlay);
            this.groupBox5.Controls.Add(this.checkBoxSaveVoice);
            this.groupBox5.Controls.Add(this.groupBox8);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Location = new System.Drawing.Point(218, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(427, 169);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "语音接收";
            // 
            // labelVoiceTime
            // 
            this.labelVoiceTime.AutoSize = true;
            this.labelVoiceTime.Location = new System.Drawing.Point(16, 98);
            this.labelVoiceTime.Name = "labelVoiceTime";
            this.labelVoiceTime.Size = new System.Drawing.Size(17, 12);
            this.labelVoiceTime.TabIndex = 15;
            this.labelVoiceTime.Text = "  ";
            // 
            // labelVoiceNo
            // 
            this.labelVoiceNo.AutoSize = true;
            this.labelVoiceNo.Location = new System.Drawing.Point(14, 46);
            this.labelVoiceNo.Name = "labelVoiceNo";
            this.labelVoiceNo.Size = new System.Drawing.Size(17, 12);
            this.labelVoiceNo.TabIndex = 14;
            this.labelVoiceNo.Text = "  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "时  间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "编  号";
            // 
            // checkBoxAutoPlay
            // 
            this.checkBoxAutoPlay.AutoSize = true;
            this.checkBoxAutoPlay.Checked = true;
            this.checkBoxAutoPlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoPlay.Location = new System.Drawing.Point(6, 122);
            this.checkBoxAutoPlay.Name = "checkBoxAutoPlay";
            this.checkBoxAutoPlay.Size = new System.Drawing.Size(144, 16);
            this.checkBoxAutoPlay.TabIndex = 2;
            this.checkBoxAutoPlay.Text = "自动播放接收到的语音";
            this.checkBoxAutoPlay.UseVisualStyleBackColor = true;
            this.checkBoxAutoPlay.CheckedChanged += new System.EventHandler(this.checkBoxAutoPlay_CheckedChanged);
            // 
            // checkBoxSaveVoice
            // 
            this.checkBoxSaveVoice.AutoSize = true;
            this.checkBoxSaveVoice.Checked = true;
            this.checkBoxSaveVoice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSaveVoice.Location = new System.Drawing.Point(6, 144);
            this.checkBoxSaveVoice.Name = "checkBoxSaveVoice";
            this.checkBoxSaveVoice.Size = new System.Drawing.Size(144, 16);
            this.checkBoxSaveVoice.TabIndex = 7;
            this.checkBoxSaveVoice.Text = "自动保存接收到的语音";
            this.checkBoxSaveVoice.UseVisualStyleBackColor = true;
            this.checkBoxSaveVoice.CheckedChanged += new System.EventHandler(this.checkBoxSaveVoice_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.checkBoxSlience);
            this.groupBox8.Controls.Add(this.trackBarVoiceVolume);
            this.groupBox8.Location = new System.Drawing.Point(155, 11);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(55, 154);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "音量";
            // 
            // checkBoxSlience
            // 
            this.checkBoxSlience.AutoSize = true;
            this.checkBoxSlience.Location = new System.Drawing.Point(6, 133);
            this.checkBoxSlience.Name = "checkBoxSlience";
            this.checkBoxSlience.Size = new System.Drawing.Size(48, 16);
            this.checkBoxSlience.TabIndex = 5;
            this.checkBoxSlience.Text = "静音";
            this.checkBoxSlience.UseVisualStyleBackColor = true;
            this.checkBoxSlience.CheckedChanged += new System.EventHandler(this.checkBoxSlience_CheckedChanged);
            // 
            // trackBarVoiceVolume
            // 
            this.trackBarVoiceVolume.Location = new System.Drawing.Point(6, 12);
            this.trackBarVoiceVolume.Maximum = 100;
            this.trackBarVoiceVolume.Name = "trackBarVoiceVolume";
            this.trackBarVoiceVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVoiceVolume.Size = new System.Drawing.Size(45, 127);
            this.trackBarVoiceVolume.TabIndex = 3;
            this.trackBarVoiceVolume.Value = 80;
            this.trackBarVoiceVolume.Scroll += new System.EventHandler(this.trackBarVoiceVolume_Scroll);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.buttonDelete);
            this.groupBox7.Controls.Add(this.buttonPlay);
            this.groupBox7.Controls.Add(this.listBoxVoice);
            this.groupBox7.Location = new System.Drawing.Point(209, 11);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(212, 154);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "历史语音";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(185, 19);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(21, 56);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "删  除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(185, 84);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(21, 55);
            this.buttonPlay.TabIndex = 6;
            this.buttonPlay.Text = "播  放";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // listBoxVoice
            // 
            this.listBoxVoice.FormattingEnabled = true;
            this.listBoxVoice.ItemHeight = 12;
            this.listBoxVoice.Location = new System.Drawing.Point(6, 15);
            this.listBoxVoice.Name = "listBoxVoice";
            this.listBoxVoice.Size = new System.Drawing.Size(173, 124);
            this.listBoxVoice.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxLog);
            this.groupBox6.Location = new System.Drawing.Point(218, 348);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(427, 70);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "日志详情";
            // 
            // textBoxLog
            // 
            this.textBoxLog.AcceptsReturn = true;
            this.textBoxLog.AcceptsTab = true;
            this.textBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLog.Location = new System.Drawing.Point(8, 20);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(415, 43);
            this.textBoxLog.TabIndex = 0;
            this.textBoxLog.TabStop = false;
            this.textBoxLog.DoubleClick += new System.EventHandler(this.textBoxLog_DoubleClick);
            // 
            // timerFrazeSend
            // 
            this.timerFrazeSend.Interval = 2000;
            this.timerFrazeSend.Tick += new System.EventHandler(this.timerFrazeSend_Tick);
            // 
            // timerSend
            // 
            this.timerSend.Interval = 1000;
            this.timerSend.Tick += new System.EventHandler(this.timerSend_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.ReadBufferSize = 40960;
            this.serialPort1.ReceivedBytesThreshold = 9;
            this.serialPort1.WriteBufferSize = 20480;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timerMain
            // 
            this.timerMain.Interval = 20;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 425);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "矿井无线语音通信管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVoiceVolumeSelf)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVoiceVolume)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Label labelStatu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSingal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxVoice;
        private System.Windows.Forms.CheckBox checkBoxAutoPlay;
        private System.Windows.Forms.TrackBar trackBarVoiceVolume;
        private System.Windows.Forms.CheckBox checkBoxSlience;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.CheckBox checkBoxSaveVoice;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ListBox listBoxVoiceSend;
        private System.Windows.Forms.Button buttonPlaySent;
        private System.Windows.Forms.Button buttonDeleteSent;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TrackBar trackBarVoiceVolumeSelf;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label labelVoiceTime;
        private System.Windows.Forms.Label labelVoiceNo;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.CheckBox checkBoxAutoSend;
        private System.Windows.Forms.CheckBox checkBoxListenSelf;
        private System.Windows.Forms.ComboBox comboBoxCOM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timerFrazeSend;
        private System.Windows.Forms.Timer timerSend;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonAutoGetSerialPortNames;
    }
}


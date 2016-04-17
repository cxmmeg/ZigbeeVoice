using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZigbeeVoice
{
    public partial class FormMain : Form
    {
        private int SendTime = 0;
        public FormMain()
        {
            InitializeComponent();
        }
        Recorder recorder;
        Player player = new Player();
        float Volume = 0.7F;
        float VolumeSelf = 0.7F;
        bool ListenSelf = false;
        private void buttonSend_MouseDown(object sender, EventArgs e)
        {
            StartSend();
        }
        private void buttonSend_MouseUp(object sender, EventArgs e)
        {
            StopSend();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            recorder = new Recorder();
            recorder.wavePlayer_Self.Volume = VolumeSelf;
            player.wavePlayer.Volume = Volume;
            GetFileList(1);
            GetFileList(2);
        }
        private void StopSend()
        {
            recorder.StopRecord();
            FrazeSend();
            GC.Collect();
            listBoxLog.Items.Add("发送时间：" + DateTime.Now.ToLongTimeString() + "  " + "时长：" + SendTime);
            timerSend.Stop();
            SendTime = 0;
            SendingStop = true;
        }
        public static string GetFileName(string folder)
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            string FileName = DateTime.Now.ToShortDateString().Replace('/', '-') + ' ';
            FileName += DateTime.Now.ToLongTimeString().Replace(':', '-');
            int i = 1;
            if (File.Exists(folder + "/" + FileName + ".midi"))
            {
                while (File.Exists(folder + "/" + FileName + "-" + i.ToString() + ".midi")) ;
                FileName += "-" + i.ToString();
            }
            return FileName;
        }
        private void StartSend()
        {
            recorder = new Recorder();
            player.wavePlayer.Volume = Volume;
            recorder.wavePlayer_Self.Volume = VolumeSelf;
            recorder.ListenSelf = ListenSelf;
            string soundfile = GetFileName("Send");
            recorder.BeginRecord("Send/" + soundfile + ".wav");
            listBoxVoiceSend.Items.Add(soundfile + ".wav");
            timerSend.Enabled = true;
            timerSend.Start();
            buttonSend.Text = "稍等一秒";
            SendingStart = true;
        }

        private void GetFileList(int inf)
        {
            string folderName = "";
            if (inf == 1)
            {
                folderName = "Send";
                listBoxVoiceSend.Items.Clear();
            }
            else if (inf == 2)
            {
                folderName = "Resived";
                listBoxVoice.Items.Clear();
            }
            if (!Directory.Exists(folderName))
                return;
            DirectoryInfo folder = new DirectoryInfo(folderName);

            foreach (FileInfo file in folder.GetFiles("*.midi"))
            {
                if (inf == 1)
                    listBoxVoiceSend.Items.Add(file.Name);
                else
                    listBoxVoice.Items.Add(file.Name);
            }
            foreach (FileInfo file in folder.GetFiles("*.wav"))
            {
                if (inf == 1)
                    listBoxVoiceSend.Items.Add(file.Name);
                else
                    listBoxVoice.Items.Add(file.Name);
            }
        }
        private void checkBoxAutoSend_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoSend.Checked == true)
            {
                StartSend();
                buttonSend.Enabled = false;
            }
            else
            {
                StopSend();
            }
        }

        private void checkBoxListenSelf_CheckedChanged(object sender, EventArgs e)
        {
            ListenSelf = checkBoxListenSelf.Checked;
            recorder.ListenSelf = ListenSelf;
        }

        private void trackBarVoiceValueSelf_Scroll(object sender, EventArgs e)
        {
            VolumeSelf = (float)trackBarVoiceVolumeSelf.Value / 100;
            recorder.wavePlayer_Self.Volume = VolumeSelf;
        }

        private void trackBarVoiceVolume_Scroll(object sender, EventArgs e)
        {
            Volume = (float)trackBarVoiceVolume.Value / 100;
            player.wavePlayer.Volume = Volume;
        }

        private void buttonPlaySent_Click(object sender, EventArgs e)
        {
            if (listBoxVoiceSend.SelectedItem == null)
                return;
            string filename = listBoxVoiceSend.GetItemText(listBoxVoiceSend.SelectedItem);
            player.play_sound("Send/" + filename);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (listBoxVoice.SelectedItem == null)
                return;
            string filename = listBoxVoice.GetItemText(listBoxVoice.SelectedItem);
            player.play_sound("Resived/" + filename);
        }

        private void buttonDeleteSent_Click(object sender, EventArgs e)
        {
            if (listBoxVoiceSend.SelectedItem == null)
                return;
            string filename = listBoxVoiceSend.GetItemText(listBoxVoiceSend.SelectedItem);
            listBoxVoiceSend.Items.Remove(listBoxVoiceSend.SelectedItem);
            File.Delete("Send/" + filename);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxVoice.SelectedItem == null)
                return;
            string filename = listBoxVoice.GetItemText(listBoxVoice.SelectedItem);
            listBoxVoice.Items.Remove(listBoxVoice.SelectedItem);
            File.Delete("Resived/" + filename);
        }

        private void checkBoxSlience_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSlience.Checked == true)
            {
                player.wavePlayer.Volume = 0;
                Volume = 0;
                trackBarVoiceVolume.Enabled = false;
            }
            else
            {
                Volume = (float)trackBarVoiceVolume.Value / 100;
                player.wavePlayer.Volume = Volume;
                trackBarVoiceVolume.Enabled = true;
            }
        }
        private void FrazeSend(int ms = 1000)
        {
            buttonSend.Enabled = false;
            buttonSend.Text = "请稍等...";
            checkBoxAutoSend.Enabled = false;
            timerFrazeSend.Interval = ms;
            timerFrazeSend.Enabled = true;
            timerFrazeSend.Start();
        }
        private void timerFrazeSend_Tick(object sender, EventArgs e)
        {
            timerFrazeSend.Stop();
            timerFrazeSend.Enabled = false;
            buttonSend.Enabled = true;
            buttonSend.Text = "按住发送";
            checkBoxAutoSend.Enabled = true;
        }

        private void timerSend_Tick(object sender, EventArgs e)
        {
            SendTime++;
            if (SendTime == 1)
                buttonSend.Text = "按住发送";
        }

        private void listBoxLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxLog.SelectedItem == null)
                return;
            textBoxLog.Text = listBoxLog.GetItemText(listBoxLog.SelectedItem);
        }
        private void listBoxLog_DoubleClicked(object sender, EventArgs e)
        {
            if (listBoxLog.SelectedItem == null)
                return;
            Clipboard.SetDataObject(listBoxLog.GetItemText(listBoxLog.SelectedItem));
        }

        private void textBoxLog_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBoxLog.Text);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (buttonConnect.BackColor == Color.Red)
            {
                serialPort1.PortName = "COM" + comboBoxCOM.Text;
                try
                {
                    serialPort1.Open();
                }
                catch
                {
                    MessageBox.Show("串口号选择错误或串口被占用。");
                    return;
                }
                buttonConnect.Text = "断开";
                buttonConnect.BackColor = Color.Green;
                C51SystemReset = true;

                ms5000 = 0;
                C51PlayQueueStatu = 0;
                C51RecordQueueStatu = 0;
                DataBlockResived = 0;
                if (Fs != null)
                    Fs.Close();
                SendingStart = false;
                SendingStop = false;
                Sending = false;
                Resiving = false;
                C51SystemReset = false;
                DataRecorded.Clear();

                timerMain.Enabled = true;
                timerMain.Start();
            }
            else
            {
                serialPort1.Close();
                buttonConnect.Text = "连接";
                buttonConnect.BackColor = Color.Red;
                labelStatu.ForeColor = Color.Red;
                timerMain.Enabled = false;
                timerMain.Stop();
            }
        }
        int ms5000 = 0;
        private void timerMain_Tick(object sender, EventArgs e)
        {
            timerMain.Stop();
            if (!Resiving)
                UARTSendData();
            WorkOnDataResived();
            timerMain.Start();
            ms5000 += timerMain.Interval;
            if (ms5000 > 1000 && Resiving)
            {
                StopResiving();
                while (SerialData.Count >= 9)
                    WorkOnDataResived();
                if (ms5000 > 1000 && Resiving)
                    StopResiving();
            }
                
            if (ms5000 >= 5000)
            {
                ms5000 = 0;
                serialPort1.Close();
                buttonConnect.Text = "连接";
                buttonConnect.BackColor = Color.Red;
                timerMain.Enabled = false;
                timerMain.Stop();
            }
        }
        int C51PlayQueueStatu = 0;
        int C51RecordQueueStatu = 0;
        Queue<byte> SerialData = new Queue<byte>(100000);
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int a;
            byte[] t = new byte[100000];
            try
            {
                a = serialPort1.BytesToRead;
                serialPort1.Read(t, 0, a);
                for (int i = 0; i < a; i++)
                {
                    SerialData.Enqueue(t[i]);
                }
                ms5000 = 0;

            }
            catch(Exception)
            {
                serialPort1.Close();
                try
                {
                    serialPort1.Open();
                }
                catch(Exception)
                {
                    serialPort1.Open();
                }
            }
        }
        bool FlagPassHeader = false;
        private void WorkOnDataResived()
        {
            byte[] t = new byte[50];
            if (SerialData.Count < 9)
                return;
            if (FlagPassHeader)
                if (SerialData.Count >= 256)
                {
                    byte[] t1 = new byte[520];

                    for (int i = 0; i < 256; i++)
                        t1[i] = SerialData.Dequeue();
                    DataBlockResived++;

                    player.PlayResivedSound_AddData(t1, 0, 256);
                    Fs.Write(t1, 0, 256);
                    FixFileHeader();
                    FlagPassHeader = false;
                    return;
                }
                else
                {
                    FlagPassHeader = true;
                    return;
                }
            for (int i = 0; i < 9; i++)
                t[i] = SerialData.Dequeue();

            if (t[0] == 0x96 && t[1] == 0x38 && t[2] == 0x52 && t[3] == 0x74 && t[4] == 0x10)
            {
                C51PlayQueueStatu = t[5];
                C51RecordQueueStatu = t[6];
                labelSingal.ForeColor = Color.Blue;
                labelStatu.ForeColor = Color.Green;
                switch (t[7])
                {
                    case (0x00): if (Resiving) StopResiving(); break;   //系统空闲
                    case (0x10): break;                                 //正在播放
                    case (0x01): StartResiving(); break;                //录音开始
                    case (0x02): if (!Resiving) StartResiving(); break;  //正在录音
                    case (0x03): StopResiving(); break;                 //录音结束
                    default: break;
                }
                if (t[8] == 0x01 && SerialData.Count >= 256)
                {
                    byte[] t1 = new byte[520];

                    for (int i = 0; i < 256; i++)
                        t1[i] = SerialData.Dequeue();
                    DataBlockResived++;

                    player.PlayResivedSound_AddData(t1, 0, 256);
                    Fs.Write(t1, 0, 256);
                    FixFileHeader();
                }
                else if (t[8] == 0x01 && SerialData.Count < 256)
                    FlagPassHeader = true;
                labelSingal.ForeColor = Color.Gray;
            }
            else
            {
                serialPort1.Close();
                serialPort1.Open();
            }
            //if (Resiving)
            //    UARTSendData();
        }       
        FileStream Fs;
        string ResivedFileName;
        private void StartResiving()
        {
            if (!Resiving)
            {
                Resiving = true;
                serialPort1.ReceivedBytesThreshold = 265;
                ResivedFileName =  GetFileName("Resived") + ".midi";
                Fs = new FileStream("Resived/" + ResivedFileName, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
                player.PlayResivedSound_Init();
                player.PlayResivedSound_AddData(header, 0, 60);
                Fs.Write(header, 0, 60);                
            }
        }
        int DataBlockResived = 0;
        private void StopResiving()
        {
            if (!Resiving)
                return;
            FlagPassHeader = false;
            Resiving = false;
            serialPort1.ReceivedBytesThreshold = 9;
            listBoxVoice.Items.Add(ResivedFileName);
            FixFileHeader();

            DataBlockResived = 0;
            Fs.Close();
            player.PlayResivedSound_Stop();
        }
        private void FixFileHeader()
        {
            int temp = 0;
            byte[] t1 = new byte[4];
            Fs.Seek(4, SeekOrigin.Begin);
            temp = DataBlockResived * 256 + 52;
            t1[0] = (byte)(temp & 0xff);
            temp >>= 8;
            t1[1] = (byte)(temp & 0xff);
            temp >>= 8;
            t1[2] = (byte)(temp & 0xff);
            temp >>= 8;
            t1[3] = (byte)(temp & 0xff);
            Fs.Write(t1, 0, 4);

            Fs.Seek(48, SeekOrigin.Begin);
            temp = DataBlockResived * 505;
            t1[0] = (byte)(temp & 0xff);
            temp >>= 8;
            t1[1] = (byte)(temp & 0xff);
            temp >>= 8;
            t1[2] = (byte)(temp & 0xff);
            temp >>= 8;
            t1[3] = (byte)(temp & 0xff);
            Fs.Write(t1, 0, 4);

            Fs.Seek(56, SeekOrigin.Begin);
            temp = DataBlockResived * 256;
            t1[0] = (byte)(temp & 0xff);
            temp >>= 8;
            t1[1] = (byte)(temp & 0xff);
            temp >>= 8;
            t1[2] = (byte)(temp & 0xff);
            temp >>= 8;
            t1[3] = (byte)(temp & 0xff);
            Fs.Write(t1, 0, 4);
            Fs.Seek(0, SeekOrigin.End);
        }
        bool SendingStart = false;
        bool SendingStop = false;
        bool Sending = false;
        bool Resiving = false;
        bool C51SystemReset = false;
        Queue<byte> DataRecorded = new Queue<byte>();
        private void UARTSendData()
        {
            labelSingal.ForeColor = Color.Blue;
            byte[] temp = new byte[330];
            int lenth = 0;
            temp[0] = 0x14; temp[1] = 0x72; temp[2] = 0x58; temp[3] = 0x36; temp[4] = 0x90;
            if (SendingStart)
            {
                temp[5] = 0x01;
                SendingStart = false;
            }
            else if (SendingStop)
            {
                temp[5] = 0x03;
                SendingStop = false;
            }
            else if (Sending)
                temp[5] = 0x02;
            else if (Resiving)
                temp[5] = 0x10;
            else if (C51SystemReset)
            {
                temp[5] = 0x99;
                C51SystemReset = false;
            }
            else temp[5] = 0x00;

            if (Sending && C51PlayQueueStatu < 3)
            {
                temp[6] = 0x01;
                for (int i = 0; i < 256; i++)
                    temp[i + 5] = DataRecorded.Dequeue();
                lenth = 256 + 7;
            }
            else
            {
                temp[6] = 0x00;
                lenth = 7;
            }

            UARTSendData1(temp, 0, lenth);

        }
        private void UARTSendData1(byte[] dat, int offset, int count)
        {
            try
            {
                serialPort1.Write(dat, offset, count);
            }
            catch (Exception)
            {
                UARTSendData1(dat, offset, count);
            }
        }
        public static byte[] header = {
0x52, 0x49, 0x46, 0x46, 0x34, 0x14, 0x00, 0x00,
0x57, 0x41, 0x56, 0x45, 0x66, 0x6d, 0x74, 0x20, /*|RIFF....WAVEfmt |*/
0x14, 0x00, 0x00, 0x00, 0x11, 0x00, 0x01, 0x00,
0x40, 0x1f, 0x00, 0x00, 0xd7, 0x0f, 0x00, 0x00, /*|........@...OE...|*/
0x00, 0x01, 0x04, 0x00, 0x02, 0x00, 0xf9, 0x01,
0x66, 0x61, 0x63, 0x74, 0x04, 0x00, 0x00, 0x00, /*|......ù.fact....|*/
0x74, 0x27, 0x00, 0x00, 0x64, 0x61, 0x74, 0x61,
0x00, 0x14, 0x00, 0x00
};
        bool AutoPlayVoiceResived = true;
        private void checkBoxAutoPlay_CheckedChanged(object sender, EventArgs e)
        {
            AutoPlayVoiceResived = checkBoxAutoPlay.Checked;
        }
        bool AutoSaveVoiceResived = true;
        private void checkBoxSaveVoice_CheckedChanged(object sender, EventArgs e)
        {
            AutoSaveVoiceResived = checkBoxSaveVoice.Checked;
        }
    }
}

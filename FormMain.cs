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
            UARTSendCommend(0x06);
        }
        private string GetFileName(string folder)
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            string FileName = DateTime.Now.ToShortDateString().Replace('/', '-') + ' ';
            FileName += DateTime.Now.ToLongTimeString().Replace(':', '-');
            int i = 1;
            if (File.Exists(folder + "/" + FileName + folder))
            {
                while (File.Exists(folder + "/" + FileName + "-" + i.ToString() + ".wav")) ;
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
            UARTSendCommend(0x05);
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
                folderName = "Get";
                listBoxVoice.Items.Clear();
            }
            if (!Directory.Exists(folderName))
                return;
            DirectoryInfo folder = new DirectoryInfo(folderName);

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
            player.play_sound("Get/" + filename);
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
            File.Delete("Get/" + filename);
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
                //UARTSendCommend(0x00);
                UARTSendCommend(0x01);
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
            try
            {
                UARTSendCommend(0x02);
            }
            catch (IOException)
            {
                ms5000 += 5;
                return;
            }
            catch (InvalidOperationException)
            {
                ms5000 += 5;
                return;
            }
            ms5000 += 5;
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

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] t = new byte[50];
            serialPort1.Read(t, 0, 5);
            if (t[0] == 0x96 && t[1] == 0x38 && t[2] == 0x52 && t[3] == 0x74)
            {
                labelSingal.ForeColor = Color.Blue;
                labelStatu.ForeColor = Color.Green;
                switch (t[4])
                {
                    case (0x11): ms5000 = 0; break;                         //重启系统
                    case (0x12): ms5000 = 0; ReadStatu(); break;            //读取状态
                    case (0x13): ms5000 = 0; ReadData(); break;            //读取数据
                    case (0x14): ms5000 = 0; break;                         //写入数据
                    case (0x15): ms5000 = 0; break;                         //开始播放
                    case (0x16): ms5000 = 0; break;                         //停止播放
                    case (0x1c): break;                                     //读取数据出错
                    case (0x1d): break;                                     //写入数据出错
                    case (0x1e): break;                                     //开始播放失败
                    case (0x00): serialPort1.Read(t, 0, 5); break;          //命令无效
                    default: break;
                }
                labelSingal.ForeColor = Color.Gray;
            }
            else
            {
                serialPort1.Close();
                serialPort1.Open();
            }

        }
        int DataBlockResived = 0;
        private void ReadData()
        {
            byte[] t = new byte[260];
            serialPort1.Read(t, 0, 256);
            DataBlockResived++;
            Fs.Write(t, 0, 256);
        }
        bool Recording = false;
        FileStream Fs;
        int RecordQueueStatu = 0, PlayQueueStatu = 0;
        int SystemStatu = 0;
        private void ReadStatu()
        {
            byte[] t = new byte[5];
            serialPort1.Read(t, 0, 5);
            RecordQueueStatu = t[0] << 8 | t[1];
            PlayQueueStatu = t[2] << 8 | t[3];
            SystemStatu = t[4];
            if (SystemStatu == 2 && RecordQueueStatu >= 256)    //读取音频数据
            {
                if (Recording == false)
                {
                    Recording = true;
                    Fs = new FileStream("Resived/" + GetFileName("Resived") + ".midi", FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
                    Fs.Write(header, 0, 60);
                }
                byte[] a = { 0x14, 0x72, 0x58, 0x36, 0x93 };
                serialPort1.Write(a, 0, 5);
            }
            else if (SystemStatu == 1 && PlayQueueStatu <= 768)
            {
                byte[] a = new byte[330];
                a[0] = 0x14; a[1] = 0x72; a[2] = 0x58; a[3] = 0x36; a[4] = 0x94;
            }
            else
            {
                if (Recording == true)
                {
                    byte[] t1 = new byte[4];
                    int temp = 0;
                    Recording = false;

                    Fs.Seek(4, SeekOrigin.Begin);
                    temp = DataBlockResived * 256 + 52;
                    t1[0] = (byte)(temp & 0xff);
                    temp >>= 8;
                    t1[1] = (byte)(temp & 0xff);
                    temp >>= 8;
                    t1[2] = (byte)(temp & 0xff);
                    temp >>= 8;
                    t1[3] = (byte)(temp & 0xff);
                    Fs.Write(t1,0,4);

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

                    DataBlockResived = 0;
                    Fs.Close();
                }
            }
        }
        private void UARTSendCommend(byte commend)
        {
            byte[] a = { 0x14, 0x72, 0x58, 0x36, 0x90 };
            a[4] |= commend;
            serialPort1.Write(a, 0, 5);
        }
byte[] header = {
0x52, 0x49, 0x46, 0x46, 0xFF, 0xFF, 0xFF, 0xFF,
0x57, 0x41, 0x56, 0x45, 0x66, 0x6d, 0x74, 0x20, /*|RIFF....WAVEfmt |*/
0x14, 0x00, 0x00, 0x00, 0x11, 0x00, 0x01, 0x00,
0x40, 0x1f, 0x00, 0x00, 0x75, 0x12, 0x00, 0x00, /*|........@...OE...|*/
0x00, 0x01, 0x04, 0x00, 0x02, 0x00, 0xf9, 0x01,
0x66, 0x61, 0x63, 0x74, 0x04, 0x00, 0x00, 0x00, /*|......ù.fact....|*/
0xFF, 0xFF, 0xFF, 0xFF, 0x64, 0x61, 0x74, 0x61,
0xFF, 0xFF, 0xFF, 0xFF
};
    }
}

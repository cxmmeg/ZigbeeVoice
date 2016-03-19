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
        Sound sound;
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
            sound = new Sound();
            sound.wavePlayer_Self.Volume = VolumeSelf;
            sound.wavePlayer.Volume = Volume;
            GetFileList(1);
            GetFileList(2);
        }
        private void StopSend()
        {
            sound.StopRecord();
            FrazeSend();
            GC.Collect();
            listBoxLog.Items.Add("发送时间：" + DateTime.Now.ToLongTimeString() + "  " + "时长：" + SendTime);
            timerSend.Stop();
            SendTime = 0;
        }
        private void StartSend()
        {
            sound = new Sound();
            sound.wavePlayer.Volume = Volume;
            sound.wavePlayer_Self.Volume = VolumeSelf;
            sound.ListenSelf = ListenSelf;
            if (!Directory.Exists("Send"))
                Directory.CreateDirectory("send");
            string soundfile = DateTime.Now.ToShortDateString().Replace('/', '-') + ' ';
            soundfile += DateTime.Now.ToLongTimeString().Replace(':', '-');
            int i = 1;
            if (File.Exists("Send/" + soundfile + ".wav"))
            {
                while (File.Exists("Send/" + soundfile + "-" + i.ToString() + ".wav")) ;
                soundfile += "-" + i.ToString();
            }
            sound.BeginRecord("Send/" + soundfile + ".wav");
            listBoxVoiceSend.Items.Add(soundfile + ".wav");
            timerSend.Enabled = true;
            timerSend.Start();
            buttonSend.Text = "稍等一秒";
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
            sound.ListenSelf = ListenSelf;
        }

        private void trackBarVoiceValueSelf_Scroll(object sender, EventArgs e)
        {
            VolumeSelf = (float)trackBarVoiceVolumeSelf.Value / 100;
            sound.wavePlayer_Self.Volume = VolumeSelf;
        }

        private void trackBarVoiceVolume_Scroll(object sender, EventArgs e)
        {
            Volume= (float)trackBarVoiceVolume.Value / 100;
            sound.wavePlayer.Volume = Volume;
        }

        private void buttonPlaySent_Click(object sender, EventArgs e)
        {
            if (listBoxVoiceSend.SelectedItem == null)
                return;
            string filename = listBoxVoiceSend.GetItemText(listBoxVoiceSend.SelectedItem);
            sound.play_sound("Send/" + filename);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (listBoxVoice.SelectedItem == null)
                return;
            string filename = listBoxVoice.GetItemText(listBoxVoice.SelectedItem);
            sound.play_sound("Get/" + filename);
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
                sound.wavePlayer.Volume = 0;
                Volume = 0;
                trackBarVoiceVolume.Enabled = false;
            }
            else
            {
                Volume = (float)trackBarVoiceVolume.Value / 100;
                sound.wavePlayer.Volume = Volume;
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
    }
}

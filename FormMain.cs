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
        public FormMain()
        {
            InitializeComponent();
        }
        Sound sound;
        private void buttonSend_MouseDown(object sender, EventArgs e)
        {
            StartSend();
        }
        private void buttonSend_MouseUp(object sender, EventArgs e)
        {
            sound.StopRecord();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            sound = new Sound();
            sound.wavePlayer_Self.Volume = (float)trackBarVoiceVolumeSelf.Value / 100;
            sound.wavePlayer.Volume = (float)trackBarVoiceVolume.Value / 100;
            GetFileList(1);
            GetFileList(2);
        }
        private void StartSend()
        {
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
                sound.StopRecord();
                buttonSend.Enabled = true;
            }
        }

        private void checkBoxListenSelf_CheckedChanged(object sender, EventArgs e)
        {
            sound.ListenSelf = checkBoxListenSelf.Checked;
        }

        private void trackBarVoiceValueSelf_Scroll(object sender, EventArgs e)
        {
            sound.wavePlayer_Self.Volume = (float)trackBarVoiceVolumeSelf.Value / 100;
        }

        private void trackBarVoiceVolume_Scroll(object sender, EventArgs e)
        {
            sound.wavePlayer.Volume = (float)trackBarVoiceVolume.Value / 100;
        }

        private void buttonPlaySent_Click(object sender, EventArgs e)
        {
            string filename = listBoxVoiceSend.GetItemText(listBoxVoiceSend.SelectedItem);
            sound.play_sound("Send/" + filename);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            string filename = listBoxVoice.GetItemText(listBoxVoice.SelectedItem);
            sound.play_sound("Get/" + filename);
        }

        private void buttonDeleteSent_Click(object sender, EventArgs e)
        {
            string filename = listBoxVoiceSend.GetItemText(listBoxVoiceSend.SelectedItem);
            listBoxVoiceSend.Items.Remove(listBoxVoiceSend.SelectedItem);
            File.Delete("Send/" + filename);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string filename = listBoxVoice.GetItemText(listBoxVoice.SelectedItem);
            listBoxVoice.Items.Remove(listBoxVoice.SelectedItem);
            File.Delete("Get/" + filename);
        }

        private void checkBoxSlience_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxSlience.Checked==true)
            {
                sound.wavePlayer.Volume = 0;
                trackBarVoiceVolume.Enabled = false;
            }
            else
            {
                sound.wavePlayer.Volume = (float)trackBarVoiceVolume.Value / 100;
                trackBarVoiceVolume.Enabled = true;
            }
        }
    }
}

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
        }
        private void StartSend()
        {
            string soundfile = DateTime.Now.ToShortDateString().Replace('/', '-') + ' ';
            soundfile += DateTime.Now.ToLongTimeString().Replace(':', '-');
            int i = 1;
            if (File.Exists(soundfile + ".wav"))
            {
                while (File.Exists(soundfile + "-" + i.ToString() + ".wav")) ;
                soundfile += "-" + i.ToString();
            }
            sound.BeginRecord(soundfile + ".wav");
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
    }
}

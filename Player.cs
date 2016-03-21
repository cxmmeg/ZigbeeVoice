using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.WindowsMediaFormat;
using NAudio.CoreAudioApi;
using System.IO;

namespace ZigbeeVoice
{
    class Player
    {
        public IWavePlayer wavePlayer = new WaveOut();
        private WaveStream reader;
        //--------播放部分----------      
        public void play_sound(string filename)
        {
            if (wavePlayer != null)
            {
                wavePlayer.Dispose();
                wavePlayer = null;
            }
            if (reader != null)
            {
                reader.Dispose();
            }
            try
            {
                reader = new MediaFoundationReader(filename, new MediaFoundationReader.MediaFoundationReaderSettings() { SingleReaderObject = true });
            }
            catch (Exception)
            {
                return;
            }

            if (wavePlayer == null)
            {
                wavePlayer = new WaveOut();
                wavePlayer.PlaybackStopped += WavePlayerOnPlaybackStopped;
                wavePlayer.Init(reader);
            }
            wavePlayer.Play();
        }
        private void WavePlayerOnPlaybackStopped(object sender, StoppedEventArgs stoppedEventArgs)
        {
            if (wavePlayer != null)
            {
                wavePlayer.Stop();
            }
        }
    }
}

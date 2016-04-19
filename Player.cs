using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.WindowsMediaFormat;
using NAudio.CoreAudioApi;
using System.IO;
using System.Threading;

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
                //if (filename.Split('.')[1].Equals("midi")) reader = WaveFormatConversionStream.CreatePcmStream(reader);
            }
            catch (Exception)
            {
                wavePlayer = new WaveOut();
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
        public IWavePlayer wavePlayer_Resived = new WaveOut();
        private WaveStream reader_Resived;
        private void WavePlayerOnPlaybackStopped_Resived(object sender, StoppedEventArgs stoppedEventArgs)
        {
            if (wavePlayer_Resived != null)
            {
                wavePlayer_Resived.Stop();
            }
        }
        public void PlayResivedSound_Stop()
        {
            wavePlayer_Resived.Stop();
            wavePlayer_Resived_Buffer = 0;
            if (wavePlayer_Resived != null)
            {
                wavePlayer_Resived.Dispose();
                wavePlayer_Resived = null;
            }
            if (reader_Resived != null)
            {
                reader_Resived.Dispose();
            }
            try
            {
                if (File.Exists(filename))
                    File.Delete(filename);
                if (File.Exists(lastfilename))
                    File.Delete(lastfilename);
            }
            catch (Exception)
            {

            }
        }
        public void PlayResivedSound_Start(string filename)
        {
            if (wavePlayer_Resived != null)
            {
                wavePlayer_Resived.Dispose();
                wavePlayer_Resived = null;
            }
            if (reader_Resived != null)
            {
                reader_Resived.Dispose();
            }
            try
            {
                reader_Resived = new MediaFoundationReader(filename, new MediaFoundationReader.MediaFoundationReaderSettings() { SingleReaderObject = true });
                //if (filename.Split('.')[1].Equals("midi")) reader = WaveFormatConversionStream.CreatePcmStream(reader);
            }
            catch (Exception)
            {
                return;
            }

            if (wavePlayer_Resived == null)
            {
                wavePlayer_Resived = new WaveOut();
                wavePlayer_Resived.PlaybackStopped += WavePlayerOnPlaybackStopped_Resived;
                wavePlayer_Resived.Init(reader_Resived);
            }
            wavePlayer_Resived.Play();
        }
        int wavePlayer_Resived_Buffer = 0;
        FileStream fs;
        string filename;
        string lastfilename;
        public void PlayResivedSound_AddData(byte[] samples, int offset, int count)
        {
            if (wavePlayer_Resived_Buffer == 0)
            {
                lastfilename = filename;
                filename = "temp/" + FormMain.GetFileName("temp") + ".midi";
                fs = new FileStream(filename, FileMode.Create);
                fs.Write(FormMain.header, 0, 60);
                fs.Write(samples, offset, count);
            }
            if (wavePlayer_Resived_Buffer == 1)
            {
                fs.Write(samples, offset, count);
                try
                {
                    if (File.Exists(lastfilename))
                        File.Delete(lastfilename);
                }
                catch (Exception) { }
            }
            else if (wavePlayer_Resived_Buffer == 10)
            {
                wavePlayer_Resived_Buffer = -1;
                fs.Write(samples, offset, count);
                fs.Close();
                if (wavePlayer_Resived != null && wavePlayer_Resived.PlaybackState == PlaybackState.Playing)
                    wavePlayer_Resived.Stop();
                PlayResivedSound_Start(filename);
            }
            else fs.Write(samples, offset, count);
            wavePlayer_Resived_Buffer++;
        }
    }
}

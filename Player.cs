using NAudio.Wave;
using System;
using System.IO;
//这个是音频播放模块
namespace ZigbeeVoice
{
    class Player
    {
        public IWavePlayer wavePlayer = new WaveOut();
        private WaveStream reader;
        //播放记录的音频
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
        //播放收到的音频
        public IWavePlayer wavePlayer_Received = new WaveOut();
        private WaveStream reader_Received;
        private void WavePlayerOnPlaybackStopped_Received(object sender, StoppedEventArgs stoppedEventArgs)
        {
            if (wavePlayer_Received != null)
            {
                wavePlayer_Received.Stop();
            }
        }
        //停止播放处理函数
        public void PlayReceivedSound_Stop()
        {            
            //清空缓冲区，释放播放组件
            wavePlayer_Received_Buffer = 0;
            if (wavePlayer_Received != null)
            {
                wavePlayer_Received.Stop();
                wavePlayer_Received.Dispose();
                wavePlayer_Received = null;
            }
            if (reader_Received != null)
            {
                reader_Received.Dispose();
            }
            //删除临时文件
            try
            {
                if (File.Exists(filename))
                    File.Delete(filename);
                if (File.Exists(lastfilename))
                    File.Delete(lastfilename);
            }
            catch (Exception) { }
        }
        public void PlayReceivedSound_Start(string filename)
        {
            if (wavePlayer_Received != null)
            {
                wavePlayer_Received.Dispose();
                wavePlayer_Received = null;
            }
            if (reader_Received != null)
            {
                reader_Received.Dispose();
            }
            //读取临时文件
            try
            {
                reader_Received = new MediaFoundationReader(filename, new MediaFoundationReader.MediaFoundationReaderSettings() { SingleReaderObject = true });
            }
            catch (Exception)
            {
                return;
            }
            wavePlayer.Volume = 1;  //设置音量为最大
            //创建播放控件
            if (wavePlayer_Received == null)
            {
                wavePlayer_Received = new WaveOut();
                wavePlayer_Received.PlaybackStopped += WavePlayerOnPlaybackStopped_Received;
                wavePlayer_Received.Init(reader_Received);
            }
            wavePlayer_Received.Play();
        }
        int wavePlayer_Received_Buffer = 0;
        FileStream fs;
        string filename;
        string lastfilename;
        //将接收到的音频写入临时文件
        public void PlayReceivedSound_AddData(byte[] samples, int offset, int count)
        {
            //新建临时文件
            if (wavePlayer_Received_Buffer == 0)
            {
                lastfilename = filename;
                filename = "temp/" + FormMain.GetFileName("temp") + ".midi";
                fs = new FileStream(filename, FileMode.Create);
                fs.Write(FormMain.header, 0, 60);
                fs.Write(samples, offset, count);
            }
            //删除上次的临时文件
            if (wavePlayer_Received_Buffer == 1)
            {
                fs.Write(samples, offset, count);
                try
                {
                    if (File.Exists(lastfilename))
                        File.Delete(lastfilename);
                }
                catch (Exception) { }
            }
            //播放本次的临时文件
            else if (wavePlayer_Received_Buffer == 10)
            {
                wavePlayer_Received_Buffer = -1;
                fs.Write(samples, offset, count);
                fs.Close();
                if (wavePlayer_Received != null && wavePlayer_Received.PlaybackState == PlaybackState.Playing)
                    wavePlayer_Received.Stop();
                PlayReceivedSound_Start(filename);
            }
            else fs.Write(samples, offset, count);
            wavePlayer_Received_Buffer++;
        }
    }
}

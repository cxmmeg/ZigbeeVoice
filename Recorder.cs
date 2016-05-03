using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
//这个部分是录音模块
namespace ZigbeeVoice
{
    class Recorder
    {
        public bool ListenSelf = false;
        private IWaveIn waveIn;
        private WaveFileWriter writer;
        public IWavePlayer wavePlayer_Self = new WaveOut();
        private static WaveFormat waveFormat = new WaveFormat(8000, 8, 2);  //录音格式
        private BufferedWaveProvider bufferedWaveProvider;

        //开始录音
        public void BeginRecord(string soundfile)
        {
            if (waveIn == null)
            {
                CreateWaveInDevice();
            }
            //设置回放
            if (ListenSelf)
            {
                bufferedWaveProvider = new BufferedWaveProvider(waveIn.WaveFormat);
                wavePlayer_Self = new WaveOut();
                wavePlayer_Self.Init(bufferedWaveProvider);
                wavePlayer_Self.Play();
            }
            else
            {
                writer = new WaveFileWriter(soundfile, waveIn.WaveFormat);
                DataRecordedQueue = new Queue<byte>(1000000);
            }
            //开始录音、回放
            waveIn.StartRecording();
        }
        //停止录音
        public void StopRecord()
        {
            if (waveIn != null)
                waveIn.StopRecording();
            if (wavePlayer_Self != null)
                wavePlayer_Self.Dispose();
            if (writer != null)
                writer.Dispose();
        }
        //获取音频输入设备
        private void CreateWaveInDevice()
        {
            waveIn = new WaveIn();
            waveIn.WaveFormat = waveFormat;
            waveIn.DataAvailable += OnDataAvailable;
        }
        string filename;
        public Queue<byte> DataRecordedQueue;   //录音缓冲区
        private WaveFileWriter writer2;
        
        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (ListenSelf) //如果是测试模式，则播放获取到的音频
            {
                bufferedWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
                if (wavePlayer_Self == null)
                {
                    wavePlayer_Self = new WaveOut();
                    wavePlayer_Self.Init(bufferedWaveProvider);
                    wavePlayer_Self.Play();
                }
            }
            else
            {
                //否则写出到临时文件
                filename = "temp/" + FormMain.GetFileName("temp") + ".wav";
                writer2 = new WaveFileWriter(filename, waveIn.WaveFormat);
                writer2.Write(e.Buffer, 0, e.BytesRecorded);
                writer2.Dispose();

                try
                {
                    //转码
                    MediaFoundationReader reader = new MediaFoundationReader(filename);
                    WaveStream convertedStream = new WaveFormatConversionStream(new WaveFormat(4000, 8, 1), reader);
                    byte[] t = new byte[100000];
                    int lenth = (int)convertedStream.Length;

                    convertedStream.Read(t, 0, lenth);
                    convertedStream.Dispose();
                    reader.Dispose();
                    //写入到录音缓冲区
                    for (int i = 0; i < lenth; i++)
                    {
                        DataRecordedQueue.Enqueue(t[i]);
                    }
                    File.Delete(filename);
                    //写入到音频记录文件
                    writer.Write(e.Buffer, 0, e.BytesRecorded);
                }
                catch (Exception) { }               
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using NAudio.WindowsMediaFormat;
using NAudio.CoreAudioApi;
using System.IO;

namespace ZigbeeVoice
{
    class Recorder
    {
        public bool ListenSelf = false;
        private IWaveIn waveIn;
        private WaveFileWriter writer;
        public IWavePlayer wavePlayer_Self = new WaveOut();
        private static WaveFormat waveFormat = new WaveFormat(8000, 8, 2);
        private BufferedWaveProvider bufferedWaveProvider;
        //------------------录音相关-----------------------------
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
        private void CreateWaveInDevice()
        {
            waveIn = new WaveIn();
            waveIn.WaveFormat = waveFormat;
            waveIn.DataAvailable += OnDataAvailable;
        }
        string filename;
        string lastfilename;
        public Queue<byte> DataRecordedQueue;
        private WaveFileWriter writer2;
        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (ListenSelf)
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
                lastfilename = filename;
                filename = "temp/" + FormMain.GetFileName("temp") + ".midi";
                writer2 = new WaveFileWriter(filename, waveIn.WaveFormat);
                writer2.Write(e.Buffer, 0, e.BytesRecorded);
                writer2.Dispose();

                WaveFileReader reader = new WaveFileReader(filename);
                WaveStream convertedStream = new WaveFormatConversionStream(new WaveFormat(8000, 8, 1), reader);
                byte[] t = new byte[100000];
                int lenth = (int)convertedStream.Length;
                //WaveFileWriter.CreateWaveFile("1.wav", convertedStream);
                convertedStream.Read(t, 0, lenth);
                convertedStream.Dispose();
                reader.Dispose();
                for (int i = 0; i < lenth; i++)
                {
                    DataRecordedQueue.Enqueue(t[i]);
                }
                try
                {
                    File.Delete(lastfilename);
                }
                catch (Exception) { }

                writer.Write(e.Buffer, 0, e.BytesRecorded);
            }

        }
    }
}

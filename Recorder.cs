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
        private static WaveFormat waveFormat = new WaveFormat(12000, 2);
        private BufferedWaveProvider bufferedWaveProvider;
        //------------------录音相关-----------------------------
        //开始录音
        public void BeginRecord(string soundfile)
        {
            if (waveIn == null)
            {
                CreateWaveInDevice();
            }
            writer = new WaveFileWriter(soundfile, waveIn.WaveFormat);
            bufferedWaveProvider = new BufferedWaveProvider(waveIn.WaveFormat);
            //设置回放
            wavePlayer_Self = new WaveOut();
            wavePlayer_Self.Init(bufferedWaveProvider);

            //开始录音、回放
            waveIn.StartRecording();
            wavePlayer_Self.Play();
        }
        //停止录音
        public void StopRecord()
        {
            if (waveIn != null)
                waveIn.StopRecording();
        }
        private void CreateWaveInDevice()
        {
            waveIn = new WaveIn();
            waveIn.WaveFormat = waveFormat;
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.RecordingStopped += OnRecordingStopped;
        }
        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            writer.Write(e.Buffer, 0, e.BytesRecorded);
            if (ListenSelf)
                bufferedWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }
        private void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            if (writer != null)
            {
                writer.Dispose();
                writer = null;
            }
        }      
    }
}

using NAudio.Wave;
using System;
using System.IO;

namespace voice_to_text_prototype
{
    public class cRecorder
    {

        WaveIn sourceStream;
        WaveFileWriter waveWriter;
        
        readonly String FilePath;
        readonly String FileName;
        readonly int InputDeviceIndex;
        

        public cRecorder(int inputDeviceIndex, String filePath, String fileName)
        {
            //InitializeComponent();
            this.InputDeviceIndex = inputDeviceIndex;
            this.FileName = fileName;
            this.FilePath = filePath;
        }

        public void StartRecording()
        {
            sourceStream = new WaveIn
            {
                DeviceNumber = this.InputDeviceIndex,
                WaveFormat = new WaveFormat(44100, WaveIn.GetCapabilities(this.InputDeviceIndex).Channels)
            };
            sourceStream.DataAvailable += this.SourceStreamDataAvailable;

            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            waveWriter = new WaveFileWriter(FilePath + FileName, sourceStream.WaveFormat);
            sourceStream.StartRecording();

        }

        public void SourceStreamDataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveWriter == null) return;
            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
            waveWriter.Flush();

        }

        public void RecordEnd()
        {
            if (sourceStream != null)
            {
                sourceStream.StopRecording();
                sourceStream.Dispose();
                sourceStream = null;
            }
            if (this.waveWriter == null)
            {
                return;
            }
            this.waveWriter.Dispose();
            this.waveWriter = null;

        }

        public void convert()
        {


        }
        
    }
}

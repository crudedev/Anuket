using NAudio.Wave;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation;

namespace Anuket
{
    public class cRecorder
    {

        WaveIn sourceStream;
        WaveFileWriter waveWriter;
        
       public  readonly String FilePath;
       public readonly String FileName;
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

        public static void convert(CoreData _c, string _guid)
        {
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript(@"$opusenc='" + _c.pathToEXE + @"\opusenc'" + Environment.NewLine + @" & $opusenc --bitrate 64 '" + _c.pathToEXE + @"\WavStore\" + _guid + @".wav' '" + _c.pathToEXE + @"\OpusStore\" + _guid + @".opus'");

                try
                {

                    Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                    foreach (PSObject outputItem in PSOutput)
                    {
                        if (outputItem != null)
                        {
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

        }
        
    }
}

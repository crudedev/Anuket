using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace voice_to_text_prototype
{
    class cSpeechManager
    {
        public static string transcribe(CoreData _c,string _guid)
        {

            string ret = "";
            try
            {

                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    string curlstring = @"$curl='" + _c.pathToEXE + @"\curl'" + Environment.NewLine + @"& $curl -X POST -u  " + _c.stCredentials + @" --header 'Content-Type: audio/ogg;codecs=opus' --header 'Transfer-Encoding: chunked' --data-binary '@" + _c.pathToEXE + @"\OpusStore\" + _guid + @"' 'https://stream.watsonplatform.net/speech-to-text/api/v1/recognize?continuous=true' --insecure";

                    PowerShellInstance.AddScript(curlstring);

                    try
                    {

                        Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                        foreach (PSObject outputItem in PSOutput)
                        {
                            if (outputItem != null)
                            {
                                ret += outputItem;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            catch (Exception exx)
            {

                throw;
            }
            return ret;
        }

        public static string synthasizeVoice(CoreData _c, string textToSynth)
        {
            string ret = "";
            string filename = Guid.NewGuid().ToString();
            try
            {

                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                   
                    string data =
@"$data = @{
    text = "" " + textToSynth + @" ""
}";

                    string curlstring = @"$curl='" + _c.pathToEXE + @"\curl'" + Environment.NewLine + data + Environment.NewLine +

                        @"& ConvertTo-Json $data  -Compress | &$curl -X POST -u " + _c.tsCredentials + @" --header 'Content-Type: application/json' --header 'Accept: audio/ogg;codecs=opus' --data '@-'  --output '" + _c.pathToEXE + @"\" + filename + @".opus' 'https://stream.watsonplatform.net/text-to-speech/api/v1/synthesize?voice=en-GB_KateVoice' --insecure";


                    PowerShellInstance.AddScript(curlstring);

                    try
                    {

                        Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                        foreach (PSObject outputItem in PSOutput)
                        {
                            if (outputItem != null)
                            {
                                ret += outputItem;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return ret;
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return filename;
        }
    }
}

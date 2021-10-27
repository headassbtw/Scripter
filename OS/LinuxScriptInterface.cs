using System.Diagnostics;
using System.IO;

namespace Scripter.OS
{
    public class LinuxScriptInterface : ScriptInterface
    {
        public override bool BashSupported()
        {
            return true;
        }

        public override bool PowershellSupported()
        {
            return File.Exists("Z:\\usr\\bin\\powershell");
        }

        public override void Run(string script, ScriptType fileType)
        {
            switch (fileType)
            {
                case ScriptType.Bash:
                    Process BashRunner = new Process();
                    BashRunner.StartInfo.FileName = "cmd";
                    BashRunner.StartInfo.Arguments = $"/c start /unix {script}";
                    BashRunner.Start();
                    break;
                case ScriptType.Batch:
                    
                    break;
                case ScriptType.Powershell:
                    Process PowershellRunner = new Process();
                    PowershellRunner.StartInfo.FileName = "cmd";
                    PowershellRunner.StartInfo.Arguments = $"/c start /unix /usr/bin/powershell {script}";
                    PowershellRunner.Start();
                    break;
            }
        }
    }
}
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

        public override void Run(Script.Script script)
        {
            switch (script.Type)
            {
                case ScriptType.Bash:
                    Process bashRunner = new Process();
                    bashRunner.StartInfo.FileName = "cmd";
                    bashRunner.StartInfo.Arguments = $"/c start /unix {script.Path}";
                    bashRunner.Start();
                    break;
                case ScriptType.Batch:
                    
                    break;
                case ScriptType.Powershell:
                    Process powershellRunner = new Process();
                    powershellRunner.StartInfo.FileName = "cmd";
                    powershellRunner.StartInfo.Arguments = $"/c start /unix /usr/bin/powershell {script.Path}";
                    powershellRunner.Start();
                    break;
            }
        }
    }
}
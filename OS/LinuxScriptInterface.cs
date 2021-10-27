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
                    string LinuxPath = script.Path
                        .Replace("Z:\\", "/")
                        .Replace('\\', '/')
                        .Replace(" ", "\\ ");
                    Plugin.Log.Warn($"Running script via bash at {script.Path}");
                    Plugin.Log.Warn($"({LinuxPath})");
                    Plugin.Log.Warn($"/c start /unix /bin/bash -c \"{LinuxPath}\"");
                    bashRunner.StartInfo.Arguments = $"/c start /unix /bin/bash -c \"{LinuxPath}\"";
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
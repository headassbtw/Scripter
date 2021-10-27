using static Scripter.OS.ScriptInterface;

namespace Scripter.Script
{
    public class Script
    {
        public string Path;
        public ScriptType Type;
        public bool GameLoad;
        public bool GameExit;

        public Script(string path)
        {
            Path = path;
            if (path.EndsWith(".sh")) Type = ScriptType.Bash;
            else if (path.EndsWith(".bat")) Type = ScriptType.Batch;
            else if (path.EndsWith(".ps1")) Type = ScriptType.Powershell;
        }
    }
}
namespace Scripter.OS
{
    public abstract class ScriptInterface
    {
        public enum ScriptType
        {
            Bash,           //.sh
            Batch,          //.bat
            Powershell      //.ps1
        }
        //.sh files, usually linux
        public abstract bool BashSupported();
        //.ps1, powershell, both compatible, but optionally installable on linux, this is to make sure it's there
        public abstract bool PowershellSupported();
        
        public abstract void Run(Script.Script script);
    }
}
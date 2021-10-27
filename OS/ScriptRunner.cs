using System;

namespace Scripter.OS
{
    public class ScriptRunner
    {
        public ScriptInterface Interface;

        public ScriptRunner()
        {
            switch (OS.OSDetector.OS())
            {
                case true:
                    Interface = new LinuxScriptInterface();
                    break;
                case false:
                    throw new NotImplementedException("Not Implemented on windows yet");
            }
        }
        public void Run(Script.Script script)
        {
            Interface.Run(script);
        }
    }
}
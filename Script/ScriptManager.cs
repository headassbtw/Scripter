using System.Collections.Generic;
using System.IO;
using Scripter.OS;

namespace Scripter.Script
{
    public class ScriptManager
    {
        public List<Script> Scripts = new List<Script>();

        public ScriptManager(string folder)
        {
            foreach (string path in Directory.GetFiles(folder))
            {
                Scripts.Add(new Script(path));
            }
        }

        public void RunAll()
        {
            foreach (Script script in Scripts)
            {
                
            }
        }
    }
}
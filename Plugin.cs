using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Utilities;
using Scripter.Configuration;
using Scripter.OS;
using Scripter.Script;
using UnityEngine.SceneManagement;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;

namespace Scripter
{

    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        internal static string EnablePath = Path.Combine(UnityGame.UserDataPath, "Scripter", "Scripts","OnLoad");
        internal static string ExitPath = Path.Combine(UnityGame.UserDataPath, "Scripter", "Scripts","OnQuit");
        internal ScriptRunner Runner;
        internal ScriptManager LoadScripts;
        internal ScriptManager ExitScripts;
        [Init]
        public void Init(IPALogger logger)
        {
            Instance = this;
            Log = logger;
            Log.Info("Scripter initialized.");
            string os = OSDetector.OS() ? "Linux" : "Windows";
            Log.Notice($"OS is: {os}");
            Runner = new ScriptRunner();
            #region dir creation
            if (!Directory.Exists(Path.Combine(UnityGame.UserDataPath, "Scripter")))
                Directory.CreateDirectory(Path.Combine(UnityGame.UserDataPath, "Scripter"));
            if (!Directory.Exists(Path.Combine(UnityGame.UserDataPath, "Scripter","Scripts")))
                Directory.CreateDirectory(Path.Combine(UnityGame.UserDataPath, "Scripter","Scripts"));
            if (!Directory.Exists(EnablePath))
                Directory.CreateDirectory(EnablePath);
            if (!Directory.Exists(ExitPath))
                Directory.CreateDirectory(ExitPath);
            
            #endregion
        }

        #region BSIPA Config
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Log.Debug("Config loaded");
            PluginConfig.Instance.Scripts = new List<Script.Script>();
            PluginConfig.Instance.Scripts.Add(new Script.Script("Z:\\home\\headass\\hi.sh"));
        }

        #endregion

        [OnStart]
        public void OnApplicationStart()
        {
            LoadScripts = new ScriptManager(EnablePath);
            ExitScripts = new ScriptManager(ExitPath);
            
            foreach(Script.Script script in LoadScripts.Scripts) Runner.Run(script);
            Log.Debug("OnApplicationStart");

        }

        [OnExit]
        public void OnApplicationQuit()
        {
            foreach(Script.Script script in ExitScripts.Scripts) Runner.Run(script);
            Log.Debug("OnApplicationQuit");

        }
    }
}

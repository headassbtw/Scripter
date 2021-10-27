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

        [Init]
        public void Init(IPALogger logger)
        {
            Instance = this;
            Log = logger;
            Log.Info("Scripter initialized.");
            string os = OSDetector.OS() ? "Linux" : "Windows";
            Log.Notice($"OS is: {os}");
            #region dir creation
            if (!Directory.Exists(Path.Combine(UnityGame.UserDataPath, "Scripter")))
                Directory.CreateDirectory(Path.Combine(UnityGame.UserDataPath, "Scripter"));
            if (!Directory.Exists(Path.Combine(UnityGame.UserDataPath, "Scripter","Scripts")))
                Directory.CreateDirectory(Path.Combine(UnityGame.UserDataPath, "Scripter","Scripts"));
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
            Log.Debug("OnApplicationStart");

        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Log.Debug("OnApplicationQuit");

        }
    }
}

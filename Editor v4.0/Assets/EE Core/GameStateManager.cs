using EEDemo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EECore 
{
    public static class GameStateManager
    {

        public static string loadedScene = null;
        public static float number = 0;

        public static Vector3 playerPosition = Vector3.zero;

        public static GameObject dialogueBox;
        public static GameObject player;
        public static Dictionary<string, Flag> flags = new Dictionary<string, Flag>();

        //public static void 

        public static Flag GetFlag(string flagName)
        {
            if (!flags.ContainsKey(flagName))
            {
                return null;
            }
            return flags[flagName];
        }

        public static void LoadScene(string scene)
        {
            number += 1;
            loadedScene = scene;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

}
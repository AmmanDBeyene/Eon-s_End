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

        public static int memberCount = 0; 
        public static List<Character> party = new List<Character>(4);
        public static Dictionary<string, Flag> flags = new Dictionary<string, Flag>();
        public static string victorySceneName = "";
        public static Vector3 victoryScenePosition;
        public static string defeatSceneName = "";
        public static Vector3 defeatScenePosition;

        //public static void 

        public static Flag GetFlag(string flagName)
        {
            if (!flags.ContainsKey(flagName))
            {
                return null;
            }
            return flags[flagName];
        }

        public static void AddToParty(Character chara)
        {
            // Character already in party or max party members
            if (InParty(chara.name) || memberCount >= 4)
            {
                return; 
            }

            party.Add(chara);
        }

        public static bool InParty(string name)
        {
            return GetCharacter(name) != null;
        }

        public static Character GetCharacter(string name)
        {
            Character match = party.Find(i => i.name == name);
            return match;
        }

        public static void LoadScene(string scene)
        {
            number += 1;
            loadedScene = scene;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

}
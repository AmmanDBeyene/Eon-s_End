using Assets.Event_Scripts.Event_Commands;
using EECore;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Event_Editor.Event_Scripts.Commands
{
    public class StartCombatCommand : CommandNode
    {
        [Serialize]
        public string _targetSceneName;

        [Serialize]
        public string _targetVSceneName;

        [Serialize]
        public Vector3 _targetVPosition;

        [Serialize]
        public string _targetDSceneName;
        [Serialize]
        public Vector3 _targetDPosition;

        public StartCombatCommand(string name, string nameV, Vector3 posV, string nameD, Vector3 posD)
        {
            _targetSceneName = name;
            _targetVSceneName = nameV;
            _targetVPosition = posV;
            _targetDSceneName = nameD;
            _targetDPosition = posD;
        }

        internal override void DoCommand()
        {
            // switch the damn scene! (and prepare some combat stuff)
            GameStateManager.playerPosition = Vector3.zero; // A combat scene should not have any players
            GameStateManager.victorySceneName = _targetVSceneName;
            GameStateManager.victoryScenePosition = _targetVPosition;
            GameStateManager.defeatSceneName = _targetDSceneName;
            GameStateManager.defeatScenePosition = _targetDPosition;
            GameStateManager.LoadScene(_targetSceneName);
            
            // not gonna lie, I have absolutely no idea what happens to the game object running this script when the scene is changed ... 
            // switching scenes technically should be the end of an event but at the same time 
            // I do think that all the commands in the current event node will still be executed but I genuinely have no idea ... 
        }

        internal override bool IsComplete()
        {
            return true; // this is a command that completes instantly,
                         // technically scene switching can take a bit 
                         // but in this specific case we can treat it as
                         // instant and without any loading time. 
        }
    }
}

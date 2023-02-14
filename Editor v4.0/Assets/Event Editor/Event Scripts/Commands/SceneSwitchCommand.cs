using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Event_Scripts.Event_Commands
{
    public class SceneSwitchCommand : CommandNode
    {
        [Serialize]
        public string _targetSceneName;

        [Serialize]
        public Vector3 _targetPlayerPosition;

        public SceneSwitchCommand(string targetSceneName, Vector3 targetPlayerPosition)
        {
            _targetSceneName = targetSceneName;
            _targetPlayerPosition = targetPlayerPosition;
        }

        internal override void DoCommand()
        {
            // switch the damn scene!
            GameStateManager.PlayerPosition = _targetPlayerPosition;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Event_Scripts.Event_Commands
{
    internal class SceneSwitchCommand : EventCommand
    {
        private string _targetSceneName;
        private Vector3 _targetPlayerPosition;

        public SceneSwitchCommand(string targetSceneName, Vector3 targetPlayerPosition) : base()
        {
            _targetSceneName = targetSceneName;
            _targetPlayerPosition = targetPlayerPosition;
        }

        protected override void DoCommand()
        {
            // switch the damn scene!
            GameStateManager.PlayerPosition = _targetPlayerPosition;
            GameStateManager.LoadScene(_targetSceneName);

            // not gonna lie, I have absolutely no idea what happens to the game object running this script when the scene is changed ... 
            // switching scenes technically should be the end of an event but at the same time 
            // I do think that all the commands in the current event node will still be executed but I genuinely have no idea ... 
        }

        protected override bool IsCommandComplete()
        {
            return true; // this is a command that completes instantly,
                         // technically scene switching can take a bit 
                         // but in this specific case we can treat it as
                         // instant and without any loading time. 
        }
    }
}

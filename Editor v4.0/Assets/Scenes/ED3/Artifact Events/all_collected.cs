using Unity.VisualScripting; using Assets.Event_Scripts;
public class all_collected : EventController {
	void Start() { Load(); }
	public void Load() {
		SerializationData data = new SerializationData(
		"{" +
			"  \"_pipes\": [" +
			"    {" +
			"      \"command\": {" +
			"        \"_targetSceneName\": \"A1_intro\"," +
			"        \"_targetPlayerPosition\": {" +
			"          \"x\": 0.0," +
			"          \"y\": 0.0," +
			"          \"z\": 0.0" +
			"        }," +
			"        \"next\": null," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SceneSwitchCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"2\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_awaitedKey\": \"Z\"," +
			"          \"_pressed\": true," +
			"          \"next\": {" +
			"            \"$ref\": \"2\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"4\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"(Sending you back to the intro scene)\"," +
			"        \"next\": {" +
			"          \"$ref\": \"4\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"7\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_awaitedKey\": \"Z\"," +
			"          \"_pressed\": true," +
			"          \"next\": {" +
			"            \"$ref\": \"7\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"9\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"Thank you for playing the demo version of Eon's End!\\n\"," +
			"        \"next\": {" +
			"          \"$ref\": \"9\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"12\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_showFirst\": false," +
			"        \"_textFirst\": \"option 1 text\"," +
			"        \"_showSecond\": false," +
			"        \"_textSecond\": \"option 2 text\"," +
			"        \"_showThird\": false," +
			"        \"_textThird\": \"option 3 text\"," +
			"        \"next\": {" +
			"          \"$ref\": \"12\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"14\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_flag\": \"artifact 4\"," +
			"          \"_check\": \"==\"," +
			"          \"_value\": 1," +
			"          \"next\": {" +
			"            \"$ref\": \"14\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Editor.Event_Scripts.Conditions.NumFlagCondition\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"16\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_flag\": \"artifact 3\"," +
			"          \"_check\": \"==\"," +
			"          \"_value\": 1," +
			"          \"next\": {" +
			"            \"$ref\": \"16\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Editor.Event_Scripts.Conditions.NumFlagCondition\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"19\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_flag\": \"artifact 2\"," +
			"          \"_check\": \"==\"," +
			"          \"_value\": 1," +
			"          \"next\": {" +
			"            \"$ref\": \"19\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Editor.Event_Scripts.Conditions.NumFlagCondition\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"22\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_flag\": \"artifact 1\"," +
			"          \"_check\": \"==\"," +
			"          \"_value\": 1," +
			"          \"next\": {" +
			"            \"$ref\": \"22\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Editor.Event_Scripts.Conditions.NumFlagCondition\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"25\"" +
			"    }" +
			"  ]," +
			"  \"_root\": {" +
			"    \"$ref\": \"25\"" +
			"  }," +
			"  \"$type\": \"Assets.Event_Scripts.EventPipeWrapper\"" +
			"}");
		EventPipeWrapper wrapper = (EventPipeWrapper)data.Deserialize();
		rootPipe = wrapper._root;
		rootPipe.PropogateController(this);
	}
}

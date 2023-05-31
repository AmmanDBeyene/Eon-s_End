using Unity.VisualScripting; using Assets.Event_Scripts;
public class artifact_3_collect : EventController {
	void Start() { Load(); }
	public void Load() {
		SerializationData data = new SerializationData(
		"{" +
			"  \"_pipes\": [" +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"Artifact 3\"," +
			"        \"_position\": {" +
			"          \"x\": -100.0," +
			"          \"y\": -100.0," +
			"          \"z\": -100.0" +
			"        }," +
			"        \"next\": null," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ControlPrefabCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"2\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"next\": {" +
			"          \"$ref\": \"2\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.HideTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"4\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_flag\": \"artifact 3\"," +
			"        \"_value\": 1," +
			"        \"next\": {" +
			"          \"$ref\": \"4\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SetFlagCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"6\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_awaitedKey\": \"Z\"," +
			"          \"_pressed\": true," +
			"          \"next\": {" +
			"            \"$ref\": \"6\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"8\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"You carefully creep up to the artifact and put it in your bag.\"," +
			"        \"next\": {" +
			"          \"$ref\": \"8\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"11\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_awaitedKey\": \"Z\"," +
			"          \"_pressed\": true," +
			"          \"next\": {" +
			"            \"$ref\": \"11\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"13\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"An artifact teetering on the edge of a walkway. \"," +
			"        \"next\": {" +
			"          \"$ref\": \"13\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"16\"" +
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
			"          \"$ref\": \"16\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"18\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_gameObjectFrom\": null," +
			"          \"_gameObjectTo\": null," +
			"          \"_triggerLimit\": 1.0," +
			"          \"_inside\": true," +
			"          \"next\": {" +
			"            \"conditions\": [" +
			"              {" +
			"                \"_awaitedKey\": \"Z\"," +
			"                \"_pressed\": true," +
			"                \"next\": {" +
			"                  \"conditions\": [" +
			"                    {" +
			"                      \"_gameObjectFrom\": null," +
			"                      \"_gameObjectTo\": null," +
			"                      \"_triggerLimit\": 1.0," +
			"                      \"_inside\": true," +
			"                      \"next\": {" +
			"                        \"$ref\": \"18\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"" +
			"                    }," +
			"                    {" +
			"                      \"_gameObjectFrom\": null," +
			"                      \"_gameObjectTo\": null," +
			"                      \"_triggerLimit\": 1.0," +
			"                      \"_inside\": false," +
			"                      \"next\": {" +
			"                        \"$ref\": \"20\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"" +
			"                    }" +
			"                  ]," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                  \"$id\": \"26\"" +
			"                }," +
			"                \"controller\": null," +
			"                \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"              }" +
			"            ]," +
			"            \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"            \"$id\": \"23\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"," +
			"          \"$id\": \"22\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"20\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"26\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"23\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"$ref\": \"22\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"30\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_flag\": \"artifact 3\"," +
			"          \"_check\": \"==\"," +
			"          \"_value\": 0," +
			"          \"next\": {" +
			"            \"$ref\": \"30\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Editor.Event_Scripts.Conditions.NumFlagCondition\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"32\"" +
			"    }" +
			"  ]," +
			"  \"_root\": {" +
			"    \"$ref\": \"32\"" +
			"  }," +
			"  \"$type\": \"Assets.Event_Scripts.EventPipeWrapper\"" +
			"}");
		EventPipeWrapper wrapper = (EventPipeWrapper)data.Deserialize();
		rootPipe = wrapper._root;
		rootPipe.PropogateController(this);
	}
}

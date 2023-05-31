using Unity.VisualScripting; using Assets.Event_Scripts;
public class MainzDisplay : EventController {
	void Start() { Load(); }
	public void Load() {
		SerializationData data = new SerializationData(
		"{" +
			"  \"_pipes\": [" +
			"    {" +
			"      \"command\": {" +
			"        \"next\": null," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.HideTextCommand\"" +
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
			"        \"_showFirst\": false," +
			"        \"_textFirst\": \"option 1 text\"," +
			"        \"_showSecond\": false," +
			"        \"_textSecond\": \"option 2 text\"," +
			"        \"_showThird\": false," +
			"        \"_textThird\": \"option 3 text\"," +
			"        \"next\": {" +
			"          \"$ref\": \"4\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"7\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"Mainz Gladius\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"This first Roman Gladius, adapted from a leaf-shaped sword seen on the battlefields of the Punic Wars. The Romans gave it a triangular blade with a sharper angle. The Mainz averaged a length of 28 inches. \"," +
			"        \"next\": {" +
			"          \"$ref\": \"7\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"9\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_gameObjectFrom\": null," +
			"          \"_gameObjectTo\": null," +
			"          \"_triggerLimit\": 1.5," +
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
			"                      \"_triggerLimit\": 1.5," +
			"                      \"_inside\": true," +
			"                      \"next\": {" +
			"                        \"$ref\": \"9\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"" +
			"                    }," +
			"                    {" +
			"                      \"_gameObjectFrom\": null," +
			"                      \"_gameObjectTo\": null," +
			"                      \"_triggerLimit\": 1.5," +
			"                      \"_inside\": false," +
			"                      \"next\": {" +
			"                        \"$ref\": \"11\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"" +
			"                    }" +
			"                  ]," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                  \"$id\": \"17\"" +
			"                }," +
			"                \"controller\": null," +
			"                \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"              }" +
			"            ]," +
			"            \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"            \"$id\": \"14\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"," +
			"          \"$id\": \"13\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"11\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"17\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"14\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"$ref\": \"13\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"21\"" +
			"    }" +
			"  ]," +
			"  \"_root\": {" +
			"    \"$ref\": \"21\"" +
			"  }," +
			"  \"$type\": \"Assets.Event_Scripts.EventPipeWrapper\"" +
			"}");
		EventPipeWrapper wrapper = (EventPipeWrapper)data.Deserialize();
		rootPipe = wrapper._root;
		rootPipe.PropogateController(this);
	}
}

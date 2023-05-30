using Unity.VisualScripting; using Assets.Event_Scripts;
public class A1_to_N1 : EventController {
	void Start() { Load(); }
	public void Load() {
		SerializationData data = new SerializationData(
		"{" +
			"  \"_pipes\": [" +
			"    {" +
			"      \"command\": {" +
			"        \"_targetSceneName\": \"N1\"," +
			"        \"_targetPlayerPosition\": {" +
			"          \"x\": -2.0," +
			"          \"y\": 1.4," +
			"          \"z\": -7.0" +
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
			"                        \"$ref\": \"2\"" +
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
			"                        \"$ref\": \"4\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"" +
			"                    }" +
			"                  ]," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                  \"$id\": \"10\"" +
			"                }," +
			"                \"controller\": null," +
			"                \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"              }" +
			"            ]," +
			"            \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"            \"$id\": \"7\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"," +
			"          \"$id\": \"6\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"4\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"10\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"7\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"$ref\": \"6\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"14\"" +
			"    }" +
			"  ]," +
			"  \"_root\": {" +
			"    \"$ref\": \"14\"" +
			"  }," +
			"  \"$type\": \"Assets.Event_Scripts.EventPipeWrapper\"" +
			"}");
		EventPipeWrapper wrapper = (EventPipeWrapper)data.Deserialize();
		rootPipe = wrapper._root;
		rootPipe.PropogateController(this);
	}
}

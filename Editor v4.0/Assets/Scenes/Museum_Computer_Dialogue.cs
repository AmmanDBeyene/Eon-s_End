using Unity.VisualScripting; using Assets.Event_Scripts;
public class Museum_Computer_Dialogue : EventController {
	void Start() { Load(); }
	public void Load() {
		SerializationData data = new SerializationData(
		"{" +
			"  \"conditions\": [" +
			"    {" +
			"      \"_awaitedKey\": \"Z\"," +
			"      \"_pressed\": true," +
			"      \"next\": {" +
			"        \"conditions\": [" +
			"          {" +
			"            \"_gameObjectFrom\": null," +
			"            \"_gameObjectTo\": null," +
			"            \"_triggerLimit\": 1.0," +
			"            \"_inside\": true," +
			"            \"next\": {" +
			"              \"command\": {" +
			"                \"_showFirst\": false," +
			"                \"_textFirst\": \"option 1 text\"," +
			"                \"_showSecond\": false," +
			"                \"_textSecond\": \"option 2 text\"," +
			"                \"_showThird\": false," +
			"                \"_textThird\": \"option 3 text\"," +
			"                \"next\": {" +
			"                  \"command\": {" +
			"                    \"_name\": \"Museum Computer\"," +
			"                    \"_portrait\": null," +
			"                    \"_positionLeft\": true," +
			"                    \"_text\": \"This museum is dedicated to the four great regions of the world; you will find each in their proper cardinal direction. A discerning museum explorer such as yourself will surely find the secrets hidden within.\"," +
			"                    \"next\": {" +
			"                      \"conditions\": [" +
			"                        {" +
			"                          \"_awaitedKey\": \"Z\"," +
			"                          \"_pressed\": true," +
			"                          \"next\": {" +
			"                            \"command\": {" +
			"                              \"_name\": \"Jeanne\"," +
			"                              \"_portrait\": null," +
			"                              \"_positionLeft\": true," +
			"                              \"_text\": \"Hmm yes, I AM a discerning explorer\"," +
			"                              \"next\": null," +
			"                              \"controller\": null," +
			"                              \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                            }," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                          }," +
			"                          \"controller\": null," +
			"                          \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                        }" +
			"                      ]," +
			"                      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"                    }," +
			"                    \"controller\": null," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                  }," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                }," +
			"                \"controller\": null," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"              }," +
			"              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"            }," +
			"            \"controller\": null," +
			"            \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"" +
			"          }" +
			"        ]," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"      }," +
			"      \"controller\": null," +
			"      \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"    }" +
			"  ]," +
			"  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"}");
		rootPipe = (IEventPipe)data.Deserialize();
		rootPipe.PropogateController(this);
	}
}

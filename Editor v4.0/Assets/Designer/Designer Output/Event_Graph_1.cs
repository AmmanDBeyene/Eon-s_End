using Unity.VisualScripting; using Assets.Event_Scripts;
public class Event_Graph_1 : EventController {
	void Start() { Load(); }
	public void Load() {
		SerializationData data = new SerializationData(
		"{" +
			"  \"conditions\": [" +
			"    {" +
			"      \"_awaitedKey\": \"A\"," +
			"      \"_pressed\": true," +
			"      \"next\": {" +
			"        \"command\": {" +
			"          \"_name\": \"\"," +
			"          \"_portrait\": null," +
			"          \"_positionLeft\": true," +
			"          \"_text\": \"AAAAAAAAAAAAAAAAA\"," +
			"          \"next\": {" +
			"            \"conditions\": [" +
			"              {" +
			"                \"_awaitedKey\": \"A\"," +
			"                \"_pressed\": true," +
			"                \"next\": {" +
			"                  \"command\": {" +
			"                    \"next\": null," +
			"                    \"controller\": null," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.HideTextCommand\"" +
			"                  }," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                }," +
			"                \"controller\": null," +
			"                \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"              }" +
			"            ]," +
			"            \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"        }," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
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

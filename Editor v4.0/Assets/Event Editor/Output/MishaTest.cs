using Unity.VisualScripting; using Assets.Event_Scripts;
public class MishaTest : EventController {
	void Start() { Load(); }
	public void Load() {
		SerializationData data = new SerializationData(
		"{" +
			"  \"conditions\": [" +
			"    {" +
			"      \"_awaitedKey\": \"Z\"," +
			"      \"_pressed\": true," +
			"      \"next\": {" +
			"        \"command\": {" +
			"          \"_name\": \"Misha\"," +
			"          \"_portrait\": null," +
			"          \"_positionLeft\": true," +
			"          \"_text\": \"Want Fish For Dinner?\"," +
			"          \"next\": {" +
			"            \"conditions\": [" +
			"              {" +
			"                \"_awaitedKey\": \"Z\"," +
			"                \"_pressed\": true," +
			"                \"next\": {" +
			"                  \"command\": {" +
			"                    \"_name\": \"Andrey\"," +
			"                    \"_portrait\": null," +
			"                    \"_positionLeft\": true," +
			"                    \"_text\": \"Yeah sure!\"," +
			"                    \"next\": null," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                  }," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"              }" +
			"            ]," +
			"            \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"          }," +
			"          \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"        }," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"    }" +
			"  ]," +
			"  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"}");
		rootPipe = (IEventPipe)data.Deserialize();
		rootPipe.PropogateController(this);
	}
}

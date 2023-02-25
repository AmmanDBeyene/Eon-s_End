using Unity.VisualScripting; using Assets.Event_Scripts;
public class fox_footprint : EventController {
	void Start() { Load(); }
	public void Load() {
		SerializationData data = new SerializationData(
		"{" +
			"  \"conditions\": [" +
			"    {" +
			"      \"_gameObjectFrom\": null," +
			"      \"_gameObjectTo\": null," +
			"      \"_triggerLimit\": 1.0," +
			"      \"_inside\": true," +
			"      \"next\": {" +
			"        \"conditions\": [" +
			"          {" +
			"            \"_awaitedKey\": \"E\"," +
			"            \"_pressed\": true," +
			"            \"next\": {" +
			"              \"command\": {" +
			"                \"_name\": \"Misha\"," +
			"                \"_portrait\": null," +
			"                \"_positionLeft\": true," +
			"                \"_text\": \"A fox's footprint? ... \\nIt seems to be leading deeper into the forest.\"," +
			"                \"next\": null," +
			"                \"controller\": null," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"              }," +
			"              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"            }," +
			"            \"controller\": null," +
			"            \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"          }" +
			"        ]," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"      }," +
			"      \"controller\": null," +
			"      \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"" +
			"    }" +
			"  ]," +
			"  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"}");
		rootPipe = (IEventPipe)data.Deserialize();
		rootPipe.PropogateController(this);
	}
}

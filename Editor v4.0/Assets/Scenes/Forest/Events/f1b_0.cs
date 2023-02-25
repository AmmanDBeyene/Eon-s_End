using Unity.VisualScripting; using Assets.Event_Scripts;
public class f1b_0 : EventController {
	void Start() { Load(); }
	public void Load() {
		SerializationData data = new SerializationData(
		"{" +
			"  \"conditions\": [" +
			"    {" +
			"      \"_gameObjectFrom\": null," +
			"      \"_gameObjectTo\": null," +
			"      \"_triggerLimit\": 0.1," +
			"      \"_inside\": true," +
			"      \"next\": {" +
			"        \"command\": {" +
			"          \"_targetSceneName\": \"forest-entrance\"," +
			"          \"_targetPlayerPosition\": {" +
			"            \"x\": 4.0," +
			"            \"y\": 0.0," +
			"            \"z\": 6.0" +
			"          }," +
			"          \"next\": null," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SceneSwitchCommand\"" +
			"        }," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
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

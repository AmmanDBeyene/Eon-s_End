using Unity.VisualScripting; using Assets.Event_Scripts;
public class f2d_2c : EventController {
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
			"          \"_targetSceneName\": \"forest-2c\"," +
			"          \"_targetPlayerPosition\": {" +
			"            \"x\": -12.5," +
			"            \"y\": 1.4," +
			"            \"z\": 11.5" +
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
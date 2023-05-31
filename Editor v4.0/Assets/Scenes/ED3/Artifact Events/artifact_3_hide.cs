using Unity.VisualScripting; using Assets.Event_Scripts;
public class artifact_3_hide : EventController {
	void Start() { Load(); }
	public void Load() {
		SerializationData data = new SerializationData(
		"{" +
			"  \"_pipes\": [" +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_gameObjectFrom\": null," +
			"          \"_gameObjectTo\": null," +
			"          \"_triggerLimit\": 999.0," +
			"          \"_inside\": false," +
			"          \"next\": null," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"2\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"Artifact 3\"," +
			"        \"_position\": {" +
			"          \"x\": -100.0," +
			"          \"y\": -100.0," +
			"          \"z\": -100.0" +
			"        }," +
			"        \"next\": {" +
			"          \"$ref\": \"2\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ControlPrefabCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"5\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_flag\": \"artifact 3\"," +
			"          \"_check\": \"==\"," +
			"          \"_value\": 1," +
			"          \"next\": {" +
			"            \"$ref\": \"5\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Editor.Event_Scripts.Conditions.NumFlagCondition\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"7\"" +
			"    }" +
			"  ]," +
			"  \"_root\": {" +
			"    \"$ref\": \"7\"" +
			"  }," +
			"  \"$type\": \"Assets.Event_Scripts.EventPipeWrapper\"" +
			"}");
		EventPipeWrapper wrapper = (EventPipeWrapper)data.Deserialize();
		rootPipe = wrapper._root;
		rootPipe.PropogateController(this);
	}
}

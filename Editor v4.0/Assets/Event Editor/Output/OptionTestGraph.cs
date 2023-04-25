using Unity.VisualScripting; using Assets.Event_Scripts;
public class OptionTestGraph : EventController {
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
			"          \"_name\": \"TestDialogue\"," +
			"          \"_portrait\": null," +
			"          \"_positionLeft\": true," +
			"          \"_text\": \"\"," +
			"          \"next\": {" +
			"            \"command\": {" +
			"              \"_showFirst\": true," +
			"              \"_textFirst\": \"option 1 text\"," +
			"              \"_showSecond\": true," +
			"              \"_textSecond\": \"option 2 text\"," +
			"              \"_showThird\": true," +
			"              \"_textThird\": \"option 3 text\"," +
			"              \"next\": {" +
			"                \"command\": {" +
			"                  \"_optionToSelect\": \"Option 1\"," +
			"                  \"next\": {" +
			"                    \"conditions\": [" +
			"                      {" +
			"                        \"_awaitedKey\": \"S\"," +
			"                        \"_pressed\": true," +
			"                        \"next\": {" +
			"                          \"command\": {" +
			"                            \"_optionToSelect\": \"Option 2\"," +
			"                            \"next\": {" +
			"                              \"conditions\": [" +
			"                                {" +
			"                                  \"_awaitedKey\": \"S\"," +
			"                                  \"_pressed\": true," +
			"                                  \"next\": {" +
			"                                    \"command\": {" +
			"                                      \"_optionToSelect\": \"Option 3\"," +
			"                                      \"next\": {" +
			"                                        \"conditions\": [" +
			"                                          {" +
			"                                            \"_awaitedKey\": \"W\"," +
			"                                            \"_pressed\": true," +
			"                                            \"next\": {" +
			"                                              \"command\": {" +
			"                                                \"$ref\": \"13\"" +
			"                                              }," +
			"                                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                                            }," +
			"                                            \"controller\": null," +
			"                                            \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                          }," +
			"                                          {" +
			"                                            \"_awaitedKey\": \"Z\"," +
			"                                            \"_pressed\": true," +
			"                                            \"next\": {" +
			"                                              \"command\": {" +
			"                                                \"_name\": \"No\"," +
			"                                                \"_portrait\": null," +
			"                                                \"_positionLeft\": true," +
			"                                                \"_text\": \"This is the wrong option. \"," +
			"                                                \"next\": null," +
			"                                                \"controller\": null," +
			"                                                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                              }," +
			"                                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                                            }," +
			"                                            \"controller\": null," +
			"                                            \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                          }" +
			"                                        ]," +
			"                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"                                      }," +
			"                                      \"controller\": null," +
			"                                      \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"" +
			"                                    }," +
			"                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                                  }," +
			"                                  \"controller\": null," +
			"                                  \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                }," +
			"                                {" +
			"                                  \"_awaitedKey\": \"W\"," +
			"                                  \"_pressed\": true," +
			"                                  \"next\": {" +
			"                                    \"command\": {" +
			"                                      \"$ref\": \"8\"" +
			"                                    }," +
			"                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                                  }," +
			"                                  \"controller\": null," +
			"                                  \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                }," +
			"                                {" +
			"                                  \"_awaitedKey\": \"Z\"," +
			"                                  \"_pressed\": true," +
			"                                  \"next\": {" +
			"                                    \"command\": {" +
			"                                      \"_name\": \"Howdy\"," +
			"                                      \"_portrait\": null," +
			"                                      \"_positionLeft\": true," +
			"                                      \"_text\": \"You have selected option 2?\"," +
			"                                      \"next\": null," +
			"                                      \"controller\": null," +
			"                                      \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                    }," +
			"                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                                  }," +
			"                                  \"controller\": null," +
			"                                  \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                }" +
			"                              ]," +
			"                              \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"                            \"$id\": \"13\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }," +
			"                      {" +
			"                        \"_awaitedKey\": \"Z\"," +
			"                        \"_pressed\": true," +
			"                        \"next\": {" +
			"                          \"command\": {" +
			"                            \"_name\": \"Hello\"," +
			"                            \"_portrait\": null," +
			"                            \"_positionLeft\": true," +
			"                            \"_text\": \"You have selected option 1\"," +
			"                            \"next\": null," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }" +
			"                    ]," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"                  \"$id\": \"8\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"              }," +
			"              \"controller\": null," +
			"              \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"            }," +
			"            \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
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

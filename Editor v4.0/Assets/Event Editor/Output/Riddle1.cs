using Unity.VisualScripting; using Assets.Event_Scripts;
public class Riddle1 : EventController {
	void Start() { Load(); }
	public void Load() {
		SerializationData data = new SerializationData(
		"{" +
			"  \"conditions\": [" +
			"    {" +
			"      \"_gameObjectFrom\": null," +
			"      \"_gameObjectTo\": null," +
			"      \"_triggerLimit\": 2.0," +
			"      \"_inside\": true," +
			"      \"next\": {" +
			"        \"conditions\": [" +
			"          {" +
			"            \"_awaitedKey\": \"Z\"," +
			"            \"_pressed\": true," +
			"            \"next\": {" +
			"              \"command\": {" +
			"                \"_name\": \"Demon\"," +
			"                \"_portrait\": null," +
			"                \"_positionLeft\": true," +
			"                \"_text\": \"Think well cur… What is red with a green hat?\"," +
			"                \"next\": {" +
			"                  \"command\": {" +
			"                    \"_showFirst\": true," +
			"                    \"_textFirst\": \"Tomato\"," +
			"                    \"_showSecond\": true," +
			"                    \"_textSecond\": \"Gnome\"," +
			"                    \"_showThird\": true," +
			"                    \"_textThird\": \"A strangled prisoner\"," +
			"                    \"next\": {" +
			"                      \"command\": {" +
			"                        \"_optionToSelect\": \"Option 1\"," +
			"                        \"next\": {" +
			"                          \"conditions\": [" +
			"                            {" +
			"                              \"_awaitedKey\": \"S\"," +
			"                              \"_pressed\": true," +
			"                              \"next\": {" +
			"                                \"command\": {" +
			"                                  \"_optionToSelect\": \"Option 2\"," +
			"                                  \"next\": {" +
			"                                    \"conditions\": [" +
			"                                      {" +
			"                                        \"_awaitedKey\": \"S\"," +
			"                                        \"_pressed\": true," +
			"                                        \"next\": {" +
			"                                          \"command\": {" +
			"                                            \"_optionToSelect\": \"Option 3\"," +
			"                                            \"next\": {" +
			"                                              \"conditions\": [" +
			"                                                {" +
			"                                                  \"_awaitedKey\": \"W\"," +
			"                                                  \"_pressed\": true," +
			"                                                  \"next\": {" +
			"                                                    \"command\": {" +
			"                                                      \"$ref\": \"16\"" +
			"                                                    }," +
			"                                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                                                  }," +
			"                                                  \"controller\": null," +
			"                                                  \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                                }," +
			"                                                {" +
			"                                                  \"_awaitedKey\": \"Z\"," +
			"                                                  \"_pressed\": true," +
			"                                                  \"next\": {" +
			"                                                    \"command\": {" +
			"                                                      \"_showFirst\": false," +
			"                                                      \"_textFirst\": \"option 1 text\"," +
			"                                                      \"_showSecond\": false," +
			"                                                      \"_textSecond\": \"\"," +
			"                                                      \"_showThird\": false," +
			"                                                      \"_textThird\": \"option 3 text\"," +
			"                                                      \"next\": {" +
			"                                                        \"command\": {" +
			"                                                          \"_name\": \"Demon\"," +
			"                                                          \"_portrait\": null," +
			"                                                          \"_positionLeft\": true," +
			"                                                          \"_text\": \"Think again, fool!\"," +
			"                                                          \"next\": {" +
			"                                                            \"conditions\": [" +
			"                                                              {" +
			"                                                                \"_awaitedKey\": \"Z\"," +
			"                                                                \"_pressed\": true," +
			"                                                                \"next\": {" +
			"                                                                  \"command\": {" +
			"                                                                    \"next\": null," +
			"                                                                    \"controller\": null," +
			"                                                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.HideTextCommand\"" +
			"                                                                  }," +
			"                                                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                                                                }," +
			"                                                                \"controller\": null," +
			"                                                                \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"," +
			"                                                                \"$id\": \"33\"" +
			"                                                              }" +
			"                                                            ]," +
			"                                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"                                                          }," +
			"                                                          \"controller\": null," +
			"                                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                                        }," +
			"                                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                                                      }," +
			"                                                      \"controller\": null," +
			"                                                      \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                                                    }," +
			"                                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                                                  }," +
			"                                                  \"controller\": null," +
			"                                                  \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                                }" +
			"                                              ]," +
			"                                              \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"                                            }," +
			"                                            \"controller\": null," +
			"                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"" +
			"                                          }," +
			"                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                                        }," +
			"                                        \"controller\": null," +
			"                                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                      }," +
			"                                      {" +
			"                                        \"_awaitedKey\": \"W\"," +
			"                                        \"_pressed\": true," +
			"                                        \"next\": {" +
			"                                          \"command\": {" +
			"                                            \"$ref\": \"11\"" +
			"                                          }," +
			"                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                                        }," +
			"                                        \"controller\": null," +
			"                                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                      }," +
			"                                      {" +
			"                                        \"_awaitedKey\": \"Z\"," +
			"                                        \"_pressed\": true," +
			"                                        \"next\": {" +
			"                                          \"command\": {" +
			"                                            \"_showFirst\": false," +
			"                                            \"_textFirst\": \"option 1 text\"," +
			"                                            \"_showSecond\": false," +
			"                                            \"_textSecond\": \"option 2 text\"," +
			"                                            \"_showThird\": false," +
			"                                            \"_textThird\": \"option 3 text\"," +
			"                                            \"next\": {" +
			"                                              \"command\": {" +
			"                                                \"_name\": \"Demon\"," +
			"                                                \"_portrait\": null," +
			"                                                \"_positionLeft\": true," +
			"                                                \"_text\": \"Wrong, mortal!\"," +
			"                                                \"next\": {" +
			"                                                  \"conditions\": [" +
			"                                                    {" +
			"                                                      \"$ref\": \"33\"" +
			"                                                    }" +
			"                                                  ]," +
			"                                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"                                                }," +
			"                                                \"controller\": null," +
			"                                                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                              }," +
			"                                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                                            }," +
			"                                            \"controller\": null," +
			"                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                                          }," +
			"                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                                        }," +
			"                                        \"controller\": null," +
			"                                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                      }" +
			"                                    ]," +
			"                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"                                  }," +
			"                                  \"controller\": null," +
			"                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"                                  \"$id\": \"16\"" +
			"                                }," +
			"                                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                              }," +
			"                              \"controller\": null," +
			"                              \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                            }," +
			"                            {" +
			"                              \"_awaitedKey\": \"Z\"," +
			"                              \"_pressed\": true," +
			"                              \"next\": {" +
			"                                \"command\": {" +
			"                                  \"_showFirst\": false," +
			"                                  \"_textFirst\": \"option 1 text\"," +
			"                                  \"_showSecond\": false," +
			"                                  \"_textSecond\": \"option 2 text\"," +
			"                                  \"_showThird\": false," +
			"                                  \"_textThird\": \"option 3 text\"," +
			"                                  \"next\": {" +
			"                                    \"command\": {" +
			"                                      \"_name\": \"Demon\"," +
			"                                      \"_portrait\": null," +
			"                                      \"_positionLeft\": true," +
			"                                      \"_text\": \"Correct!\"," +
			"                                      \"next\": {" +
			"                                        \"conditions\": [" +
			"                                          {" +
			"                                            \"$ref\": \"33\"" +
			"                                          }" +
			"                                        ]," +
			"                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"                                      }," +
			"                                      \"controller\": null," +
			"                                      \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                    }," +
			"                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                                  }," +
			"                                  \"controller\": null," +
			"                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                                }," +
			"                                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                              }," +
			"                              \"controller\": null," +
			"                              \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                            }" +
			"                          ]," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"                        \"$id\": \"11\"" +
			"                      }," +
			"                      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                    }," +
			"                    \"controller\": null," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                  }," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"" +
			"                }," +
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

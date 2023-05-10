using Unity.VisualScripting; using Assets.Event_Scripts;
public class OptionsTest3 : EventController {
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
			"            \"_awaitedKey\": \"Z\"," +
			"            \"_pressed\": true," +
			"            \"next\": {" +
			"              \"command\": {" +
			"                \"_name\": \"\"," +
			"                \"_portrait\": null," +
			"                \"_positionLeft\": true," +
			"                \"_text\": \"Fiddle my riddle what chooseth thee?\"," +
			"                \"next\": {" +
			"                  \"command\": {" +
			"                    \"_showFirst\": true," +
			"                    \"_textFirst\": \"To suck on thy thumb.\"," +
			"                    \"_showSecond\": true," +
			"                    \"_textSecond\": \"To lay on thy knee.\"," +
			"                    \"_showThird\": true," +
			"                    \"_textThird\": \"Die.\"," +
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
			"                                                          \"_name\": \"\"," +
			"                                                          \"_portrait\": null," +
			"                                                          \"_positionLeft\": true," +
			"                                                          \"_text\": \"Die?\"," +
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
			"                                                \"_name\": \"\"," +
			"                                                \"_portrait\": null," +
			"                                                \"_positionLeft\": true," +
			"                                                \"_text\": \"No knees today. \"," +
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
			"                                      \"_name\": \"\"," +
			"                                      \"_portrait\": null," +
			"                                      \"_positionLeft\": true," +
			"                                      \"_text\": \"Filthy Thumb Sucker\"," +
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

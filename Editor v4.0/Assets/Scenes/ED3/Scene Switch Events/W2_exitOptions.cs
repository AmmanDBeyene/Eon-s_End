using Unity.VisualScripting; using Assets.Event_Scripts;
public class W2_exitOptions : EventController {
	void Start() { Load(); }
	public void Load() {
		SerializationData data = new SerializationData(
		"{" +
			"  \"_pipes\": [" +
			"    {" +
			"      \"command\": {" +
			"        \"_targetSceneName\": \"W1\"," +
			"        \"_targetPlayerPosition\": {" +
			"          \"x\": -1.0," +
			"          \"y\": 1.4," +
			"          \"z\": 7.0" +
			"        }," +
			"        \"next\": null," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SceneSwitchCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"2\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_optionToSelect\": \"Option 2\"," +
			"        \"next\": {" +
			"          \"conditions\": [" +
			"            {" +
			"              \"_awaitedKey\": \"S\"," +
			"              \"_pressed\": true," +
			"              \"next\": {" +
			"                \"command\": {" +
			"                  \"_optionToSelect\": \"Option 3\"," +
			"                  \"next\": {" +
			"                    \"conditions\": [" +
			"                      {" +
			"                        \"_awaitedKey\": \"W\"," +
			"                        \"_pressed\": true," +
			"                        \"next\": {" +
			"                          \"$ref\": \"4\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }," +
			"                      {" +
			"                        \"_awaitedKey\": \"Z\"," +
			"                        \"_pressed\": true," +
			"                        \"next\": {" +
			"                          \"command\": {" +
			"                            \"_showFirst\": false," +
			"                            \"_textFirst\": \"option 1 text\"," +
			"                            \"_showSecond\": false," +
			"                            \"_textSecond\": \"\"," +
			"                            \"_showThird\": false," +
			"                            \"_textThird\": \"option 3 text\"," +
			"                            \"next\": {" +
			"                              \"$ref\": \"2\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"15\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }" +
			"                    ]," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                    \"$id\": \"11\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"9\"" +
			"              }," +
			"              \"controller\": null," +
			"              \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"            }," +
			"            {" +
			"              \"_awaitedKey\": \"W\"," +
			"              \"_pressed\": true," +
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
			"                            \"$ref\": \"5\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"23\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }," +
			"                      {" +
			"                        \"_awaitedKey\": \"Z\"," +
			"                        \"_pressed\": true," +
			"                        \"next\": {" +
			"                          \"command\": {" +
			"                            \"_showFirst\": false," +
			"                            \"_textFirst\": \"option 1 text\"," +
			"                            \"_showSecond\": false," +
			"                            \"_textSecond\": \"option 2 text\"," +
			"                            \"_showThird\": false," +
			"                            \"_textThird\": \"option 3 text\"," +
			"                            \"next\": {" +
			"                              \"command\": {" +
			"                                \"_targetSceneName\": \"W2\"," +
			"                                \"_targetPlayerPosition\": {" +
			"                                  \"x\": -2.0," +
			"                                  \"y\": 1.4," +
			"                                  \"z\": -5.0" +
			"                                }," +
			"                                \"next\": null," +
			"                                \"controller\": null," +
			"                                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SceneSwitchCommand\"" +
			"                              }," +
			"                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                              \"$id\": \"27\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"25\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }" +
			"                    ]," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                    \"$id\": \"20\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"                  \"$id\": \"19\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"18\"" +
			"              }," +
			"              \"controller\": null," +
			"              \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"            }," +
			"            {" +
			"              \"_awaitedKey\": \"Z\"," +
			"              \"_pressed\": true," +
			"              \"next\": {" +
			"                \"command\": {" +
			"                  \"_showFirst\": false," +
			"                  \"_textFirst\": \"option 1 text\"," +
			"                  \"_showSecond\": false," +
			"                  \"_textSecond\": \"option 2 text\"," +
			"                  \"_showThird\": false," +
			"                  \"_textThird\": \"option 3 text\"," +
			"                  \"next\": {" +
			"                    \"command\": {" +
			"                      \"_targetSceneName\": \"A1\"," +
			"                      \"_targetPlayerPosition\": {" +
			"                        \"x\": -4.0," +
			"                        \"y\": -0.2999998," +
			"                        \"z\": 2.0" +
			"                      }," +
			"                      \"next\": null," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SceneSwitchCommand\"" +
			"                    }," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                    \"$id\": \"32\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"30\"" +
			"              }," +
			"              \"controller\": null," +
			"              \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"            }" +
			"          ]," +
			"          \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"          \"$id\": \"6\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"        \"$id\": \"5\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"4\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"15\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"11\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"32\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"9\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"18\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"30\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"6\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"27\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"23\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"25\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"20\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"$ref\": \"19\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"34\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_showFirst\": true," +
			"        \"_textFirst\": \"Continue exploring...\"," +
			"        \"_showSecond\": true," +
			"        \"_textSecond\": \"Return to lobby...\"," +
			"        \"_showThird\": true," +
			"        \"_textThird\": \"Return to maze...\"," +
			"        \"next\": {" +
			"          \"$ref\": \"34\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"35\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"What to do?\"," +
			"        \"next\": {" +
			"          \"$ref\": \"35\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"37\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_gameObjectFrom\": null," +
			"          \"_gameObjectTo\": null," +
			"          \"_triggerLimit\": 2.0," +
			"          \"_inside\": true," +
			"          \"next\": {" +
			"            \"$ref\": \"37\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"39\"" +
			"    }" +
			"  ]," +
			"  \"_root\": {" +
			"    \"$ref\": \"39\"" +
			"  }," +
			"  \"$type\": \"Assets.Event_Scripts.EventPipeWrapper\"" +
			"}");
		EventPipeWrapper wrapper = (EventPipeWrapper)data.Deserialize();
		rootPipe = wrapper._root;
		rootPipe.PropogateController(this);
	}
}

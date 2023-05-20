using Unity.VisualScripting; using Assets.Event_Scripts;
public class Jesse_Bear_1 : EventController {
	void Start() { Load(); }
	public void Load() {
		SerializationData data = new SerializationData(
		"{" +
			"  \"_pipes\": [" +
			"    {" +
			"      \"command\": {" +
			"        \"_targetSceneName\": \"ED2\"," +
			"        \"_targetPlayerPosition\": {" +
			"          \"x\": -41.0," +
			"          \"y\": 0.0," +
			"          \"z\": 38.0" +
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
			"        \"next\": {" +
			"          \"$ref\": \"2\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.HideTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"4\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_awaitedKey\": \"Z\"," +
			"          \"_pressed\": true," +
			"          \"next\": {" +
			"            \"$ref\": \"4\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"6\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_targetSceneName\": \"ED2\"," +
			"        \"_targetPlayerPosition\": {" +
			"          \"x\": 0.0," +
			"          \"y\": 0.0," +
			"          \"z\": 0.0" +
			"        }," +
			"        \"next\": null," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SceneSwitchCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"9\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"Bear of Despair\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"Thank you kind soul for saving my life. I would have choked to death if it were not for you shoving your hand down my throat.\"," +
			"        \"next\": {" +
			"          \"$ref\": \"6\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"11\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"next\": {" +
			"          \"$ref\": \"9\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.HideTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"13\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_awaitedKey\": \"Z\"," +
			"          \"_pressed\": true," +
			"          \"next\": {" +
			"            \"$ref\": \"11\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"15\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_awaitedKey\": \"Z\"," +
			"          \"_pressed\": true," +
			"          \"next\": {" +
			"            \"$ref\": \"13\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"," +
			"          \"$id\": \"20\"" +
			"        }," +
			"        {" +
			"          \"$ref\": \"20\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"18\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"Bear of Despair\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"*COUGH* *KHAAAK* The bear takes a deep breath\"," +
			"        \"next\": {" +
			"          \"$ref\": \"15\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"21\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"Bear of Despair\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"I DON'T HAVE SLIPPERS BUT I CAN DO THIS!\"," +
			"        \"next\": {" +
			"          \"$ref\": \"18\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"23\"" +
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
			"                          \"$ref\": \"25\"" +
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
			"                              \"$ref\": \"21\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"36\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }" +
			"                    ]," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                    \"$id\": \"32\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"30\"" +
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
			"                            \"$ref\": \"26\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"44\"" +
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
			"                                \"_name\": \"\"," +
			"                                \"_portrait\": null," +
			"                                \"_positionLeft\": true," +
			"                                \"_text\": \"You try to run but it is futile…\"," +
			"                                \"next\": {" +
			"                                  \"conditions\": [" +
			"                                    {" +
			"                                      \"_awaitedKey\": \"Z\"," +
			"                                      \"_pressed\": true," +
			"                                      \"next\": {" +
			"                                        \"command\": {" +
			"                                          \"_name\": \"\"," +
			"                                          \"_portrait\": null," +
			"                                          \"_positionLeft\": true," +
			"                                          \"_text\": \"This bear is a famous spartathlon runner. You faint... \"," +
			"                                          \"next\": {" +
			"                                            \"conditions\": [" +
			"                                              {" +
			"                                                \"$ref\": \"20\"" +
			"                                              }" +
			"                                            ]," +
			"                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                            \"$id\": \"55\"" +
			"                                          }," +
			"                                          \"controller\": null," +
			"                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                        }," +
			"                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                        \"$id\": \"53\"" +
			"                                      }," +
			"                                      \"controller\": null," +
			"                                      \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                    }" +
			"                                  ]," +
			"                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                  \"$id\": \"50\"" +
			"                                }," +
			"                                \"controller\": null," +
			"                                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                              }," +
			"                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                              \"$id\": \"48\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"46\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }" +
			"                    ]," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                    \"$id\": \"41\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"                  \"$id\": \"40\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"39\"" +
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
			"                      \"_name\": \"Bear of Despair\"," +
			"                      \"_portrait\": null," +
			"                      \"_positionLeft\": true," +
			"                      \"_text\": \"OH YEAH YOU WANNA GO?\"," +
			"                      \"next\": {" +
			"                        \"conditions\": [" +
			"                          {" +
			"                            \"_awaitedKey\": \"Z\"," +
			"                            \"_pressed\": true," +
			"                            \"next\": {" +
			"                              \"$ref\": \"23\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                          }" +
			"                        ]," +
			"                        \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                        \"$id\": \"62\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                    }," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                    \"$id\": \"60\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"58\"" +
			"              }," +
			"              \"controller\": null," +
			"              \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"            }" +
			"          ]," +
			"          \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"          \"$id\": \"27\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"        \"$id\": \"26\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"25\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"36\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"62\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"55\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"32\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"60\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"53\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"30\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"39\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"58\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"50\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"27\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"48\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"44\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"46\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"41\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"$ref\": \"40\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"65\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_showFirst\": true," +
			"        \"_textFirst\": \"Run because your life depends on it\"," +
			"        \"_showSecond\": true," +
			"        \"_textSecond\": \"Take off your sandal and wield it above your head menacingly\"," +
			"        \"_showThird\": true," +
			"        \"_textThird\": \"Shove “edible” berries down the bear’s throat\"," +
			"        \"next\": {" +
			"          \"$ref\": \"65\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"66\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"Bear of Despair\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"The bear stares at you meaningly...\"," +
			"        \"next\": {" +
			"          \"$ref\": \"66\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"68\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_gameObjectFrom\": null," +
			"          \"_gameObjectTo\": null," +
			"          \"_triggerLimit\": 2.0," +
			"          \"_inside\": true," +
			"          \"next\": {" +
			"            \"conditions\": [" +
			"              {" +
			"                \"_awaitedKey\": \"Z\"," +
			"                \"_pressed\": true," +
			"                \"next\": {" +
			"                  \"conditions\": [" +
			"                    {" +
			"                      \"_gameObjectFrom\": null," +
			"                      \"_gameObjectTo\": null," +
			"                      \"_triggerLimit\": 2.0," +
			"                      \"_inside\": true," +
			"                      \"next\": {" +
			"                        \"$ref\": \"68\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"" +
			"                    }," +
			"                    {" +
			"                      \"_gameObjectFrom\": null," +
			"                      \"_gameObjectTo\": null," +
			"                      \"_triggerLimit\": 2.0," +
			"                      \"_inside\": false," +
			"                      \"next\": {" +
			"                        \"$ref\": \"70\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"" +
			"                    }" +
			"                  ]," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                  \"$id\": \"76\"" +
			"                }," +
			"                \"controller\": null," +
			"                \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"              }" +
			"            ]," +
			"            \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"            \"$id\": \"73\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"," +
			"          \"$id\": \"72\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"70\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"76\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"73\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"$ref\": \"72\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"80\"" +
			"    }" +
			"  ]," +
			"  \"_root\": {" +
			"    \"$ref\": \"80\"" +
			"  }," +
			"  \"$type\": \"Assets.Event_Scripts.EventPipeWrapper\"" +
			"}");
		EventPipeWrapper wrapper = (EventPipeWrapper)data.Deserialize();
		rootPipe = wrapper._root;
		rootPipe.PropogateController(this);
	}
}

using Unity.VisualScripting; using Assets.Event_Scripts;
public class Jesse_Bear_1 : EventController {
	void Start() { Load(); }
	public void Load() {
		SerializationData data = new SerializationData(
		"{" +
			"  \"_pipes\": [" +
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
			"                          \"$ref\": \"2\"" +
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
			"                              \"command\": {" +
			"                                \"_name\": \"Bear of Despair\"," +
			"                                \"_portrait\": null," +
			"                                \"_positionLeft\": true," +
			"                                \"_text\": \"*COUGH* *KHAAAK* The bear takes a deep breath\"," +
			"                                \"next\": {" +
			"                                  \"conditions\": [" +
			"                                    {" +
			"                                      \"_awaitedKey\": \"Z\"," +
			"                                      \"_pressed\": true," +
			"                                      \"next\": {" +
			"                                        \"command\": {" +
			"                                          \"_name\": \"Bear of Despair\"," +
			"                                          \"_portrait\": null," +
			"                                          \"_positionLeft\": true," +
			"                                          \"_text\": \"Thank you kind soul for saving my life. I would have choked to death if it were not for you shoving your hand down my throat.\"," +
			"                                          \"next\": {" +
			"                                            \"conditions\": [" +
			"                                              {" +
			"                                                \"_awaitedKey\": \"Z\"," +
			"                                                \"_pressed\": true," +
			"                                                \"next\": {" +
			"                                                  \"command\": {" +
			"                                                    \"next\": null," +
			"                                                    \"controller\": null," +
			"                                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.HideTextCommand\"" +
			"                                                  }," +
			"                                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                  \"$id\": \"25\"" +
			"                                                }," +
			"                                                \"controller\": null," +
			"                                                \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"," +
			"                                                \"$id\": \"24\"" +
			"                                              }" +
			"                                            ]," +
			"                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                            \"$id\": \"22\"" +
			"                                          }," +
			"                                          \"controller\": null," +
			"                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                        }," +
			"                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                        \"$id\": \"20\"" +
			"                                      }," +
			"                                      \"controller\": null," +
			"                                      \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                    }" +
			"                                  ]," +
			"                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                  \"$id\": \"17\"" +
			"                                }," +
			"                                \"controller\": null," +
			"                                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                              }," +
			"                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                              \"$id\": \"15\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"13\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }" +
			"                    ]," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                    \"$id\": \"9\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"7\"" +
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
			"                            \"$ref\": \"3\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"33\"" +
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
			"                                                \"$ref\": \"24\"" +
			"                                              }" +
			"                                            ]," +
			"                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                            \"$id\": \"44\"" +
			"                                          }," +
			"                                          \"controller\": null," +
			"                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                        }," +
			"                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                        \"$id\": \"42\"" +
			"                                      }," +
			"                                      \"controller\": null," +
			"                                      \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                    }" +
			"                                  ]," +
			"                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                  \"$id\": \"39\"" +
			"                                }," +
			"                                \"controller\": null," +
			"                                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                              }," +
			"                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                              \"$id\": \"37\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"35\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }" +
			"                    ]," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                    \"$id\": \"30\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"                  \"$id\": \"29\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"28\"" +
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
			"                              \"command\": {" +
			"                                \"_name\": \"Bear of Despair\"," +
			"                                \"_portrait\": null," +
			"                                \"_positionLeft\": true," +
			"                                \"_text\": \"I DON'T HAVE SLIPPERS BUT I CAN DO THIS!\"," +
			"                                \"next\": {" +
			"                                  \"conditions\": [" +
			"                                    {" +
			"                                      \"$ref\": \"24\"" +
			"                                    }," +
			"                                    {" +
			"                                      \"$ref\": \"24\"" +
			"                                    }" +
			"                                  ]," +
			"                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                  \"$id\": \"56\"" +
			"                                }," +
			"                                \"controller\": null," +
			"                                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                              }," +
			"                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                              \"$id\": \"54\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                          }" +
			"                        ]," +
			"                        \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                        \"$id\": \"51\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                    }," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                    \"$id\": \"49\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"47\"" +
			"              }," +
			"              \"controller\": null," +
			"              \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"            }" +
			"          ]," +
			"          \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"          \"$id\": \"4\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"        \"$id\": \"3\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"2\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"25\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"22\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"20\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"17\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"15\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"13\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"9\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"7\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"28\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"56\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"54\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"51\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"49\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"47\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"4\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"33\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"44\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"42\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"39\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"37\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"35\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"30\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"$ref\": \"29\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"58\"" +
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
			"          \"$ref\": \"58\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"59\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"Bear of Despair\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"The bear stares at you meaningly...\"," +
			"        \"next\": {" +
			"          \"$ref\": \"59\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"61\"" +
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
			"                        \"$ref\": \"61\"" +
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
			"                        \"$ref\": \"63\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"" +
			"                    }" +
			"                  ]," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                  \"$id\": \"69\"" +
			"                }," +
			"                \"controller\": null," +
			"                \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"              }" +
			"            ]," +
			"            \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"            \"$id\": \"66\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"," +
			"          \"$id\": \"65\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"63\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"69\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"66\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"$ref\": \"65\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"73\"" +
			"    }" +
			"  ]," +
			"  \"_root\": {" +
			"    \"$ref\": \"73\"" +
			"  }," +
			"  \"$type\": \"Assets.Event_Scripts.EventPipeWrapper\"" +
			"}");
		EventPipeWrapper wrapper = (EventPipeWrapper)data.Deserialize();
		rootPipe = wrapper._root;
		rootPipe.PropogateController(this);
	}
}

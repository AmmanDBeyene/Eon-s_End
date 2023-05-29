using Unity.VisualScripting; using Assets.Event_Scripts;
public class Demon_Riddle_Full_v2 : EventController {
	void Start() { Load(); }
	public void Load() {
		SerializationData data = new SerializationData(
		"{" +
			"  \"_pipes\": [" +
			"    {" +
			"      \"command\": {" +
			"        \"_targetSceneName\": \"E2\"," +
			"        \"_targetPlayerPosition\": {" +
			"          \"x\": 3.0," +
			"          \"y\": 3.4," +
			"          \"z\": -8.0" +
			"        }," +
			"        \"next\": null," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SceneSwitchCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"2\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_awaitedKey\": \"Z\"," +
			"          \"_pressed\": true," +
			"          \"next\": {" +
			"            \"$ref\": \"2\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"4\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"Demon\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"You know, I’ve been having trouble domesticating them, any idea of how to get them to calm down? Right, well, you win!\"," +
			"        \"next\": {" +
			"          \"$ref\": \"4\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"7\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"next\": null," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.HideTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"9\"" +
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
			"                          \"$ref\": \"11\"" +
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
			"                              \"$ref\": \"7\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"22\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }" +
			"                    ]," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                    \"$id\": \"18\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"16\"" +
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
			"                            \"$ref\": \"12\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"30\"" +
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
			"                                \"_name\": \"Demon\"," +
			"                                \"_portrait\": null," +
			"                                \"_positionLeft\": true," +
			"                                \"_text\": \"Succubi aren’t stingy. How could you say that? That’s defamation, mortal!\"," +
			"                                \"next\": {" +
			"                                  \"conditions\": [" +
			"                                    {" +
			"                                      \"_awaitedKey\": \"Z\"," +
			"                                      \"_pressed\": true," +
			"                                      \"next\": {" +
			"                                        \"$ref\": \"9\"" +
			"                                      }," +
			"                                      \"controller\": null," +
			"                                      \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"," +
			"                                      \"$id\": \"38\"" +
			"                                    }" +
			"                                  ]," +
			"                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                  \"$id\": \"36\"" +
			"                                }," +
			"                                \"controller\": null," +
			"                                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                              }," +
			"                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                              \"$id\": \"34\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"32\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }" +
			"                    ]," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                    \"$id\": \"27\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"                  \"$id\": \"26\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"25\"" +
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
			"                      \"_name\": \"Demon\"," +
			"                      \"_portrait\": null," +
			"                      \"_positionLeft\": true," +
			"                      \"_text\": \"It’s really rather salty, I’ve died around 60 times, of course, I keep coming back…\"," +
			"                      \"next\": {" +
			"                        \"conditions\": [" +
			"                          {" +
			"                            \"$ref\": \"38\"" +
			"                          }" +
			"                        ]," +
			"                        \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                        \"$id\": \"44\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                    }," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                    \"$id\": \"42\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"40\"" +
			"              }," +
			"              \"controller\": null," +
			"              \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"            }" +
			"          ]," +
			"          \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"          \"$id\": \"13\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"        \"$id\": \"12\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"11\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"22\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"44\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"18\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"42\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"16\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"25\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"40\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"36\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"13\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"34\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"30\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"32\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"27\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"next\": null," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.HideTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"46\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"$ref\": \"26\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"48\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_awaitedKey\": \"Z\"," +
			"          \"_pressed\": true," +
			"          \"next\": {" +
			"            \"$ref\": \"46\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"," +
			"          \"$id\": \"51\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"49\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_showFirst\": true," +
			"        \"_textFirst\": \"A Succubus\"," +
			"        \"_showSecond\": true," +
			"        \"_textSecond\": \"Death\"," +
			"        \"_showThird\": true," +
			"        \"_textThird\": \"Bees\"," +
			"        \"next\": {" +
			"          \"$ref\": \"48\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"52\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"Demon\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"No buried treasure round’ here. It's ALL on display\"," +
			"        \"next\": {" +
			"          \"$ref\": \"49\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"54\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"Demon\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"What is stingy but carries sweet stuff?\"," +
			"        \"next\": {" +
			"          \"$ref\": \"52\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"56\"" +
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
			"                          \"$ref\": \"58\"" +
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
			"                              \"$ref\": \"54\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"69\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }" +
			"                    ]," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                    \"$id\": \"65\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"63\"" +
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
			"                            \"$ref\": \"59\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"77\"" +
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
			"                                \"_name\": \"Demon\"," +
			"                                \"_portrait\": null," +
			"                                \"_positionLeft\": true," +
			"                                \"_text\": \"Wrong, the one built here is awfully close to the surface, poor engineering if you ask me.\"," +
			"                                \"next\": {" +
			"                                  \"conditions\": [" +
			"                                    {" +
			"                                      \"$ref\": \"51\"" +
			"                                    }" +
			"                                  ]," +
			"                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                  \"$id\": \"83\"" +
			"                                }," +
			"                                \"controller\": null," +
			"                                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                              }," +
			"                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                              \"$id\": \"81\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"79\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }" +
			"                    ]," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                    \"$id\": \"74\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"                  \"$id\": \"73\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"72\"" +
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
			"                      \"_name\": \"Demon\"," +
			"                      \"_portrait\": null," +
			"                      \"_positionLeft\": true," +
			"                      \"_text\": \"Yes, and these will make an excellent addition to my agricultural efforts.\"," +
			"                      \"next\": {" +
			"                        \"conditions\": [" +
			"                          {" +
			"                            \"_awaitedKey\": \"Z\"," +
			"                            \"_pressed\": true," +
			"                            \"next\": {" +
			"                              \"$ref\": \"56\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                          }" +
			"                        ]," +
			"                        \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                        \"$id\": \"90\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                    }," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                    \"$id\": \"88\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"86\"" +
			"              }," +
			"              \"controller\": null," +
			"              \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"            }" +
			"          ]," +
			"          \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"          \"$id\": \"60\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"        \"$id\": \"59\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"58\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"69\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"90\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"65\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"88\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"63\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"72\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"86\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"83\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"60\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"81\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"next\": null," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.HideTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"93\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"77\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"79\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"_awaitedKey\": \"Z\"," +
			"          \"_pressed\": true," +
			"          \"next\": {" +
			"            \"$ref\": \"93\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"," +
			"          \"$id\": \"97\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"95\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"74\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"Demon\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"Incorrect; the last mortal I imprisoned had no headwear to speak of.\"," +
			"        \"next\": {" +
			"          \"$ref\": \"95\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"98\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"$ref\": \"73\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"100\"" +
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
			"                          \"$ref\": \"101\"" +
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
			"                              \"$ref\": \"98\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"112\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }" +
			"                    ]," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                    \"$id\": \"108\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"106\"" +
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
			"                            \"$ref\": \"102\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"120\"" +
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
			"                                \"_name\": \"Demon\"," +
			"                                \"_portrait\": null," +
			"                                \"_positionLeft\": true," +
			"                                \"_text\": \"Precisely mortal, I’m thinking of starting a garden…\"," +
			"                                \"next\": {" +
			"                                  \"conditions\": [" +
			"                                    {" +
			"                                      \"_awaitedKey\": \"Z\"," +
			"                                      \"_pressed\": true," +
			"                                      \"next\": {" +
			"                                        \"command\": {" +
			"                                          \"_name\": \"Demon\"," +
			"                                          \"_portrait\": null," +
			"                                          \"_positionLeft\": true," +
			"                                          \"_text\": \"Tremble mortal! What is buried deep beneath the ground?\"," +
			"                                          \"next\": {" +
			"                                            \"command\": {" +
			"                                              \"_showFirst\": true," +
			"                                              \"_textFirst\": \"A Necropolis\"," +
			"                                              \"_showSecond\": true," +
			"                                              \"_textSecond\": \"Potatoes\"," +
			"                                              \"_showThird\": true," +
			"                                              \"_textThird\": \"Treasure\"," +
			"                                              \"next\": {" +
			"                                                \"$ref\": \"100\"" +
			"                                              }," +
			"                                              \"controller\": null," +
			"                                              \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                                            }," +
			"                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                            \"$id\": \"131\"" +
			"                                          }," +
			"                                          \"controller\": null," +
			"                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                        }," +
			"                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                        \"$id\": \"129\"" +
			"                                      }," +
			"                                      \"controller\": null," +
			"                                      \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                    }" +
			"                                  ]," +
			"                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                  \"$id\": \"126\"" +
			"                                }," +
			"                                \"controller\": null," +
			"                                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                              }," +
			"                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                              \"$id\": \"124\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"122\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }" +
			"                    ]," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                    \"$id\": \"117\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"                  \"$id\": \"116\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"115\"" +
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
			"                      \"_name\": \"Demon\"," +
			"                      \"_portrait\": null," +
			"                      \"_positionLeft\": true," +
			"                      \"_text\": \"No, the last one I saw was wearing a distinctly blue hat\"," +
			"                      \"next\": {" +
			"                        \"conditions\": [" +
			"                          {" +
			"                            \"$ref\": \"97\"" +
			"                          }" +
			"                        ]," +
			"                        \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                        \"$id\": \"138\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                    }," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                    \"$id\": \"136\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"134\"" +
			"              }," +
			"              \"controller\": null," +
			"              \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"            }" +
			"          ]," +
			"          \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"          \"$id\": \"103\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"        \"$id\": \"102\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"101\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"112\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"138\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"131\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"108\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"136\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"129\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"106\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"115\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"134\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"126\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"103\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"124\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"120\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"122\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"117\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"$ref\": \"116\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"140\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_showFirst\": true," +
			"        \"_textFirst\": \"Tomato\"," +
			"        \"_showSecond\": true," +
			"        \"_textSecond\": \"Gnome\"," +
			"        \"_showThird\": true," +
			"        \"_textThird\": \"A strangled prisoner\"," +
			"        \"next\": {" +
			"          \"$ref\": \"140\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"141\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"Demon\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"Think well cur… What is red with a green hat?\"," +
			"        \"next\": {" +
			"          \"$ref\": \"141\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"143\"" +
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
			"                        \"$ref\": \"143\"" +
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
			"                        \"$ref\": \"145\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"" +
			"                    }" +
			"                  ]," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                  \"$id\": \"151\"" +
			"                }," +
			"                \"controller\": null," +
			"                \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"              }" +
			"            ]," +
			"            \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"            \"$id\": \"148\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"," +
			"          \"$id\": \"147\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"145\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"151\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"148\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"$ref\": \"147\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"155\"" +
			"    }" +
			"  ]," +
			"  \"_root\": {" +
			"    \"$ref\": \"155\"" +
			"  }," +
			"  \"$type\": \"Assets.Event_Scripts.EventPipeWrapper\"" +
			"}");
		EventPipeWrapper wrapper = (EventPipeWrapper)data.Deserialize();
		rootPipe = wrapper._root;
		rootPipe.PropogateController(this);
	}
}

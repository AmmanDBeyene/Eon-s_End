using Unity.VisualScripting; using Assets.Event_Scripts;
public class RiddleDemonFull : EventController {
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
			"                                \"_name\": \"Demon\"," +
			"                                \"_portrait\": null," +
			"                                \"_positionLeft\": true," +
			"                                \"_text\": \"Think again, fool!\"," +
			"                                \"next\": {" +
			"                                  \"conditions\": [" +
			"                                    {" +
			"                                      \"_awaitedKey\": \"Z\"," +
			"                                      \"_pressed\": true," +
			"                                      \"next\": {" +
			"                                        \"command\": {" +
			"                                          \"next\": null," +
			"                                          \"controller\": null," +
			"                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.HideTextCommand\"" +
			"                                        }," +
			"                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                        \"$id\": \"20\"" +
			"                                      }," +
			"                                      \"controller\": null," +
			"                                      \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"," +
			"                                      \"$id\": \"19\"" +
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
			"                          \"$id\": \"28\"" +
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
			"                                \"_text\": \"Correct!\"," +
			"                                \"next\": {" +
			"                                  \"command\": {" +
			"                                    \"_name\": \"Demon\"," +
			"                                    \"_portrait\": null," +
			"                                    \"_positionLeft\": true," +
			"                                    \"_text\": \"Tremble mortal! What is buried deep beneath the ground?\"," +
			"                                    \"next\": {" +
			"                                      \"command\": {" +
			"                                        \"_showFirst\": true," +
			"                                        \"_textFirst\": \"A Necropolis\"," +
			"                                        \"_showSecond\": true," +
			"                                        \"_textSecond\": \"Potatoes\"," +
			"                                        \"_showThird\": true," +
			"                                        \"_textThird\": \"Treasure\"," +
			"                                        \"next\": {" +
			"                                          \"command\": {" +
			"                                            \"_optionToSelect\": \"Option 1\"," +
			"                                            \"next\": {" +
			"                                              \"conditions\": [" +
			"                                                {" +
			"                                                  \"_awaitedKey\": \"S\"," +
			"                                                  \"_pressed\": true," +
			"                                                  \"next\": {" +
			"                                                    \"command\": {" +
			"                                                      \"_optionToSelect\": \"Option 2\"," +
			"                                                      \"next\": {" +
			"                                                        \"conditions\": [" +
			"                                                          {" +
			"                                                            \"_awaitedKey\": \"S\"," +
			"                                                            \"_pressed\": true," +
			"                                                            \"next\": {" +
			"                                                              \"command\": {" +
			"                                                                \"_optionToSelect\": \"Option 3\"," +
			"                                                                \"next\": {" +
			"                                                                  \"conditions\": [" +
			"                                                                    {" +
			"                                                                      \"_awaitedKey\": \"W\"," +
			"                                                                      \"_pressed\": true," +
			"                                                                      \"next\": {" +
			"                                                                        \"command\": {" +
			"                                                                          \"$ref\": \"44\"" +
			"                                                                        }," +
			"                                                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                        \"$id\": \"53\"" +
			"                                                                      }," +
			"                                                                      \"controller\": null," +
			"                                                                      \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                                                    }," +
			"                                                                    {" +
			"                                                                      \"_awaitedKey\": \"Z\"," +
			"                                                                      \"_pressed\": true," +
			"                                                                      \"next\": {" +
			"                                                                        \"command\": {" +
			"                                                                          \"_showFirst\": false," +
			"                                                                          \"_textFirst\": \"option 1 text\"," +
			"                                                                          \"_showSecond\": false," +
			"                                                                          \"_textSecond\": \"\"," +
			"                                                                          \"_showThird\": false," +
			"                                                                          \"_textThird\": \"option 3 text\"," +
			"                                                                          \"next\": {" +
			"                                                                            \"command\": {" +
			"                                                                              \"_name\": \"Demon\"," +
			"                                                                              \"_portrait\": null," +
			"                                                                              \"_positionLeft\": true," +
			"                                                                              \"_text\": \"NOPE\"," +
			"                                                                              \"next\": {" +
			"                                                                                \"conditions\": [" +
			"                                                                                  {" +
			"                                                                                    \"_awaitedKey\": \"Z\"," +
			"                                                                                    \"_pressed\": true," +
			"                                                                                    \"next\": {" +
			"                                                                                      \"command\": {" +
			"                                                                                        \"next\": null," +
			"                                                                                        \"controller\": null," +
			"                                                                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.HideTextCommand\"" +
			"                                                                                      }," +
			"                                                                                      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                                      \"$id\": \"62\"" +
			"                                                                                    }," +
			"                                                                                    \"controller\": null," +
			"                                                                                    \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"," +
			"                                                                                    \"$id\": \"61\"" +
			"                                                                                  }" +
			"                                                                                ]," +
			"                                                                                \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                                                                \"$id\": \"59\"" +
			"                                                                              }," +
			"                                                                              \"controller\": null," +
			"                                                                              \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                                                            }," +
			"                                                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                            \"$id\": \"57\"" +
			"                                                                          }," +
			"                                                                          \"controller\": null," +
			"                                                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                                                                        }," +
			"                                                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                        \"$id\": \"55\"" +
			"                                                                      }," +
			"                                                                      \"controller\": null," +
			"                                                                      \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                                                    }" +
			"                                                                  ]," +
			"                                                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                                                  \"$id\": \"50\"" +
			"                                                                }," +
			"                                                                \"controller\": null," +
			"                                                                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"" +
			"                                                              }," +
			"                                                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                              \"$id\": \"48\"" +
			"                                                            }," +
			"                                                            \"controller\": null," +
			"                                                            \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                                          }," +
			"                                                          {" +
			"                                                            \"_awaitedKey\": \"W\"," +
			"                                                            \"_pressed\": true," +
			"                                                            \"next\": {" +
			"                                                              \"command\": {" +
			"                                                                \"$ref\": \"39\"" +
			"                                                              }," +
			"                                                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                              \"$id\": \"65\"" +
			"                                                            }," +
			"                                                            \"controller\": null," +
			"                                                            \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                                          }," +
			"                                                          {" +
			"                                                            \"_awaitedKey\": \"Z\"," +
			"                                                            \"_pressed\": true," +
			"                                                            \"next\": {" +
			"                                                              \"command\": {" +
			"                                                                \"_showFirst\": false," +
			"                                                                \"_textFirst\": \"option 1 text\"," +
			"                                                                \"_showSecond\": false," +
			"                                                                \"_textSecond\": \"option 2 text\"," +
			"                                                                \"_showThird\": false," +
			"                                                                \"_textThird\": \"option 3 text\"," +
			"                                                                \"next\": {" +
			"                                                                  \"command\": {" +
			"                                                                    \"_name\": \"Demon\"," +
			"                                                                    \"_portrait\": null," +
			"                                                                    \"_positionLeft\": true," +
			"                                                                    \"_text\": \"Correct!\"," +
			"                                                                    \"next\": {" +
			"                                                                      \"command\": {" +
			"                                                                        \"_name\": \"Demon\"," +
			"                                                                        \"_portrait\": null," +
			"                                                                        \"_positionLeft\": true," +
			"                                                                        \"_text\": \"YOU FOOL! What is stingy but carries sweet stuff?\"," +
			"                                                                        \"next\": {" +
			"                                                                          \"command\": {" +
			"                                                                            \"_showFirst\": true," +
			"                                                                            \"_textFirst\": \"A Succubus\"," +
			"                                                                            \"_showSecond\": true," +
			"                                                                            \"_textSecond\": \"Death\"," +
			"                                                                            \"_showThird\": true," +
			"                                                                            \"_textThird\": \"Bees\"," +
			"                                                                            \"next\": {" +
			"                                                                              \"command\": {" +
			"                                                                                \"_optionToSelect\": \"Option 1\"," +
			"                                                                                \"next\": {" +
			"                                                                                  \"conditions\": [" +
			"                                                                                    {" +
			"                                                                                      \"_awaitedKey\": \"S\"," +
			"                                                                                      \"_pressed\": true," +
			"                                                                                      \"next\": {" +
			"                                                                                        \"command\": {" +
			"                                                                                          \"_optionToSelect\": \"Option 2\"," +
			"                                                                                          \"next\": {" +
			"                                                                                            \"conditions\": [" +
			"                                                                                              {" +
			"                                                                                                \"_awaitedKey\": \"S\"," +
			"                                                                                                \"_pressed\": true," +
			"                                                                                                \"next\": {" +
			"                                                                                                  \"command\": {" +
			"                                                                                                    \"_optionToSelect\": \"Option 3\"," +
			"                                                                                                    \"next\": {" +
			"                                                                                                      \"conditions\": [" +
			"                                                                                                        {" +
			"                                                                                                          \"_awaitedKey\": \"W\"," +
			"                                                                                                          \"_pressed\": true," +
			"                                                                                                          \"next\": {" +
			"                                                                                                            \"command\": {" +
			"                                                                                                              \"$ref\": \"81\"" +
			"                                                                                                            }," +
			"                                                                                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                                                            \"$id\": \"90\"" +
			"                                                                                                          }," +
			"                                                                                                          \"controller\": null," +
			"                                                                                                          \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                                                                                        }," +
			"                                                                                                        {" +
			"                                                                                                          \"_awaitedKey\": \"Z\"," +
			"                                                                                                          \"_pressed\": true," +
			"                                                                                                          \"next\": {" +
			"                                                                                                            \"command\": {" +
			"                                                                                                              \"_showFirst\": false," +
			"                                                                                                              \"_textFirst\": \"option 1 text\"," +
			"                                                                                                              \"_showSecond\": false," +
			"                                                                                                              \"_textSecond\": \"\"," +
			"                                                                                                              \"_showThird\": false," +
			"                                                                                                              \"_textThird\": \"option 3 text\"," +
			"                                                                                                              \"next\": {" +
			"                                                                                                                \"command\": {" +
			"                                                                                                                  \"_name\": \"Demon\"," +
			"                                                                                                                  \"_portrait\": null," +
			"                                                                                                                  \"_positionLeft\": true," +
			"                                                                                                                  \"_text\": \"Correct!\"," +
			"                                                                                                                  \"next\": {" +
			"                                                                                                                    \"conditions\": [" +
			"                                                                                                                      {" +
			"                                                                                                                        \"_awaitedKey\": \"Z\"," +
			"                                                                                                                        \"_pressed\": true," +
			"                                                                                                                        \"next\": {" +
			"                                                                                                                          \"command\": {" +
			"                                                                                                                            \"next\": null," +
			"                                                                                                                            \"controller\": null," +
			"                                                                                                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.HideTextCommand\"" +
			"                                                                                                                          }," +
			"                                                                                                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                                                                          \"$id\": \"99\"" +
			"                                                                                                                        }," +
			"                                                                                                                        \"controller\": null," +
			"                                                                                                                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"," +
			"                                                                                                                        \"$id\": \"98\"" +
			"                                                                                                                      }" +
			"                                                                                                                    ]," +
			"                                                                                                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                                                                                                    \"$id\": \"96\"" +
			"                                                                                                                  }," +
			"                                                                                                                  \"controller\": null," +
			"                                                                                                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                                                                                                }," +
			"                                                                                                                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                                                                \"$id\": \"94\"" +
			"                                                                                                              }," +
			"                                                                                                              \"controller\": null," +
			"                                                                                                              \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                                                                                                            }," +
			"                                                                                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                                                            \"$id\": \"92\"" +
			"                                                                                                          }," +
			"                                                                                                          \"controller\": null," +
			"                                                                                                          \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                                                                                        }" +
			"                                                                                                      ]," +
			"                                                                                                      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                                                                                      \"$id\": \"87\"" +
			"                                                                                                    }," +
			"                                                                                                    \"controller\": null," +
			"                                                                                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"" +
			"                                                                                                  }," +
			"                                                                                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                                                  \"$id\": \"85\"" +
			"                                                                                                }," +
			"                                                                                                \"controller\": null," +
			"                                                                                                \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                                                                              }," +
			"                                                                                              {" +
			"                                                                                                \"_awaitedKey\": \"W\"," +
			"                                                                                                \"_pressed\": true," +
			"                                                                                                \"next\": {" +
			"                                                                                                  \"command\": {" +
			"                                                                                                    \"$ref\": \"76\"" +
			"                                                                                                  }," +
			"                                                                                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                                                  \"$id\": \"102\"" +
			"                                                                                                }," +
			"                                                                                                \"controller\": null," +
			"                                                                                                \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                                                                              }," +
			"                                                                                              {" +
			"                                                                                                \"_awaitedKey\": \"Z\"," +
			"                                                                                                \"_pressed\": true," +
			"                                                                                                \"next\": {" +
			"                                                                                                  \"command\": {" +
			"                                                                                                    \"_showFirst\": false," +
			"                                                                                                    \"_textFirst\": \"option 1 text\"," +
			"                                                                                                    \"_showSecond\": false," +
			"                                                                                                    \"_textSecond\": \"option 2 text\"," +
			"                                                                                                    \"_showThird\": false," +
			"                                                                                                    \"_textThird\": \"option 3 text\"," +
			"                                                                                                    \"next\": {" +
			"                                                                                                      \"command\": {" +
			"                                                                                                        \"_name\": \"Demon\"," +
			"                                                                                                        \"_portrait\": null," +
			"                                                                                                        \"_positionLeft\": true," +
			"                                                                                                        \"_text\": \"DELUSIONAL!\"," +
			"                                                                                                        \"next\": {" +
			"                                                                                                          \"conditions\": [" +
			"                                                                                                            {" +
			"                                                                                                              \"$ref\": \"98\"" +
			"                                                                                                            }" +
			"                                                                                                          ]," +
			"                                                                                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                                                                                          \"$id\": \"108\"" +
			"                                                                                                        }," +
			"                                                                                                        \"controller\": null," +
			"                                                                                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                                                                                      }," +
			"                                                                                                      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                                                      \"$id\": \"106\"" +
			"                                                                                                    }," +
			"                                                                                                    \"controller\": null," +
			"                                                                                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                                                                                                  }," +
			"                                                                                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                                                  \"$id\": \"104\"" +
			"                                                                                                }," +
			"                                                                                                \"controller\": null," +
			"                                                                                                \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                                                                              }" +
			"                                                                                            ]," +
			"                                                                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                                                                            \"$id\": \"82\"" +
			"                                                                                          }," +
			"                                                                                          \"controller\": null," +
			"                                                                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"                                                                                          \"$id\": \"81\"" +
			"                                                                                        }," +
			"                                                                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                                        \"$id\": \"80\"" +
			"                                                                                      }," +
			"                                                                                      \"controller\": null," +
			"                                                                                      \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                                                                    }," +
			"                                                                                    {" +
			"                                                                                      \"_awaitedKey\": \"Z\"," +
			"                                                                                      \"_pressed\": true," +
			"                                                                                      \"next\": {" +
			"                                                                                        \"command\": {" +
			"                                                                                          \"_showFirst\": false," +
			"                                                                                          \"_textFirst\": \"option 1 text\"," +
			"                                                                                          \"_showSecond\": false," +
			"                                                                                          \"_textSecond\": \"option 2 text\"," +
			"                                                                                          \"_showThird\": false," +
			"                                                                                          \"_textThird\": \"option 3 text\"," +
			"                                                                                          \"next\": {" +
			"                                                                                            \"command\": {" +
			"                                                                                              \"_name\": \"Demon\"," +
			"                                                                                              \"_portrait\": null," +
			"                                                                                              \"_positionLeft\": true," +
			"                                                                                              \"_text\": \"HA! No.\"," +
			"                                                                                              \"next\": {" +
			"                                                                                                \"conditions\": [" +
			"                                                                                                  {" +
			"                                                                                                    \"$ref\": \"98\"" +
			"                                                                                                  }" +
			"                                                                                                ]," +
			"                                                                                                \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                                                                                \"$id\": \"115\"" +
			"                                                                                              }," +
			"                                                                                              \"controller\": null," +
			"                                                                                              \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                                                                            }," +
			"                                                                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                                            \"$id\": \"113\"" +
			"                                                                                          }," +
			"                                                                                          \"controller\": null," +
			"                                                                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                                                                                        }," +
			"                                                                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                                        \"$id\": \"111\"" +
			"                                                                                      }," +
			"                                                                                      \"controller\": null," +
			"                                                                                      \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                                                                    }" +
			"                                                                                  ]," +
			"                                                                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                                                                  \"$id\": \"77\"" +
			"                                                                                }," +
			"                                                                                \"controller\": null," +
			"                                                                                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"                                                                                \"$id\": \"76\"" +
			"                                                                              }," +
			"                                                                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                              \"$id\": \"75\"" +
			"                                                                            }," +
			"                                                                            \"controller\": null," +
			"                                                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                                                                          }," +
			"                                                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                          \"$id\": \"73\"" +
			"                                                                        }," +
			"                                                                        \"controller\": null," +
			"                                                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                                                      }," +
			"                                                                      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                      \"$id\": \"71\"" +
			"                                                                    }," +
			"                                                                    \"controller\": null," +
			"                                                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                                                  }," +
			"                                                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                                  \"$id\": \"69\"" +
			"                                                                }," +
			"                                                                \"controller\": null," +
			"                                                                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                                                              }," +
			"                                                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                              \"$id\": \"67\"" +
			"                                                            }," +
			"                                                            \"controller\": null," +
			"                                                            \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                                          }" +
			"                                                        ]," +
			"                                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                                        \"$id\": \"45\"" +
			"                                                      }," +
			"                                                      \"controller\": null," +
			"                                                      \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"                                                      \"$id\": \"44\"" +
			"                                                    }," +
			"                                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                    \"$id\": \"43\"" +
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
			"                                                      \"_textSecond\": \"option 2 text\"," +
			"                                                      \"_showThird\": false," +
			"                                                      \"_textThird\": \"option 3 text\"," +
			"                                                      \"next\": {" +
			"                                                        \"command\": {" +
			"                                                          \"_name\": \"Demon\"," +
			"                                                          \"_portrait\": null," +
			"                                                          \"_positionLeft\": true," +
			"                                                          \"_text\": \"Ugh, WRONG.\"," +
			"                                                          \"next\": {" +
			"                                                            \"conditions\": [" +
			"                                                              {" +
			"                                                                \"$ref\": \"61\"" +
			"                                                              }" +
			"                                                            ]," +
			"                                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                                            \"$id\": \"122\"" +
			"                                                          }," +
			"                                                          \"controller\": null," +
			"                                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                                        }," +
			"                                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                        \"$id\": \"120\"" +
			"                                                      }," +
			"                                                      \"controller\": null," +
			"                                                      \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                                                    }," +
			"                                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                                    \"$id\": \"118\"" +
			"                                                  }," +
			"                                                  \"controller\": null," +
			"                                                  \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                                                }" +
			"                                              ]," +
			"                                              \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                                              \"$id\": \"40\"" +
			"                                            }," +
			"                                            \"controller\": null," +
			"                                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"                                            \"$id\": \"39\"" +
			"                                          }," +
			"                                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                          \"$id\": \"38\"" +
			"                                        }," +
			"                                        \"controller\": null," +
			"                                        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                                      }," +
			"                                      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                      \"$id\": \"36\"" +
			"                                    }," +
			"                                    \"controller\": null," +
			"                                    \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                                  }," +
			"                                  \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                                  \"$id\": \"34\"" +
			"                                }," +
			"                                \"controller\": null," +
			"                                \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                              }," +
			"                              \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                              \"$id\": \"32\"" +
			"                            }," +
			"                            \"controller\": null," +
			"                            \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                          }," +
			"                          \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                          \"$id\": \"30\"" +
			"                        }," +
			"                        \"controller\": null," +
			"                        \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"                      }" +
			"                    ]," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                    \"$id\": \"25\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.SelectOptionCommand\"," +
			"                  \"$id\": \"24\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"23\"" +
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
			"                      \"_text\": \"Wrong, mortal!\"," +
			"                      \"next\": {" +
			"                        \"conditions\": [" +
			"                          {" +
			"                            \"$ref\": \"19\"" +
			"                          }" +
			"                        ]," +
			"                        \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                        \"$id\": \"129\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"                    }," +
			"                    \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                    \"$id\": \"127\"" +
			"                  }," +
			"                  \"controller\": null," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"                }," +
			"                \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"                \"$id\": \"125\"" +
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
			"      \"$ref\": \"23\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"129\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"127\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"125\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"4\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"28\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"53\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"62\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"59\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"57\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"55\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"50\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"48\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"65\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"90\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"99\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"96\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"94\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"92\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"87\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"85\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"102\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"108\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"106\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"104\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"82\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"80\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"115\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"113\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"111\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"77\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"75\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"73\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"71\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"69\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"67\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"45\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"43\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"122\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"120\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"118\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"40\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"38\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"36\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"34\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"32\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"30\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"25\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"$ref\": \"24\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"131\"" +
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
			"          \"$ref\": \"131\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowOptionCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"132\"" +
			"    }," +
			"    {" +
			"      \"command\": {" +
			"        \"_name\": \"Demon\"," +
			"        \"_portrait\": null," +
			"        \"_positionLeft\": true," +
			"        \"_text\": \"Think well cur… What is red with a green hat?\"," +
			"        \"next\": {" +
			"          \"$ref\": \"132\"" +
			"        }," +
			"        \"controller\": null," +
			"        \"$type\": \"Assets.Event_Editor.Event_Scripts.Commands.ShowTextCommand\"" +
			"      }," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.CommandPipeSystem\"," +
			"      \"$id\": \"134\"" +
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
			"                        \"$ref\": \"134\"" +
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
			"                        \"$ref\": \"136\"" +
			"                      }," +
			"                      \"controller\": null," +
			"                      \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"" +
			"                    }" +
			"                  ]," +
			"                  \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"                  \"$id\": \"142\"" +
			"                }," +
			"                \"controller\": null," +
			"                \"$type\": \"Assets.Event_Scripts.Conditions.InputCondition\"" +
			"              }" +
			"            ]," +
			"            \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"            \"$id\": \"139\"" +
			"          }," +
			"          \"controller\": null," +
			"          \"$type\": \"Assets.Event_Scripts.Conditions.ProximityCondition\"," +
			"          \"$id\": \"138\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"136\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"142\"" +
			"    }," +
			"    {" +
			"      \"$ref\": \"139\"" +
			"    }," +
			"    {" +
			"      \"conditions\": [" +
			"        {" +
			"          \"$ref\": \"138\"" +
			"        }" +
			"      ]," +
			"      \"$type\": \"Assets.Event_Editor.Event_Scripts.ConditionPipeSystem\"," +
			"      \"$id\": \"146\"" +
			"    }" +
			"  ]," +
			"  \"_root\": {" +
			"    \"$ref\": \"146\"" +
			"  }," +
			"  \"$type\": \"Assets.Event_Scripts.EventPipeWrapper\"" +
			"}");
		EventPipeWrapper wrapper = (EventPipeWrapper)data.Deserialize();
		rootPipe = wrapper._root;
		rootPipe.PropogateController(this);
	}
}

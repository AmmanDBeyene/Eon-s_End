using EECore;
using EECore.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public string characterName;
    public string className = "";
    public bool combat = false;
    private Character character;
    public GameObject targetBox;
    public GameObject characterVisualPrefab;

    void Start()
    {
        if (className == "")
        {
            className = characterName;
        }
        if (CombatManager.targetBox == null)
        {
            CombatManager.targetBox = targetBox;
        }
        
        Instantiate(characterVisualPrefab, transform.position, Quaternion.identity, transform);  
        
        Load();
    }

    private void Load()
    {
        character = GameStateManager.InParty(characterName)
            ? GameStateManager.GetCharacter(characterName)
            : (Character)Activator.CreateInstance(Type.GetType($"EECore.Characters.{className}"));
        
        if (combat)
        {
            CombatManager.AddCombatant(character, gameObject);
        }
    }
}

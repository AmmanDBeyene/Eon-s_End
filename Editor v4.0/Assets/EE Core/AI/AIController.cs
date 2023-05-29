using EECore.AI.Modules;
using EECore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public int AIModuleLevel = 0;
    private AIModule module = null;

    // Start is called before the first frame update
    void Start()
    {
        module = new AIZero();
    }

    // Update is called once per frame
    void Update()
    {
        if (CombatManager.uiMode == "start-cpu-turn")
        {
            // combat manager is waiting for the cpu to make its turn
            StartCoroutine(Routine());
        }
    }

    private IEnumerator Routine()
    {
        StartTurn();
        CollectData();
        yield return module.DoTurn(CombatManager.CurrentCombatant());
        yield return new WaitForSeconds(0.5f);
        FinishTurn();
        yield return null;
    }

    private void CollectData()
    {
        // this method does not do much at the moment but in the future it should collect
        // required battlefield data
    }
    
    private void StartTurn()
    {
        CombatManager.uiMode = "working-cpu-turn";
    }

    private void FinishTurn()
    {
        CombatManager.uiMode = "finish-cpu-turn";
    }
}

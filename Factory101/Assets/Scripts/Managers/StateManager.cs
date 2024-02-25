using System;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public List<StateSO> states = new List<StateSO>();

    private StateSO idleState;
    //Our current state should be equal to Idle as default. 
    public StateSO currentState;

    private void Start()
    {
        idleState = currentState;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var state in states)
        {
            if (Input.GetKeyDown(state.key))
            {
                ChangeState(state);
            }
        }
    }

    private void ChangeState(StateSO state)
    {
        currentState.Deactivated();
        if (currentState != state)
        {
            currentState = state;
            currentState.Activated();
        }
        else
        {
            currentState = idleState;
        }
    }
}

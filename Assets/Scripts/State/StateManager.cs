using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public IdleState Idle;
    public MoveState Move;
    public JumpState Jump;
    public FallState Fall;
    public KnockbackState Knockback;
    

    public void SetupStates(PlayerController agent)
    {
        foreach (var state in GetComponentsInChildren<State>())
        {
            state.InitializeState(agent);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected PlayerController player;
    public void InitializeState(PlayerController pc)
    {
        this.player = pc;
    }

    public void Enter()
    {
        player.Input.OnPlayerMove += OnPlayerMove;
        player.Input.OnPlayerJump += OnPlayerJump;
        OnEnterState();
    }


    public void Exit() 
    {
        player.Input.OnPlayerMove -= OnPlayerMove;
        player.Input.OnPlayerJump -= OnPlayerJump;
        OnExitState();
    }

    protected virtual void OnEnterState()
    { 
    
    }

    public virtual void StateUpdate()
    {
        FallTransition();
    }

    protected virtual void OnExitState()
    { 
    
    }
    protected virtual void OnPlayerJump()
    {
        if (player.IsGrounded)
        {
            player.TransitionToState(player.stateManager.Jump);
        }
    }
    private void FallTransition()
    {
        if (!player.IsGrounded)
        {
            player.TransitionToState(player.stateManager.Fall);
        }
    }
    protected virtual void OnPlayerMove(Vector2 vector)
    {

    }

    [Serializable]
    public class MovementData
    {
        public float horizontalMovementDirection;
        public float currentSpeed;
        public Vector2 currentVelocity;
    }
}

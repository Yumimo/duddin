using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : MoveState
{
    public float fallGravityModifier = 10;
    protected override void OnEnterState()
    {
        player.Animation.Fall();
    }
    public override void StateUpdate()
    {
        movementData.currentVelocity = player.rigidbody2D.velocity;
        movementData.currentVelocity.y += (fallGravityModifier * Physics2D.gravity.y) * Time.deltaTime;
        player.rigidbody2D.velocity = movementData.currentVelocity;


        Move(speed);
        if (player.IsGrounded)
        {
            player.TransitionToState(player.stateManager.Idle);
        }
    }
    protected override void OnPlayerJump()
    {
       
    }
}

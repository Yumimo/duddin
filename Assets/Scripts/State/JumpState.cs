using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : MoveState
{
    public float jumpHeight = 10;
    protected override void OnEnterState()
    {
        player.Animation.Jump();
        Jump();
    }

    public override void StateUpdate()
    {
        if (player.rigidbody2D.velocity.y < 0)
        {
            player.TransitionToState(player.stateManager.Fall);
            return;
        }
        Move(speed);
    }
    private void Jump()
    {
       // player.rigidbody2D.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        movementData.currentVelocity = player.rigidbody2D.velocity;
        var _jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * player.rigidbody2D.gravityScale) * -2) * player.rigidbody2D.mass;
        movementData.currentVelocity.y = _jumpForce;
        player.rigidbody2D.velocity = movementData.currentVelocity;
    }

    protected override void OnPlayerJump()
    {
        
    }
    protected override void OnExitState() 
    {
    
    }
}

using System;
using UnityEngine;

public class MoveState : State
{
    public State.MovementData movementData;
    public float speed = 5f;
    public float acceleration = 0.1f;
    public float decceleration = 10f;
    protected override void OnEnterState()
    {
        player.Animation.Run();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        Move(speed);
        if (Mathf.Approximately(player.rigidbody2D.velocity.x, 0))
        {
            player.TransitionToState(player.stateManager.Idle);
        }
    }

    public void Move(float speed)
    {
        var _agentInput = player.Input.MovementInput;
        HorizontalDirection(_agentInput);
        ComputeSpeed(_agentInput, speed);

        movementData.currentVelocity = Vector2.right * movementData.horizontalMovementDirection * movementData.currentSpeed;
        movementData.currentVelocity.y = player.rigidbody2D.velocity.y;
        player.rigidbody2D.velocity = movementData.currentVelocity;
    }

    protected void ComputeSpeed(Vector2 _agentInput, float speed)
    {
        if (Mathf.Abs(_agentInput.x) > 0)
        {
            movementData.currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            movementData.currentSpeed -= decceleration * Time.deltaTime;
        }

        movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0, speed);

    }

    protected void HorizontalDirection(Vector2 _agentInput)
    {
        movementData.horizontalMovementDirection = _agentInput.x switch
        {
            > 0 => 1,
            < 0 => -1,
            _ => movementData.horizontalMovementDirection
        };
    }
}

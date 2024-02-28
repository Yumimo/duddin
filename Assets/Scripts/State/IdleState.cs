
using UnityEngine;

public class IdleState : State
{
    protected override void OnEnterState()
    {
        player.rigidbody2D.velocity = Vector2.zero;
        player.Animation.Idle();
    }
    protected override void OnPlayerMove(Vector2 vector)
    {
        if (Mathf.Abs(vector.x) > 0)
        {
            player.TransitionToState(player.stateManager.Move);
        }
    }

    protected override void OnExitState()
    {

    }
}

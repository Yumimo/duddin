using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackState : State
{
    public float knockbackTime = 1.5f;
    public float knockbackForce = 5f;
    protected override void OnEnterState()
    {
        player.Input.HoldInput = true;
        player.Animation.Hurt();
        player.rigidbody2D.AddForce(-Vector2.right * knockbackForce, ForceMode2D.Impulse);
        Invoke(nameof(StopKnockback), knockbackTime);
    }

    private void StopKnockback()
    {
        player.TransitionToState(player.stateManager.Idle);
    }
    public override void StateUpdate()
    {
       
    }
    protected override void OnExitState()
    {
        player.Input.HoldInput = false;
    }
}

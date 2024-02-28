using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Action OnPlayerJump;
    public bool HoldInput;
    public Action<Vector2> OnPlayerMove;

    public Vector2 MovementInput;
    public bl_Joystick joyStick;
    private void Update()
    {
        JumpInput();
        MovementInput = new Vector2(joyStick.Horizontal, Input.GetAxisRaw("Vertical"));
        MoveHorizontal(MovementInput);
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (HoldInput) return;
            Jump();
        }    
    }

    private void MoveHorizontal(Vector2 movement)
    {
        if (HoldInput) return;
        OnPlayerMove?.Invoke(movement);
    }

    public void Jump()
    { 
        OnPlayerJump?.Invoke();
    }
    
}

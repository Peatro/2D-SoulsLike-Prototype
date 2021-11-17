using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }

    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool LightAttackInput { get; private set; }
    public bool HeavyAttackInput { get; private set; }

    public void OnMoveinput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            JumpInput = true;
        }
        if(context.canceled)
        {
            JumpInput = false;
        }
    }

    public void OnLightAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            LightAttackInput = true;
        }
        if (context.canceled)
        {
            LightAttackInput = false;
        }            
    }
    public void OnHeavyAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            HeavyAttackInput = true;
        }
        if (context.canceled)
        {
            HeavyAttackInput = false;
        }
    }

    public void UseJumpInput() => JumpInput = false;
}

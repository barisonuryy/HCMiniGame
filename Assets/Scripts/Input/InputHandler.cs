using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : IInputHandler
{
    private PlayerController inputActions;

    public InputHandler()
    {
        inputActions = new PlayerController();
        inputActions.Player.Enable();
    }

    public Vector2 GetMovementInput()
    {
        return inputActions.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetLookInput()
    {
        return inputActions.Player.Look.ReadValue<Vector2>();
    }
}

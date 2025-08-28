using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private InputActions inputActions;

    private void Awake()
    {
        Instance = this;

        inputActions = new InputActions();
        inputActions.Enable();
    }

    private void Update()
    {
        if (GameManager.Instance.GetIsJackCrashed())
        {
            inputActions.Disable();
        }
    }

    public bool IsJetThrustPressed()
    {
        return inputActions.Player.JetThrust.IsPressed();
    }
}
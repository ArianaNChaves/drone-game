using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReaderDrone : MonoBehaviour,  InputDrone.IFlyingActions
{
    public event Action<bool> IsGrabbingEvent;
    public event Action<bool> IsSprintingEvent;
    private InputDrone _inputDrone;
    private Vector3 _movementValue;
    private float _upValue;
    private float _downValue;
    private bool _isGrabbing;
    
    private void Start()
    {
        _inputDrone = new InputDrone();
        _inputDrone.Flying.SetCallbacks(this);
        _inputDrone.Flying.Enable();
    }
    
    public void OnMovement(InputAction.CallbackContext context)
    {
        _movementValue = context.ReadValue<Vector3>();
    }

    public void OnGrab(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _isGrabbing = !_isGrabbing;
            IsGrabbingEvent?.Invoke(_isGrabbing);
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsSprintingEvent?.Invoke(true);
        }
        else if (context.canceled)
        {
            IsSprintingEvent?.Invoke(false);
        }
    }

    public Vector3 GetMovementValue()
    {
        return _movementValue;
    }
}

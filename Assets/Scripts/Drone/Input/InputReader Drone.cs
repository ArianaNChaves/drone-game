using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReaderDrone : MonoBehaviour,  InputDrone.IFlyingActions
{
    public event Action<bool> isGrabbingEvent;
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
            Debug.Log("APRETE BOTON");
            _isGrabbing = !_isGrabbing;
            isGrabbingEvent?.Invoke(_isGrabbing);
        }
    }

    public Vector3 GetMovementValue()
    {
        return _movementValue;
    }
}

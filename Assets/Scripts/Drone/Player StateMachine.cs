using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStateMachine : StateMachine
{
    
    [SerializeField] public InputReaderDrone inputReader;
    [SerializeField] public Collider playerCollider;
    [SerializeField] public Rigidbody playerRigidbody;
    [SerializeField] public GameObject model;
    [SerializeField] public Camera mainCamera;
    
    
    [Header("Data")]
    [SerializeField] public float baseMoveSpeed;
    [SerializeField] public float sprintMoveSpeed;
    [SerializeField] public float force;
    [SerializeField] public float rotationSpeed;
    [SerializeField] public float rotationAngle;


    private void Start()
    {
        SwitchState(new MoveState(this));
    }
}

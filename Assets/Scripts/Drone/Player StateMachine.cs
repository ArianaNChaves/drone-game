using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStateMachine : StateMachine
{
    
    [SerializeField] public InputReaderDrone inputReader;
    [SerializeField] public CharacterController controller;
    
    [Header("Data")]
    [SerializeField] public float baseMoveSpeed;
    [SerializeField] public float sprintMoveSpeed;
    [SerializeField] public float accelerationTime;
    [SerializeField] public float relentizationTime;
    [SerializeField] public float rotationSpeed;
    [SerializeField] public float gravity;


    private void Start()
    {
        SwitchState(new MoveState(this));
    }
}

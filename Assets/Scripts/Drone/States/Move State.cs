using UnityEngine;

public class MoveState : PlayerBaseState
{
    
    private bool _isSprinting;
    public MoveState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.inputReader.IsSprintingEvent += IsSprinting;
    }
    

    public override void Tick(float deltaTime)
    {

        RotateModel(deltaTime);
        RotateTowardsCamera(deltaTime);
        
    }

    public override void Exit()
    {
        stateMachine.inputReader.IsSprintingEvent -= IsSprinting;
    }

    private void Move(Vector3 direction)
    {
        if (direction.sqrMagnitude > 0f)
        {
            stateMachine.playerRigidbody.AddForce(direction.normalized * stateMachine.force, ForceMode.Acceleration);
        }
        
        if (stateMachine.playerRigidbody.linearVelocity.magnitude > stateMachine.baseMoveSpeed)
        {
            if (_isSprinting)
            {
                
                stateMachine.playerRigidbody.linearVelocity = stateMachine.playerRigidbody.linearVelocity.normalized * stateMachine.sprintMoveSpeed;
            }
            else
            {
                stateMachine.playerRigidbody.linearVelocity = stateMachine.playerRigidbody.linearVelocity.normalized * stateMachine.baseMoveSpeed;
            }
        }
    }
    
    
    private void IsSprinting(bool obj)
    {
        _isSprinting = obj;
    }

    private void RotateModel(float deltaTime)
    {
        float maxRotationAngle = stateMachine.rotationAngle;

        Vector3 input = stateMachine.inputReader.GetMovementValue();

        float pitch = input.z * maxRotationAngle;
        float roll = -input.x * maxRotationAngle;

        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);

        stateMachine.model.transform.localRotation = Quaternion.RotateTowards(stateMachine.model.transform.localRotation, targetRotation, stateMachine.rotationSpeed * deltaTime);
    }

    private void RotateTowardsCamera(float deltaTime)
    {
        Vector3 input = stateMachine.inputReader.GetMovementValue();

        Transform cameraTransform = Camera.main.transform;

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 direction = forward * input.z + right * input.x + Vector3.up * input.y;

        if (direction.sqrMagnitude <= 0f)
        {
            return;
        }

        Vector3 horizontalDirection = new Vector3(direction.x, 0f, direction.z);

        if (horizontalDirection.sqrMagnitude > 0f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(horizontalDirection);

            stateMachine.playerRigidbody.MoveRotation(Quaternion.RotateTowards(stateMachine.playerRigidbody.rotation, targetRotation, stateMachine.rotationSpeed * deltaTime));
        }
        Move(direction);
    }
}

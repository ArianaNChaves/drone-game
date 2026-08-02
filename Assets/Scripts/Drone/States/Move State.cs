using UnityEngine;

public class MoveState : PlayerBaseState
{
    private float _currentMoveSpeed;
    private Vector3 _currentMoveDirection;

    public MoveState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        
    }

    public override void Enter()
    {
        _currentMoveSpeed = stateMachine.baseMoveSpeed;
        _currentMoveDirection = Vector3.zero;
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);
    }

    public override void Exit()
    {
        
    }

    private void Move(float deltaTime)
    {
        Vector3 input = stateMachine.inputReader.GetMovementValue();
        // float acceleration = (stateMachine.sprintMoveSpeed - stateMachine.baseMoveSpeed) / stateMachine.accelerationTime;

        if (input.sqrMagnitude > 0f)
        {
            _currentMoveDirection = input.normalized;
            // _currentMoveSpeed = Mathf.Max(_currentMoveSpeed, stateMachine.baseMoveSpeed);
            _currentMoveSpeed = Mathf.MoveTowards(_currentMoveSpeed, stateMachine.sprintMoveSpeed,  stateMachine.accelerationTime * deltaTime);
        }
        else
        {
            _currentMoveSpeed = Mathf.MoveTowards(_currentMoveSpeed, 0f, stateMachine.relentizationTime * deltaTime);
        }
        
        stateMachine.controller.Move(_currentMoveDirection * (_currentMoveSpeed * deltaTime));
        
        Debug.Log(input);
    }
}

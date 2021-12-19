using System;
using UnityEngine;

namespace States
{
    public class MovementState : State
    {
        public MovementData movementData;
        public State idleState;

        public float acceleration, deacceleration, maxSpeed;

        private void Awake()
        {
            movementData = GetComponentInParent<MovementData>();
            ;
        }

        protected override void EnterState()
        {
            Agent.agentAnim.PlayAnimation(AnimationType.Run);
            movementData.horizontalMovementDirection = 0;
            movementData.currentSpeed = 0;
            movementData.currentVelocity = Vector2.zero;
        }

        public override void UpdateState()
        {
            base.UpdateState();
            CalculateVelocity();
            SetPlayerVelocity();
            if (Agent.IsInputValueEmpty()) Agent.TransitionToNextState(idleState, this);
        }

        private void SetPlayerVelocity()
        {
            Agent.rb.velocity = movementData.currentVelocity;
        }

        private void CalculateVelocity()
        {
            CalculateSpeed(Agent.AgentInput.MovementVector, movementData);
            CalculateHorizontalDirection(movementData);
            
            movementData.currentVelocity = Vector3.right * movementData.horizontalMovementDirection * movementData.currentSpeed;
            movementData.currentVelocity.y = Agent.rb.velocity.y;
        }

        private void CalculateHorizontalDirection(MovementData movementData)
        {
            if (Agent.AgentInput.MovementVector.x > 0) movementData.horizontalMovementDirection = 1;
            
            else if (Agent.AgentInput.MovementVector.x < 0) movementData.horizontalMovementDirection = -1;
            
        }

        private void CalculateSpeed(Vector2 movementVector, MovementData movementData)
        {
            if (Mathf.Abs(movementVector.x) > 0)
            {
                movementData.currentSpeed += acceleration * Time.deltaTime;
            }
            else
            {
                movementData.currentSpeed -= deacceleration * Time.deltaTime;
            }
            movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0, maxSpeed); // clamp speed with our max.
        }
    }
}
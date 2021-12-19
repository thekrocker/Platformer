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
        }

        protected override void EnterState()
        {
            Agent.agentAnim.PlayAnimation(AnimationType.Run);
            movementData.HorizontalMovementDirection = 0;
            movementData.CurrentSpeed = 0;
            movementData.CurrentVelocity = Vector2.zero;
        }

        public override void UpdateState()
        {
            base.UpdateState();
            CalculateVelocity();
            SetPlayerVelocity();
            if (Agent.IsInputValueEmpty()) Agent.TransitionToNextState(idleState);
        }

        private void SetPlayerVelocity()
        {
            Agent.rb.velocity = movementData.CurrentVelocity;
        }

        private void CalculateVelocity()
        {
            CalculateSpeed(Agent.AgentInput.MovementVector, movementData);
            CalculateHorizontalDirection(movementData);
            
            movementData.CurrentVelocity = Vector3.right * movementData.HorizontalMovementDirection * movementData.CurrentSpeed;
            movementData.CurrentVelocity.y = Agent.rb.velocity.y;
        }

        private void CalculateHorizontalDirection(MovementData movementData)
        {
            if (Agent.AgentInput.MovementVector.x > 0) movementData.HorizontalMovementDirection = 1;
            
            else if (Agent.AgentInput.MovementVector.x < 0) movementData.HorizontalMovementDirection = -1;
            
        }

        private void CalculateSpeed(Vector2 movementVector, MovementData movementData)
        {
            if (Mathf.Abs(movementVector.x) > 0)
            {
                movementData.CurrentSpeed += acceleration * Time.deltaTime;
            }
            else
            {
                movementData.CurrentSpeed -= deacceleration * Time.deltaTime;
            }
            movementData.CurrentSpeed = Mathf.Clamp(movementData.CurrentSpeed, 0, maxSpeed); // clamp speed with our max.
        }
    }
}
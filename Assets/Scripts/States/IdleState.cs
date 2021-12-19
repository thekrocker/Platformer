using UnityEngine;

namespace States
{
    public class IdleState : State
    {
        public State moveState;
        
        protected override void EnterState()
        {
            Agent.agentAnim.PlayAnimation(AnimationType.Idle);
        }

        protected override void HandleMovement(Vector2 input)
        {
            if (Mathf.Abs(input.x) > 0) Agent.TransitionToNextState(moveState, this); // Change to next state
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

namespace States
{
    public abstract class State : MonoBehaviour
    {
        [SerializeField] private UnityEvent onEnter;
        [SerializeField] private UnityEvent onExit;
        protected Agent Agent;

        public void InitializeState(Agent agent)
        {
            Agent = agent;
        }

        public void Enter()
        {
            Agent.AgentInput.OnAttack += HandleAttack;
            Agent.AgentInput.OnJumpPressed += HandleJumpPressed;
            Agent.AgentInput.OnJumpReleased += HandleJumpReleased;
            Agent.AgentInput.OnMovement += HandleMovement;
            onEnter?.Invoke();
            EnterState();
        }

        protected virtual void EnterState()
        {
           
        }

        protected virtual void HandleMovement(Vector2 input)
        {
            
        }

        protected virtual void HandleJumpReleased()
        {
            
        }

        protected virtual void HandleJumpPressed()
        {
           
        }

        protected virtual void HandleAttack()
        {
            
        }

        public virtual void UpdateState()
        {
            
        }

        public virtual void FixedUpdateState()
        {
            
        }

        public void Exit()
        {
            Agent.AgentInput.OnAttack -= HandleAttack;
            Agent.AgentInput.OnJumpPressed -= HandleJumpPressed;
            Agent.AgentInput.OnJumpReleased -= HandleJumpReleased;
            Agent.AgentInput.OnMovement -= HandleMovement;
            onExit?.Invoke();
            ExitState();
        }

        public virtual void ExitState()
        {
            
        }
    }
}

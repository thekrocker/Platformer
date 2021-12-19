using UnityEngine;
using UnityEngine.Events;

namespace States
{
    public abstract class State : MonoBehaviour
    {
        [SerializeField] private UnityEvent onEnter;
        [SerializeField] private UnityEvent onExit;
        private Agent _agent;

        public void InitializeState(Agent agent)
        {
            _agent = agent;
        }

        public void Enter()
        {
            _agent.AgentInput.OnAttack += HandleAttack;
            _agent.AgentInput.OnJumpPressed += HandleJumpPressed;
            _agent.AgentInput.OnJumpReleased += HandleJumpReleased;
            _agent.AgentInput.OnMovement += HandleMovement;
            onEnter?.Invoke();
            EnterState();
        }

        private void EnterState()
        {
           
        }

        protected virtual void HandleMovement(Vector2 obj)
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
            _agent.AgentInput.OnAttack -= HandleAttack;
            _agent.AgentInput.OnJumpPressed -= HandleJumpPressed;
            _agent.AgentInput.OnJumpReleased -= HandleJumpReleased;
            _agent.AgentInput.OnMovement -= HandleMovement;
            onExit?.Invoke();
            ExitState();
        }

        private void ExitState()
        {
            throw new System.NotImplementedException();
        }
    }
}

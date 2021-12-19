using System;
using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AgentRenderer agentRenderer; // for scale flip

    [SerializeField] private PlayerInput agentInput;
    public PlayerInput AgentInput
    {
        get => agentInput;
        set => agentInput = value;
    }

    public AgentAnimation agentAnim;
    
    
    private void Start()
    {
        AgentInput.OnMovement += HandleMovement;
        AgentInput.OnMovement += agentRenderer.HandleFlipDirection;
    }

    private void HandleMovement(Vector2 input)
    {
        if (Mathf.Abs(input.x) > 0)
        {
            if (IsInputValueEmpty()) agentAnim.PlayAnimation(AnimationType.Run);
            rb.velocity = new Vector2(input.x * 5, rb.velocity.y);
        }
        else
        {
            if (!IsInputValueEmpty()) agentAnim.PlayAnimation(AnimationType.Idle);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    #region Summary

    /// <summary>
    /// Checks if user moves.
    /// </summary>
    /// <param name=" "></param>
    /// <returns>Returns true if user is not moving</returns>

    #endregion
    internal bool IsInputValueEmpty()
    {
        return Mathf.Abs(rb.velocity.x) < 0.01f;
    }

    public void TransitionToNextState(State nextState, State callingState)
    {
        throw new NotImplementedException();
    }
}

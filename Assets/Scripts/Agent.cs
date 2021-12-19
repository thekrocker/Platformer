using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AgentAnimation agentAnim;
    [SerializeField] private AgentRenderer agentRenderer; // for scale flip

    [SerializeField] private PlayerInput agentInput;
    public PlayerInput AgentInput
    {
        get => agentInput;
        set => agentInput = value;
    }

    private void Start()
    {
        AgentInput.OnMovement += HandleMovement;
        AgentInput.OnMovement += agentRenderer.HandleFlipDirection;
    }

    private void HandleMovement(Vector2 input)
    {
        if (Mathf.Abs(input.x) > 0)
        {
            if (IsIdle()) agentAnim.PlayAnimation(AnimationType.Run);
            rb.velocity = new Vector2(input.x * 5, rb.velocity.y);
        }
        else
        {
            if (!IsIdle()) agentAnim.PlayAnimation(AnimationType.Idle);
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
    private bool IsIdle()
    {
        return Mathf.Abs(rb.velocity.x) < 0.01f;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private AgentRenderer agentRenderer; // for scale flip
    [SerializeField] private PlayerInput agentInput;

    public PlayerInput AgentInput
    {
        get => agentInput;
        set => agentInput = value;
    }

    public Rigidbody2D rb;
    public AgentAnimation agentAnim;

   
    [Header("State Debug")] 
    public string stateName = "";
    public State currentState = null, previousState = null;
    public State idleState;



    private void Awake()
    {
        State[] states = GetComponentsInChildren<State>();
        foreach (State state in states) state.InitializeState(this);
    }

    private void Start()
    {
        AgentInput.OnMovement += agentRenderer.HandleFlipDirection;
        TransitionToNextState(idleState); // Set start state as idle.
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

    public void TransitionToNextState(State nextState)
    {
        if (nextState == null) return;
        if (currentState != null) currentState.Exit();
        previousState = currentState;
        currentState = nextState;
        currentState.Enter();
        DisplayState();
    }

    private void DisplayState()
    {
        if (previousState == null || previousState.GetType() != currentState.GetType())
        {
            stateName = currentState.GetType().ToString();
        }
    }

    private void Update()
    {
        currentState.UpdateState();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState();
    }
}
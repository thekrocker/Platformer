using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnimationType
{
    Die,
    Hit,
    Idle,
    Attack,
    Run,
    Jump,
    Fall,
    Climb,
    Land
}

public class AgentAnimation : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }


    public void PlayAnimation(AnimationType animType)
    {
        switch (animType)
        {
            case AnimationType.Die:
                break;
            case AnimationType.Hit:
                break;
            case AnimationType.Idle:
                Play("Idle");
                break;
            case AnimationType.Attack:
                break;
            case AnimationType.Run:
                Play("Run");
                break;
            case AnimationType.Jump:
                break;
            case AnimationType.Fall:
                break;
            case AnimationType.Climb:
                break;
            case AnimationType.Land:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(animType), animType, null);
        }
    }
    public void Play(string animName)
    {
        _anim.Play(animName, -1, 0);
    }
    
}
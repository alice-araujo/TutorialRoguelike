using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class PlayerAnimation : MonoBehaviour
{
    private enum Facing
    {
        up,
        down,
        left,
        right
    }
    
    private enum AnimationName
    {
        IdleUp,
        IdleDown,
        IdleLeft,
        IdleRight,
        WalkingUp,
        WalkingDown,
        WalkingRight,
        WalkingLeft
    }

    private string m_CurrentAnimation;
    private Facing m_Facing;
    private Animator m_Animator;
    private Rigidbody2D m_Rb;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ChangeAnimation();
    }

    private void ChangeAnimation()
    {
        if (m_Rb.velocity == Vector2.zero)
        {
            switch (m_Facing)
            {
                case Facing.up:
                    PlayAnimation(AnimationName.IdleUp);
                    break;
                case Facing.down:
                    PlayAnimation(AnimationName.IdleDown);
                    break;
                case Facing.right:
                    PlayAnimation(AnimationName.IdleRight);
                    break;
                case Facing.left:
                    PlayAnimation(AnimationName.IdleLeft);
                    break;
            }
        }
        else
        {
            if (m_Rb.velocity.x > 0.1f)
            {
                PlayAnimation(AnimationName.WalkingRight);
                m_Facing = Facing.right;
            }
            else if (m_Rb.velocity.x < -0.1f)
            {
                PlayAnimation(AnimationName.WalkingLeft);
                m_Facing = Facing.left;
            } else if (m_Rb.velocity.y > 0.1f)
            {
                PlayAnimation(AnimationName.WalkingUp);
                m_Facing = Facing.up;
            } else if (m_Rb.velocity.y < -0.1f)
            {
                PlayAnimation(AnimationName.WalkingDown);
                m_Facing = Facing.down;
            }
        }
    }

    private void PlayAnimation(AnimationName animName)
    {
        if (m_CurrentAnimation == animName.ToString()) return;

        m_CurrentAnimation = animName.ToString();
        m_Animator.Play(m_CurrentAnimation);
    }
}

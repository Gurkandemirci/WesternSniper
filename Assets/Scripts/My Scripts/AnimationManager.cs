using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;
using System;
public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;
    Action endFunctionAction;
    bool isAnimationEnded;



    public AnimationClip playerAim;
    public AnimationClip playerIdle;
    public AnimationClip enemyIdle;
    public AnimationClip enemyAim;
    public AnimationClip enemyHitDamage;
    public AnimationClip enemyHitDamageFromBack;
    public AnimationClip enemyDead;
    public AnimationClip enemyHeadshot;
    public AnimationClip enemyRun;




    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }    
    }
    

    public float PlayAnim(AnimationClip clip, AnimancerComponent anim, float fade = 0.3f, float speed = 1, Action endAnimation = null)
    {
        var state = anim.Play(clip, fade);
        state.Speed = speed;

        isAnimationEnded = false;
        if (endAnimation != null)
        {
            endFunctionAction = endAnimation;
            state.Events.OnEnd = OnEndEvent;
        }
        return state.Duration / speed;
    }

    private void OnEndEvent()
    {
        if (!isAnimationEnded)
        {
            isAnimationEnded = true;
            endFunctionAction();
        }
    }
}

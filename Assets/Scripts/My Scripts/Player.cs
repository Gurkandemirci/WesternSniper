using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class Player : MonoBehaviour
{

    AnimancerComponent anim;
    public int health = 10;


    void Start()
    {
        anim = GetComponent<AnimancerComponent>();
        AnimationManager.instance.PlayAnim(AnimationManager.instance.playerIdle, anim, 0.3f, 1);
    }


    public void ChangeHealth()
    {
        health--;
        UIManager.instance.UpdateHealth(health);
        if(health == 0)
        {
            GameManager.instance.FailLevel();
        }
    }


    public void PlayIdleAnim()
    {
        AnimationManager.instance.PlayAnim(AnimationManager.instance.playerIdle, anim, 0.8f, 1);
    }

    public void PlayAimAnim()
    {
        AnimationManager.instance.PlayAnim(AnimationManager.instance.playerAim, anim, 0.3f, 1);
    }


}

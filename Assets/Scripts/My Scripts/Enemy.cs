using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;
using DG.Tweening;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    AnimancerComponent anim;

    public Player player;

    private GameObject gun;
    public GameObject headShotPanel;

    public int life = 2;
    public bool isDead = false;

    void Start()
    {
        anim = GetComponent<AnimancerComponent>();
        gun = transform.GetChild(2).gameObject;
        PlayIdleAnim();
    }

    public IEnumerator AimToPlayer()
    {
        while (!isDead)
        {
            int waitTime = Random.Range(3,8);
            yield return new WaitForSeconds(waitTime);
            if(!GameManager.isGameEnded)
                StartCoroutine(ShootToPlayer());
        }
        
    }

    [System.Obsolete]
    public IEnumerator ShootToPlayer()
    {
        float i = 0.0f;

        GameObject bullet = BulletPool.instance.TakeOutFromPool();

        while (i < 1)
        {
            
            yield return new WaitForSeconds(0.02f);
            i = i + Time.deltaTime;
            bullet.transform.position = Vector3.Lerp(transform.position, player.transform.position, i);
            bullet.transform.LookAt(player.transform);

        }
        bullet.active = false;
        BulletPool.instance.AddToPool(bullet);
        player.ChangeHealth();
    }



    public void Damaged()
    {
        if (life == 2)
        {
            if(transform.rotation.eulerAngles.y > 90 && transform.rotation.eulerAngles.y < 270 )
            {
                StartCoroutine(PlayHitDamageAnim());
            }
            else
            {
                StartCoroutine(PlayHitDamageFromBackAnim());
            }
            
            life--;
        }
        else if(life > 1)
        {
            StartCoroutine(PlayHitDamageAnim());
            life--;
        }
        else if(!isDead)
        {
            life = 0;
            isDead = true;
            PlayDeadAnim();

            GameManager.instance.deadCount++;
            if (GameManager.instance.deadCount == 4)
            {
                GameManager.instance.FinishLevel();
            }
        }
    }

    public void PlayIdleAnim()
    {
        AnimationManager.instance.PlayAnim(AnimationManager.instance.enemyIdle, anim, 0.3f, 1);
    }

    public void PlayAimAnim()
    {
        AnimationManager.instance.PlayAnim(AnimationManager.instance.enemyAim, anim, 0.8f, 1);
        transform.DOLookAt(player.transform.position,1);
        gun.transform.DOLocalMoveY(0.95f, 1);
        gun.transform.DOLocalMoveZ(0.8f, 1);
    }

    public IEnumerator PlayHitDamageAnim()
    {
        AnimationManager.instance.PlayAnim(AnimationManager.instance.enemyHitDamage, anim, 1.2f, 1.5f);
        yield return new WaitForSeconds(1.2f);
        PlayAimAnim();
    }

    public IEnumerator PlayHitDamageFromBackAnim()
    {
        AnimationManager.instance.PlayAnim(AnimationManager.instance.enemyHitDamageFromBack, anim, 1.2f, 1.5f);
        yield return new WaitForSeconds(1.2f);
        PlayAimAnim();
    }

    public void PlayDeadAnim()
    {
        AnimationManager.instance.PlayAnim(AnimationManager.instance.enemyDead, anim, 0.8f, 1);
    }
    public void PlayRunAnim(int speed)
    {
        AnimationManager.instance.PlayAnim(AnimationManager.instance.enemyRun, anim, 0.8f, speed);
    }

    public void PlayHeadShotAnim()
    {
        life = 0;
        isDead = true;
        GameManager.instance.deadCount++;
        if(GameManager.instance.deadCount == 4)
        {
            GameManager.instance.FinishLevel();
        }

        AnimationManager.instance.PlayAnim(AnimationManager.instance.enemyHeadshot, anim, 0.8f, 1);
        StartCoroutine(DisplayHeadShotPanel());
       
    }

    public IEnumerator DisplayHeadShotPanel()
    {
        headShotPanel.SetActive(true);
        headShotPanel.transform.DOShakeScale(0.8f);
        yield return new WaitForSeconds(1);
        headShotPanel.SetActive(false);
    }

}

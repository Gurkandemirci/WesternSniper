using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Path : MonoBehaviour
{

    public static Path instance;

    public Transform target;

    private Enemy enemy;


    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
        enemy.life = 1;
        if (instance == null)
        {
            instance = this;
        }

        

    }

    public IEnumerator StartPath()
    {
        float i = 0.0f;
        
        while (i < 1)
        {
            enemy.PlayRunAnim(1);

            if (enemy.life == 0)
            {
                enemy.PlayRunAnim(0);
                enemy.PlayDeadAnim();
                break;
            }

            yield return new WaitForSeconds(0.3f);
            i = i + Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target.position, i);

            if(Vector3.Distance(transform.position, target.position) < 0.2f )
            {
                GameManager.instance.FailLevel();
                enemy.PlayRunAnim(0);
                enemy.PlayIdleAnim();
                break;
            }
        }
        

    }

   


}

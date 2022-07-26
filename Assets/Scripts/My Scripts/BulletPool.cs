using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance; 

    public GameObject bulletClone;
    
    public Transform[] enemy;

    //public AudioClip bulletAudio;

    public List<GameObject> bullets; 

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        for (int i = 0; i < 50; i++)
        {
            GameObject tempBullet = Instantiate(bulletClone, this.transform);
            bullets.Add(tempBullet);
        }
    }

    [System.Obsolete]
    public GameObject TakeOutFromPool()
    {
        for (int i = 0; i < 100; i++)
        {
            if (!bullets[i].active)
            {
                bullets[i].active = true;
                return bullets[i];
            }
        }
        return null;
    }
    public void AddToPool(GameObject bullet)
    {
        bullets.Add(bullet);
    }


}

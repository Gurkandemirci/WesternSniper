using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    EnumManager myEnum;
    public void ExplodeDynamite(Vector3 point , Transform[] explosiveObjects)
    {
        

        foreach(Transform nearObject in explosiveObjects)
        {
            if(Vector3.Distance(point,nearObject.position) < 10)
            {
                myEnum = nearObject.transform.gameObject.GetComponent<EnumManager>();

                if (myEnum.myObjectType == ObjectTypes.enemy && !myEnum.GetComponentInParent<Enemy>().isDead)
                {
                    myEnum.GetComponentInParent<Enemy>().PlayHeadShotAnim();
                }

                if (myEnum.myObjectType == ObjectTypes.dynamite)
                {
                    myEnum.gameObject.SetActive(false);
                }

            }
            
        }

        
    }

    

}

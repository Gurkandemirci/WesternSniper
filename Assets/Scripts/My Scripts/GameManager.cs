using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    EnumManager myEnumManager;
    public ObjectTypes myObjectType;

    public ParticleSystem bulletDecal;
    public ParticleSystem dynamiteExplosion;

    public Player player;
    public Enemy[] enemy;
    public Enemy selectedEnemy;
    public Dynamite selectedDynamite;

    public Transform[] explosiveObjects;

    public AudioSource reloadGun;

    public static bool isAiming;
    public static bool isGameEnded;

    public int deadCount = 0;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }


        player = player.GetComponent<Player>();

        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i] = enemy[i].GetComponent<Enemy>();
        }
    }

 
    public void ClickObject()
    {
        StartCoroutine(Path.instance.StartPath());

        for (int i = 0; i < enemy.Length; i++)
        {
            if(enemy[i].life != 0)
            {
                enemy[i].PlayAimAnim();
                StartCoroutine(enemy[i].AimToPlayer());
                
            }
                
        }

        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            myEnumManager = hitInfo.transform.gameObject.GetComponent<EnumManager>();
            if (myEnumManager != null)
            {
                reloadGun.Play();

                if (myEnumManager.myObjectType == ObjectTypes.dynamite)
                {

                    dynamiteExplosion.transform.position = hitInfo.point;
                    dynamiteExplosion.Play();
                    dynamiteExplosion.GetComponent<AudioSource>().Play();

                    Vector3 hitPoint = hitInfo.point;
                    selectedDynamite = hitInfo.transform.gameObject.GetComponent<Dynamite>();
                    selectedDynamite.ExplodeDynamite(hitPoint,explosiveObjects);

                    
                    Debug.Log("patladýý");
                }

                else if (myEnumManager.myObjectType == ObjectTypes.enemyHead)
                {

                    selectedEnemy = hitInfo.transform.parent.parent.gameObject.GetComponent<Enemy>();
                    selectedEnemy.PlayHeadShotAnim();
                }

                else if (myEnumManager.myObjectType == ObjectTypes.enemy)
                {

                    selectedEnemy = hitInfo.transform.parent.gameObject.GetComponent<Enemy>();
                    selectedEnemy.Damaged();
                }

                else if (myEnumManager.myObjectType == ObjectTypes.environment)
                {
                    Vector3 hitPoint = hitInfo.point;

                    bulletDecal.transform.position = hitInfo.point;
                    bulletDecal.Play();


                }
                
            }

        }

    }

    public void FailLevel()
    {

        GameManager.isGameEnded = true;
        UIManager.instance.DisplayFailLevelCanvas();
    }

    public void FinishLevel()
    {
        GameManager.isGameEnded = true;
        UIManager.instance.DisplayFinishLevelCanvas();
    }
}

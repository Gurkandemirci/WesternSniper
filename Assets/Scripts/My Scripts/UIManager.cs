using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject aimPanel;
    public GameObject aimButton;
    public GameObject sniperCanvas;
    public GameObject FinishLevelCanvas;
    public GameObject FailLevelCanvas;

    public SpriteRenderer crosshair;
    public Image touchImage;

    public Slider healthSlider;


    private float delayTime = 1.2f;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        crosshair = aimButton.GetComponent<SpriteRenderer>();

        StartCoroutine(AimButtonMove());
    }

    IEnumerator AimButtonMove()
    {
        while (true)
        {

            aimPanel.transform.DOMoveX(590, delayTime).SetEase(Ease.OutQuad);
            aimButton.transform.DOLocalMoveX(0.09f, delayTime).SetEase(Ease.OutQuad);
            yield return new WaitForSeconds(delayTime);

            aimPanel.transform.DOMoveX(490, delayTime).SetEase(Ease.OutQuad);
            aimButton.transform.DOLocalMoveX(-0.09f, delayTime).SetEase(Ease.OutQuad);
            yield return new WaitForSeconds(delayTime);

            aimPanel.transform.DOMoveX(540, delayTime).SetEase(Ease.OutQuad);
            aimButton.transform.DOLocalMoveX(0, delayTime).SetEase(Ease.OutQuad);

            yield return new WaitForSeconds(delayTime * 2);

            aimPanel.transform.DOMoveY(700, delayTime).SetEase(Ease.OutQuad);
            aimButton.transform.DOLocalMoveY(-0.757f, delayTime).SetEase(Ease.OutQuad);
            yield return new WaitForSeconds(delayTime);
            aimPanel.transform.DOMoveY(600, delayTime).SetEase(Ease.OutQuad);
            aimButton.transform.DOLocalMoveY(-0.957f, delayTime).SetEase(Ease.OutQuad);
            yield return new WaitForSeconds(delayTime);
            aimPanel.transform.DOMoveY(650, delayTime).SetEase(Ease.OutQuad);
            aimButton.transform.DOLocalMoveY(-0.857f, delayTime).SetEase(Ease.OutQuad);


            yield return new WaitForSeconds(delayTime * 2);

            touchImage.DOFade(0, 0.5f);
            yield return new WaitForSeconds(delayTime);
            touchImage.DOFade(1, 0.5f);

            yield return new WaitForSeconds(delayTime * 2);

        }




    }



    public void DisplayAim(bool activate)
    {
        aimPanel.SetActive(activate);
        crosshair.forceRenderingOff = !activate;
        
    }


    public void ActivateSniperCanvas(bool activate)
    {
        
         sniperCanvas.SetActive(!activate);
        
    }

    public void UpdateHealth(int health)
    {
        if(health >= 0)
            healthSlider.value = health;
    }

    public void DisplayFailLevelCanvas()
    {
        FailLevelCanvas.SetActive(true);
        healthSlider.gameObject.SetActive(false);
    }

    public void DisplayFinishLevelCanvas()
    {
        FinishLevelCanvas.SetActive(true);
        healthSlider.gameObject.SetActive(false);
    }



}

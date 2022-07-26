using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
   

    

    void OnMouseDown()
    {
        if (!GameManager.isGameEnded)
        {
            GameManager.isAiming = true;
            GameManager.instance.player.PlayAimAnim();

            StartCoroutine(CameraMovement.instance.FocusCameraToArea(-15, false));
            UIManager.instance.DisplayAim(false);

        }
        else
        {
            UIManager.instance.aimPanel.SetActive(false);
            UIManager.instance.aimButton.SetActive(false);
        }

    }

    
    void OnMouseUp()
    {

        GameManager.isAiming = false;

        GameManager.instance.player.PlayIdleAnim();

        StartCoroutine(CameraMovement.instance.FocusCameraToArea(15, true));
        UIManager.instance.ActivateSniperCanvas(true);


        if (Camera.main.fieldOfView == 30)
        {
            GameManager.instance.ClickObject();
        }
        
        
    }
}

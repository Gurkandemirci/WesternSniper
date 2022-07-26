using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;
    public Transform cameraOrigin;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float x = 0;
            float y = 0;
            float z = 0;

            y = 1 * Input.GetAxis("Mouse X");

            if (transform.position.x < -7 && y > 0)
            {
                y = 0;
            }

            if (transform.position.x > -2 && y < 0)
            {
                y = 0;
            }

            x = 1 * -Input.GetAxis("Mouse Y");

            if (transform.position.y < 21 && x < 0)
            {
                x = 0;
            }

            if (transform.position.y > 25 && x > 0)
            {
                x = 0;
            }            

            transform.RotateAround(cameraOrigin.transform.position, new Vector3(x, y, 0), 0.4f);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, z);
        }

    }


    public IEnumerator FocusCameraToArea(int value, bool activate)
    {
        Camera.main.DOFieldOfView(45 + value,0.8f);

        yield return new WaitForSeconds(0.8f);

        if (Camera.main.fieldOfView > 58)
        {
            UIManager.instance.DisplayAim(true);

            UIManager.instance.DisplayAim(true);
        }
        else if(Camera.main.fieldOfView == 30)
        {
            UIManager.instance.ActivateSniperCanvas(false);
            UIManager.instance.DisplayAim(false);
        }
    }





}

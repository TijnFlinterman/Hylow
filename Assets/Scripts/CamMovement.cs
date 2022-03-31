using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] GameObject cam;
    public Transform right, left, Up, bottem;
    public bool gotBumped;
    public bool isMoveing;
    public float lookUpSpeed;

    public void Tilt(int _tiltAmount)
    {
        switch (_tiltAmount)
        {
            case 1: // Right
                if (!gotBumped)
                    cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, right.rotation, 8 * Time.deltaTime);
                isMoveing = true;
                break;

            case 2: //left
                if (!gotBumped)
                    cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, left.rotation, 8f * Time.deltaTime);
                isMoveing = true;
                break;

            case 3: // idle
                if (!gotBumped)
                {
                    if (!isMoveing)
                    {
                        cam.GetComponent<CamWobble>().camWobbeling();
                    }
                    if (cam.transform.rotation == Up.rotation)
                    {
                        lookUpSpeed = 7;
                        isMoveing = false;
                    }
                    if (isMoveing)
                    {
                        cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Up.rotation, lookUpSpeed * Time.deltaTime);
                    }
                }
                break;

            case 4: //down

                cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, bottem.rotation, 5f * Time.deltaTime);
                if (cam.transform.rotation == bottem.rotation)
                {
                    isMoveing = true;
                    lookUpSpeed = 3;
                    gotBumped = false;
                }
                break;
        }
    }
}

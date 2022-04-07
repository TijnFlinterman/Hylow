using UnityEngine;
using Cinemachine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] GameObject cam;
    public Transform right, left, Up, bottem;
    public bool gotBumped;
    public bool isMoveing;
    public float lookUpSpeed;
   [SerializeField] CinemachineVirtualCamera vcam;
    public void Tilt(int a)
    {
        switch (a)
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
                    if (cam.transform.rotation == Up.rotation)
                    {
                        lookUpSpeed = 7;
                        isMoveing = false;
                    }
                    cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Up.rotation, lookUpSpeed * Time.deltaTime);
                }
                break;

            case 4: //down

                cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, bottem.rotation, 5f * Time.deltaTime);
                vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 5;
                if (cam.transform.rotation == bottem.rotation)
                {
                    vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
                    isMoveing = true;
                    lookUpSpeed = 3;
                    gotBumped = false;
                }
                break;
        }
    }
}

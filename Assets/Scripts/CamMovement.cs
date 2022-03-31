using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField]GameObject cam;
    public Transform right, left, Up, bottem;
    public bool gotBumped;
    public float lookUpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Tilt(int a)
    {
        switch (a)
        {
       
                case 1: // Right
                if(!gotBumped)
                    cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, right.rotation, 8 * Time.deltaTime);
            break;

                case 2: //left
                if (!gotBumped)
                    cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, left.rotation, 8f * Time.deltaTime);
            break;

                case 3: // idle
                if (!gotBumped)
                {
                    cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Up.rotation, lookUpSpeed * Time.deltaTime);
                    if (cam.transform.rotation == Up.rotation)
                    {
                        lookUpSpeed = 7;

                    }
                }
            break;

          
             case 4: //down
                 
        cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, bottem.rotation, 5f * Time.deltaTime);
        if (cam.transform.rotation == bottem.rotation)
        {
            lookUpSpeed = 3;
            gotBumped = false;
        }
                break;
      }
    }
        
    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private bool hasBumped;
    private float dist;
    [SerializeField] [Range(0f, 1f)] float distance = 0.75f;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Zombie")
        {
            dist = Vector3.Distance(transform.position, coll.transform.position);
            if (dist > distance)
            {
                //Debug.Log("far hit, distance is: " + dist);

                if (transform.position.x < coll.transform.position.x)
                {
                    Debug.Log("Left");
                    if (hasBumped == false)
                    {
                        BumpLeft();
                        hasBumped = true;
                    }
                }
                if (transform.position.x > coll.transform.position.x)
                {
                    Debug.Log("Right");
                    if (hasBumped == false)
                    {
                        BumpRight();
                        hasBumped = true;
                    }
                }
            }
            if (dist < distance)
            {
                //Debug.Log("close hit, distance is: " + dist);
                Debug.Log("Death");

                // add player death

            }
        }

        if (coll.gameObject.tag == "Tree")
        {
            if (transform.position.x < coll.transform.position.x)
            {
                Debug.Log("Left");
                if (hasBumped == false)
                {
                    BumpLeft();
                    hasBumped = true;
                }
            }
            if (transform.position.x > coll.transform.position.x)
            {
                Debug.Log("Right");
                if (hasBumped == false)
                {
                    BumpRight();
                    hasBumped = true;
                }
            }
        }
    }

    void BumpLeft()
    {
    
    }
    void BumpRight()
    {
    
    }

    private void OnTriggerExit(Collider coll)
    {
        hasBumped = false;
    }
}

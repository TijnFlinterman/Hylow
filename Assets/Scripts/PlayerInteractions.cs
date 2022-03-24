using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Zombie")
        {
            float dist = Vector3.Distance(transform.position, coll.transform.position);
            if (dist > 0.8f)
            {
                Debug.Log("far hit, distance is: " + dist);
            }
            if (dist < 0.8f)
            {
                Debug.Log("close hit, distance is: " + dist);
            }
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour
{
    private bool hasBumped;
    private float dist;
    [SerializeField] [Range(0f, 1f)] float distance = 0.75f;

    private CharacterController character;
    float mass = 3.0F;
    Vector3 impact = Vector3.zero;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (impact.magnitude > 0.2F) character.Move(impact * Time.deltaTime);
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }

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
                        AddImpact(Vector3.left, 20);
                        AddImpact(Vector3.forward, 10);
                        hasBumped = true;
                    }
                }
                if (transform.position.x > coll.transform.position.x)
                {
                    Debug.Log("Right");
                    if (hasBumped == false)
                    {
                        AddImpact(Vector3.right, 20);
                        AddImpact(Vector3.forward, 10);
                        hasBumped = true;
                    }
                }
            }
            if (dist < distance)
            {
                //Debug.Log("close hit, distance is: " + dist);
                Debug.Log("Death");

                SceneManager.LoadScene("PostGameMenu");

            }
        }

        if (coll.gameObject.tag == "Tree")
        {
            if (transform.position.x < coll.transform.position.x)
            {
                Debug.Log("Left");
                if (hasBumped == false)
                {
                    AddImpact(Vector3.left, 20);
                    AddImpact(Vector3.forward, 10);
                    hasBumped = true;
                }
            }
            if (transform.position.x > coll.transform.position.x)
            {
                Debug.Log("Right");
                if (hasBumped == false)
                {
                    AddImpact(Vector3.right, 20);
                    AddImpact(Vector3.forward, 10);
                    hasBumped = true;
                }
            }
        }
    }

    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
    }

    private void OnTriggerExit(Collider coll)
    {
        hasBumped = false;
    }
}

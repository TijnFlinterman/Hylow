using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour
{
    private bool hasBumped;
    private float dist;
    [SerializeField] [Range(0f, 1f)] float distance = 0.75f;
    [SerializeField] [Range(10f, 50f)] float forceSideways = 20;
    [SerializeField] [Range(10f, 50f)] float forceForward = 10;
    PlayerMovement _playerMovement;
    CamMovement _camMovement;
    private CharacterController character;
    private float mass = 3.0f;
    Vector3 impact = Vector3.zero;

    void Start()
    {
        character = GetComponent<CharacterController>();
        _playerMovement = GetComponent<PlayerMovement>();
        _camMovement = GetComponent<CamMovement>();
    }

    private void Update()
    {
        if (impact.magnitude > 0.2F) character.Move(impact * Time.deltaTime);
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Fuel")
        {
            if (GameManager.main._chainsaw.fuel < 5)
            { 
                GameManager.main._chainsaw.fuel++;
            }
        }

        if (coll.gameObject.tag == "Zombie")
        {
          _camMovement.gotBumped = true;
            dist = Vector3.Distance(transform.position, coll.transform.position);
            if (dist > distance)
            {
                if (transform.position.x < coll.transform.position.x)
                {
                    if (hasBumped == false)
                    {
                        _camMovement.bottem.eulerAngles = new Vector3(40, -25, 0);
                        AddImpact(Vector3.left, forceSideways);
                        AddImpact(Vector3.forward, forceForward);
                        hasBumped = true;
                    }
                }
                if (transform.position.x > coll.transform.position.x)
                {
                    if (hasBumped == false)
                    {
                        _camMovement.bottem.eulerAngles = new Vector3(40, 25, 0);
                        AddImpact(Vector3.right, forceSideways);
                        AddImpact(Vector3.forward, forceForward);
                        hasBumped = true;
                    }
                }
            }

            if (dist < distance)
            {
                SceneManager.LoadScene("DeathScreen");
            }
        }

        if (coll.gameObject.tag == "Tree")
        {
            _camMovement.gotBumped = true;
            if (transform.position.x < coll.transform.position.x)
            {
                if (hasBumped == false)
                {
                    _camMovement.bottem.eulerAngles = new Vector3(40,-25, 0);
                    AddImpact(Vector3.left, forceSideways);
                    AddImpact(Vector3.forward, forceForward);
                    hasBumped = true;
                }
            }

            if (transform.position.x > coll.transform.position.x)
            {
                if (hasBumped == false)
                {
                    _camMovement.bottem.eulerAngles = new Vector3(40, 25, 0);
                    AddImpact(Vector3.right, forceSideways);
                    AddImpact(Vector3.forward, forceForward);
                    hasBumped = true;
                }
            }
        }
    }

    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y;
        impact += dir.normalized * force / mass;
    }

    private void OnTriggerExit(Collider coll)
    {
        hasBumped = false;
    }
}

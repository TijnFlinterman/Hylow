using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] float movementSpeed = 5f;
    [SerializeField] [Range(0f, 10f)] float strafeSpeed = 5f;
    [SerializeField] GameObject cam;
    public CharacterController controller;
    public float metersWalked;
    private float distanceFootstepCount;
    public float stepSize = 5;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] steps;

    public bool gotBumped;
    Vector3 velocity;
    CamMovement _camMovement;
    private void Start()
    {
        _camMovement = GetComponent<CamMovement>();
    }
    private void Update()
    {
        metersWalked = this.transform.position.z;
        Scoring.currentScore = metersWalked;

        distanceFootstepCount += movementSpeed * Time.deltaTime;

        if(distanceFootstepCount > stepSize)
        {
            distanceFootstepCount = 0;
            audioSource.PlayOneShot(steps[Random.Range(0, steps.Length - 1)]);
        }
    }

    private void FixedUpdate()
    {
        ForwardMovement();
        StrafeMovement();

        if (_camMovement.gotBumped == true)
        {
            _camMovement.Tilt(4);
        }
    }

    private void ForwardMovement()
    {
        Vector3 move = transform.forward * movementSpeed;
        velocity.z = move.z;
    }
    void StrafeMovement()
    {
        float x = Input.GetAxis("Horizontal");
        CamMovement(x);

        Vector3 move = transform.right * x;
        controller.Move(move * strafeSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    void CamMovement(float x)
    {
        if (_camMovement.gotBumped == false)
        {
            if (x > 0.2)
            {
                _camMovement.Tilt(1);
            }
            else if (x < -0.2f)
            {
                _camMovement.Tilt(2);
            }
            else
            {
                _camMovement.Tilt(3);
            }
        }
    }
    public void Step(int _stepNumber)
    {
        audioSource.clip = steps[_stepNumber - 1];
        audioSource.Play();
    }
}

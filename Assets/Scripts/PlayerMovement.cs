using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] float movementSpeed = 5f;
    [SerializeField] [Range(0f, 10f)] float strafeSpeed = 5f;
    public CharacterController controller;
    public PlayerInteractions inter;
    public Transform spawnpoint;
    public float metersWalked;

    Vector3 velocity;

    private void Update()
    {
        metersWalked = Vector3.Distance(transform.position, spawnpoint.position);
    }

    private void FixedUpdate()
    {
        ForwardMovement();
        StrafeMovement();
    }
    void ForwardMovement()
    {

        Vector3 move = transform.forward * movementSpeed;
        velocity.z = move.z;
    }
    void StrafeMovement()
    {
        float x = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * x;
        controller.Move(move * strafeSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }
}

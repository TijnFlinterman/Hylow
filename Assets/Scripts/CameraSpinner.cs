using UnityEngine;

public class CameraSpinner : MonoBehaviour
{
    public float rotateAmount = 1.0f;

    private void Update()
    {
        transform.Rotate(0,rotateAmount,0);
    }
}

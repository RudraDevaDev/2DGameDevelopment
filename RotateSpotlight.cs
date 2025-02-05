using UnityEngine;

public class RotateSpotlight : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of rotation

    void Update()
    {
        // Rotate continuously around the Z-axis
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}

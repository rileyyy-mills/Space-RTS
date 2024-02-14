using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 30f; // Adjust this to change the rotation speed

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its local up axis (Y-axis)
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

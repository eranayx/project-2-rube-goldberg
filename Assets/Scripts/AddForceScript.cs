using UnityEngine;
using UnityEngine.UIElements;

public class AddForceScript : MonoBehaviour
{
    [SerializeField]
    private ForceMode forceMode;
    [SerializeField]
    private Vector3 vectorToAdd;
    [SerializeField]
    private float forceMultiplier;
    [SerializeField]
    private bool stopX;
    [SerializeField]
    private bool stopY;
    [SerializeField]
    private bool stopZ;

    private static bool normalized = false;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();

        if (!normalized)
        {
            float x = (stopX) ? 0f : otherRb.velocity.x;
            float y = (stopY) ? 0f : otherRb.velocity.y;
            float z = (stopZ) ? 0f : otherRb.velocity.z;

            otherRb.velocity = new Vector3(x, y, z);

            normalized = true;
        }

        // Add vector as force
        otherRb.AddForce(vectorToAdd * forceMultiplier, forceMode);
    }
}

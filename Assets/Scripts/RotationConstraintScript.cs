// NOT CURRENLTY USED

using UnityEngine;

public class RotationConstraintScript : MonoBehaviour
{
    [SerializeField]
    private bool freeze;
    [SerializeField]
    private GameObject ball;

    private void OnTriggerEnter(Collider other)
    {
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
    }
}

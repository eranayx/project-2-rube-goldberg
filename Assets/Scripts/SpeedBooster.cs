// Could likely be consolidated into AddForceScript

using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField]
    private float speedBoost;
    [SerializeField]
    private ParticleSystem vfx;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().velocity *= speedBoost;
        Instantiate(vfx, transform.position, transform.rotation);
    }
}

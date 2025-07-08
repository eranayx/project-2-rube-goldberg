using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField]
    private Material newSelfMaterial;
    [SerializeField]
    private Material newOtherMaterial;
    [SerializeField]
    private PhysicMaterial newSelfPhysicMaterial;
    [SerializeField]
    private PhysicMaterial newOtherPhysicMaterial;

    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer selfMeshRenderer = gameObject.GetComponent<MeshRenderer>();
        MeshRenderer otherMeshRenderer = other.gameObject.GetComponent<MeshRenderer>();
        Collider selfCollider = gameObject.GetComponent<Collider>();
        Collider otherCollider = other.gameObject.GetComponent<Collider>();

        if (other.CompareTag("Ball"))
        {
            // Change material if provided
            if (newSelfMaterial != null && selfMeshRenderer != null)
            {
                selfMeshRenderer.material = newSelfMaterial;
            }

            if (newOtherMaterial != null && otherMeshRenderer != null)
            {
                otherMeshRenderer.material = newOtherMaterial;
            }

            if (newSelfPhysicMaterial != null && selfCollider.material != null)
            {
                selfCollider.material = newSelfPhysicMaterial;
            }

            if (newOtherPhysicMaterial != null && otherCollider.material != null)
            {
                otherCollider.material = newOtherPhysicMaterial;
            }
        }
    }
}

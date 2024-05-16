using System.Collections;
using UnityEngine;
using UnityStandardAssets.Effects; 

public class FireController : MonoBehaviour
{
    [SerializeField] private GameObject wildFirePrefab;
    [SerializeField] private float particleEmissionDelay = 1f;
    public MouseMovement mouseMovement;

    private bool flameThrowerParticlesOn;

    private float fireUsage = 0f;

    private bool isFireSpreading = false;

    public bool IsFireSpreading { get { return isFireSpreading; } }

    // Custom function to find the closest point on a mesh collider
    private Vector3 FindClosestPointOnMesh(MeshCollider meshCollider, Vector3 point)
    {
        Mesh mesh = meshCollider.sharedMesh;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 closestPoint = Vector3.zero;

        foreach (Vector3 vertex in mesh.vertices)
        {
            Vector3 worldVertex = meshCollider.transform.TransformPoint(vertex);
            float distanceSqr = (point - worldVertex).sqrMagnitude;

            if (distanceSqr < closestDistanceSqr)
            {
                closestDistanceSqr = distanceSqr;
                closestPoint = worldVertex;
            }
        }

        return closestPoint;
    }

    void Update()
    {
        flameThrowerParticlesOn = mouseMovement.IsFlameThrowerPlaying();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.name == "House" && flameThrowerParticlesOn)
        {
            
            Vector3 contactPoint;

            if (other is BoxCollider || other is SphereCollider || other is CapsuleCollider)
            {
                contactPoint = other.ClosestPoint(transform.position);
            }
            else if (other is MeshCollider meshCollider)
            {
                // Custom closest point calculation for mesh colliders
                contactPoint = FindClosestPointOnMesh(meshCollider, transform.position);
            }
            else
            {
                contactPoint = other.bounds.center;
                Debug.LogWarning("Building collider type not fully supported. Using approximate contact point.");
            }

            wildFirePrefab.transform.position = contactPoint;

            if (!isFireSpreading)
            {
                StartCoroutine(DelayParticleEmission());
            }
        }
    }

    public float GetFireUsed()
    {
        return fireUsage;
    }

    IEnumerator DelayParticleEmission()
    {
        isFireSpreading = true;
        yield return new WaitForSeconds(particleEmissionDelay);

        ParticleSystemMultiplier particleSystemMultiplier = wildFirePrefab.GetComponent<ParticleSystemMultiplier>();
        if (particleSystemMultiplier != null)
        {
            particleSystemMultiplier.PlayParticles();
        }

        fireUsage += 1.1f;

        isFireSpreading = false;
    }
}

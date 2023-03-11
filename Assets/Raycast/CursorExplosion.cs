using UnityEngine;

class CursorExplosion : MonoBehaviour
{
    [SerializeField] new Camera camera;
    [SerializeField] new ParticleSystem particleSystem;
    [SerializeField] Transform cursor3D;
    [SerializeField] float baseImpulse = 100;
    [SerializeField] float range = 10;

    void OnValidate()
    {
        camera = Camera.main;
    }


    void Update()
    {
        Vector3 v = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(v);

        bool doHit = Physics.Raycast(ray, out RaycastHit hit);

        if (doHit)
        {
            // Debug.Log(hit.collider.name);
            cursor3D.position = hit.point;

            if (Input.GetMouseButtonDown(0)) 
            {
                Explode(hit.point);
            }
        }
    }

    void Explode(Vector3 center)
    {
        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();

        particleSystem.Play();

        foreach (Rigidbody rb in rigidbodies)
        {
            Vector3 distanceVector = rb.position - center;
            float distance = distanceVector.magnitude;
            Vector3 direction = distanceVector / distance;

            /*
            float distance1 = Vector3.Distance(center, rb.position);
            Vector3 direction1 = (rb.position - center).normalized;
            */
            if (distance < range)
            {

                float rangeMultiplier = 1 - (distance / range);
                rangeMultiplier = Mathf.Min(1, rangeMultiplier);

                float impulse = baseImpulse * rangeMultiplier / rb.mass;
                Vector3 impulseVector = direction * impulse;

                rb.velocity += impulseVector;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(cursor3D.position, range);
    }
}

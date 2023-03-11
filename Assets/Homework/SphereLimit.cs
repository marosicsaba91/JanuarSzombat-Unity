using UnityEngine;

[ExecuteAlways]
class SphereLimit : MonoBehaviour
{
    [SerializeField] Vector3 center;
    [SerializeField] float radius;
    // [SerializeField] Transform limitedObject;

    void Update()
    {
        Vector3 point = transform.position;

        float distance = Vector3.Distance(center, point);

        if (distance > radius) 
        {
            Vector3 offset = point - center;
            offset.Normalize();
            offset *= radius;

            transform.position = center + offset;
        }
    }

    void OnDrawGizmos()
    {
        Color c = Color.white;
        c.a = 0.15f;
        Gizmos.color = c;

        Gizmos.color = new Color(1,1,1, 0.15f);

        Gizmos.DrawSphere(center, radius);
    }

}

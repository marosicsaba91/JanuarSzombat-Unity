using UnityEngine;

class ChildRotator : MonoBehaviour
{
    [SerializeField] float angularSpeed;

    void Update()
    {
        MeshRenderer[] children = GetComponentsInChildren<MeshRenderer>();

        float angle = angularSpeed * Time.deltaTime;
        Vector3 position = transform.position;

        foreach (MeshRenderer child in children)
        {
            if (child.gameObject != gameObject)
            {
                Transform childT = child.transform;
                float distance = Vector3.Distance(childT.position, position);

                childT.Rotate(Vector3.up, angle / distance, Space.Self);                       
            }
        }        
    }
}
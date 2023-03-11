using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] float accelleration = 5;
    [SerializeField] float angularSpeed = 360;
    [SerializeField] float drag = 1;

    Vector2 velocity;

    void FixedUpdate()
    {
        bool forward = Input.GetKey(KeyCode.UpArrow);

        if (forward) 
        {
            velocity += (Vector2)transform.up * (accelleration * Time.fixedDeltaTime);
        }

        transform.position += (Vector3) (velocity * Time.fixedDeltaTime);

        // --------

        velocity *= 1f - (drag * Time.fixedDeltaTime); 

        // --------

        float h = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward, -h * Time.fixedDeltaTime * angularSpeed);
    }

    void OnDrawGizmos()
    {
        Collider2D coll = GetComponent<Collider2D>();

        if (coll != null) 
        {
            Bounds b = coll.bounds;
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(b.center, b.size);
        }        
    }
}

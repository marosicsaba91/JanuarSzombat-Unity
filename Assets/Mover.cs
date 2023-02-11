using UnityEngine;

class Mover : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        Vector3 direction = GetInputDirction();
        Move(direction);
    }

    void Move(Vector3 direction)
    {
        Transform t = transform;

        // Quaternion rotation =  t.rotation;


        Vector3 pos = t.position;

        Vector3 velocity = direction * speed;
        pos += velocity * Time.deltaTime;

        t.position = pos;

        if(direction != Vector3.zero)
            t.rotation = Quaternion.LookRotation(direction);
    }

    Vector3 GetInputDirction()
    {
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);

        float x = 0;
        if (right)
            x += 1;
        if (left)
            x -= 1;

        float z = 0;
        if (up)
            z += 1;
        if (down)
            z -= 1;

        Vector3 direction = new Vector3(x, 0, z);
        direction.Normalize();
        return direction;
    }
}
using UnityEngine;

class AirJumpRefill : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject go = otherCollider.gameObject;
        PlatformerPlayer player = go.GetComponent<PlatformerPlayer>();

        if (player != null) 
        {
            player.RefillAirJump();
        }
    }

}

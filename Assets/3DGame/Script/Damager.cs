using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] int damage = 10;

    void OnTriggerEnter(Collider other)
    {
        HPOwner hpo = other.GetComponent<HPOwner>();
        if (hpo != null) 
        {
            hpo.Damage(damage);
        
        }
    }

}

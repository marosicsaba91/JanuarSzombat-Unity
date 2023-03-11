using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

class MouseEvent : MonoBehaviour
{
    [SerializeField] Material mouseOverMaterial;

    Material mat;
    void OnMouseEnter()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        if (mr == null)
            return;


        mat = mr.material;

        mr.material = mouseOverMaterial;
    }

    void OnMouseExit()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        if (mr == null)
            return;

        mr.material = mat;
    }


}

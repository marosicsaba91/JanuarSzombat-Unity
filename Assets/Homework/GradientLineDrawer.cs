using System;
using UnityEngine;

class GradientLineDrawer : MonoBehaviour
{
    [SerializeField] Vector3 p1 = Vector3.left, p2 = Vector3.right;
    [SerializeField] Color c1 = Color.white, c2 = Color.black;
    [SerializeField, Min(2)] int colorCount = 10;

    void OnDrawGizmos()
    {
        DrawGradientLine(p1, p2, c1, c2, colorCount);
    }

    void DrawGradientLine(Vector3 p1, Vector3 p2, Color c1, Color c2, int colorCount)
    {
        float step = 1f / colorCount;

        for (int i = 0; i < colorCount; i++)
        {
            // --- Color ----

            float tColor = (float)i / (colorCount-1);
            Gizmos.color = Color.Lerp(c1, c2, tColor);

            // --- Position ---

            float t1 = i * step;
            float t2 = (i+1) * step;

            Vector3 start = Vector3.Lerp(p1, p2, t1);
            Vector3 end = Vector3.Lerp(p1, p2, t2);

            Gizmos.DrawLine(start, end);
        }
    }
}

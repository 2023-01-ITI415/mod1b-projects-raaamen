using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public static bool goalHit;

    private void OnTriggerEnter(Collider other) {
        Projectile proj = other.GetComponent<Projectile>();
        if (proj != null)
        {
            Goal.goalHit = true;
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 0.75f;
            mat.color = c;
        }
    }
}

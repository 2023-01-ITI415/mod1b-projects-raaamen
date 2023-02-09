using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public static GameObject projectile;

    private void Awake() {
        
    }
    

    private void FixedUpdate() {
        if (projectile=null) return;
        Vector3.Lerp(transform.position, projectile.transform.position, Time
        .deltaTime);
    }

}

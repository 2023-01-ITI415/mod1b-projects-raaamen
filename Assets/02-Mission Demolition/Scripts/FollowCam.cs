using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public static GameObject projectile;
    float camZ;
    public Vector3 minimum = Vector3.zero;

    private void Awake() {
        camZ = transform.position.z;
    }
    

    private void FixedUpdate() {
        if (projectile=null) return;
        
        Vector3 camDestination = projectile.transform.position;

        

        camDestination = Vector3.Lerp(transform.position, camDestination, 0.05f); 
        camDestination.z = camZ;
        transform.position=camDestination;
    }

}

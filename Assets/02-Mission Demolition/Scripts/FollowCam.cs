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
        Vector3 destination = Vector3.zero;
        if (projectile!=null){
            if(projectile.GetComponent<Rigidbody>().IsSleeping()){
                projectile=null;
            }
        }
        if (projectile!=null)
        {
            destination = projectile.transform.position;
        }



        
        
        Vector3 camDestination = projectile.transform.position;

        camDestination.x = Mathf.Max(minimum.x, camDestination.x);
        camDestination.y = Mathf.Max(minimum.y, camDestination.y);

        camDestination = Vector3.Lerp(transform.position, camDestination, 0.05f); 
        camDestination.z = camZ;
        transform.position=camDestination;
        Camera.main.orthographicSize = destination.y + 10;
    }

}

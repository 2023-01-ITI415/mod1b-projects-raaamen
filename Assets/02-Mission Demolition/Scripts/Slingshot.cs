using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject haloObj;
    public GameObject projectilePrefab;
    public GameObject currentProjectile;

    public bool isAiming;
    
    public Vector3 launchPos;

    public float velocityMultiply;

    private void Awake() {
        launchPos = GameObject.Find("LaunchPoint").gameObject.transform.position;
    }

    private void Update() {
        if (!isAiming) return;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        Vector3 pos3D = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 delta = pos3D-launchPos;

        float maxMag = GetComponent<SphereCollider>().radius;

        if (delta.magnitude >  maxMag)
        {
            delta.Normalize();
            delta*=maxMag;
            currentProjectile.transform.position = launchPos + delta;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isAiming=false;
            var rb = currentProjectile.GetComponent<Rigidbody>();
            rb.isKinematic=false;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rb.velocity=-delta*velocityMultiply;

            currentProjectile=null;
        }
    }

    private void OnMouseEnter() {
        haloObj.SetActive(true);
    }
    private void OnMouseExit() {
        haloObj.SetActive(false);
    }

    private void OnMouseDown() {
        currentProjectile = Instantiate(projectilePrefab, haloObj.transform.position, Quaternion.identity);
        FollowCam.projectile = currentProjectile;
        currentProjectile.GetComponent<Rigidbody>().isKinematic=true;
        isAiming=true;
    }
}

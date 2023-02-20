using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    public Vector3 cloudMovespeed;
    public float timer=30f;

    void Update()
    {
        transform.position+=cloudMovespeed*Time.deltaTime;
        timer-=Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

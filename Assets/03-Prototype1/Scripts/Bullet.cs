using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    private void OnCollisionEnter(Collision other) {
        Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}

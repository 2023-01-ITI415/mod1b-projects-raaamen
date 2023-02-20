using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag != "Player" || other.gameObject.tag != "Gun" || other.gameObject.tag != "Bullet")
        {
            StartCoroutine("DestroySelf");
        }
       
    }

    IEnumerator DestroySelf(){
        var temp = Instantiate(explosion,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(1);
        Destroy(temp);
        Destroy(this.gameObject);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        switch (other.gameObject.tag)
        {
            case "Ground":
                Destroy(gameObject);
            break;
        }
    }
}

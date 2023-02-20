using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject.tag);
        switch (other.gameObject.tag)
        {
            case "Ground":
                GameManager.Instance.Lives--;
                Destroy(this.gameObject);

            break;
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{

    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos); 
        Vector3 pos = this.transform.position;  
        pos.x = mousePos3D.x;
        this.transform.position = pos;   
    }

    private void OnCollisionEnter(Collision other) {
        //only collision will be apple in theory so no check is needed
        Destroy(other.gameObject);

    }
}

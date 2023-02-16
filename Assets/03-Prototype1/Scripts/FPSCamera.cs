using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public GameObject player;
    public float sensitivity;
    public float xRot;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");   
    }

    // Update is called once per frame
    void Update()
    {
        MouseLook();
        transform.position = player.transform.position;
        
    }

    void MouseLook(){
        float mouseX = Input.GetAxis("Mouse X") * sensitivity *Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity*Time.deltaTime;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        player.transform.Rotate(Vector3.up * mouseX);
    }
}

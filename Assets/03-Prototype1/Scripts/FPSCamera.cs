using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public GameObject player;
    public float sensitivity;
    public float xRot;
    
    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Start()
    {
        player = GameObject.Find("Player");   
    }

    void Update()
    {
        MouseLook();
        transform.position = player.transform.position+new Vector3(0,0.5f,0);
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

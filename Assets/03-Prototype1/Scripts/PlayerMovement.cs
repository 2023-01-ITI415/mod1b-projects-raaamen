using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float horizontalSpeed;
    public float verticalSpeed;
    public float xRot;
    public float yRot;
    public Camera camera;

    public float movementSpeed;

    public CharacterController characterController;
    public Vector3 jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        
        
    }

    private void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 moveDirection = new Vector3(horizontal,0,vertical);
        transform.Translate(moveDirection*movementSpeed*Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera camera;
    public float movementSpeed;
    public CharacterController characterController;
    
    public float shootCooldown;
    public bool canShoot;
    public Vector3 jumpForce;
    public Vector3 bulletForce;
    public float bulletForceMultiplier;
    public Rigidbody rb;

    public GameObject bulletPrefab;
    public GameObject playerGun;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = Camera.main;
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 moveDirection = new Vector3(horizontal,0,vertical);
        transform.Translate(moveDirection*movementSpeed*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce);
        }

        if (Input.GetMouseButton(0) && canShoot)
        {
            canShoot=false;
            StartCoroutine("ShootCooldown");
            bulletForce = camera.transform.forward*bulletForceMultiplier;
            var bullet = Instantiate(bulletPrefab, playerGun.transform.position, camera.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bulletForce);
        }
    }

    public IEnumerator ShootCooldown(){
        yield return new WaitForSeconds(shootCooldown);
        canShoot=true;
    }


}

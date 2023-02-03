using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTreeBehavior : MonoBehaviour
{
    public GameObject applePrefab;
    public float appleTimerSeconds;
    public float movementSpeed;
    private Vector3 startPos;
    public Vector3 moveVector;
    Vector3 tempPos;
    public float currentTime;
    void Start()
    {
        startPos = transform.position;
        StartCoroutine(DropApple());
    }
    void Update()
    {
        tempPos = Camera.main.WorldToViewportPoint(transform.position);
        moveVector = new Vector3(movementSpeed*Time.deltaTime, 0 ,0);
        transform.position += moveVector;
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -30, 28);
        transform.position=pos;
        Calculate();
    }

    IEnumerator DropApple(){
        while (GameManager.Instance.gameRunning)
        {
            yield return new WaitForSecondsRealtime(appleTimerSeconds);
            Instantiate(applePrefab, transform.position, Quaternion.identity);
        }
        yield return null;
    }

    public void Calculate(){
        float randValue = Random.value;
        if (randValue <= 0.1)
        {
            movementSpeed*=-1;
        }

    }
}

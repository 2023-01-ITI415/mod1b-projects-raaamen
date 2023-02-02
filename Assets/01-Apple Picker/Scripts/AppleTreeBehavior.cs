using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTreeBehavior : MonoBehaviour
{
    public GameObject applePrefab;

    public float appleTimerSeconds;
    public float movementSpeed;
    private Vector3 startPos;
    Vector3 tempPos;

    public float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        StartCoroutine(DropApple());
    }

    // Update is called once per frame
    void Update()
    {
        currentTime=Time.time;
        tempPos = startPos + new Vector3(Mathf.Sin(currentTime)*movementSpeed,0,0);
        //sin goes between 1 and -1 so this makes it move back and forth
        transform.position = tempPos;
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
            Debug.Log("change direction");
           tempPos*=-1;
        }

    }
}

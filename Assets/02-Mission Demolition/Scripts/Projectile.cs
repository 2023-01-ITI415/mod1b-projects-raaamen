using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    const int Lookback_Count = 10;
    private Vector3 prevpos;
    private List<float> deltas = new List<float>();
    private Rigidbody rb;
    private bool awake;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        awake=true;
        prevpos = new Vector3(1000,1000,0);
        deltas.Add(1000);
    }

    private async void FixedUpdate() {
        if (rb.isKinematic || !awake) return;
        Vector3 deltav3 = transform.position - prevpos;
        deltas.Add(deltav3.magnitude);
        prevpos = transform.position;

        while(deltas.Count > Lookback_Count){
            deltas.RemoveAt(0);
        }

        float maxdelta = 0;
        foreach (var item in deltas)
        {
            if(item > maxdelta) maxdelta=item;
        }
        if (maxdelta<=Physics.sleepThreshold){
            awake=false;
            rb.Sleep();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

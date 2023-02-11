using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    private LineRenderer line;
    private bool drawing=true;
    private Projectile projectile;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1;
        line.SetPosition(0, transform.position);
        projectile = GetComponentInParent<Projectile>();
    }

    private void FixedUpdate() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

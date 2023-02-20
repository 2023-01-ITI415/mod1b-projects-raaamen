using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    NavMeshAgent agent;
    public Transform player;

    public enum State{
        Attacking,
        Moving,
        TakeDamage
    }

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag=="Bullet")
        {
            Destroy(this.gameObject);
        }
    }



}

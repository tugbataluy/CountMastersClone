using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EC2: MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    void Start()
    {
        target = GameObject.Find("SpawningPoint2").transform;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

}

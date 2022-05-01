using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavScript : MonoBehaviour {
    public GameObject theDestination;
    NavMeshAgent theAgent;

    void Start () {
        theAgent = GetComponent<NavMeshAgent> ();
    }
    
    // Update is called once per frame
    public void FixedUpdate () {
        theAgent.SetDestination (theDestination.transform.position);
    }
}


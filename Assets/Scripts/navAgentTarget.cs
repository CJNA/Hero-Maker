using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navAgentTarget : MonoBehaviour
{
	public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
    	GetComponent<NavMeshAgent>().SetDestination(target);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

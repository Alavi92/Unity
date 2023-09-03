using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chasing : FsmState
{
    [SerializeField] private Transform movePositionTransform;

    private NavMeshAgent navMeshAgent;
   // public GameObject Text;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
      

    }
    void OnEnable()
    { 
        Debug.Log("Chasing");
    }

    void Update()
    {
        //Text.SetActive(false);
        navMeshAgent.destination = movePositionTransform.position;
        
    }


}

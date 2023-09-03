using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemymovement : FsmState
{
    

    private NavMeshAgent navMeshAgent;
    bool dirR = true;
    // public GameObject Text;
    public int Offset=0;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
        //Text.SetActive(false);
       
    }
    void OnEnable()
    {
        Debug.Log("Movement");
    }
    void Update()
    {
        //Text.SetActive(false);
        if (dirR == true && transform.position.x < Offset+25)
        {
            navMeshAgent.destination = new Vector3(transform.position.x + 20, transform.position.y, transform.position.z -30);
        }
        if (dirR == true && transform.position.x > Offset+25)
        {
            dirR = !dirR;
        }
        if (dirR == false && transform.position.x > Offset-25)
        {
            navMeshAgent.destination = new Vector3(transform.position.x - 20, transform.position.y, transform.position.z +20);
        }
        if (dirR == false && transform.position.x < Offset -25)
        {
            dirR = !dirR;
        }

       
    }
}

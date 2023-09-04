using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Counting2 : FsmState
{
    private NavMeshAgent navMeshAgent;
    public GameObject Text;
    public Text Number;
    bool CountBegin = false;
    public static bool PassedTime = false;
    public Vector3 CountingPlace= new Vector3(-6, 2, 30);
    

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        // Number= GetComponent<Text>();

    }


    void OnEnable()
    {
        PassedTime = false;
        CountBegin = false;
        Debug.Log("Counting2");
        SyncScript.StartOver = false;
    }
    void Update()
    {
        navMeshAgent.destination = CountingPlace;
        

        if (transform.position.x == CountingPlace.x && transform.position.z == CountingPlace.z && CountBegin == false)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            CountBegin = true;
            Debug.Log("2 is in position");
             PassedTime = false;
            StartCoroutine(Count());


        }



       
    }

    IEnumerator Count()
    {
        
        for (int i = 0; i < 5; i++)
        {
            
            yield return new WaitForSeconds(0.1F);

            if (i == 4)
            { PassedTime = true;
                Debug.Log("Counting 2 is done!");
            }

        }
       


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public  class Counting :FsmState
{
    private NavMeshAgent navMeshAgent;
    public GameObject Text;
    public Text Number;
    bool CountBegin = false ;
    public static bool PassedTime = false;
    //public Counting counting;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
       // Number= GetComponent<Text>();

    }


    void OnEnable()
    {
        PassedTime = false;
        CountBegin = false;
        Debug.Log("Counting");
        SyncScript.StartOver = false;
    }
    void Update()
    {
        navMeshAgent.destination = new Vector3(1,2,30);
        //PassedTime = false;

        if (transform.position.x == 1 && transform.position.z == 30 && CountBegin == false)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            CountBegin = true;
            Debug.Log("in position");
           // PassedTime = false;
            StartCoroutine(Count());


        }



      
    }

    IEnumerator Count()
    {
        Text.SetActive(true);
        for (int i = 0; i < 5; i++)
        {
            Number.text = " "+(i+1).ToString();
            yield return new WaitForSeconds(0.1F);
            
            Debug.Log(i);
            if (i == 4)
            { PassedTime = true; }
           
        }
        Text.SetActive(false);
        

    }
}

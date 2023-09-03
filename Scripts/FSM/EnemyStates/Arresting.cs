using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Doublsb.Dialog;



public class Arresting : FsmState
{
    public DialogManager dialogManager;
    //public static bool  DialogStart = false;
    private NavMeshAgent navMeshAgent;

    void OnEnable()
    { // SyncScript.DialogStart = false;
      // SyncScript.StartOver = false;
       Debug.Log("Arresting");
        //TargetInHand.Arrested = false;
    }
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();


    }

    void Update()
    {
        var Player = GameObject.Find("Sphere");
        Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        navMeshAgent.destination = transform.position;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        if (SyncScript.DialogStart == false)
        {
            StartCoroutine(Delay());
            //SyncScript.DialogStart = true;
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("/size:up/ Game over!  I finally caught you! ", "Enemy1"));
            dialogTexts.Add(new DialogData("/size:up/ Press Space to play again.", "Enemy1"));

            dialogManager.Show(dialogTexts);
           

        }
        
       

    }

    IEnumerator Delay()
    {
        SyncScript.DialogStart = true;
        yield return new WaitForSeconds(15F);
        SyncScript.DialogStart = false;

    }
   
}

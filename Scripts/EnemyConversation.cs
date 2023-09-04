using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Doublsb.Dialog;

public class EnemyConversation : FsmState
{
    public DialogManager dialogManager;
    public GameObject Text;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        

    }

    void Update()
    {
        Text.SetActive(true);
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Text.SetActive(false);
            
            navMeshAgent.destination = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("/size:up/ I am your biggest enemy!", "Enemy1"));
            dialogTexts.Add(new DialogData("/size:up/ Run if you can!", "Enemy1"));

            dialogManager.Show(dialogTexts);
            Debug.Log("Conversation");
        }
    }
}

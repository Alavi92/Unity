using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Doublsb.Dialog;

public class PassingByConversation : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public DialogManager dialogManager;
    float X, Y, Z, X2, Y2, Z2;
    public GameObject button;
    bool follow = false;
    [SerializeField] private Transform movePositionTransform;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    void Start()
    {
        button = GameObject.Find("WarningButton");
             button.SetActive(false);
    }
    
    void Update()
    {   if (follow == false)
        {
            X = transform.localPosition.x;
            Y = transform.localPosition.y;
            Z = transform.localPosition.z;

            var player = GameObject.FindWithTag("Player");
            X2 = player.transform.localPosition.x;
            Y2 = player.transform.localPosition.y;
            Z2 = player.transform.localPosition.z;

            if (Mathf.Sqrt(Mathf.Pow((X - X2), 2) + Mathf.Pow((Y - Y2), 2) + Mathf.Pow((Z - Z2), 2)) < 5)

            {

                button.SetActive(true);

            }
        }
        else 
        {
            navMeshAgent.destination = movePositionTransform.position;
        }



    }


    public void Char3Conversation()
    {
        button.SetActive(false);
        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/size:up/ It is dangerous here. Can I please come with you? ", "Capsule"));

        dialogManager.Show(dialogTexts);
        follow = true;


    }
}

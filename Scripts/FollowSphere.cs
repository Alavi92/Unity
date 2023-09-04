using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Doublsb.Dialog;

public class FollowSphere : MonoBehaviour
{ 
    [SerializeField] private Transform movePositionTransform;

    private NavMeshAgent navMeshAgent;
    public DialogManager dialogManager;
    bool ConversationBegin = false;
    float X, Y, Z, X2, Y2, Z2;
    public GameObject Text;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Text = GameObject.Find("Text1");
        Text.SetActive(false);

    }


        void Update()
    {
        if (ConversationBegin == false)
        {
            navMeshAgent.destination = movePositionTransform.position;
        }

        X = transform.localPosition.x;
        Y = transform.localPosition.y;
        Z = transform.localPosition.z;

        var player = GameObject.FindWithTag("Player");
        X2 = player.transform.localPosition.x;
        Y2 = player.transform.localPosition.y;
        Z2 = player.transform.localPosition.z;

        if (ConversationBegin==false && (Mathf.Sqrt(Mathf.Pow((X - X2), 2) + Mathf.Pow((Y - Y2), 2) + Mathf.Pow((Z - Z2), 2)) < 5))
        {
            Text.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Text.SetActive(false);
                StartCoroutine(DelayedConversation1());
            }

        }
    }

    
    
    
    public void Char1Conversation()
   {
      var dialogTexts = new List<DialogData>();
      dialogTexts.Add(new DialogData("/size:up/ /sound:HiSound/Hay You! ", "Capsule"));
       dialogTexts.Add(new DialogData(" Can you stop for a second? I need to tell you something.", "Capsule"));
       //dialogTexts.Add(new DialogData(" You need to be very careful.", "Capsule"));
      

      dialogManager.Show(dialogTexts);


   }
    

    IEnumerator DelayedConversation1()
    {
        ConversationBegin = true;
        Char1Conversation();
        yield return new WaitForSeconds(15F);
        ConversationBegin = false;
        Text.SetActive(true);


    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Doublsb.Dialog;


public class MoveAround : MonoBehaviour
{
    //[SerializeField] private Transform movePositionTransform;

    private NavMeshAgent navMeshAgent;
    bool dirR = true, Conversation = false;
    public DialogManager dialogManager;
    float X, Y, Z, X2, Y2, Z2;
    public GameObject Text;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Text = GameObject.Find("Text2");
        Text.SetActive(false);

    }

    void Update()
    {
              
        
        if (Conversation == false)
        {
            if (dirR == true && transform.localPosition.x < 15)
            {
                navMeshAgent.destination = new Vector3(transform.localPosition.x + 20, transform.localPosition.y, transform.localPosition.z - 5);
            }
            if (dirR == true && transform.localPosition.x > 15)
            {
                dirR = !dirR;
            }
            if (dirR == false && transform.localPosition.x > -15)
            {
                navMeshAgent.destination = new Vector3(transform.localPosition.x - 20, transform.localPosition.y, transform.localPosition.z + 5);
            }
            if (dirR == false && transform.localPosition.x < -15)
            {
                dirR = !dirR;
            }


            X = transform.localPosition.x;
            Y = transform.localPosition.y;
            Z = transform.localPosition.z;

            var player = GameObject.FindWithTag("Player");
            X2 = player.transform.localPosition.x;
            Y2 = player.transform.localPosition.y;
            Z2 = player.transform.localPosition.z;

            if  (Mathf.Sqrt(Mathf.Pow((X - X2), 2) + Mathf.Pow((Y - Y2), 2) + Mathf.Pow((Z - Z2), 2)) < 5)
            {
                Text.SetActive(true);
                if (Input.GetKeyDown(KeyCode.S))
                {
                    Conversation = true;
                    Text.SetActive(false);
                    navMeshAgent.destination = new Vector3(transform.localPosition.x , transform.localPosition.y, transform.localPosition.z);
                    var dialogTexts = new List<DialogData>();
                    dialogTexts.Add(new DialogData("/size:up/ Leave me alone! ", "Capsule2"));

                    dialogManager.Show(dialogTexts);
                }

            }




        }
        
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Conversation = true;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("/size:up/ Leave me alone! ", "Capsule2"));

            dialogManager.Show(dialogTexts);
        }
    }
    */
}

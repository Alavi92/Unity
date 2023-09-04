using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;


public class DialogueScript : MonoBehaviour
{
    public DialogManager dialogManager;


    //
    //public void TreeDialogue()

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))

        {
           

            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("/size:up/Hi, /size:init/I am the wise tree.", "Tree"));
            
            //To stop the ball from moving
            var player = GameObject.Find("Sphere");
            player.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            dialogTexts.Add(new DialogData(" I am here to help you find the coin", "Tree"));

            player.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            dialogTexts.Add(new DialogData("Go and find the mushroom.", "Tree"));

           

            dialogManager.Show(dialogTexts);
        }

    }
}

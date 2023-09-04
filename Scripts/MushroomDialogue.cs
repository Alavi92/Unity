using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class MushroomDialogue : MonoBehaviour
{
    public DialogManager dialogManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))

        {
            //To stop the ball from moving
            var player = GameObject.Find("Sphere");
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData(" /size:init/Are you looking for the coin?", "Mushroom"));
            dialogTexts.Add(new DialogData("Look behind the rock!", "Mushroom"));

            dialogManager.Show(dialogTexts);
        }
    }
}

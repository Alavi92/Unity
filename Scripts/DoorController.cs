using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    bool push;

    // Update is called once per frame
    void Update()
    {
        if (push == true && transform.position.y > 0.4)
        {
            transform.Translate(0, (-7) * Time.deltaTime, 0);
        }

        if (push == true && GameObject.Find("Door").transform.position.y < 5)
        {
            GameObject.Find("Door").transform.Translate(0,10 * Time.deltaTime, 0);
        }

        /* if (push == false && transform.position.y < 0.8)
         {
             transform.Translate(0,  5*Time.deltaTime, 0);
         }*/
        Debug.Log("Push:" + push);
    }

    void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.CompareTag("Player") && SphereScript.Grounded==false)
        {

            push = true;

        }
    }

    /*void OnCollisionExit(Collision collision)

    {
        if (collision.gameObject.CompareTag("Player"))
        {

            push = false;
        }
    }
    */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false;
            Debug.Log("No Collider");
        }
    
    }

    private void OnCollisionExit(Collision endcollision)
    {
        if (endcollision.gameObject.CompareTag("Player"))
        {
            if (GameObject.Find("Sphere").transform.position.x < -85 || GameObject.Find("Sphere").transform.position.x > -30)
            {
                GetComponent<Collider>().enabled = true;
                Debug.Log("Collider");
            }
        }

    }
    */
}

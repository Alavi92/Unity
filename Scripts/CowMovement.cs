using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMovement : MonoBehaviour
{
    int n = 5;
    int dir = -1;
    Vector3 v;
    //public  Vector3 Position=tr;

    // Update is called once per frame

    void Start()

    {
         v = transform.position;
    
    }
    void Update()
    {

        if (dir == -1 && transform.position.x > v.x -20)
        { transform.Translate(0, 0,  n * Time.deltaTime); }

        if (dir == -1 && transform.position.x < v.x -20)
        {
            dir *= -1;
            transform.eulerAngles = new Vector3(0, 90, 0);
            transform.Translate(0, 0,  n * Time.deltaTime);
        }
        if (dir == 1 && transform.position.x < v.x +20)
        { transform.Translate(0, 0,  n * Time.deltaTime); }

        if (dir == 1 && transform.position.x > v.x +20)
        {
            dir *= -1;

            transform.eulerAngles = new Vector3(0, -90, 0);
            transform.Translate(0, 0, n * Time.deltaTime);
        }
    }
}

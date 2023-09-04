using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{

    public int degreesPerSecond=80;
   
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * degreesPerSecond );
    }
}

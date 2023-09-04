using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInHand : FsmCondition
{
    public static bool Arrested=false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Arrested = true;
        }
        
        
    }
    private void OnCollisionExit(Collision exitcollision)
    {
        if (exitcollision.gameObject.CompareTag("Player"))
        {

            Arrested = false;
        }
    

    } 

    public override bool IsSatisfied(FsmState curr, FsmState next)
	{
        return (Arrested);
	}
}

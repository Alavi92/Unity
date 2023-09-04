using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : FsmCondition
{
    public static bool Space;

    
    public override bool IsSatisfied(FsmState curr, FsmState next)
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SyncScript.StartOver = true;
        }
        else if (Input.anyKey)
        {
            SyncScript.StartOver = false;
        }
        return (SyncScript.StartOver);
   
    }
   
}

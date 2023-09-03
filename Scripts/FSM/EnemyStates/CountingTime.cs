using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountingTime : FsmCondition
{
	
	
	public override bool IsSatisfied(FsmState curr, FsmState next)
	{

		//return (GetComponent<Counting>().PassedTime || GetComponent<Counting2>().PassedTime);
		//return (GetComponent<Counting>().PassedTime);
		return Counting.PassedTime;
	}
}

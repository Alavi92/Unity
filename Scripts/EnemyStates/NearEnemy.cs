using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearEnemy : FsmCondition
{
	public float Range;

	public Transform Player;

	public override bool IsSatisfied(FsmState curr, FsmState next)
	{
		return (transform.position - Player.position).sqrMagnitude <= Range * Range;
	}
} 

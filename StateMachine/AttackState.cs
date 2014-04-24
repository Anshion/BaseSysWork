using UnityEngine;
using System.Collections;

public class AttackState : State {

	public override void Initialize ()
	{
		Debug.Log("AttackState Initialize");
	}

	public override void Logic()
	{
		Debug.Log("AttackState Logic");
	}
}

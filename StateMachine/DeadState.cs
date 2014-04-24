using UnityEngine;
using System.Collections;

public class DeadState : State {

	public override void Initialize ()
	{
		Debug.Log("DeadState Initialize");
	}

	public override void Logic()
	{
		Debug.Log("DeadState Logic");
	}
}

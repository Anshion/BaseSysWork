using UnityEngine;
using System.Collections;

public class ActRunning : IAction {

	public ActRunning(Avatar avatar):this(avatar, ActionCode.RUNNING)
	{

	}

	public ActRunning(Avatar avatar, ActionCode code):base(avatar, code)
	{
	}

	public override bool CanGetIn ()
	{
		return true;
	}

	public override void GetIn (params object[] list)
	{
		Debug.Log("GetIn Running");
	}

	public override void GetOut()
	{
		Debug.Log("GetOut Running");
	}

	public override void Update (float dt)
	{
		Debug.Log("ActRunning Update");
		base.physics.MoveAvatarOnFloor(Time.fixedDeltaTime);
	}
}

using UnityEngine;
using System.Collections;

public class ActOnAir : IAction {

	public ActOnAir(Avatar avatar):base(avatar, ActionCode.ON_AIR)
	{

	}

	public override bool CanGetIn ()
	{
		return true;
	}

	public override void GetIn (params object[] list)
	{
		Debug.Log("GetIn ActOnAir");
	}

	public override void GetOut ()
	{
		Debug.Log("GetOut ActOnAir");
	}

	public override void Update (float dt)
	{
		base.avatar.physics.MoveAvatarOnAir(dt);
	}
}

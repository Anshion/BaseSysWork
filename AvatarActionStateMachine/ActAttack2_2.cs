using UnityEngine;
using System.Collections;

public class ActAttack2_2 : IAction {

	public ActAttack2_2(Avatar avatar):base(avatar, ActionCode.ATTACK2_2)
	{

	}

	public override bool CanGetIn ()
	{
		return true;
	}

	public override void GetIn (params object[] list)
	{
		Debug.Log("ActAttack2_2 GetIn");
		base.avatar.avatarFlags.StartAttack();
	}

	public override void GetOut()
	{
		Debug.Log("ActAttack2_2 GetOut");
		base.avatar.avatarFlags.isOnAttack = false;
	}

	public override void Update (float dt)
	{
		base.avatar.physics.MoveAvatarOnFloor(dt);
	}
}

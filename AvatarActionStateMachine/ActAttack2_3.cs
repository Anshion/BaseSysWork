using UnityEngine;
using System.Collections;

public class ActAttack2_3 : IAction {

	public ActAttack2_3(Avatar avatar):base(avatar, ActionCode.ATTACK2_3)
	{

	}

	public override bool CanGetIn ()
	{
		return true;
	}

	public override void GetIn (params object[] list)
	{
		Debug.Log("ActAttack2_3 GetIn");
		base.avatar.avatarFlags.StartAttack();
	}

	public override void GetOut()
	{
		Debug.Log("ActAttack2_3 GetOut");
		base.avatar.avatarFlags.isOnAttack = false;
	}

	public override void Update (float dt)
	{
		base.avatar.physics.MoveAvatarOnFloor(dt);
	}
}

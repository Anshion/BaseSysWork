using UnityEngine;
using System.Collections;

public class ActAttack2_1 : IAction {

	public ActAttack2_1(Avatar avatar):base(avatar, ActionCode.ATTACK2_1)
	{

	}

	public override bool CanGetIn ()
	{
		return true;
	}

	public override void GetIn (params object[] list)
	{
		Debug.Log("ActAttack2_1 GetIn");
		base.avatar.avatarFlags.StartAttack();
	}

	public override void GetOut()
	{
		Debug.Log("ActAttack2_1 GetOut");
		base.avatar.avatarFlags.isOnAttack = false;
	}

	public override void Update (float dt)
	{
		base.avatar.physics.MoveAvatarOnFloor(dt);
	}
}

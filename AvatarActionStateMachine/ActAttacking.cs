using UnityEngine;
using System.Collections;

public class ActAttacking : IAction {

	public ActAttacking(Avatar avatar):base(avatar, ActionCode.ATTACKING)
	{

	}

	public override bool CanGetIn ()
	{
		return true;
	}
	public override void GetIn (params object[] list)
	{
		Debug.LogWarning("GetIn ActAttaking");

		base.avatar.avatarFlags.isOnAttack = true;
	}

	public override void GetOut ()
	{
		Debug.Log("GetOut ActAttaking");
		base.avatar.avatarFlags.isOnAttack = false;

	}

	public override void Update (float dt)
	{
		base.avatar.physics.MoveAvatarOnFloor(dt);
	}
}

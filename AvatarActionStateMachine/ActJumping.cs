using UnityEngine;
using System.Collections;

public class ActJumping : IAction {

	public ActJumping(Avatar avatar):this(avatar, ActionCode.JUMPING)
	{

	}

	public ActJumping(Avatar avatar, ActionCode code):base(avatar, code)
	{

	}

	public override bool CanGetIn ()
	{
		return true;
	}

	public override void GetIn (params object[] list)
	{
		Debug.Log("GetIn Jumping");
		base.physics.velocity.y = Mathf.Max(base.physics.velocity.y, 0);
		base.physics.velocity += (Vector3) base.physics.hitNormal * base.avatar.attributes.JumpSpeed;
		base.physics.velocity.y = Mathf.Min(base.physics.velocity.y, base.avatar.attributes.JumpSpeed * 2f);
	}

	public override void GetOut()
	{
		Debug.Log("GetOut Jumping");
	}

	public override void Update (float dt)
	{
		Debug.Log("ActJumping Update");
		base.physics.MoveAvatarOnAir(dt);
	}
}

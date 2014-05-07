using UnityEngine;
using System.Collections;

public class EventJump : IEvent {

	public EventJump():base(EventCode.EVN_JUMP)
	{

	}

	public override bool Check()
	{
		return 
			(base.avatar.avatarInput.Jump) && 
			(base.avatar.avatarFlags.lastOnFloorTime > Time.time - base.avatar.attributes.JumpOnFloorTimeTolerance) &&
			((PlayerAvatarAnimation)	base.avatar.avatarAnimation).IsRunState();
	}
}

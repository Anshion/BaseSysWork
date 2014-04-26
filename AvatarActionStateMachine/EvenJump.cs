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
			(base.avatar.avatarFlags.onFloorDuration > 0.4f);
	}
}

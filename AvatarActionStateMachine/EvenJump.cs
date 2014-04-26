using UnityEngine;
using System.Collections;

public class EventJump : IEvent {

	public EventJump():base(EventCode.EVENT_JUMP)
	{

	}

	public override bool Check()
	{
		return base.avatar.avatarInput.Jump;
	}
}

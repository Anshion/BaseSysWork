using UnityEngine;
using System.Collections;

public class EventEndAttack : IEvent {
	public EventEndAttack():base(EventCode.EVN_END_ATTACK)
	{

	}

	public override bool Check ()
	{
		return ((PlayerAvatarAnimation)base.avatar.avatarAnimation).IsRunState() && base.avatar.avatarFlags.attackTime > 0.6f;
	}
}

using UnityEngine;
using System.Collections;

public class EventAttack2_3 : IEvent {

	public EventAttack2_3():base(EventCode.EVN_ATTACK2_3)
	{

	}

	public override bool Check ()
	{
		return ((PlayerAvatarAnimation)base.avatar.avatarAnimation).CheckCurAnimationName("Attack2_3");
	}
}

using UnityEngine;
using System.Collections;

public class EventEndAttack : IEvent {
	
	bool isInAttack = false;
	
	public EventEndAttack():base(EventCode.EVN_END_ATTACK)
	{

	}

	public override bool Check ()
	{
		if(!isInAttack)
		{
			isInAttack = ((PlayerAvatarAnimation)base.avatar.avatarAnimation).IsPlayAttackStateAnim();
		}

		if(isInAttack)
		{
			 if(((PlayerAvatarAnimation)base.avatar.avatarAnimation).IsRunState())
			{
				isInAttack = false;
				return true;
			}
		}

		return false;
	}
}

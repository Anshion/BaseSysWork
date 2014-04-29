using UnityEngine;
using System.Collections;

public class EventAttack2_2 : IEvent {

	public EventAttack2_2():base(EventCode.EVN_ATTACK2_2)
	{

	}

	public override bool Check ()
	{Debug.Log("Check EventAttack2_2:" +  base.avatar.avatarFlags.attackTime);
		return base.avatar.avatarInput.Attack && base.avatar.avatarFlags.attackTime > 0.4f;
	}
}

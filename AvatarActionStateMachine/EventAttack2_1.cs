using UnityEngine;
using System.Collections;

public class EventAttack2_1 : IEvent {

	public EventAttack2_1():base(EventCode.EVN_ATTACK2_1)
	{

	}

	public override bool Check ()
	{Debug.Log("Check EventAttack2_1:" +  base.avatar.avatarFlags.attackTime);
		return base.avatar.avatarInput.Attack && base.avatar.avatarFlags.attackTime > 0.4f;
	}
}

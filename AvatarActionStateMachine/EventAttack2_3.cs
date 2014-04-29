using UnityEngine;
using System.Collections;

public class EventAttack2_3 : IEvent {

	public EventAttack2_3():base(EventCode.EVN_ATTACK2_3)
	{

	}

	public override bool Check ()
	{
		Debug.Log("Check EventAttack2_3:" + base.avatar.avatarFlags.attackTime);
		return base.avatar.avatarInput.Attack && base.avatar.avatarFlags.attackTime > 0.4f;
	}
}

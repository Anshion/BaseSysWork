using UnityEngine;
using System.Collections;

public class EventAttack : IEvent {

	public EventAttack():base(EventCode.EVN_ATTACK)
	{

	}

	public override bool Check ()
	{
		return base.avatar.avatarInput.Attack;
	}
}

using UnityEngine;
using System.Collections;

public class EventNotOnFloor : IEvent {

	public EventNotOnFloor():base(EventCode.EVN_NOT_ON_FLOOR)
	{

	}

	public override bool Check ()
	{
		return !base.avatar.physics.IsOnFloor();
	}


}

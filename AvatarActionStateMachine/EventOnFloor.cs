using UnityEngine;
using System.Collections;

public class EventOnFloor : IEvent {

	public EventOnFloor():base(EventCode.EVN_ON_FLOOR)
	{

	 }

	public override bool Check ()
	{
		return base.avatar.physics.IsOnFloor();
	}
}

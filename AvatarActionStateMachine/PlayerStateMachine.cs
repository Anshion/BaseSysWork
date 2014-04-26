using UnityEngine;
using System.Collections;

public class PlayerStateMachine : AvatarStateMachine {

	protected override void InitActions()
	{
		base.AddAction(new ActRunning(base.avatar));
		base.AddAction(new ActJumping(base.avatar));
	}

	protected override void InitEventMatrix ()
	{
		base.AddEventTranstion(ActionCode.RUNNING, ActionCode.JUMPING, new EventJump());
		base.AddEventTranstion(ActionCode.JUMPING, ActionCode.RUNNING, new EventOnFloor());
	}
}

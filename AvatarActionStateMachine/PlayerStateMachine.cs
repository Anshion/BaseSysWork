using UnityEngine;
using System.Collections;

public class PlayerStateMachine : AvatarStateMachine {

	protected override void InitActions()
	{
		base.AddAction(new ActRunning(base.avatar));
		base.AddAction(new ActJumping(base.avatar));
		base.AddAction(new ActOnAir(base.avatar));
		base.AddAction(new ActAttacking(base.avatar));
		base.AddAction(new ActAttack2_1(base.avatar));
		base.AddAction(new ActAttack2_2(base.avatar));
		base.AddAction(new ActAttack2_3(base.avatar));
	}

	protected override void InitEventMatrix ()
	{
		base.AddEventTranstion(ActionCode.RUNNING, ActionCode.JUMPING, new EventJump());
		base.AddEventTranstion(ActionCode.JUMPING, ActionCode.RUNNING, new EventOnFloor());
		base.AddEventTranstion(ActionCode.RUNNING, ActionCode.ON_AIR, new EventNotOnFloor());
		base.AddEventTranstion(ActionCode.ON_AIR, ActionCode.RUNNING, new EventOnFloor());
		base.AddEventTranstion (ActionCode.RUNNING, ActionCode.ATTACKING, new EventAttack());
		base.AddEventTranstion (ActionCode.ATTACKING, ActionCode.RUNNING, new EventEndAttack());
		base.AddEventTranstion(ActionCode.ATTACKING, ActionCode.ATTACK2_1, new EventAttack2_1());
		base.AddEventTranstion(ActionCode.ATTACK2_1, ActionCode.ATTACK2_2, new EventAttack2_2());
		base.AddEventTranstion (ActionCode.ATTACK2_1, ActionCode.RUNNING, new EventEndAttack());
		base.AddEventTranstion(ActionCode.ATTACK2_2, ActionCode.ATTACK2_3, new EventAttack2_3());
		base.AddEventTranstion (ActionCode.ATTACK2_2, ActionCode.RUNNING, new EventEndAttack());
		base.AddEventTranstion (ActionCode.ATTACK2_3, ActionCode.RUNNING, new EventEndAttack());
	}
}

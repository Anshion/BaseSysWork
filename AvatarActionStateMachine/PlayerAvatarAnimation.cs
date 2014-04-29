using UnityEngine;
using System.Collections;

public class PlayerAvatarAnimation : AvatarAnimation {

	public Animator avatarAnimator;

	private ActionCode avatarState;

	public AnimatorStateInfo currentState;
	public AnimatorStateInfo nextState;
	public bool avatarOnFloor;

	public AnimationEventReceiver aniEventReceiver;

	public override void Initialize ()
	{
		base.Initialize();
		avatarAnimator = base.avatarGameObjectTransform.GetComponent<Animator>();
//		aniEventReceiver = base.avatarGameObjectTransform.GetComponent<AnimationEventReceiver>();
//		aniEventReceiver.avatar = base.avatar;
	}

	public override void UpdateAnimation ()
	{
		avatarState = base.avatar.avatarStateMachine.GetCurState();
		currentState = avatarAnimator.GetCurrentAnimatorStateInfo(0);
		nextState = avatarAnimator.GetNextAnimatorStateInfo(0);
		avatarOnFloor = base.avatar.physics.IsOnFloor();

		UpdateRunning();
		UpdateJumping();
		UpdateAttacking();
	}

	private void UpdateRunning()
	{
		avatarAnimator.SetBool("onfloor", avatarOnFloor);
	}

	private void UpdateJumping()
	{
		bool isJump = (avatarState == ActionCode.JUMPING);
		if(IsJumpState(currentState))
		{
			avatarAnimator.SetBool("startJump", false);
		}else
		{
			avatarAnimator.SetBool("startJump", isJump);
		}

		avatarAnimator.SetBool("jumping", isJump);
	}

	private void UpdateAttacking()
	{
		bool isAttack = (avatarState == ActionCode.ATTACKING);
//		if(IsAttackState(currentState))
//		{
		avatarAnimator.SetBool("attack", isAttack);
		avatarAnimator.SetBool("attack2_1", (avatarState == ActionCode.ATTACK2_1));
		avatarAnimator.SetBool("attack2_2", (avatarState == ActionCode.ATTACK2_2));
		avatarAnimator.SetBool("attack2_3", (avatarState == ActionCode.ATTACK2_3));
//		}

	}

	bool IsJumpState(AnimatorStateInfo state)
	{
		return state.IsTag("Jump");
	}

	bool IsAttackState(AnimatorStateInfo state)
	{
		return state.IsTag("attack");
	}

	public bool IsRunState()
	{
		currentState = avatarAnimator.GetCurrentAnimatorStateInfo(0);
		return currentState.IsTag("run");
	}
}

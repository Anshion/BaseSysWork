using UnityEngine;
using System.Collections;

public class PlayerAvatarAnimation : AvatarAnimation {

	public Animator avatarAnimator;

	private ActionCode avatarState;

	public AnimatorStateInfo currentState;
	public bool avatarOnFloor;

	public override void Initialize ()
	{
		base.Initialize();
		avatarAnimator = base.avatarGameObjectTransform.GetComponent<Animator>();
	}

	public override void UpdateAnimation ()
	{
		avatarState = base.avatar.avatarStateMachine.GetCurState();
		currentState = avatarAnimator.GetCurrentAnimatorStateInfo(0);
		avatarOnFloor = base.avatar.physics.IsOnFloor();
		UpdateRunning();
		UpdateJumping();
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


	bool IsJumpState(AnimatorStateInfo state)
	{
		return state.IsTag("Jump");
	}
}

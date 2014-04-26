using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {

	public AvatarAttributes attributes;
	public AvatarPhysics physics;
	public AvatarStateMachine avatarStateMachine;
	public AvatarInput avatarInput;

	public virtual void Initialize()
	{
		this.physics = this.GetComponent<AvatarPhysics>();
		this.physics.charController = this.GetComponent<CharacterController>();
		this.avatarStateMachine = this.GetComponent<AvatarStateMachine>();
		this.attributes = this.GetComponent<AvatarAttributes>();
		this.avatarInput = this.GetComponent<AvatarInput>();
		this.avatarInput.avatar = this;
		this.physics.avatar = this;
		this.physics.trans = this.transform;
		this.avatarStateMachine.InitStateMachine();
	}

	public void Update()
	{
		this.avatarInput.UpdateInput();
	}

	public void FixedUpdate()
	{
		this.avatarStateMachine.UpdateStateMachine();
		this.avatarInput.InputProcessed();
	}

//	public void FixedUpdate()
//	{
//		this.avatarStateMachine.UpdateStateMachine();
//		this.avatarInput.InputProcessed();
//		this.UpdateFlags();
//		this.UpdateShadow();
//		this.avatarAnimation.UpdateAnimation();
//		this.flags.updateFrame++;
//		this.OnFixedUpdate();
//	}
}

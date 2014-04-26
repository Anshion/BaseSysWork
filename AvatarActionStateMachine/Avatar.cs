using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {
	/// <summary>
	/// 角色属性
	/// </summary>
	public AvatarAttributes attributes;

	/// <summary>
	/// 角色物理控制，运动，碰撞检测
	/// </summary>
	public AvatarPhysics physics;

	/// <summary>
	/// 角色状态机
	/// </summary>
	public AvatarStateMachine avatarStateMachine;

	/// <summary>
	/// 玩家输入
	/// </summary>
	public AvatarInput avatarInput;

	/// <summary>
	/// 角色动画
	/// </summary>
	public AvatarAnimation avatarAnimation;

	/// <summary>
	/// 角色当前状态变量
	/// </summary>
	public AvatarFlags avatarFlags;

	public GameObject avatarGameObject;

	public virtual void Initialize()
	{
		this.physics = this.GetComponent<AvatarPhysics>();
		this.physics.charController = this.GetComponent<CharacterController>();
		this.avatarStateMachine = this.GetComponent<AvatarStateMachine>();
		this.attributes = this.GetComponent<AvatarAttributes>();
		this.avatarInput = this.GetComponent<AvatarInput>();
		this.avatarAnimation = this.GetComponent<AvatarAnimation>();
		this.avatarFlags = this.GetComponent<AvatarFlags>();
		this.avatarInput.avatar = this;
		this.avatarFlags.avatar = this;
		this.physics.avatar = this;
		this.physics.trans = this.transform;
		this.avatarStateMachine.Initialize();
		this.avatarAnimation.Initialize();
	}

	public void Update()
	{
		this.avatarInput.UpdateInput();
	}

	public void FixedUpdate()
	{
		this.avatarStateMachine.UpdateStateMachine();
		this.avatarInput.InputProcessed();
		this.avatarFlags.UpdateFlags();
		this.avatarAnimation.UpdateAnimation();
	
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

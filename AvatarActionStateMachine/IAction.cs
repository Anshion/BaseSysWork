using UnityEngine;
using System.Collections;

public abstract class IAction {

	protected Avatar avatar;
	protected AvatarPhysics physics;
	protected ActionCode stateName;

	public IAction(Avatar avatar, ActionCode stateName)
	{
		this.avatar = avatar;
		this.physics = avatar.physics;
		this.stateName = stateName;
	}
	
	public abstract bool CanGetIn();
	public abstract void GetIn(params object[] list);
	public abstract void GetOut();
	public abstract void Update(float dt);

	public ActionCode GetState()
	{
		return this.stateName;
	}
}

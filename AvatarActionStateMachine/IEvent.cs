using UnityEngine;
using System.Collections;

public abstract class IEvent  {

	protected Avatar avatar;

	protected EventCode code;

	public IEvent(EventCode code)
	{
		this.code = code;
	}


	public abstract bool Check();


	public EventCode GetCode()
	{
		return this.code;
	}

	public void SetAvatarRef(Avatar avatar)
	{
		this.avatar = avatar;
	}
}

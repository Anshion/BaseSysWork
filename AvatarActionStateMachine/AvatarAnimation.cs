using UnityEngine;
using System.Collections;

public class AvatarAnimation : MonoBehaviour {
	public Avatar avatar;
	public Transform avatarGameObjectTransform;


	public virtual void Initialize()
	{
		this.avatar = this.GetComponent<Avatar>();
		this.avatarGameObjectTransform = this.avatar.avatarGameObject.transform;
	}


	public virtual void UpdateAnimation()
	{

	}

}

using UnityEngine;
using System.Collections;

public class AvatarFlags : MonoBehaviour {
	public Avatar avatar;
	public float lastOnFloorTime;
	public float onFloorDuration;

	public void UpdateFlags()
	{
		if(avatar.physics.IsOnFloor())
		{
			lastOnFloorTime = Time.time;
			onFloorDuration += Time.deltaTime;

		}else{
			onFloorDuration = 0;
		}
	}
}

using UnityEngine;
using System.Collections;

public class AvatarFlags : MonoBehaviour {
	public Avatar avatar;
	public float lastOnFloorTime;
	public float onFloorDuration;

	public bool startAttack;
	public bool isOnAttack;
	public float attackTime;

	public void UpdateFlags()
	{
		if(avatar.physics.IsOnFloor())
		{
			lastOnFloorTime = Time.time;
			onFloorDuration += Time.deltaTime;

		}else{
			onFloorDuration = 0;
		}
		if(isOnAttack)
		{
			attackTime += Time.deltaTime;
		}else
		{
			attackTime = 0;
		}
	}

	public void StartAttack()
	{
		isOnAttack = true;
		attackTime = 0;
	}
}

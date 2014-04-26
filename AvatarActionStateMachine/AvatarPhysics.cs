using UnityEngine;
using System.Collections;

public class AvatarPhysics : MonoBehaviour {

	public Avatar avatar;
	public Transform trans;
	public Vector3 velocity;

	public CharacterController charController;

	//地形的法方向
	public Vector3 hitNormal = Vector3.up;
	

	//移动到新位置和新旋转
	public void MoveAvatar(Vector3 newPosition, Quaternion newRotation, bool avatarOnFloor)
	{
		this.trans.rotation = newRotation;
		charController.Move(newPosition - this.trans.position);
	}


	public void MoveAvatarOnFloor(float dt)
	{
		Vector3 forward = this.trans.forward;
		Quaternion rotation = this.trans.rotation;
		Vector3 position = this.trans.position;
//		this.IncreaseForwardSpeed(forward, dt);
//		this.AlignVelocityWithForward(forward, dt, true);
//		Quaternion avatarInputTargetRotation = this.GetAvatarInputTargetRotation(true);
//		rotation = MathUtils.RotateTowards(rotation, avatarInputTargetRotation, this.GetRotationSpeed() * dt);
//		this.AlignAvatarWithFloor(forward, ref rotation, true, dt);
//		rotation = this.ClampRotation(rotation, (Vector3) (rotation * Vector3.up), forward);
		this.MoveAvatar(position + ((Vector3) (this.velocity * dt)), rotation, true);
	}


	public void MoveAvatarOnAir(float dt)
	{
		Vector3 forward = this.trans.forward;
		Quaternion rotation = this.trans.rotation;
		Vector3 position = this.trans.position;
		this.AlignVelocityWithForward(forward, dt, false);
		this.velocity.y += dt * this.GetGravity();
		this.velocity = this.ClampVelocity(this.velocity, forward);
//		Quaternion avatarInputTargetRotation = this.GetAvatarInputTargetRotation(false);
//		rotation = MathUtils.RotateTowards(rotation, avatarInputTargetRotation, this.GetRotationSpeed() * dt);
//		this.AlignAvatarWithFloor(forward, ref rotation, false, dt);
//		rotation = this.ClampRotation(rotation, (Vector3) (rotation * Vector3.up), forward);
		this.MoveAvatar(position + ((Vector3) (this.velocity * dt)), rotation, false);

	}

	//将速度与人物的向前方法做插值
	void AlignVelocityWithForward(Vector3 forward, float deltaTime, bool avatarOnFloor)
	{
		float num = this.GetRotationSpeed();
		float y = this.velocity.y;
		this.velocity.y = 0f;
		Vector3 vector = (Vector3) (forward * this.velocity.magnitude);
		this.velocity = Vector3.RotateTowards(this.velocity, vector, (num * 0.01745329f) * deltaTime, 0f);
		this.velocity.y = y;
	}


	float GetRotationSpeed()
	{
		return avatar.attributes.RotationSpeed;
	}

	float GetGravity()
	{
		return avatar.attributes.Gravity;
	}

	public Vector3 ClampVelocity(Vector3 velocity, Vector3 forward)
	{
//		float magnitude = velocity.magnitude;
//		if (Vector3.Dot(velocity, forward) < 0f)
//		{
//			velocity = (Vector3) (forward * Mathf.Max(this.GetMinSpeed(), magnitude));
//			return velocity;
//		}
//		Vector2 vector = new Vector2(velocity.x, velocity.z);
//		float y = velocity.y;
//		if (Mathf.Abs(y) > this.attributes.MaxSpeedVertical)
//		{
//			y = Mathf.Sign(y) * this.attributes.MaxSpeedVertical;
//		}
//		float current = vector.magnitude;
//		if (current > this.GetMaxSpeed())
//		{
//			vector = (Vector2) ((vector / current) * Mathf.MoveTowards(current, this.GetMaxSpeed(), 200f * Time.deltaTime));
//		}
//		else if (current < this.GetMinSpeed())
//		{
//			if (current > 0.1f)
//			{
//				vector = (Vector2) ((vector / current) * this.GetMinSpeed());
//			}
//			else
//			{
//				Vector2 vector2 = new Vector2(forward.x, forward.z);
//				vector = (Vector2) (vector2.normalized * this.GetMinSpeed());
//			}
//		}
//		velocity.y = y;
//		velocity.x = vector.x;
//		velocity.z = vector.y;
		return velocity;
	}


	public bool IsOnFloor()
	{
		return charController.isGrounded;
	}

}

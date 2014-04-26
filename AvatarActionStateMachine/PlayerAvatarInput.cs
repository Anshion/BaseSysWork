using UnityEngine;
using System.Collections;

public class PlayerAvatarInput : AvatarInput {

	protected override void OnUpdateInput ()
	{
		base.Jump = Input.GetAxis("Vertical") > 0;
	}
	
}

using UnityEngine;
using System.Collections;

public class AnimationEventReceiver : MonoBehaviour {
	public Animator animator;
	void Start () {
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StartAttack()
	{
		Debug.Log("StartAttack");
//		animator.SetBool("attack", false);
	}
}

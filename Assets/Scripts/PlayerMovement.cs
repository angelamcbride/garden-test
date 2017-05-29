using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1f;

	private Animator anim;
	private Rigidbody2D rb2d;

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate() 
	{

		float input_x = Input.GetAxisRaw ("Horizontal");
		float input_y = Input.GetAxisRaw ("Vertical");
		Vector2 movement_vector = new Vector2 (input_x, input_y);

		if (movement_vector != Vector2.zero) 
		{
			anim.SetBool ("isWalking", true);
			anim.SetFloat ("x", input_x);
			anim.SetFloat ("y", input_y);
		} 
		else 
		{
			anim.SetBool ("isWalking", false);
		}

		rb2d.MovePosition (rb2d.position + movement_vector.normalized * Time.deltaTime);
	}
		
}

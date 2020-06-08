using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{

	public float moveSpeed ;
	public float health;
	public Rigidbody rigidbody;
	Camera viewCamera;
	Vector3 velocity;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
		viewCamera = Camera.main;
		health = 100;
	}

	void Update()
	{

		//Finding the position of the mouse relative to world space.
		Vector3 mousePos = viewCamera.ScreenToWorldPoint
			(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));

		//Rotating object to look at the position of where the mouse is in the world space.
		transform.LookAt(mousePos + Vector3.up * transform.position.y);

		//provides the player object movement speed
		velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;

		rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
	}

	/*
	 void FixedUpdate()
    {
		rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);			//can rigidbody can also be moved with fixed update
	}
	*/
}

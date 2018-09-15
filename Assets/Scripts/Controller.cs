using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

	public Rigidbody rb;

	public float speed;

	public float xSpeed;
	public float ySpeed;
	
	private float x;
	private float y;

	public float minY;
	public float maxY;

	[Space] public Transform head;
	
	
	
	void Start ()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () 
	{
		
	}

	void FixedUpdate()
	{
		CheckInputs();
		
		TurnBody();
		
		TurnHead();
	}

	void CheckInputs()
	{
		x = Input.GetAxis("Mouse X");
		y = Input.GetAxis("Mouse Y");

		if (Input.GetMouseButton(0))
		{
			Run();
		}
		else
		{
			Stop();
		}
	}
	//tourner tout le corp
	void TurnBody()
	{
		transform.Rotate(Vector3.up * x * xSpeed, Space.World);
	}

	//lever/baisser la tete, il faut clamper la rotation max
	void TurnHead()
	{
		head.Rotate(Vector3.right*y * -ySpeed, Space.Self);
		
		float angle = head.localEulerAngles.x;
		angle = (angle > 180) ? angle - 360 : angle;
		
		head.transform.localEulerAngles = new Vector3(Mathf.Clamp(angle, minY, maxY), 0,0);
	}
	
	//RUN
	void Run()
	{
		rb.velocity = transform.forward * speed;
	}

	void Stop()
	{
		rb.velocity = Vector3.zero;
	}
}

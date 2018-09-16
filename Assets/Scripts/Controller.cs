using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{

	public SubtitleManager sub;
	
	[Space]

	public Rigidbody rb;

	public float speed;

	public float xSpeed;
	public float ySpeed;
	
	private float x;
	private float y;

	public float minY;
	public float maxY;

	[Space] public Transform head;


	private RaycastHit hit;

	public float barkDistance;

	public LayerMask barkMask;


	[Space] public Transform mouth;

	public Transform grabbedObject;
	
	public float throwForce;
	
	


	[Space] public Animator anim;
	private bool running;

	public GameObject aim;

	public bool bobbleHead = true;
	
	void Start ()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			Interact();
		}
	}
	
	void FixedUpdate()
	{
		CheckInputs();
		
		TurnBody();
		
		TurnHead();
		
		CheckAim();
	}

	void CheckInputs()
	{
		x = Input.GetAxis("Mouse X");
		y = Input.GetAxis("Mouse Y");

		if (Input.GetMouseButton(0))
		{
			Run();
			if (running == false)
			{
				running = true;
				if(bobbleHead)
				anim.SetTrigger("Run");
			}
		}
		else
		{
			Stop();
			if (running == true)
			{
				running = false;
				anim.SetTrigger("Stop");
			}
		}

		
	}

	void CheckAim()
	{
		if (Physics.Raycast(head.position, head.forward, out hit, barkDistance, barkMask))
		{
			aim.SetActive(true);
		}
		else
		{
			aim.SetActive(false);
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

	void Interact()
	{

		if (grabbedObject != null)
		{
			Throw();
		}
		else if (Physics.Raycast(head.position, head.forward, out hit, barkDistance, barkMask))
		{
			hit.collider.GetComponent<Interaction>().Poke();
		}
		else
		{
			Bark();
		}
	}
	
	void Bark()
	{
		PlaySound("bark");

		
		sub.Talk("BARK", false);
		
		
	}

	void PlaySound(string _string)
	{
		AudioSource _son = Harmony.SetSource(_string);

		_son.pitch = Random.Range(.8f, 1.2f);

		_son.volume = .5f;
		
		Harmony.Play(_son);
	}

	public void Grab(Transform _target)
	{
		grabbedObject = _target;
		
		Destroy(_target.GetComponent<Rigidbody>());
		_target.SetParent(mouth);
		_target.transform.localPosition = Vector3.zero;
		_target.GetComponent<Collider>().enabled = false;
	}

	void Throw()
	{
		grabbedObject.parent = null;
		Rigidbody _rb = grabbedObject.gameObject.AddComponent<Rigidbody>();
		_rb.drag = 1;
		_rb.angularDrag = 1;
		_rb.velocity = head.forward * throwForce + Vector3.up * throwForce/2;
		grabbedObject.GetComponent<Collider>().enabled = true;

		grabbedObject = null;
	}
}

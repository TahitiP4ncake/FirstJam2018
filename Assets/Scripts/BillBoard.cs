using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour {

	public GameObject cam;

	public bool yRotation;

	private void Start()
	{
		cam = Camera.main.gameObject;
	}

	void Update () {
		transform.LookAt(cam.transform.position);
		
		if (!yRotation)
		{
			transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
		}
	}
}

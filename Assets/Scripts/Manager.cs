using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			
			Application.Quit();
		}
	}
}

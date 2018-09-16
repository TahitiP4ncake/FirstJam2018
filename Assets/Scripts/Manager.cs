using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

	public float sessionTime;

	public Image whiteScreen;

	public TextMeshProUGUI endText;

	public int gaminFound;
	
	void Start()
	{
		whiteScreen.color = Color.white;
		whiteScreen.CrossFadeAlpha(0,2,true);
		StartCoroutine(Timer());
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			
			Application.Quit();
		}
	}

	IEnumerator Timer()
	{
		yield return new WaitForSecondsRealtime(sessionTime);
		
		End();
		
	}

	void End()
	{
		whiteScreen.CrossFadeAlpha(1,1,true);


		StartCoroutine(EndState());
	}

	IEnumerator EndState()
	{
		yield return new WaitForSecondsRealtime(1);
		
		//.CrossFadeAlpha(1,1,true);

		endText.color = Color.black;
		
		while (true)
		{
			if (Input.GetKeyDown(KeyCode.Return))
			{

				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				
			}
			
			yield return null;

		}
		
	
	}
}

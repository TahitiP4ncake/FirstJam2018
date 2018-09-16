using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
	private SubtitleManager sub;
	
	public float sessionTime;

	public Image whiteScreen;

	public TextMeshProUGUI endText;

	public int gaminFound;

	public GameObject pauseMenu;

	private Controller dog;

	public TextMeshProUGUI bobbleText;
	
	
	
	void Start()
	{
		dog = FindObjectOfType<Controller>();
		whiteScreen.color = Color.white;
		whiteScreen.CrossFadeAlpha(0,2,true);
		StartCoroutine(Timer());

		sub = FindObjectOfType<SubtitleManager>();

		sub.Talk("Come on, let's play!", true);

	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Pause();
		}
	}

	public void Pause()
	{
		if (pauseMenu.activeSelf == false)
		{
			pauseMenu.SetActive(true);
			Time.timeScale = 0;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			pauseMenu.SetActive(false);
			Time.timeScale = 1;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
	
	IEnumerator Timer()
	{
		yield return new WaitForSecondsRealtime(sessionTime);
		
		sub.Talk("Dad's waiting for us, we're going home!", true);
		
		yield return new WaitForSecondsRealtime(3);
		
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

	
	public void SwitchBobbleHead()
	{
		if (dog.bobbleHead)
		{
			dog.bobbleHead = false;
			bobbleText.text = "bobblehead off";
			dog.anim.SetTrigger("Stop");
			
		}
		else
		{
			dog.bobbleHead = true;
			bobbleText.text = "bobblehead on";
		}
	}

	public void Quit()
	{
		print("QUIT");
		Application.Quit();
	}
}

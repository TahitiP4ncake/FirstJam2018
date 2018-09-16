using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PigeonManager : MonoBehaviour
{

	public int pigeonTotal;

	public int pigeonGone;

	public SpriteRenderer rend;

	public Sprite finalSprite;

	public SpriteRenderer sandwich;

	public Interaction gamine;

	public SpriteRenderer gamineFace;


	public Transform hands;

	private bool canFlap;
	public void Fly()
	{
		pigeonGone++;

		if (pigeonGone == pigeonTotal)
		{
			Sandwich();
		}

		if (canFlap)
		{
			canFlap = false;
			
			Invoke("Go", .5f);

			
			AudioSource _son = Harmony.SetSource("SFX_pigeons");

			_son.pitch = Random.Range(.8f, 1.2f);
			_son.volume = .5f;

			Harmony.Play(_son);
		}
		
	}

	void Go()
	{
		canFlap = true;
	}
	
	public void Sandwich()
	{
		
		FindObjectOfType<SubtitleManager>().Talk("YES, MY SANDWICH!", true);

		sandwich.transform.SetParent(hands);

		sandwich.transform.localPosition = Vector3.zero;
		
		gamine.done = true;
		gamine.lineIndex = 0;

		gamineFace.enabled = false;
		
		

	}

}

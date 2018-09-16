using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonManager : MonoBehaviour
{

	public int pigeonTotal;

	public int pigeonGone;

	public SpriteRenderer rend;

	public Sprite finalSprite;

	public SpriteRenderer sandwich;

	public void Fly()
	{


		if (pigeonGone == pigeonTotal)
		{
			Sandwich();
		}
	}

	public void Sandwich()
	{
		sandwich.enabled = false;
		rend.sprite = finalSprite;
	}

}

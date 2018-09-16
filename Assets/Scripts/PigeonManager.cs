﻿using System.Collections;
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
		pigeonGone++;

		if (pigeonGone == pigeonTotal)
		{
			Sandwich();
		}
	}

	public void Sandwich()
	{
		
		FindObjectOfType<SubtitleManager>().Talk("YES, MY SANDWICH!", true);

		sandwich.enabled = false;
		rend.sprite = finalSprite;
		
	}

}
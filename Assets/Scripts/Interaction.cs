using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum interactionType
{
	maitre,
	ball, 
	stick
	
}

public class Interaction : MonoBehaviour
{
	
	
	private SubtitleManager sub;

	public interactionType type;

	private void Start()
	{
		sub = FindObjectOfType<SubtitleManager>();
	}

	public void Poke()
	{
		if (type == interactionType.ball)
		{
			FindObjectOfType<Controller>().Grab(transform);
		}
		else if(type == interactionType.stick)
		{
			FindObjectOfType<Controller>().Grab(transform);
		}
		else
		{
			sub.Talk("You're talking to me", true);
			PlaySound("ah");
		}
			
		
	
	}

	public void PlaySound(string _clip)
	{
		AudioSource _son = Harmony.SetSource(_clip);

		_son.pitch = Random.Range(.8f, 1.2f);

		_son.volume = .5f;
		
		Harmony.Play(_son);
	}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum interactionType
{
	maitre,
	ball, 
	stick, 
	hide
	
}

public class Interaction : MonoBehaviour
{

	public Manager manager;
	
	private SubtitleManager sub;

	public interactionType type;

	public List<string> lines;

	public int lineIndex;

	private bool done;
	
	private void Start()
	{
		sub = FindObjectOfType<SubtitleManager>();
	}

	public void Poke()
	{
		if (type == interactionType.ball)
		{
			FindObjectOfType<Controller>().Grab(transform);
			
			sub.Talk("bal", true);

		}
		else if(type == interactionType.stick)
		{
			FindObjectOfType<Controller>().Grab(transform);
			
			sub.Talk("sticc", true);

		}
		else if (type == interactionType.hide)
		{
			if (!done)
			{
				sub.Talk(lines[manager.gaminFound], true);
				manager.gaminFound++;

				//change animation
			
				//PlaySound("sad");
				
				done = true;
			}
			
		
			
			
		}
		else
		{
			
			sub.Talk(lines[lineIndex], true);
			if (lineIndex < lines.Count - 1)
			{
				lineIndex++;
			}
			else
			{
				lineIndex = 0;
			}

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

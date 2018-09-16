using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	public string clipName;

	public float volume = 1;
	
	
	void OnCollisionEnter(Collision other)
	{

		if (other.collider.tag != "Player")
		{
			AudioSource _son = Harmony.SetSource(clipName);

			_son.pitch = Random.Range(.8f, 1.2f);

			_son.volume = volume;

			Harmony.Play(_son);
		}
	}
}

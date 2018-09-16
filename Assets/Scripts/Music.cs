using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
	private AudioSource son;
	
	void Start () {
		DontDestroyOnLoad(gameObject);

		son = GetComponent<AudioSource>();
		
		float _vol = son.volume;

		son.volume = 0;

		StartCoroutine(FadeIn(_vol));

	}

	IEnumerator FadeIn(float _vol)
	{		
		float _i = 0;

		while (_i < 1)
		{

			son.volume = Mathf.Lerp(0, _vol, _i);
			
			_i += Time.deltaTime;
			yield return null;
		}

		son.volume = _vol;

	}
	
}

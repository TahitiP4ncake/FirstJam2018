using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chateau : MonoBehaviour
{

	public SpriteRenderer rend;

	public List<Sprite> sprites;

	public bool built;
	
	private void OnTriggerEnter(Collider other)
	{
		if (built)
		{
			built = false;
			rend.sprite = sprites[1];

			AudioSource _son = Harmony.SetSource("chateau");

			_son.pitch = Random.Range(.9f, 1.1f);

			Harmony.Play(_son);

			
			Invoke("Rebuild", 15);
		}
	}

	void Rebuild()
	{
		built = true;
		rend.sprite = sprites[0];
	}
}

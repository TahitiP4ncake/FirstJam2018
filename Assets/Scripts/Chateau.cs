using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chateau : MonoBehaviour
{

	public SpriteRenderer rend;

	public List<Sprite> sprites;

	public Sprite brokenSprite;

	public bool built;

	public List<ParticleSystem> sands;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{

			if (built)
			{
				
				foreach (var _sand in sands)
				{
					_sand.Play();
				}

				
				built = false;
				rend.sprite = brokenSprite;

				AudioSource _son = Harmony.SetSource("chateau");

				_son.pitch = Random.Range(.9f, 1.1f);

				Harmony.Play(_son);


				
				Invoke("Rebuild", 15);
			}
		}
	}

	void Rebuild()
	{
		built = true;
		rend.sprite = sprites[Random.Range(0,sprites.Count)];
	}
}

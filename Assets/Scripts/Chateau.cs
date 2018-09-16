using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chateau : MonoBehaviour
{

	public SpriteRenderer rend;

	private SubtitleManager sub;

	public List<Sprite> sprites;

	public Sprite brokenSprite;

	public bool built;

	public List<ParticleSystem> sands;

	private void Start()
	{
		sub = FindObjectOfType<SubtitleManager>();
	}

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
				
				sub.Talk("nooo, my castle", true);
				
				Invoke("Rebuild", 15);

				
				built = false;
				rend.sprite = brokenSprite;
				
				

				AudioSource _son = Harmony.SetSource("SFX_sand_castle");

				_son.pitch = Random.Range(.9f, 1.1f);

				_son.volume = .4f;

				Harmony.Play(_son);


				
			}
		}
	}

	void Rebuild()
	{
		built = true;
		rend.sprite = sprites[Random.Range(0,sprites.Count)];
	}
}

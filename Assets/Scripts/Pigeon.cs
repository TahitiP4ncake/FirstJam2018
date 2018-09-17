using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
	private Vector3 origin;

	private Vector3 direction;

	public float maxDistancce;

	public int maxJumpNumber;

	private int jumpNumber;
	private int jumpIndex;

	public AnimationCurve jumpCurve;

	public float jumpforce;

	public float jumpDistance;

	public bool closeEnough;

	public SpriteRenderer rend;

	public List<Sprite> sprites;

	public Sprite flySprite;

	private float y;
	
	void Start ()
	{
		origin = transform.position;
		
		Invoke("Aim", Random.Range(1f, 2f));

		rend.sprite = sprites[Random.Range(0, sprites.Count)];

		//rend.castShadows = true;*

		y = transform.position.y;
	}


	private void Update()
	{
		if (closeEnough)
		{
			if (Input.GetMouseButtonDown(1))
			{
				StartFly();
			}
		}
	}

	void StartFly()
	{
		closeEnough = false;
		CancelInvoke();
		StopAllCoroutines();

		direction = transform.position +
		            new Vector3(Random.Range(-1f, 1f), 5, Random.Range(-1f, 1f));


		rend.sprite = flySprite;	

		AudioSource _son = Harmony.SetSource("SFX_pigeons");

		_son.pitch = Random.Range(.8f, 1.2f);

		Harmony.Play(_son);
		
		StartCoroutine(Fly());
		
		FindObjectOfType<PigeonManager>().Fly();
	}

	IEnumerator Fly()
	{
		Vector3 _origin = transform.position;
		
		float _i = 0;

		while (_i < 1)
		{

			transform.position = Vector3.Lerp(_origin, direction, _i);
			transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, _i);
			_i += Time.deltaTime;
			yield return null;
		}
	}
	
	void Aim()
	{
		direction = origin + new Vector3(Random.Range(-maxDistancce, maxDistancce), 0,
			            Random.Range(-maxDistancce, maxDistancce));

//		direction -= origin;
//		
//		direction.Normalize();

		direction = direction - transform.position;
		
		direction.Normalize();

		jumpIndex = 0;
		jumpNumber = Random.Range(2, maxJumpNumber);

		StartCoroutine(Jump());
	}

	IEnumerator Jump()
	{
		Vector3 _origin = transform.position;
		
		float _i = 0;

		while (_i < 1)
		{

			transform.position = new Vector3(Mathf.Lerp(_origin.x, _origin.x + direction.x/jumpDistance, _i), y + jumpCurve.Evaluate(_i) * jumpforce, Mathf.Lerp(_origin.z, _origin.z + direction.z/jumpDistance, _i));
			
			
			yield return null;
			_i += Time.deltaTime*3;
		}

		if (jumpIndex < jumpNumber)
		{
			jumpIndex++;
			StartCoroutine(Jump());
		}
		else
		{
			Invoke("Aim", Random.Range(1f, 2f));
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			closeEnough = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			closeEnough = false;
		}
	}
}

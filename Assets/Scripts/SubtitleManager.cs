using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;

public class SubtitleManager : MonoBehaviour
{

	public TextMeshProUGUI subtitles;

	public bool active;

	public float maxTime;

	private float timer;

	public WarpTextExample warp;

	private void Start()
	{
		subtitles.text = "";
	}

	void Update () {
		if (active)
		{
			timer += Time.deltaTime;

			if (timer >= maxTime)
			{
				timer = 0;
				active = false;
				warp.Stop();
				
				subtitles.text = "";
			}
				
		}
	}

	public void Talk(string _text, bool _important = false)
	{
		if (active && !_important)
		{
			return;
		}
		if (!active)
		{
			subtitles.text = _text;
		}
		else if (active && _important)
		{
			subtitles.text = _text;
		}

		active = true;
		timer = 0;

		warp.enabled = true;
		warp.Restart();

	}
}

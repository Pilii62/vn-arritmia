using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeToQuit : MonoBehaviour {

	private static bool created = false;

	void Awake()
	{
		if (!created)
		{
			DontDestroyOnLoad(this.gameObject);
			created = true;
			// Debug.Log("Awake: " + this.gameObject);
		}
	}

	void Update()
	{
		if (Input.GetKey("escape"))
			Application.Quit();

	}
}

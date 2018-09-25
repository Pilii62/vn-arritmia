using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeChange : MonoBehaviour {

	// Use this for initialization

	Camera mCamera;
	float baseSize;

	public float change = .5f;
	public float speed = .5f;

	void Start () {
		mCamera = GetComponent<Camera>();
		baseSize = mCamera.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		mCamera.orthographicSize = baseSize + change * Mathf.Sin(Time.time * speed);
	}
}

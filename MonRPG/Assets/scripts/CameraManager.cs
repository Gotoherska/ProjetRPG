using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public GameObject player;
	private float sensitivity = 10f;
	private float minSize = 5f;
	private float maxSize = 100f;
	private Vector3 offset;

	void Start () 
	{
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () 
	{		   
		transform.position = player.transform.position + offset;
		float size = Camera.main.orthographicSize;
		size -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
		size = Mathf.Clamp(size, minSize, maxSize);
		Camera.main.orthographicSize = size;

	}
}

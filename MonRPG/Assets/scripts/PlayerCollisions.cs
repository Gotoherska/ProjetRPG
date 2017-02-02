using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "water")
		{
			Debug.Log("plouf!");
		}
	}
}

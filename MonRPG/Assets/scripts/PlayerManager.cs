using UnityEngine;
using System.Collections;
using terrain;

public class PlayerManager : MonoBehaviour {
	public float speed;	
	private Rigidbody2D rb2d;
	//chunk number
	public int x = 0;
	public int y = 0;
	private TerrainDisplayer displayer;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		displayer = GetComponentInParent<TerrainDisplayer> ();
//		printBounds ();
	}
	void printBounds(){
		Debug.Log("x: " + displayer.minX + " ; " + displayer.maxX);
		Debug.Log ("y: " + displayer.minY + " ; " + displayer.maxY);
	}


	void OnCollisionEnter2D(Collision2D coll) {	
	}

	void LateUpdate()
	{
		//move
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 mouvement = new Vector2 (moveHorizontal, moveVertical);
		mouvement *= speed;
		rb2d.velocity = mouvement;

		//check position
		Vector2 pos = rb2d.position;
		bool isOut = false;
		if (pos.x > displayer.maxX) {
			isOut = true;
			pos.x = displayer.minX;
			x++;
		}
		if (pos.x < displayer.minX) {
			isOut = true;
			pos.x = displayer.maxX;
			x--;
		}
		if (pos.y > displayer.maxY ) {
			isOut = true;
			pos.y = displayer.minY;
			y++;
		}
		if (pos.y < displayer.minY) {
			isOut = true;
			pos.y = displayer.maxY;
			y--;
		}
		if(isOut){
			displayer.DisplayChunks(x,y);
			rb2d.MovePosition(pos);
		}
	}
}

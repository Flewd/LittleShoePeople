using UnityEngine;
using System.Collections;

public class leftTouchInput : MonoBehaviour {

	public GameObject player;
	ShoeController playerShoeController;

	// Use this for initialization
	void Start () {
		playerShoeController = player.GetComponent<ShoeController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		playerShoeController.JumpButtonPressed ();
		}
}

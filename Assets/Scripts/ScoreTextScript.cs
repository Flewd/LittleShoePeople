using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTextScript : MonoBehaviour {
    Text text;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        text = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "SCORE: " + player.GetComponent<PlayerScoreScript>().score.ToString();
	}
}

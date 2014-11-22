using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthTextScript : MonoBehaviour {

    Text text;
    public GameObject player;
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<ShoeController>().gameState == ShoeController.GameStates.play)
        text.text = "HEALTH: " + player.GetComponent<HealthSystemScript>().currentHealth.ToString();

	}
}

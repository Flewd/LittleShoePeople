using UnityEngine;
using System.Collections;

public class CreditScriptC : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Time.timeScale = 3;
            GameObject.Find("LevelSpawner").GetComponent<AudioSource>().pitch = 3f;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Time.timeScale = 1;
            GameObject.Find("LevelSpawner").GetComponent<AudioSource>().pitch = 1f;
        }
        else if (Input.anyKeyDown)
        {
            Application.LoadLevel("mikeScene");
        }
	}
}

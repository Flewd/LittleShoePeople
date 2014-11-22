using UnityEngine;
using System.Collections;

public class BackgroundSpawnScript : MonoBehaviour {
    GameObject player;
    public GameObject background;
    float timer;
    public float timerReset = 2.5f;
    public float distanceFromCameraCenter = 18f;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<ShoeController>().gameState == ShoeController.GameStates.play)
        {
            timer += Time.deltaTime;
            if (timer >= timerReset)
            {
                GameObject newBackgrond = (GameObject)Instantiate(background, new Vector3(Camera.main.transform.position.x + distanceFromCameraCenter, 0.6000061f, 2.42f), new Quaternion(0f, 0f, 0f, 0f));
                timer = 0f;
            }
        }
	}
}

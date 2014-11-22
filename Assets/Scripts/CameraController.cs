using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject shoePlayer;
    Vector3 cameraOffset = new Vector3(7, 0, -10);
    public bool toiletBegan = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (toiletBegan == false)
        {
            gameObject.transform.position = new Vector3(shoePlayer.transform.position.x + cameraOffset.x, gameObject.transform.position.y, shoePlayer.transform.position.z + cameraOffset.z);
        }
        if(Input.GetKeyDown(KeyCode.RightBracket))
        {
            Time.timeScale = 3;
            GameObject.Find("LevelSpawner").GetComponent<AudioSource>().pitch = 3f;
        }
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            Time.timeScale = 1;
            GameObject.Find("LevelSpawner").GetComponent<AudioSource>().pitch = 1f;
        }
        
	}
}

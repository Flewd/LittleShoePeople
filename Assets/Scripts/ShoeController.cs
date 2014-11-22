using UnityEngine;
using System.Collections;


public class ShoeController : MonoBehaviour {

    public enum GameStates { start, play, end };
    public GameStates gameState = GameStates.start;

    public GameObject PreGameUI;
    public GameObject InGameUI;
    public GameObject PostGameUI;

    float jumpCounter = 0;
    float needleCounter = 0;

    public GameObject needle;
    Vector3 needleUpOffset = new Vector3(0, 1, 0);
    bool needleDown = true;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {

        switch (gameState)
        {
            case GameStates.start:
                startUpdate();
                break;
            case GameStates.play:
                playUpdate();
                break;
            case GameStates.end:
                endUpdate();
                break;
        }
	}

    void startUpdate()
    {
        PreGameUI.SetActive(true);
        InGameUI.SetActive(false);
        PostGameUI.SetActive(false);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameState = GameStates.play;
            GameObject.Find("LevelSpawner").GetComponent<LevelSpawner>().startGenerator();
        }
    }

    void playUpdate()
    {
        PreGameUI.SetActive(false);
        InGameUI.SetActive(true);
        PostGameUI.SetActive(false);

        jumpCounter -= Time.deltaTime;
        needleCounter -= Time.deltaTime;

        gameObject.transform.position += new Vector3(6 * Time.deltaTime, 0, 0);

        if (jumpCounter <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpCounter = 1.5f;
                gameObject.rigidbody.AddForce(0, 620, 0);
                //          gameObject.rigidbody.AddRelativeTorque(0, 0, 35);
            }
        }

        if (Input.GetKeyDown(KeyCode.S) && needleCounter <= 0 && needleDown == true)
        {
            needle.transform.position = needle.transform.position + needleUpOffset;
            needle.collider.enabled = true;
            needleCounter = 0.50F;
            needleDown = false;
        }
        if (needleCounter <= 0.25F && needleDown == false)
        {
            needle.transform.position = needle.transform.position - needleUpOffset;
            needleDown = true;
            needle.collider.enabled = false;
        }
    }
    void endUpdate()
    {
        PreGameUI.SetActive(false);
        InGameUI.SetActive(false);
        PostGameUI.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "nail")
        {

            gameObject.SendMessage("SubtractHealth", 25f);
            other.collider.enabled = false;
            
        }
        if (other.gameObject.tag == "foot")
        {
            if (needleDown == true)
            {
                gameObject.SendMessage("SubtractHealth", 25f);
                other.collider.enabled = false;
                Debug.Log("foot hit");
            }

        }
    }
}

using UnityEngine;
using System.Collections;


public class ShoeController : MonoBehaviour {

    public enum GameStates { start, play, end };
    public GameStates gameState = GameStates.start;

    public GameObject PreGameUI;
    public GameObject InGameUI;
    public GameObject PostGameUI;

    public Sprite bootWalking1;
    public Sprite bootWalking2;
    public Sprite bootWalking3;
    float animationTimer = 0.5f;
    int animationIndex = 1;

    public float scoreToAdd; 
    float jumpCounter = 0;
    float needleCounter = 0;
    float speedPowerupTimer = 0f;
    public float speedPowerupTimerReset = 5f; //The time in which the shoe people get back out of the shoe an the rollerskates leave and time is slow again. long comments ftw! hi mike! 
    float slowPowerupTimer = 0f;
    public float slowPowerupTimerReset = 0.375f;

    public GameObject needle;
    Vector3 needleUpOffset = new Vector3(0, 1, 0);
    bool needleDown = true;
    bool isSpeedPower = false;
    bool isSlowPower = false;

    float footCooldown = 2;

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
            gameObject.GetComponent<SpriteRenderer>().sprite = bootWalking1;
            GameObject.Find("LevelSpawner").GetComponent<LevelSpawner>().startGenerator();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            //Show Credits
            Application.LoadLevel("Credits");
        }
    }

    void playUpdate()
    {
        PreGameUI.SetActive(false);
        InGameUI.SetActive(true);
        PostGameUI.SetActive(false);

        jumpCounter -= Time.deltaTime;
        needleCounter -= Time.deltaTime;
        footCooldown += Time.deltaTime;

        gameObject.transform.position += new Vector3(6 * Time.deltaTime, 0, 0);

        if (jumpCounter <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpCounter = 1.5f;
                gameObject.rigidbody.AddForce(0, 650, 0);
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

        //This is the toggle for the speedPowerUp and adjusts the timescale and the pitch of the music.
        if (isSpeedPower)
        {
            Time.timeScale = 1.5f;
            GameObject.Find("LevelSpawner").GetComponent<AudioSource>().pitch = 1.5f;
            speedPowerupTimer += Time.deltaTime;
            Debug.Log("Speed Powerup Timer: " + speedPowerupTimer);
            if (speedPowerupTimer >= speedPowerupTimerReset)
            {
                Debug.Log("Speed Power Up Expired;;;;;;");
                speedPowerupTimer = 0f;
                isSpeedPower = !isSpeedPower;
            }
            
        }
        if (isSlowPower)
        {
            Time.timeScale = .75f;
            GameObject.Find("LevelSpawner").GetComponent<AudioSource>().pitch = .75f;
            slowPowerupTimer += Time.deltaTime;
            Debug.Log("Slow Power Timer: " + slowPowerupTimer);
            if (slowPowerupTimer >= slowPowerupTimerReset)
            {
                Debug.Log("Slow Powerup Over");
                slowPowerupTimer = 0f;
                isSlowPower = !isSlowPower;
            }
        }
        if (!isSpeedPower && !isSlowPower)
        {
            Time.timeScale = 1f;
            GameObject.Find("LevelSpawner").GetComponent<AudioSource>().pitch = 1f;
        }

        animationTimer -= Time.deltaTime;
        if (animationTimer <= 0)
        {
            

            switch (animationIndex)
            {
                case 1: gameObject.GetComponent<SpriteRenderer>().sprite = bootWalking1; break;
                case 2: gameObject.GetComponent<SpriteRenderer>().sprite = bootWalking2; break;
                case 3: gameObject.GetComponent<SpriteRenderer>().sprite = bootWalking3; break;
            }
            
            if (animationIndex >= 3)
            {
                animationIndex = 0;
            }
            animationIndex++;
               
            animationTimer = 0.5f;
        }
        
    }
    void endUpdate()
    {
        PreGameUI.SetActive(false);
        InGameUI.SetActive(false);
        PostGameUI.SetActive(true);

        if (Input.anyKeyDown)
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
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
            if (needleDown == true && footCooldown >= 2)
            {
                other.collider.enabled = false;
                gameObject.SendMessage("SubtractHealth", 25f);
                footCooldown = 0;
            }

        }
        if (other.gameObject.tag == "coin")
        {
            gameObject.GetComponent<PlayerScoreScript>().AddScore(scoreToAdd);
            other.collider.gameObject.GetComponent<AudioSource>().Play();
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            other.gameObject.collider.enabled = false;
            Destroy(other.gameObject, 2);
        }
        if (other.gameObject.tag == "speed") //do drugs and stuff
        {
            isSpeedPower = true;
            if (isSlowPower)
            {
                isSlowPower = !isSlowPower; //Toggle the other speed powerup because both being active will fuck things ups.
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "slow")
        {
            isSlowPower = true;
            if (isSpeedPower)
            {
                isSpeedPower = !isSpeedPower; //Toggle the other speed powerup because both being active will fuck things ups.
            }
            Destroy(other.gameObject);
        }
    }
}

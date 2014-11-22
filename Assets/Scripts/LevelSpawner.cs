using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSpawner : MonoBehaviour {

    public GameObject player;

    public enum musicEventType {nail,foot,mouseTrap,slow,speed};

    public class musicEvent
    {
        public musicEventType eventType;
        public float eventTime;

        public musicEvent(musicEventType _eventType,float _eventTime)
        {
            eventType = _eventType;
            eventTime = _eventTime;
        }
    }

    musicEvent[] eventsList = new musicEvent[]{
        new musicEvent(musicEventType.slow, 4.9f),
        new musicEvent(musicEventType.nail, 8.892f),
        new musicEvent(musicEventType.nail, 12.943f),
        new musicEvent(musicEventType.speed, 20.97f),
        new musicEvent(musicEventType.foot, 35.908f),
        new musicEvent(musicEventType.nail, 41.87f),
        new musicEvent(musicEventType.nail, 54.964f),
        new musicEvent(musicEventType.nail, 66.858f),
        new musicEvent(musicEventType.foot, 73.895f),
        new musicEvent(musicEventType.nail, 80.679f),
        new musicEvent(musicEventType.nail, 103.6f),
        new musicEvent(musicEventType.foot, 111.904f)
    };

    AudioSource musicPlayer;
    int eventIndex = 0;

    bool gameStarted = false;
    float musicTimer;

    float pointCounter = 2;
	// Use this for initialization
	void Start () {
        musicPlayer = gameObject.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

        if (gameStarted == true)
        {
            musicTimer += Time.deltaTime;

            //spawn events
            if (eventIndex <= eventsList.Length - 1)
            {
                if (musicTimer >= eventsList[eventIndex].eventTime - 3)
                {
                    switch (eventsList[eventIndex].eventType)
                    {
                        case musicEventType.nail: spawnNail(); break;
                        case musicEventType.foot: spawnFoot(); break;
                        case musicEventType.mouseTrap: spawnMouseTrap(); break;
                        case musicEventType.slow: spawnSlow(); break;
                        case musicEventType.speed: spawnSpeed(); break;
                    }
                    eventIndex++;
                }
            }


            //spawn points
            pointCounter -= Time.deltaTime;
            if (pointCounter <= 0)
            {
                GameObject point = Instantiate(Resources.Load("PointPickup", typeof(GameObject))) as GameObject;
                point.transform.position = new Vector3(player.transform.position.x + 12,-1, 0);
                GameObject.Destroy(point, 10);

                pointCounter = 2;
            }
        }
	}

    float jumpDistance = 1.85f;
    void spawnNail()
    {
        GameObject nail = Instantiate(Resources.Load("Nail", typeof(GameObject))) as GameObject;
        nail.transform.position = new Vector3(player.transform.position.x + 18 + jumpDistance, -1.85f, -0.5f);
        GameObject.Destroy(nail, 10);

    }
    void spawnFoot()
    {
        GameObject foot = Instantiate(Resources.Load("Shadow", typeof(GameObject))) as GameObject;
        foot.transform.position = new Vector3(player.transform.position.x + 18 + jumpDistance, -1.7f, -1.7f);
        StartCoroutine(DropFootAfterSeconds(2.75f, foot));
        GameObject.Destroy(foot, 10);
    }
    void spawnMouseTrap()
    {
        GameObject mouseTrap = Instantiate(Resources.Load("MouseTrap", typeof(GameObject))) as GameObject;
        mouseTrap.transform.position = new Vector3(player.transform.position.x + 18 + jumpDistance, 3, -0.5f);
        GameObject.Destroy(mouseTrap, 10);
    }
    void spawnSlow()
    {
        GameObject slow = Instantiate(Resources.Load("SlowPowerUp", typeof(GameObject))) as GameObject;
        slow.transform.position = new Vector3(player.transform.position.x + 18 + jumpDistance, -1.85f, -0.5f);
        GameObject.Destroy(slow, 10);
    }
    void spawnSpeed()
    {
        GameObject speed = Instantiate(Resources.Load("SpeedPickup", typeof(GameObject))) as GameObject;
        speed.transform.position = new Vector3(player.transform.position.x + 18 + jumpDistance, -1.85f, -0.5f);
        GameObject.Destroy(speed, 10);
    }

    IEnumerator DropFootAfterSeconds(float sec, GameObject foot)
    {
        yield return new WaitForSeconds(sec);
        foot.GetComponent<ShadowBehaviorScript>().DropFoot();
    }

    public void startGenerator()
    {
        musicPlayer.Play();
        gameStarted = true;
    }
}

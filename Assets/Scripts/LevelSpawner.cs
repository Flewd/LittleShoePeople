using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSpawner : MonoBehaviour {

    public GameObject player;

    public enum musicEventType {nail,foot};

    [System.Serializable]
    public class musicEvent
    {
        public musicEventType eventType;
        public float eventTime;
    }

    public musicEvent[] eventsList;
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
                    if (eventsList[eventIndex].eventType == musicEventType.nail)
                    {
                        spawnNail();
                    }
                    else if (eventsList[eventIndex].eventType == musicEventType.foot)
                    {
                        spawnFoot();
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
        nail.transform.position = new Vector3(player.transform.position.x + 18 + jumpDistance, -1.7f, -1.7f);
        GameObject.Destroy(nail, 10);

    }
    void spawnFoot()
    {
        GameObject foot = Instantiate(Resources.Load("Shadow", typeof(GameObject))) as GameObject;
        foot.transform.position = new Vector3(player.transform.position.x + 18 + jumpDistance, -1.7f, -1.7f);
        StartCoroutine(DropFootAfterSeconds(2.75f, foot));
        GameObject.Destroy(foot, 10);
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

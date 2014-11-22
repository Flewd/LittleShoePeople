using UnityEngine;
using System.Collections;

public class ShadowBehaviorScript : MonoBehaviour {
    public GameObject shoe;
    GameObject shadow; //TODO: Replace all the shadow 
    GameObject foot;

    public float shadowSeekSpeed;
    public float stompTime; //Time that the foot will graciously insert itself into the shoe. 
    public float wiggleRoom;
    float shadowTimer;

    float spawnXPosition;

    bool isSeeking;
    bool playerFound;
    bool hitRightBound;
	// Use this for initialization
	void Start () {
        shadow = gameObject; //I derped. This will be changed / removed soon. Originally was a footscript and this was not changed because lazy. 
        foot = GameObject.Find("Foot");
        isSeeking = true;
        hitRightBound = false;
        spawnXPosition = gameObject.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (isSeeking)
        {
            shadow.gameObject.active = true;
            ShadowSeek();
        }
        else if (!isSeeking)
        {
            //Hide the shadow and do not seek and whatnot stuffs.
            shadow.gameObject.active = false;
        }


	}

    //This will trigger the shadow to start seeking the shoe. 
    void ShadowSeek()
    {
        if (hitRightBound)
        {
            shadow.gameObject.rigidbody.MovePosition(new Vector3(shadow.gameObject.transform.position.x - shadowSeekSpeed * Time.deltaTime, shadow.gameObject.transform.position.y, shadow.gameObject.transform.position.z));
            if (shadow.gameObject.transform.position.x <= spawnXPosition + wiggleRoom * -1f)
            {
                hitRightBound = false;
            }
        }
        if (!hitRightBound)
        {
            shadow.gameObject.rigidbody.MovePosition(new Vector3(shadow.gameObject.transform.position.x + shadowSeekSpeed * Time.deltaTime, shadow.gameObject.transform.position.y, shadow.gameObject.transform.position.z));
            if (shadow.gameObject.transform.position.x >= spawnXPosition + wiggleRoom)
            {
                hitRightBound = true;
            }
        }
        /*TODO: Move left to right.
         * If Shoe in collider for X time, SpawnFoot();
         */
    }

    //This will make the foot come straight down when the shoe (Player) is in the shadow for too long. 
    void SpawnFoot ()
    {
        Debug.Log("Foot Should Go Boom!");
        foot.SendMessage("SnapToShoe");
        //TODO: Foot moves straight down. 
    }

   /* This shit aint needed no more brah. 
    * void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name + "Collided!");
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject == shoe)
        {
            shadowTimer += Time.deltaTime;
           // Debug.Log("Timer: " + shadowTimer);
            if (shadowTimer >= stompTime)
            {
                SpawnFoot();
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == shoe)
        {
            shadowTimer = 0f;
            Debug.Log("Timer Reset to 0f!");
        }
    }
    */
}

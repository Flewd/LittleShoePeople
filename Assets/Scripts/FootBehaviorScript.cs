using UnityEngine;
using System.Collections;

public class FootBehaviorScript : MonoBehaviour {
    public GameObject shoe;
    GameObject shadow;
    GameObject foot;

    public float shadowSeekSpeed;

    bool isSeeking;
    bool playerFound;
    bool hitRightBound;
	// Use this for initialization
	void Start () {
        shadow = GameObject.Find("Shadow");
        foot = GameObject.Find("foot");
        isSeeking = true;
        hitRightBound = false;
	}
	
	// Update is called once per frame
	void Update () {
	
        if (isSeeking)
        {
            ShadowSeek();
        }
	}

    //This will trigger the shadow to start seeking the shoe. 
    void ShadowSeek()
    {
        if (hitRightBound)
        {
            shadow.gameObject.transform.position = new Vector3(shadow.gameObject.transform.position.x - shadowSeekSpeed * Time.deltaTime, shadow.gameObject.transform.position.y, shadow.gameObject.transform.position.z);
            if (shadow.gameObject.transform.position.x <= -9f)
            {
                hitRightBound = false;
            }
        }
        if (!hitRightBound)
        {
            shadow.gameObject.transform.position = new Vector3(shadow.gameObject.transform.position.x + shadowSeekSpeed * Time.deltaTime, shadow.gameObject.transform.position.y, shadow.gameObject.transform.position.z);
            if (shadow.gameObject.transform.position.x >= 9f)
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
        //TODO: Foot moves straight down. 
    }
}

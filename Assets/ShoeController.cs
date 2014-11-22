﻿using UnityEngine;
using System.Collections;


public class ShoeController : MonoBehaviour {

    public enum GameStates { start, play, end };
    public GameStates gameState = GameStates.start;

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameState = GameStates.play;
        }
    }

    void playUpdate()
    {
        jumpCounter -= Time.deltaTime;
        needleCounter -= Time.deltaTime;

        gameObject.transform.position += new Vector3(2 * Time.deltaTime, 0, 0);

        if (jumpCounter <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpCounter = 2;
                gameObject.rigidbody.AddForce(0, 400, 0);
                //          gameObject.rigidbody.AddRelativeTorque(0, 0, 35);
            }
        }

        if (Input.GetKeyDown(KeyCode.S) && needleCounter <= 0 && needleDown == true)
        {
            needle.transform.position = needle.transform.position + needleUpOffset;
            needleCounter = 0.50F;
            needleDown = false;
        }
        if (needleCounter <= 0.25F && needleDown == false)
        {
            needle.transform.position = needle.transform.position - needleUpOffset;
            needleDown = true;
        }
    }
    void endUpdate()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "nail")
        {
            Debug.Log("NAIL HIT");
            collision.collider.enabled = false;
        }
    }
}
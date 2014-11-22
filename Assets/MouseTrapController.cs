using UnityEngine;
using System.Collections;

public class MouseTrapController : MonoBehaviour {

    public Sprite mouseTrap2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void switchMouseTrapSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = mouseTrap2;
    }
}

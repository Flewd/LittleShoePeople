using UnityEngine;
using System.Collections;

public class FootBehaviorScript : MonoBehaviour {
    GameObject shoe;
    bool dropTheShoe;
    public float dropSpeed;
	// Use this for initialization
	void Start () {
        shoe = GameObject.Find("Shoe");
	}
	
	// Update is called once per frame
	void Update () {
	    if (dropTheShoe)
        {
            Drop();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ToggleDrop();
        }
	}
    
    void ToggleDrop()
    {
        dropTheShoe = !dropTheShoe;
    }

    void SnapToShoe()
    {
        gameObject.transform.SetParent(shoe.transform);
        gameObject.transform.localPosition = new Vector3(0f, shoe.transform.position.y + 7.5f, 0f);
    }

    void Drop()
    {
        gameObject.transform.SetParent(null,true);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - dropSpeed * Time.deltaTime, gameObject.transform.position.x);
    }
}

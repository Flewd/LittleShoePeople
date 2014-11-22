using UnityEngine;
using System.Collections;

public class FootBehaviorScript : MonoBehaviour {
    GameObject shoe;
	// Use this for initialization
	void Start () {
        shoe = GameObject.Find("Shoe");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SnapToShoe()
    {
        gameObject.transform.SetParent(shoe.transform);
        gameObject.transform.localPosition = new Vector3(0f, shoe.transform.position.y + 7.5f, 0f);
    }

    void Drop()
    {

    }
}

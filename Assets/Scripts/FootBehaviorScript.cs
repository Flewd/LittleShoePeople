using UnityEngine;
using System.Collections;

public class FootBehaviorScript : MonoBehaviour {
    GameObject shoe;
    bool dropTheShoe;
    public float dropSpeed;
    public GameObject shadow;
	// Use this for initialization
	void Start () {
     //   shoe = GameObject.Find("Shoe");
	}
	
	// Update is called once per frame
	void Update () {
	    if (dropTheShoe)
        {
       //     Drop();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
        //    ToggleDrop();
        }
	}
    
    public void ToggleDrop()
    {
    //    dropTheShoe = !dropTheShoe;
    }

    void SnapToShoe()
    {
   //     gameObject.transform.SetParent(shoe.transform);
   //     gameObject.transform.localPosition = new Vector3(0f, shoe.transform.position.y + 7.5f, 0f);
    }

    public void Drop()
    {
     //   gameObject.transform.SetParent(null,true);
     //   gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - dropSpeed * Time.deltaTime, gameObject.transform.position.x);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "needle")
        {
            Debug.Log("foot stab");
            shadow.rigidbody.velocity = new Vector3(shadow.rigidbody.velocity.x * -1, shadow.rigidbody.velocity.y * -1, shadow.rigidbody.velocity.z * -1);
        }
    }
}

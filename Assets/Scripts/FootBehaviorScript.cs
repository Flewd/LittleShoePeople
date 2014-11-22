using UnityEngine;
using System.Collections;

public class FootBehaviorScript : MonoBehaviour {

    public GameObject shadow;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "needle")
        {
            gameObject.rigidbody.velocity = new Vector3(gameObject.rigidbody.velocity.x * -1, gameObject.rigidbody.velocity.y * -1, gameObject.rigidbody.velocity.z * -1);
        }
    }
}

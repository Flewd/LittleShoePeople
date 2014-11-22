using UnityEngine;
using System.Collections;

public class ShadowBehaviorScript : MonoBehaviour {

    public GameObject foot;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void DropFoot ()
    {
        foot.transform.parent = null;
        foot.rigidbody.AddForce(0, - 900, 0);
        Destroy(foot, 10);
        
    }

}

using UnityEngine;
using System.Collections;

public class CreditScriptC : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (gameObject.transform.position.y >= 3520f)
        {
            gameObject.transform.position = new Vector3(10f, -484.4f, -80f);
        }
        if (Input.anyKeyDown)
        {
            Application.LoadLevel("mikeScene");
        }
	}
}

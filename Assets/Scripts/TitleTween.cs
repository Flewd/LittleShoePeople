using UnityEngine;
using System.Collections;

public class TitleTween : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.MoveTo(gameObject ,gameObject.transform.position - new Vector3(0, 250, 0),2f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

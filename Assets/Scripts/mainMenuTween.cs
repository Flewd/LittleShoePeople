using UnityEngine;
using System.Collections;

public class mainMenuTween : MonoBehaviour {

    Hashtable ht = new Hashtable();

	// Use this for initialization
	void Start () {

        ht.Add("z",1.75f);
        ht.Add("time",0.5f);
        ht.Add("easetype", iTween.EaseType.linear);
        ht.Add("loopType", iTween.LoopType.pingPong);

        iTween.RotateTo(gameObject, ht);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

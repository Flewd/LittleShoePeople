using UnityEngine;
using System.Collections;

public class mainMenuTween : MonoBehaviour {

    public bool direction;

    Hashtable ht = new Hashtable();

	// Use this for initialization
	void Start () {

        if (direction == true)
        {
            ht.Add("z", -26.75f);
            ht.Add("time", 0.5f);
            ht.Add("easetype", iTween.EaseType.linear);
            ht.Add("loopType", iTween.LoopType.pingPong);
        }
        else
        {
            ht.Add("z", 26.75f);
            ht.Add("time", 0.6f);
            ht.Add("easetype", iTween.EaseType.linear);
            ht.Add("loopType", iTween.LoopType.pingPong);
        }
        iTween.RotateTo(gameObject, ht);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

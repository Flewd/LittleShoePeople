using UnityEngine;
using System.Collections;

public class endGameTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(BeginCutScene());
        }

    }


    IEnumerator BeginCutScene()
    {       
         yield return 6.8f;    //Wait one frame
         gameObject.GetComponent<AudioSource>().Play();
  
    }
}

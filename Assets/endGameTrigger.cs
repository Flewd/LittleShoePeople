using UnityEngine;
using System.Collections;

public class endGameTrigger : MonoBehaviour {

    public GameObject toiletSplash;
    public GameObject toiletPlatform;

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
        yield return new WaitForSeconds(6.8f);
         gameObject.GetComponent<AudioSource>().Play();
         toiletSplash.SetActive(true);
         toiletPlatform.SetActive(false);
         StartCoroutine(WaitThenSwitchCredits());
  
    }

    IEnumerator WaitThenSwitchCredits()
    {
        yield return new WaitForSeconds(4);
        Application.LoadLevel("Credits");
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnableIan : MonoBehaviour {
    public GameObject ian;
    public GameObject scrollingText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (scrollingText.GetComponent<RectTransform>().position.y >= 22566)
        {
            ian.SetActive(true);
        }
	}
}

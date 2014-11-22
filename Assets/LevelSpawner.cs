using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSpawner : MonoBehaviour {

    public enum musicEventType {nail,foot};

    [System.Serializable]
    public class musicEvent
    {
        public musicEventType eventType;
        public float eventTime;
    }

    public musicEvent[] eventsList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

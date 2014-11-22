using UnityEngine;
using System.Collections;

public class PlayerScoreScript : MonoBehaviour {
    public float score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddScore (float amount)
    {
        score += amount;
    }

    public void SubtractScore (float amount)
    {
        score -= amount;
    }
}

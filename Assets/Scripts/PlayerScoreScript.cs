using UnityEngine;
using System.Collections;

public class PlayerScoreScript : MonoBehaviour {
    public float score;

    public void AddScore (float amount)
    {
        score += amount;
    }

    public void SubtractScore (float amount)
    {
        score -= amount;
    }
}

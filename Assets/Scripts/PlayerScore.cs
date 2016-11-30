using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

    public int playerNum, score;
    Text playerScore;

	// Use this for initialization
	void Start () {
        playerScore = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        playerScore.text = "Player" + playerNum + " Score: " + score;
	}
}

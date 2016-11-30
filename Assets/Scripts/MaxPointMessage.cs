using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MaxPointMessage : MonoBehaviour {

    public int maxScore;
    Text midMessage;

	// Use this for initialization
	void Start () {
        midMessage = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        midMessage.text = "First to " + maxScore + " wins!";
	}
}

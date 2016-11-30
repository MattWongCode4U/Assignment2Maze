using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinnerTextScript : MonoBehaviour {

    public GameObject gm;
    private GameManagerScript gameManager;

    // Use this for initialization
    void Start () {
        gameManager = gm.GetComponent<GameManagerScript>();

    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = gameManager.winner + " is the Winner!";
	}
}

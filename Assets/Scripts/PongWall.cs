using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PongWall : MonoBehaviour {
	
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Player") {
			SceneManager.LoadScene("Menu");
		}
	}
}

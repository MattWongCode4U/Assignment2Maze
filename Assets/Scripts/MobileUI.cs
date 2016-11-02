using UnityEngine;
using System.Collections;

public class MobileUI : MonoBehaviour {
	
	public void toggleFog() {
		GameObject.FindWithTag("Player")
			.GetComponentInChildren<FogSystemScript>().ToggleFog();
	}

	public void toggleNoclip() {
		GameObject.FindWithTag("Player")
			.GetComponent<PlayerMovement>().ToggleNoclip();
	}
}

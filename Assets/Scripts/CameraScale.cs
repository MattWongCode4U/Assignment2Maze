using UnityEngine;
using System.Collections;

public class CameraScale : MonoBehaviour {

    float KEEP_ASPECT = 16 / 9f;

	// Use this for initialization
	void Start () {
        float ratio = Screen.width / (float)Screen.height;
        float percent = 1 - (ratio / KEEP_ASPECT);

        GetComponent<Camera>().rect = new Rect(0f, (percent / 2), 1f, (1 - percent));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

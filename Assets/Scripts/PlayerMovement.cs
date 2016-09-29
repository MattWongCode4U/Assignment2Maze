using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float horSpeed = 0.1f;
    public float verSpeed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void FixedUpdate() {
        transform.Translate(Input.GetAxis("Horizontal") * horSpeed, 0, Input.GetAxis("Vertical") * verSpeed);
    }
}

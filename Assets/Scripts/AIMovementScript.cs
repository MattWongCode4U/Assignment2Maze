using UnityEngine;
using System.Collections;

public class AIMovementScript : MonoBehaviour {

    GameObject playerobj;
    public float speed = 1.0f;

	// Use this for initialization
	void Start () {
        playerobj = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = playerobj.transform.position;
        targetPosition.y = this.transform.position.y;
        this.transform.LookAt(targetPosition);
	}

    void FixedUpdate() {
        moveForward();
    }

    void moveForward() {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}

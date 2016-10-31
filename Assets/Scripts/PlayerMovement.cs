using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1f;
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	
	private float minimumX = -360F;
	private float maximumX = 360F;
	private float minimumY = -60F;
	private float maximumY = 60F;
	private Rigidbody rb;
	private float rotationX = 0F;
	private float rotationY = 0F;
	private Quaternion originalRotation;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		Cursor.lockState = CursorLockMode.Locked;

		// Make the rigid body not change rotation
		if (rb)
			rb.freezeRotation = true;
		originalRotation = transform.localRotation;
	}
	public static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp (angle, min, max);
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		if (rb.isKinematic)
			move (h, v, 0.3f);
		else
			move (h, v, 1f);
		float mx = Input.GetAxis ("Mouse X");
		float my = Input.GetAxis ("Mouse Y");
		cameraRotate (mx, my);
	}

	void LateUpdate() {
		if (Input.GetKey (KeyCode.BackQuote)) {
			rb.isKinematic = !rb.isKinematic; // Toggle
		}
	}

	void move(float hor, float vert, float multiplier) {
		Vector3 forward = Camera.main.transform.forward * (vert * speed * multiplier);
		forward.y = 0f;
		Vector3 right = Camera.main.transform.right * (hor * speed * multiplier);
		right.y = 0f;
		if (!rb.isKinematic) {
			//transform.position += forward;
			//transform.position += right;
			rb.velocity = forward + right;
		} else {
			transform.position += forward;
			transform.position += right;
		}
	}

	void cameraRotate(float mx, float my) {
		if (axes == RotationAxes.MouseXAndY)
		{
			rotationX += mx * sensitivityX;
			rotationY += my * sensitivityY;
			rotationX = ClampAngle (rotationX, minimumX, maximumX);
			rotationY = ClampAngle (rotationY, minimumY, maximumY);
			Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);
			transform.localRotation = originalRotation * xQuaternion * yQuaternion;
		}
		else if (axes == RotationAxes.MouseX)
		{
			rotationX += mx * sensitivityX;
			rotationX = ClampAngle (rotationX, minimumX, maximumX);
			Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			transform.localRotation = originalRotation * xQuaternion;
		}
		else
		{
			rotationY += my * sensitivityY;
			rotationY = ClampAngle (rotationY, minimumY, maximumY);
			Quaternion yQuaternion = Quaternion.AngleAxis (-rotationY, Vector3.right);
			transform.localRotation = originalRotation * yQuaternion;
		}
	}
}

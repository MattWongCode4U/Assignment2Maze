using UnityEngine;
using CnControls;
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
	private bool pc, mac, joystick;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		Cursor.lockState = CursorLockMode.Locked;
        string[] joysticks = Input.GetJoystickNames();
		if (    Application.platform == RuntimePlatform.WindowsPlayer
			||  Application.platform == RuntimePlatform.WindowsEditor) {
			pc = true;
            GameObject.Find("Movestick").SetActive(false);
            GameObject.Find("Viewstick").SetActive(false);
        } else if(
                Application.platform == RuntimePlatform.OSXPlayer 
            ||  Application.platform == RuntimePlatform.OSXEditor) {
            mac = true;
            GameObject.Find("Movestick").SetActive(false);
            GameObject.Find("Viewstick").SetActive(false);
        } else {
            pc = mac = false;
            joystick = false;
        }
        if (joysticks.Length != 0) joystick = true;
		if (rb) rb.freezeRotation = true;
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
		float h = CnInputManager.GetAxisRaw ("Horizontal");
		float v = CnInputManager.GetAxisRaw ("Vertical");
        if (rb.isKinematic)
			move (h, v, 0.05f);
		else
			move (h, v, 1f);
		pickCameraAxes();
	}

	void LateUpdate() {
		if (Input.GetKeyDown (KeyCode.BackQuote) || Input.GetKey(KeyCode.Joystick1Button3)) {
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

	void pickCameraAxes() {
		float mx = 0, my = 0;
		if ((pc && !joystick )|| (mac && !joystick)) {
            mx = CnInputManager.GetAxisRaw("Mouse X");
            my = CnInputManager.GetAxisRaw("Mouse Y");
        }
        else if (pc && joystick) {
            mx = CnInputManager.GetAxisRaw("HJoystickXboxPC");
            my = CnInputManager.GetAxisRaw("VJoystickXboxPC");
        }
        else if (mac && joystick) {
            mx = CnInputManager.GetAxisRaw("HJoystickXboxMac");
            my = CnInputManager.GetAxisRaw("VJoystickXboxMac");
        }
        else {
            mx = CnInputManager.GetAxisRaw("HorizontalJoystick");
            my = CnInputManager.GetAxisRaw("VerticalJoystick");
        }
		cameraRotate (mx, my);
	}
}

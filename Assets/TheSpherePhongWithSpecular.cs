using UnityEngine;
using System.Collections;

public class TheSpherePhongWithSpecular : MonoBehaviour {

	private float incr;

	// Use this for initialization
	void Start () {
		incr = 0.005f;
	}

	// Update is called once per frame
	void Update () {
		Renderer rend = GetComponent<Renderer> ();
		float ambientIntensity = rend.material.GetFloat ("_AmbientLighIntensity");
		ambientIntensity += incr;
		if ((ambientIntensity > 1) || (ambientIntensity < 0))
			incr = -incr;
		rend.material.SetFloat ("_AmbientLighIntensity", ambientIntensity);
		Vector4 dld = rend.material.GetVector ("_DiffuseDirection");
		dld.x += 2*incr;
		rend.material.SetVector ("_DiffuseDirection", dld);
	}
}

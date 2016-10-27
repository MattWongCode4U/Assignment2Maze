using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    private GameObject dropdownobj;
    private Dropdown dropdown;

	// Use this for initialization
	void Start () {
        dropdownobj = GameObject.Find("DayDropdown");
        dropdown = dropdownobj.GetComponent<Dropdown>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goToScene(string scene) {
        PlayerPrefs.SetInt("lighting", dropdown.value);
        SceneManager.LoadScene(scene);
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

	public void playGame(int level)
    {
        string scene = "";
        if (level == 0)
        {
            scene = "Menu";
        }
        else if (level == 1)
        {
            scene = "Game";
        }
        SceneManager.LoadScene(scene);
    }
}

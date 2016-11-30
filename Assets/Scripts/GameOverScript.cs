using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void loadLevel(int level)
    {
        string scene = "";
        if (level == 0)
        {
            scene = "Main";
        } else if(level == 1)
        {
            scene = "Game";
        }
        SceneManager.LoadScene(scene);
    }
}

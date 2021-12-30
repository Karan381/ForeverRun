using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void playgame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void exit()
    {
        Application.Quit();
    }

    public void tomenu()
    {
        SceneManager.LoadScene("Menu");
        Destroy(GameObject.Find("my music"));
    }

    public void tohowtoplay()
    {
        SceneManager.LoadScene("how to play");
    }

}

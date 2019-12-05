using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu () {
        SceneManager.LoadScene(0);
    }

    public void QuitGame () {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}

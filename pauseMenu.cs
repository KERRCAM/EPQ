using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    public GameObject PauseMenu;
    public GameObject UI;

    void Start()
    {
        Cursor.visible = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseMenu.activeSelf)
            {
                Time.timeScale = 0f; 

                PauseMenu.SetActive(true);
                UI.SetActive(false);
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1f;
                PauseMenu.SetActive(false);
                UI.SetActive(true);
                Cursor.visible = false;
            }
        } 
    } 

    public void quit()
    {
        Application.Quit();
    } 

    public void resume()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        UI.SetActive(true);
        Cursor.visible = false;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

}


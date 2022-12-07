using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject levelSelect;


    private void Awake()
    {
        Cursor.visible = true;
        MainMenu.SetActive(true);
    }

    void Update()
    {

    }

    public void quit()
    {
        Application.Quit();
    }

    public void levelSelectButton()
    {
        MainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void mainMenuBack()
    {
        MainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void one()
    {
        SceneManager.LoadScene("level1");
    }
    public void two()
    {
        SceneManager.LoadScene("level2");
    }
    public void three()
    {
        SceneManager.LoadScene("level3");
    }
    public void four()
    {
        SceneManager.LoadScene("level4");
    }
    public void five()
    {
        SceneManager.LoadScene("level5");
    }
    public void six()
    {
        SceneManager.LoadScene("level6");
    }
    public void seven()
    {
        SceneManager.LoadScene("level7");
    }
    public void eight()
    {
        SceneManager.LoadScene("level8");
    }
    public void nine()
    {
        SceneManager.LoadScene("level9");
    }
    public void ten()
    {
        SceneManager.LoadScene("level10");
    } 
}

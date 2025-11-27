using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string SceneToLoad;

    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

}

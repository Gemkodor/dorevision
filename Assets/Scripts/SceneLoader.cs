using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadReadingNotes()
    {
        SceneManager.LoadScene("MenuNoteReading");
    }

    public void LoadRedingNoteLevel(int level)
    {
        string sceneToLoad = "NR_Level_" + level;

        if (Application.CanStreamedLevelBeLoaded(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Can't find scene to load");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

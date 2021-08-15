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

        if (GlobalGameManager.instance.isReadingNoteLevelUnlock(level) && Application.CanStreamedLevelBeLoaded(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Can't load note reading level");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

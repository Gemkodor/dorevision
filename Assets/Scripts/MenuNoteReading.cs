using UnityEngine;
using UnityEngine.UI;

public class MenuNoteReading : MonoBehaviour
{
    [SerializeField] private GameObject panelLevels;

    // Start is called before the first frame update
    void Start()
    {
        int index = 1;
        foreach (Transform levelBox in panelLevels.transform)
        {
            Transform levelScore = levelBox.GetChild(0).Find("LevelScore");
            levelScore.gameObject.GetComponent<Text>().text = "Score : " + GlobalGameManager.instance.GetReadingNoteLevelScore(index).ToString();
            index++;
        }
    }
}

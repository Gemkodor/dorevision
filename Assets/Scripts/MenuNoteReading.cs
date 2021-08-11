using UnityEngine;
using UnityEngine.UI;

public class MenuNoteReading : MonoBehaviour
{
    [SerializeField] private GameObject panelLevels;

    void Start()
    {
        int index = 1;
        foreach (Transform levelBox in panelLevels.transform)
        {
            int score = GlobalGameManager.instance.GetReadingNoteLevelScore(index);

            DisplayLevelScore(levelBox, score);
            DisplayLevelStars(levelBox, score);

            index++;
        }
    }

    private void DisplayLevelScore(Transform levelBox, int score)
    {
        Transform levelScore = levelBox.GetChild(0).Find("LevelScore");
        levelScore.gameObject.GetComponent<Text>().text = "Score : " + score.ToString();
    }

    private void DisplayLevelStars(Transform levelBox, int score)
    {
        int nbStars = 0;
        if (score >= 600)
        {
            nbStars++;
        }
        if (score >= 350)
        {
            nbStars++;
        }
        if (score >= 100)
        {
            nbStars++;
        }

        Transform stars = levelBox.GetChild(0).Find("Stars");
        int i = 0;
        foreach (Transform star in stars)
        {
            if (nbStars > i)
            {
                star.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/full_star");
            }
            i++;
        }
    }
}

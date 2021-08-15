using UnityEngine;
using UnityEngine.UI;

public class MenuNoteReading : MonoBehaviour
{
    [SerializeField] private GameObject panelLevels;

    private int[] starsLevels = new int[] { 100, 350, 500 };

    void Start()
    {
        int levelIndex = 1;
        foreach (Transform levelRow in panelLevels.transform)
        {
            foreach(Transform levelBox in levelRow)
            {
                int score = GlobalGameManager.instance.GetReadingNoteLevelScore(levelIndex);

                DisplayLevelUnlock(levelBox, levelIndex);
                DisplayLevelScore(levelBox, score);
                DisplayLevelStars(levelBox, score);

                levelIndex++;
            }
        }
    }

    private void DisplayLevelUnlock(Transform levelBox, int levelIndex)
    {
        Transform levelLockImg = levelBox.GetChild(1);
        if (GlobalGameManager.instance.isReadingNoteLevelUnlock(levelIndex))
        {
            levelLockImg.gameObject.SetActive(false);
        }
    }

    private void DisplayLevelScore(Transform levelBox, int score)
    {
        Transform levelScore = levelBox.GetChild(0).Find("LevelScore");
        levelScore.gameObject.GetComponent<Text>().text = "Score : " + score.ToString();
    }

    private void DisplayLevelStars(Transform levelBox, int score)
    {
        int nbStars = GetNbStars(score);

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

    public int GetNbStars(int score)
    {
        int nbStars = 0;
        if (score >= starsLevels[2])
        {
            nbStars++;
        }
        if (score >= starsLevels[1])
        {
            nbStars++;
        }
        if (score >= starsLevels[0])
        {
            nbStars++;
        }

        return nbStars;
    }
}

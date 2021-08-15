using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
    [SerializeField] private int nbReadingNotesLevels;
    private Dictionary<int, int> scoresReadingNotes = new Dictionary<int, int>();
    private Dictionary<int, bool> lockStateReadingNotes = new Dictionary<int, bool>();
    public static GlobalGameManager instance;

    private int nbCoins = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of GlobalGameManager");
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
        LoadProgress();
    }

    public int GetCoins()
    {
        return nbCoins;
    }

    public int GetReadingNoteLevelScore(int level)
    {
        if (scoresReadingNotes.ContainsKey(level))
        {
            return scoresReadingNotes[level];
        }

        return 0;
    }

    public void SetReadingNoteLevelState(int level, bool unlock)
    {
        if (lockStateReadingNotes.ContainsKey(level))
        {
            lockStateReadingNotes[level] = unlock;
            SaveProgress();
        }
    }

    public bool isReadingNoteLevelUnlock(int level)
    {
        if (lockStateReadingNotes.ContainsKey(level))
        {
            return lockStateReadingNotes[level];
        }

        return false;
    }

    public void SetReadingNoteScore(int level, int score)
    {
        scoresReadingNotes[level] = score;
        SaveProgress();
    }

    public void LoadProgress()
    {
        nbCoins = PlayerPrefs.GetInt("coins", 0);

        for (int i = 1; i <= nbReadingNotesLevels; i++)
        {
            scoresReadingNotes.Add(i, PlayerPrefs.GetInt("noteReadingLevelScore" + i, 0));

            if (i == 1)
            {
                lockStateReadingNotes.Add(i, true);
            } 
            else
            {
                lockStateReadingNotes.Add(i, PlayerPrefs.GetInt("noteReadingLevelState" + i, 0) == 1 ? true : false);
            }
        }
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt("coins", nbCoins);

        for (int i = 1; i <= nbReadingNotesLevels; i++)
        {
            PlayerPrefs.SetInt("noteReadingLevelScore" + i, scoresReadingNotes[i]);
            PlayerPrefs.SetInt("noteReadingLevelState" + i, lockStateReadingNotes[i] ? 1 : 0);
        }
    }
}

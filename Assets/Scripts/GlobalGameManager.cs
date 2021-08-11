using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
    [SerializeField] private int nbReadingNotesLevels;
    private Dictionary<int, int> scoresReadingNotes = new Dictionary<int, int>();
    public static GlobalGameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of GlobalGameManager");
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);

        for (int i = 1; i <= nbReadingNotesLevels; i++)
        {
            scoresReadingNotes.Add(i, 0);
        }
    }

    public int GetReadingNoteLevelScore(int level)
    {
        if (scoresReadingNotes.ContainsKey(level))
        {
            return scoresReadingNotes[level];
        }

        return 0;
    }

    public void SetReadingNoteScore(int level, int score)
    {
        scoresReadingNotes[level] = score;
    }
}

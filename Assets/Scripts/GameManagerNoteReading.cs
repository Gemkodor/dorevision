using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerNoteReading : MonoBehaviour
{
    [SerializeField] private int levelIndex;
    [SerializeField] private List<Sprite> notesSpritesTrebleKeyInError;
    [SerializeField] private List<Sprite> notesSpritesTrebleKeyInSuccess;

    public static GameManagerNoteReading instance;
    public List<Note> notesInStaff;
    public int currentIndexToGuess = 0;

    private float moveSpeed = 40;
    private int score = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of GameManagerNoteReading");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("End Of Game");
        Debug.Log(score);
        GlobalGameManager.instance.SetReadingNoteScore(levelIndex, score);
        SceneManager.LoadScene("MenuNoteReading");
        
    }

    private Sprite GetTrebleKeyNoteSpriteInError(string noteName)
    {
        for (int i = 0; i < notesSpritesTrebleKeyInError.Count; i++)
        {
            if (notesSpritesTrebleKeyInError[i].name == noteName)
            {
                return notesSpritesTrebleKeyInError[i];
            }
        }

        return null;
    }

    private Sprite GetTrebleKeyNoteSpriteInSuccess(string noteName)
    {
        for (int i = 0; i < notesSpritesTrebleKeyInSuccess.Count; i++)
        {
            if (notesSpritesTrebleKeyInSuccess[i].name == noteName)
            {
                return notesSpritesTrebleKeyInSuccess[i];
            }
        }

        return null;
    }

    public bool IsNoteInsideStaff(Image staff, Image note)
    {
        Vector3[] corners = new Vector3[4];
        float noteWidth = note.rectTransform.rect.width;
        
        staff.rectTransform.GetWorldCorners(corners); // x, y, width, height
        Rect staffRect = new Rect(corners[0].x + noteWidth, corners[0].y, (corners[2].x - corners[0].x) - (noteWidth * 2), corners[2].y - corners[0].y);

        note.rectTransform.GetWorldCorners(corners);
        Rect noteRect = new Rect(corners[0].x, corners[0].y, corners[2].x - corners[0].x, corners[2].y - corners[0].y);

        return staffRect.Overlaps(noteRect);
    }

    public void Guess(string noteGuessed)
    {
        if (notesInStaff.Count > currentIndexToGuess)
        {
            if (notesInStaff[currentIndexToGuess].GetNoteName() == noteGuessed)
            {
                notesInStaff[currentIndexToGuess].GetComponent<Image>().sprite = GetTrebleKeyNoteSpriteInSuccess(notesInStaff[currentIndexToGuess].GetName());

                if (moveSpeed == 0)
                {
                    moveSpeed = 40;
                }
                else
                {
                    moveSpeed += 5;
                }

                score += 5;
            }
            else
            {
                notesInStaff[currentIndexToGuess].GetComponent<Image>().sprite = GetTrebleKeyNoteSpriteInError(notesInStaff[currentIndexToGuess].GetName());
                if (moveSpeed == 0)
                {
                    moveSpeed = 40;
                }
                else
                {
                    moveSpeed -= 5;
                }

                score -= 3;
            }

            currentIndexToGuess++;
        }
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void StopMovement()
    {
        moveSpeed = 0;
    }
}

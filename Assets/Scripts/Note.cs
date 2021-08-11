using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    [SerializeField] private List<Sprite> notesSprites;
    [SerializeField] private string noteName;
    private int index;
    private Image staff;
    private Image noteImg;
    private Image stopScrollingLimit;
    private bool canSlowDown = true;

    private void Awake()
    {
        noteImg = GetComponent<Image>();
        staff = GameObject.FindGameObjectWithTag("EmptyStaff").GetComponent<Image>();
        stopScrollingLimit = GameObject.FindGameObjectWithTag("StopScrollingLimit").GetComponent<Image>();

        if (noteName != "")
        {
            SetSpriteFromNoteName();
        }
    }

    IEnumerator ResetSlowDown()
    {
        yield return new WaitForSeconds(2);
        canSlowDown = true;
    }

    private void Update()
    {
        // Check if we're near the limit to stop movement if player hasn't guessed yet
        float distance = Vector2.Distance(stopScrollingLimit.transform.position, transform.position);

        if (GameManagerNoteReading.instance.currentIndexToGuess == index)
        {
            if (distance < 15)
            {
                GameManagerNoteReading.instance.StopMovement();
            }
            else if (distance < 400 && canSlowDown)
            {
                GameManagerNoteReading.instance.UpdateMoveSpeed(-5);
                canSlowDown = false;
                StartCoroutine(ResetSlowDown());
            }
        }

        if (GameManagerNoteReading.instance.IsNoteInsideStaff(staff, noteImg))
        {
            noteImg.enabled = true;
        } 
        else
        {
            noteImg.enabled = false;
        }

        transform.Translate(-GameManagerNoteReading.instance.GetMoveSpeed() * Time.deltaTime, 0, 0);
    }

    private void SetSpriteFromNoteName()
    {
        for (int j = 0; j < notesSprites.Count; j++)
        {
            if (notesSprites[j].name == noteName)
            {
                noteImg.sprite = notesSprites[j];
                noteImg.SetNativeSize();
                break;
            }
        }
    }

    public string GetNoteName()
    {
        return noteName.Split('_')[0];
    }

    public string GetName()
    {
        return noteName;
    }

    public void SetName(string name)
    {
        noteName = name;
        transform.name = name;
        SetSpriteFromNoteName();
    }

    public int GetIndex()
    {
        return index;
    }

    public void SetIndex(int _index)
    {
        index = _index;
    }
}

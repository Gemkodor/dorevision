using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    [SerializeField] private List<Sprite> notesSprites;
    [SerializeField] private string noteName;
    private float moveSpeed = -80;
    private Image staff;
    private Image noteImg;

    private void Awake()
    {
        noteImg = GetComponent<Image>();
        staff = GameObject.FindGameObjectWithTag("EmptyStaff").GetComponent<Image>();

        if (noteName != "")
        {
            SetSpriteFromNoteName();
        }
    }

    private void Update()
    {
        if (noteImg.rectTransform.rect.Overlaps(staff.rectTransform.rect))
        {
            noteImg.enabled = true;
        } 
        else
        {
            noteImg.enabled = false;
        }

        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
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
}

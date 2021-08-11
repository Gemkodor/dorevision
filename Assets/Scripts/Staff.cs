using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    [SerializeField] private List<Sprite> notesSprites;
    [SerializeField] private int nbNotesToGuess = 10;
    [SerializeField] private int spaceBetweenNotes = 50;
    [SerializeField] private Note notePrefab;
    
    public List<string> notesToGuess = new List<string>();

    private string[] notes = new string[] { "do", "re", "mi", "fa", "sol", "la", "si" };

    void Start()
    {
        for (int i = 0; i < nbNotesToGuess; i++)
        {
            // Randomly generate a note to add in the staff
            string noteToAdd = notes[Random.Range(0, notes.Length)] + '_' + Random.Range(2, 3);
            notesToGuess.Add(noteToAdd);

            // Display note on staff
            Note noteOnStaff = Instantiate(notePrefab);
            noteOnStaff.SetIndex(i);
            noteOnStaff.SetName(noteToAdd);
            noteOnStaff.transform.SetParent(transform.parent);
            GameManager.instance.notesInStaff.Add(noteOnStaff);

            float initialPosX = GetComponent<RectTransform>().rect.width + (i * spaceBetweenNotes);
            noteOnStaff.transform.position = new Vector3(initialPosX + 100, transform.position.y, transform.position.z);
        }
    }
}

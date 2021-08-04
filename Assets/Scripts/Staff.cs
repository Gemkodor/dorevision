using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Staff : MonoBehaviour
{
    [SerializeField] private List<Sprite> notesSprites;
    [SerializeField] private int nbNotesToGuess = 10;
    [SerializeField] private int spaceBetweenNotes = 50;
    [SerializeField] private Note notePrefab;
    private string[] notes = new string[] { "do", "re", "mi", "fa", "sol", "la", "si" };
    private List<string> notesToGuess = new List<string>();

    void Start()
    {
        for (int i = 0; i < nbNotesToGuess; i++)
        {
            // Randomly generate a note to add in the staff
            string noteToAdd = notes[Random.Range(0, notes.Length)] + '_' + Random.Range(1, 5);
            notesToGuess.Add(noteToAdd);

            // Display note on staff
            Note noteOnStaff = Instantiate(notePrefab);
            noteOnStaff.SetName(noteToAdd);
            noteOnStaff.transform.SetParent(transform.parent);
            //noteOnStaff.GetComponent<Image>().enabled = false;

            float initialPosX = transform.position.x + (i * spaceBetweenNotes);
            noteOnStaff.transform.position = new Vector3(initialPosX, transform.position.y, transform.position.z);
        }
    }

    
}

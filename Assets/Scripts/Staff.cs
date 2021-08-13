using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Staff : MonoBehaviour
{
    [SerializeField] private Note notePrefab;
    [SerializeField] private List<Sprite> notesSprites;
    [SerializeField] private int minOctaveHeight = 1;
    [SerializeField] private int maxOctaveHeight = 4;
    [SerializeField] private int numberOfDistinctNotes = 7;
    [SerializeField] private GameObject spawnNote;

    public List<string> notesToGuess = new List<string>();

    private string[] notes = new string[] { "do", "re", "mi", "fa", "sol", "la", "si" };
    private int spaceBetweenNotes;
    private int nbNotesToGuess = 300;
    private Vector3 localScale = Vector3.one;

    void Start()
    {
        localScale = GetComponent<Image>().transform.localScale;
        spaceBetweenNotes = Screen.width / 10;

        for (int i = 0; i < nbNotesToGuess; i++)
        {
            // Randomly generate a note to add in the staff
            string noteToAdd = notes[Random.Range(0, numberOfDistinctNotes)] + '_' + Random.Range(minOctaveHeight, maxOctaveHeight + 1);
            notesToGuess.Add(noteToAdd);

            // Display note on staff
            Note noteOnStaff = Instantiate(notePrefab);
            noteOnStaff.transform.SetParent(transform.parent);
            noteOnStaff.GetComponent<Image>().transform.localScale = localScale;
            noteOnStaff.SetIndex(i);
            noteOnStaff.SetName(noteToAdd);

            GameManagerNoteReading.instance.notesInStaff.Add(noteOnStaff);

            float initialPosX = spawnNote.transform.position.x + (i * spaceBetweenNotes);
            noteOnStaff.transform.position = new Vector3(initialPosX, transform.position.y, transform.position.z);
        }
    }
}

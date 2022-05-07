using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public KeyCode keyCode;
    public GameObject notePreFab;

    public Note SpawnNote()
    {
        return Instantiate(notePreFab, transform.position, Quaternion.identity).GetComponent<Note>();
    }
}

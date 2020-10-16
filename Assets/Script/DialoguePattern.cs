using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class DialoguePattern : ScriptableObject
{
    public string dialogueTargeter;

    [TextArea(2,10)]
    public string[] sentences;

    public AudioClip[] audioClips;
}

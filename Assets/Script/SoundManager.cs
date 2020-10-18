using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public enum State
    {
        PART_1,
        PART_1_1,
        PART_2,
        PART_2_1,
        FIGHT,
    }
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip backgroundMusicPart_1;

    [SerializeField]
    private AudioClip backgroundMusicPart_1_1;

    [SerializeField]
    private AudioClip backgroundMusicPart_2;

    [SerializeField]
    private AudioClip backgroundMusicPart_2_1;

    [SerializeField]
    private AudioClip fightMusic;

    public State state = State.PART_1;

    private AudioClip currentMusic;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } 
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource.PlayOneShot(backgroundMusicPart_1);
    }

    public void FightBegin()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(fightMusic);
    }

}

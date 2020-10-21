using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public enum State
    {
        PART_1,
        PART_2,
        FIGHT,
    }
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip backgroundMusicPart_1;

    

    [SerializeField]
    private AudioClip backgroundMusicPart_2;

    [SerializeField]
    private AudioClip fightMusic;

    public State state = State.PART_1;

    private State currentState;

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
        currentState = state;
    }

    void Start()
    {
        audioSource.PlayOneShot(backgroundMusicPart_1);
    }

    public void FightBegin()
    {
        currentState = state;
        state = State.FIGHT;
        CurrentPlay();
    }

    public void FightOver()
    {
        state = currentState;
        CurrentPlay();
    }

    public void StopAll()
    {
       audioSource.Stop();
    }

    public void CurrentPlay()
    {
        switch(state)
        {
            case State.PART_1:
            audioSource.Stop();
            audioSource.PlayOneShot(backgroundMusicPart_1);
            break;

            case State.PART_2:
            audioSource.Stop();
            audioSource.PlayOneShot(backgroundMusicPart_2);
            break;

            case State.FIGHT:
            audioSource.Stop();
            audioSource.PlayOneShot(fightMusic);
            break;
        }
    }


}

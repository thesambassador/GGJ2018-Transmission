using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMusic : MonoBehaviour {

    PlayerSongs songs;

    public AudioClip clipAmbientApathy;
    public AudioClip clipAmbientNeutral;

    public AudioClip[] tracks;

    private AudioSource sourceAmbientApathy;
    private AudioSource sourceAmbientNeutral;

    private AudioSource[] sourcePowers;
    private bool[] playingEmotion;

    public float fadeTime = 1;

	// Use this for initialization
	void Start () {
        songs = FindObjectOfType<PlayerSongs>();
        songs.AddPowerListener(PlayerPowers.Sadness, PlaySadness);
        songs.AddPowerListener(PlayerPowers.Fear, PlayFear);
        songs.AddPowerListener(PlayerPowers.Anger, PlayAnger);

        sourceAmbientApathy = AddAudioSourceForClip(clipAmbientApathy);
        sourceAmbientNeutral = AddAudioSourceForClip(clipAmbientNeutral);
        sourcePowers = new AudioSource[3];
        playingEmotion = new bool[3];
        for (int i = 0; i < 3; i++)
        {
            sourcePowers[i] = AddAudioSourceForClip(tracks[i]);
            playingEmotion[i] = false;
        }

        if(sourceAmbientApathy != null)
            sourceAmbientApathy.volume = 1;
	}

    AudioSource AddAudioSourceForClip(AudioClip clip)
    {
        if (clip != null)
        {
            AudioSource newSource = gameObject.AddComponent<AudioSource>();
            newSource.clip = clip;
            newSource.loop = true;
            newSource.playOnAwake = true;
            newSource.volume = 0;
            newSource.Play();
            return newSource;
        }
        return null;
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 3; i++)
        {
            if (playingEmotion[i])
            {
                if (sourcePowers[i] != null && sourcePowers[i].volume < 1)
                {
                    sourcePowers[i].volume = Mathf.Clamp(sourcePowers[i].volume + fadeTime * Time.deltaTime, 0, 1);
                }
            }
            else
            {
                if (sourcePowers[i] != null && sourcePowers[i].volume > 0)
                {
                    sourcePowers[i].volume = Mathf.Clamp(sourcePowers[i].volume - fadeTime * Time.deltaTime, 0, 1);
                }
            }
        }
	}
    void PlaySadness(PowerEventData data)
    {
        playingEmotion[(int)PlayerPowers.Sadness] = data.active;
    
    }

    void PlayAnger(PowerEventData data)
    {
        playingEmotion[(int)PlayerPowers.Anger] = data.active;
    }

    void PlayFear(PowerEventData data)
    {
        playingEmotion[(int)PlayerPowers.Fear] = data.active;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMusic : MonoBehaviour {

    public AudioClip clipAmbientApathy;
    public AudioClip clipAmbientNeutral;

    public AudioClip[] tracks;

    private AudioSource sourceAmbientApathy;
    private AudioSource sourceAmbientNeutral;

    private AudioSource[] sourcePowers;

	// Use this for initialization
	void Start () {
        AddAudioSourceForClip(clipAmbientApathy);
        AddAudioSourceForClip(clipAmbientNeutral);
        sourcePowers = new AudioSource[4];
        for (int i = 0; i < tracks.Length; i++)
        {
            AddAudioSourceForClip(tracks[i]);
        }
	}

    void AddAudioSourceForClip(AudioClip clip)
    {
        if (clip != null)
        {
            AudioSource newSource = gameObject.AddComponent<AudioSource>();
            newSource.clip = clip;
            newSource.playOnAwake = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

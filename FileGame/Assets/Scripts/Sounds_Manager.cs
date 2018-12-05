using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds_Manager : MonoBehaviour {

    public AudioClip[] Clips;

   public AudioSource AS;

    public static Sounds_Manager Instance;

    private void Awake()
    {
        Instance = this;
    }


    // Use this for initialization
    void Start () {}
	
	// Update is called once per frame
	void Update () {}

    public void play_Audio(int i)
    {
        AS.clip = Clips[i];
        AS.Play();

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    
    // config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xLaunch = 2f;
    [SerializeField] float yLaunch = 15f;
    //[SerializeField] AudioClip[] ballSounds; Had multiple sound for ball hitting the walls. Didn't like it and now don't want an array of sounds, just 1
    [SerializeField] AudioClip ballSounds;
    
    // state
    Vector2 paddleToBallVector;
    bool Started = false;

    // Cached Component References
    AudioSource myAudioSource;

    // Use this for initialization
	void Start () {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!Started)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Started = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xLaunch, yLaunch);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Started)
        {
            //AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)]; This is linked with multiple sound for balls. Only need 1 audiosource now.
            AudioClip clip = ballSounds;
            myAudioSource.PlayOneShot(clip);
        }
    }
}

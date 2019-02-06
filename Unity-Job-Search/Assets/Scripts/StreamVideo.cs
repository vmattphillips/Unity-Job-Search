﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour {

    public RawImage rawImage;
    public VideoPlayer video;
    public AudioSource audio;
    private bool isPaused = false;
    private bool firstRun = true;

	
	public IEnumerator PlayVideo()
    {
        video.Prepare();
        while (!video.isPrepared)
        {
            yield return new WaitForSeconds(1);
            break;
        }
        rawImage.texture = video.texture;
        video.Play();
        audio.Play();
    }
    public void PlayPause()
    {
       
            StartCoroutine(PlayVideo());
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour {
    private static BGMController instance = null;
    public static BGMController Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}

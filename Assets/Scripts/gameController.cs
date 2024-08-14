using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.SocialPlatforms.Impl;


public class gameController : MonoBehaviour
{
    public float speed = -1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(speed, 0, 0);
    }

    private void ResetPosition()
    {
        transform.Translate(speed, 0, 0);

    }
}

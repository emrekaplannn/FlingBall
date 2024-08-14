using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ballController : MonoBehaviour
{
    public GameObject arrow;
    public GameObject bg; // Reference to the target object
    public GameObject bg2; // Reference to the target object
    public GameObject bg3; // Reference to the target object
    public GameObject bg4; // Reference to the target object
    public GameObject bg5; // Reference to the target object
    public GameObject bg6; // Reference to the target object
    public GameObject bg7; // Reference to the target object
    public GameObject reloadButton;
    private bgController4 targetScript;
    private bgController targetScript2;
    private bgController2 targetScript3;
    private bgController3 targetScript4;
    private bgController3 targetScript5;
    private bgController3 targetScript6;
    private bgController3 targetScript7;
    public GameObject character;
    private Animator characterAnimator;
    public GameObject character2;
    private Animator characterAnimator2;
    bool mr = true;
    bool mr2 = true;
    private Rigidbody2D rb;
    int bestScore;
    public TextMeshProUGUI bestScoreText;
    public GameObject BestScorePanel;

    public float ballVertical = 0f;

    void Start()
    {
        characterAnimator = character.GetComponent<Animator>();
        characterAnimator2 = character2.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        reloadButton.SetActive(false);
        BestScorePanel.SetActive(false);

        ballVertical = -8f;
        if (bg != null)
        {
            targetScript = bg.GetComponent<bgController4>();
        }
        if (bg2 != null)
        {
            targetScript2 = bg2.GetComponent<bgController>();
        }
        if (bg3 != null)
        {
            targetScript3 = bg3.GetComponent<bgController2>();
        }
        if (bg4 != null)
        {
            targetScript4 = bg4.GetComponent<bgController3>();
        }
        if (bg5 != null)
        {
            targetScript5 = bg5.GetComponent<bgController3>();
        }
        if (bg6 != null)
        {
            targetScript6 = bg6.GetComponent<bgController3>();
        }
        if (bg7 != null)
        {
            targetScript7 = bg7.GetComponent<bgController3>();
        }
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

    }

    void Update()
    {
 
        // Apply vertical movement
        //transform.Translate(0, ballVertical * Time.deltaTime, 0);
        transform.position = new Vector3(transform.position.x ,transform.position.y + ballVertical * Time.deltaTime , -1f);
        /*
        if (ballVertical > 0.00001f)
            ballVertical -= 0.00001f;
        else if (ballVertical <= 0.00001f && ballVertical >= 0.00001f)
            ballVertical = 0f;
        else if (ballVertical < 0.00001f)
            ballVertical += 0.00001f;
        */
        if (ballVertical > -7.8f)
            ballVertical -= 0.01f;
        else if (ballVertical <= -7.8f && ballVertical >= -8.2f)
            ballVertical = -8f;
        else if (ballVertical < 8.2f)
            ballVertical += 0.01f;

        
        if (transform.position.y < -3.5f)
        {
            ballVertical = 0f;
            if (mr)
            {
                targetScript.speed /= 2f;
                targetScript3.speed /= 2f;
                targetScript4.speed /= 2f;
                mr = false;
            }
        }
        //rb.gravityScale = 0.2f -ballVertical ;

        if (ballVertical == 0f && targetScript.speed == 0f) { 
            reloadButton.SetActive(true);
            if (targetScript3.score > bestScore)
            {
                bestScore = targetScript3.score;
                PlayerPrefs.SetInt("BestScore", bestScore);
                PlayerPrefs.Save();
            }
            bestScoreText.text = "Best Score: " + bestScore.ToString();
            BestScorePanel.SetActive(true);

        }

        if (arrow != null)
        {
            // Get the Z rotation of the target object
            float zRotation = arrow.transform.rotation.eulerAngles.z;
            // Do something with the Z rotation value
        }

        if (Input.GetMouseButtonDown(0)) // Detect left mouse button click
        {
            if (mr2 && targetScript != null && targetScript2 != null)
            {
                float zRotation = transform.rotation.eulerAngles.z;
                zRotation += 90f;
                float angleInRadians = zRotation * Mathf.Deg2Rad;

                characterAnimator.enabled = false;
                characterAnimator2.enabled = false;

                // Get sine and cosine of the angle
                float sineValue = Mathf.Sin(angleInRadians);
                float cosineValue = Mathf.Cos(angleInRadians);

                // Apply speed to the target scripts
                targetScript.speed = -12f * cosineValue;
                targetScript2.speed = -12f * cosineValue;
                targetScript3.speed = -12f * cosineValue;
                targetScript4.speed = -12f * cosineValue;
                targetScript5.speed = -12f * cosineValue;
                targetScript6.speed = -12f * cosineValue;
                targetScript7.speed = -12f * cosineValue;
                ballVertical = 12f * sineValue;
                //rb.gravityScale = 0.2f -ballVertical;

                character.transform.position = new Vector3(0f, 0f, 0f);
                Debug.Log("New value for bg: " + targetScript.speed);
                Debug.Log("New value for bg2: " + targetScript2.speed);
                Debug.Log("Ball vertical: " + ballVertical);
                mr2 = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Booster"))
        {
            targetScript.speed += -6f ;
            targetScript2.speed += -6f ;
            targetScript3.speed += -6f;
            targetScript4.speed += -6f;
            targetScript5.speed += -6f;
            targetScript6.speed += -6f;
            targetScript7.speed += -6f;
            ballVertical += 10f;
        }
    }
    public void ReloadCurrentScene()
    {
        // Get the currently active scene and reload it
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}

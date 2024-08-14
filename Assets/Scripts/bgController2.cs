using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bgController2 : MonoBehaviour
{
    public Vector3 direction = new Vector3(1, 0, 0); // Move along the x-axis
    public float speed = 0f;
    public TextMeshProUGUI ScoreText;
    public int score = 0;
    int multiplier = 0;

    void Update()
    {
        // Translate object
        transform.Translate(direction * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime , transform.position.y, -0.9f);
        if (transform.position.x < -24f) {
            transform.position = new Vector3(transform.position.x + 72.8f , transform.position.y, -0.9f);
            multiplier += 1;
            Debug.Log("Position x: " + transform.position.x);

        }
        if (multiplier == 0) score = Mathf.RoundToInt( 51.8f - transform.position.x);
        else score = Mathf.RoundToInt(multiplier * 72.8f + (48.8f - transform.position.x));
        ScoreText.text = score.ToString();

        // Gradually decrease speed
        if (speed <= -30f) speed = 29.9f;

        if (speed < 0)
            speed += 0.003f;
        if (speed >= 0)
            speed = 0f;
    }
}

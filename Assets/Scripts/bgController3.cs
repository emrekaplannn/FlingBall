using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgController3 : MonoBehaviour
{
    public Vector3 direction = new Vector3(1, 0, 0); // Move along the x-axis
    public float speed = 0f;

    void Update()
    {
        // Translate object
        transform.Translate(direction * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime , transform.position.y, -1f);
        if (transform.position.x < -5f) {
            transform.position = new Vector3(transform.position.x + Random.Range(15.0f, 30.0f), Random.Range(-3.1f, 0f) , -1f);

        }
        // Gradually decrease speed
        if (speed <= -30f) speed = 29.9f;
        if (speed < 0)
            speed += 0.003f;
        if (speed >= 0)
            speed = 0f;
    }
}

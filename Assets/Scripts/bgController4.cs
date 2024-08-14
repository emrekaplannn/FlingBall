using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgController4 : MonoBehaviour
{
    public Vector3 direction = new Vector3(1, 0, 0); // Move along the x-axis
    public float speed = 0f;

    void Update()
    {
        // Translate object
        transform.Translate(direction * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime , transform.position.y, -0.9f);
        if (transform.position.x < -24f) {
            transform.position = new Vector3(transform.position.x + 72.8f , transform.position.y, -0.9f);

        }
        // Gradually decrease speed
        if (speed <= -30f) speed = 29.9f;

        if (speed < 0)
            speed += 0.003f;
        if (speed >= 0)
            speed = 0f;
    }
}

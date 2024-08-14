using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgController : MonoBehaviour
{
    public Vector3 direction = new Vector3(1, 0, 0); // Move along the x-axis
    public float speed = 0f;

    void Update()
    {
        // Translate object
        transform.Translate(direction * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime , transform.position.y, -1f);

        // Gradually decrease speed
        if (speed <= -30f) speed = -29.9f;

        if (speed < 0)
            speed += 0.003f;
        if (speed >= 0)
            speed = 0f;
    }
}

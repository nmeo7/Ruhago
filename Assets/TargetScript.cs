using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    enum Movement
    {
        None,
        Horizontal,
        Vertical,
        Circular,
        Scaling
    };

    float speed = 1;
    Movement movement;
    Transform transform;
    float distance = 4;
    float phase = 0;
    Vector3 initialPosition;

    public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        Array values = Enum.GetValues(typeof(Movement));
        System.Random random = new System.Random();
        movement = (Movement)values.GetValue(random.Next(values.Length));

        transform = GetComponent<Transform>();
        initialPosition = transform.position;
        movement = Movement.Horizontal;
    }

    void linearMovement (Movement movement)
    {
        Vector3 pos = initialPosition;

        if (movement == Movement.Horizontal)
            pos.x = initialPosition.x + (float) Math.Sin(phase) * distance;
        if (movement == Movement.Vertical)
            pos.y = initialPosition.y + (float) Math.Sin(phase) * distance;

        transform.position = pos;
    }

    void circularMovement ()
    {
        Vector3 pos = initialPosition;

        pos.x = initialPosition.x + (float)Math.Sin(phase) * distance;
        pos.y = initialPosition.y + (float)Math.Cos(phase) * distance;

        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        phase += speed * Time.deltaTime;

        if (phase > 360)
            phase = 0;

        if (movement == Movement.Horizontal || movement == Movement.Vertical)
            linearMovement (movement);

    }

    void OnTriggerEnter()
    {
        Debug.Log("I am hit, mothafucka!");
        Instantiate(destroyEffect, transform);
        Destroy(this, 0.4f);
    }
}

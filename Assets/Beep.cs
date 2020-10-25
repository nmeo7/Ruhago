using UnityEngine;
using System.Collections;
using System;

public class Beep : MonoBehaviour
{
    public int position = 0;
    public int samplerate = 44100;

    static float frequency_A0 = 29.14f;

    private float frequency = 932.33f;

    void Start()
    {
        AudioClip myClip = AudioClip.Create("MySinusoid", samplerate * 2, 1, samplerate, true, OnAudioRead, OnAudioSetPosition);
        AudioSource aud = GetComponent<AudioSource>();
        aud.clip = myClip;
        aud.Play();
    }
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            AudioClip myClip = AudioClip.Create("MySinusoid", samplerate * 2, 1, samplerate, true, OnAudioRead, OnAudioSetPosition);
            AudioSource aud = GetComponent<AudioSource>();


            aud.clip = myClip;
            // aud.loop = true;
            aud.Play();
            // frequency += 20;
        }

        // checking button down and play that sound that doesn't damp.

        // then on button up, same note but with damping this time.
    }
    
    void OnAudioRead(float[] data)
    {
        int count = 0;
        while (count < data.Length)
        {
            float t = ((float) position) / samplerate;
            float w = 2 * Mathf.PI * frequency;

            float Y = 0.6f * Mathf.Sin(w * t) * Mathf.Exp(-0.0015f * w * t);
            Y += 0.4f * Mathf.Sin(2 * w * t) * Mathf.Exp(-0.0015f * w * t);

            Y += Y * Y * Y;
            // Y *= 1 + 16 * t * Mathf.Exp(-6 * t);

            data[count] = Y;
            position++;
            count++;
        }
    }

    void OnAudioSetPosition(int newPosition)
    {
        position = newPosition;
    }
}
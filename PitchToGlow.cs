using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchToGlow : MonoBehaviour
{
    public Light glowLight;
    public float intensityMultiplier = 5f;
    public float minIntensity = 0.0f;
    public float maxIntensity = 10f;

    public AudioSource audioSource;

    void Start()
    {
        if(glowLight == null)
        {
            enabled = false;
        }
    }
    void Update()
    {
        if (audioSource.isPlaying)
        {
            float pitch = audioSource.pitch;
            float intensity = Mathf.Clamp(pitch * intensityMultiplier, minIntensity, maxIntensity);

            glowLight.intensity = intensity;
        }
    }
}

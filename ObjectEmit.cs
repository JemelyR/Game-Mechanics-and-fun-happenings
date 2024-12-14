using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEmit : MonoBehaviour
{

    public Transform leftHand;
    public Transform rightHand;
    public Material material;
    public float emissionMultiplier = 1.0f;
    public float minEmission = 1.0f;
    public float maxEmission = 10.0f;

    void Update()
    {
        if (leftHand != null && rightHand != null)
        {
            Vector3 handDirection = rightHand.position - leftHand.position;
            float distance = handDirection.magnitude;

            float emission = MapDistanceToEmission(distance);
            material.SetColor("_EmissionColor", new Color(emission, emission, emission));
        }
    }

    float MapDistanceToEmission(float distance)
    {
        float mappedEmission = Mathf.Lerp(minEmission, maxEmission, distance / maxEmission);

        return Mathf.Clamp(mappedEmission, minEmission, maxEmission) * emissionMultiplier;
    }
}

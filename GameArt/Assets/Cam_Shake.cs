using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Shake : MonoBehaviour
{
    public float power;
    public float duration;
    public Transform camera;
    public float slowDownAmount;
    public bool shouldShake;

    Vector3 startPosition;
    float initialDuration;

    // Start is called before the first frame update
    void Start()
    {
        shouldShake = false;
        camera = Camera.main.transform;
        startPosition = camera.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldShake)
        {
            if(duration > 0)
            {
                camera.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                camera.localPosition = startPosition;
            }
        }
    }
}

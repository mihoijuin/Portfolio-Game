using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ease : MonoBehaviour {

    public float EaseInOutSine(float t)
    {
        return -0.5f * (Mathf.Cos(Mathf.PI * t) - 1f);
    }

    public float EaseInOutQuad(float t)
    {

        if(t < 0.5)
        {
            return 2f * t * t;
        } else {
            t = 2f * t - 1f;
            return -0.5f * (t * (t - 2f) - 1f);
        }

    }

    public float EaseInCubic(float t)
    {
        return t * t * t;
    }

    public float EaseOutCubic(float t)
    {
        t -= 1;
        return t * t * t + 1;
    }

    public float Liner(float t, float speed)
    {
        return t * speed;
    }
}

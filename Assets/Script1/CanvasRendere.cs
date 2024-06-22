using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRendere : MonoBehaviour
{
    public CanvasRenderer r;

    void Update()
    {
        r.SetAlpha(Mathf.Abs(Mathf.Repeat(Time.time, 2f) - 1f));
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _timeElapsed;
    
    private void Start()
    {
        _timeElapsed = 0;
    }
    
    private void Update()
    {
        _timeElapsed += Time.deltaTime;
    }

    private void OnDestroy()
    {
        GameManager.Instance.TimeElapsed = _timeElapsed;
    }
}

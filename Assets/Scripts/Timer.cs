using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float timeMultiplier = 1f;

    Action onResetTimer;
    const float SliderResetTimer = 10f;

    float currentTime;
    Slider timeSlider;

    private void Awake()
    {
        timeSlider = GetComponent<Slider>();
        timeSlider.value = timeSlider.maxValue;
        currentTime = SliderResetTimer;
    }

    public void AddActionOnResetTimer(Action x)
    {
        onResetTimer += x;
    }

    public void ClearActions()
    {
        onResetTimer = null;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime * timeMultiplier;
        if (currentTime < 0)
        {
            ResetTime();
            currentTime = SliderResetTimer;
        }
        timeSlider.value = currentTime;
    }

    private void ResetTime()
    {
        if (onResetTimer != null)
        {
            onResetTimer();
            Debug.Log("Reset timeeer");
        }
    }
}

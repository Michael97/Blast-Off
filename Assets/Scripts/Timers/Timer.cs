using UnityEngine;

public class Timer
{
    private float defaultTimerCount;
    private float currentTimerCount;

    private bool hasFinished;

    public Timer(float a_timerCount)
    {
        defaultTimerCount = a_timerCount;
        currentTimerCount = defaultTimerCount;
        hasFinished = false;
    }

    public void Update()
    {
        if (hasFinished == false)
        {
            currentTimerCount -= Time.deltaTime;

            if (currentTimerCount <= 0.0f)
                hasFinished = true;
        }

    }

    public void ResetTimer()
    {
        currentTimerCount = defaultTimerCount;
        hasFinished = false;
    }

    //Getters and setters

    public void SetHasFinished(bool a_boolean)
    {
        hasFinished = a_boolean;
    }

    public bool GetHasFinished()
    {
        return hasFinished;
    }

    public void SetDefaultTimerCount(float a_num)
    {
        defaultTimerCount = a_num;
    }

    public float GetDefaultTimerCount()
    {
        return defaultTimerCount;
    }

    public void SetCurrentTimerCount(float a_num)
    {
        currentTimerCount = a_num;
    }

    public float GetCurrentTimerCount()
    {
        return currentTimerCount;
    }
}


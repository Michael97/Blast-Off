using UnityEngine;

public class Timer
{
    private float defaultTimerCount;
    private float currentTimerCount;

    private bool hasFinished;

    private bool isEnabled;

    public Timer(float a_timerCount)
    {
        defaultTimerCount = a_timerCount;
        currentTimerCount = defaultTimerCount;
        hasFinished = false;
        isEnabled = true;
    }

    public void Update()
    {
        if (isEnabled == false)
        {
            //Debug.Log("not counting");
            return;
        }

        if (hasFinished == false)
        {
            //Debug.Log("counting " + isEnabled);
            currentTimerCount -= Time.deltaTime;

            if (currentTimerCount <= 0.0f)
                hasFinished = true;
        }

    }

    public bool GetEnabled()
    {
        return isEnabled;
    }

    public void SetEnabled(bool boolean)
    {
       // Debug.Log("first " + isEnabled);
        isEnabled = boolean;
      //  Debug.Log("second " + isEnabled);
    }

    public void ResetTimer()
    {
        currentTimerCount = defaultTimerCount;
        hasFinished = false;
        isEnabled = false;
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

    public void Dispose()
    {

    }
}


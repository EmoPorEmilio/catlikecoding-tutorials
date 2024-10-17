using UnityEngine;
using System;

public class Clock : MonoBehaviour {
    [SerializeField] 
    Transform hoursPivot, minutesPivot, secondsPivot;
    float hoursToDegrees = -30;
    float minutesToDegrees = -6;
    float secondsToDegrees = -6;

    void Awake () {
        hoursPivot.localRotation = Quaternion.Euler(0, 0, -30);
        minutesPivot.localRotation = Quaternion.Euler(0, 0, -90);
        secondsPivot.localRotation = Quaternion.Euler(0, 0, -90);
    }

    void Update () {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, (float)time.TotalHours * hoursToDegrees);
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, (float)time.TotalMinutes * minutesToDegrees);
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, (float)time.TotalSeconds * secondsToDegrees);
    }

}
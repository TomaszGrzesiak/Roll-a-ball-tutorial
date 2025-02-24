using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hoursHand;
    public Transform minutesHand;
    public Transform secondsHand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DateTime currentTime = DateTime.Now;
        
        // Converting to degrees
        float secondsAngle = currentTime.Second * 6f; // 360 degrees / 60s = 6 degrees per second
        float minutesAngle = currentTime.Minute * 6f;
        float hourAngle = (currentTime.Hour % 12) * 30f + (currentTime.Minute * 0.5f); // 360° / 12h = 30° per hour
        
        // Apply rotation
        secondsHand.localRotation = Quaternion.Euler(0f, 180f, secondsAngle);
        minutesHand.localRotation = Quaternion.Euler(0f, 180f, minutesAngle);
        hoursHand.localRotation = Quaternion.Euler(0f, 180f, hourAngle);
    }
}

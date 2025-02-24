using UnityEngine;

public class Logging : MonoBehaviour
{
    int counter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello World!");
        print("Print Hello World !");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter++;
        if (counter % 5 == 0) Debug.Log($"Logged: {gameObject.name},  counter: {counter}");
        
    }
}

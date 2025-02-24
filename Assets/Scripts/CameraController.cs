using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    void Start()
    {
        // the line below answer 50% of exercise 5
        offset = new Vector3(0,10,0) - player.transform.position;
        print($"offset: {offset}, transform.position: {transform.position} - player: {player.transform.position}");
    }

    
    void LateUpdate()
    {
        // the line below answer another 50% of the exercise 5
        transform.position = player.transform.position + offset;
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        print($"offset: {offset}, transform.position: {transform.position} + player: {player.transform.position}");
    }
}

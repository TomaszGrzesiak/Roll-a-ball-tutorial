using UnityEngine;

public class Fireworks : MonoBehaviour
{
    public GameObject fireworkPrefab;
    
    private float acceleration = 5f;
    private Vector3 startPos;
    private bool exploded;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        exploded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < startPos.y + 7f)
        {
            transform.position = transform.position + new Vector3(0, 0.5f * acceleration * Time.deltaTime, 0);
        }
        else if (!exploded)
        {
            Instantiate(fireworkPrefab,transform.position,Quaternion.identity);
            gameObject.SetActive(false);
            exploded = true;
        }
    }
}

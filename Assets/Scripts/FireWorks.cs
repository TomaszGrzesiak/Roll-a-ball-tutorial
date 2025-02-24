using UnityEngine;

public class FireWorks : MonoBehaviour
{
    public GameObject explosionPrefab;
    
    private float acceleration = 5f;
    private Vector3 startPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < startPos.y + 7f)
        {
            transform.position = transform.position + new Vector3(0, 0.5f * acceleration * Time.deltaTime, 0);
        }
        else
        {
            gameObject.SetActive(false);
            Instantiate(explosionPrefab,transform.position,Quaternion.identity);
        }
    }
}

/*
 Exercise 3:
Q: How do you make sure that you don’t instantiate more than one GameObject when you push a button?
A: It works like that out of the box.
        
Q: Are you using InvokeRepeating() and CancelInvoke() for the fireworks show?
A: No
*/

using System.Collections;
using UnityEngine;

public class FireworksManager : MonoBehaviour
{ 
    public GameObject fireworkPrefab;
    private IEnumerator coroutine;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // coroutine = SpawnFirework(2f);
        // StartCoroutine(coroutine);
    }

    private IEnumerator SpawnFirework(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0,waitTime));
            SpawnRandomFirework();
        }
    }

    private void SpawnRandomFirework()
    {
        float radius = 7.0f;
        // position random: [ x: -10 - 10,  y: 0-5, z: -10 - 10]
        float x = Random.Range(-radius, radius);
        float y = 0.0f;
        float z = Random.Range(-radius, radius);
        GameObject firework = Instantiate(fireworkPrefab, new Vector3(x,y,z), Quaternion.identity);
        Destroy(firework,5);

    }

    // Update is called once per frame
    void Update()
    {
        // press "l" to start a sequence of random fireworks. Press again to stop it
        if  (Input.GetKeyDown("l"))
        {
            if (coroutine == null)
            {
                coroutine = SpawnFirework(2f);
                StartCoroutine(coroutine);
                Debug.Log("Coroutine Started!");
            }
            else // If running, stop it
            {
                StopCoroutine(coroutine);
                coroutine = null;
                Debug.Log(":::::::: Coroutine Stopped!");
            }
        }
        // press "k" to spawn a random firework
        if  (Input.GetKeyDown("k"))
        {
            SpawnRandomFirework();
        }
    }
}


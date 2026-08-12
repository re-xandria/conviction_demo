using UnityEngine;

public class Controller_PlatformSpawner : MonoBehaviour
{

    public GameObject platformPrefab;
    public int numPlatforms = 10;
   
    public float platformXSpread = 10f;
    public float platformYSpread = 0f;
    public float platformZSpread = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i=0; i < numPlatforms; i++)
        {
            SpreadPlatform();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpreadPlatform()
    {
        Vector3 randPosition = new Vector3(Random.Range(-platformXSpread, platformXSpread), Random.Range(-platformYSpread, platformYSpread), Random.Range(-platformZSpread, platformZSpread)) + transform.position;
        GameObject clone = Instantiate(platformPrefab, randPosition, Quaternion.identity);
    }

}

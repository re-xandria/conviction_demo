using UnityEngine;

public class Controller_PlatformSpawner : MonoBehaviour
{

    public GameObject platformUnitPrefab;
    [Range(1, 10)]
    public int numPlatforms = 5;
   
    public float platformXSpread = 0f;
    public float platformYSpread = 5f;
    public float platformZSpread = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i=0; i < numPlatforms; i++)
        {
            SpreadPlatforms();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpreadPlatforms()
    {

        // Create first platform, then randomly pick a number from 1-4 and add that many more platforms offset by the width of the platform prefab

        int numUnits = Random.Range(1, 4);
        Vector3 startPosition = new Vector3(Random.Range(-platformXSpread, platformXSpread), Random.Range(-platformYSpread, platformYSpread), Random.Range(0, platformZSpread)) + transform.position;
        Vector3 updatedPosition = startPosition;

        Instantiate(platformUnitPrefab, startPosition, Quaternion.identity);
        
        for (int i=0; i < numUnits; i++)
        {
            updatedPosition = new Vector3(updatedPosition.x, updatedPosition.y, updatedPosition.z + platformUnitPrefab.transform.localScale.z);
            Instantiate(platformUnitPrefab, updatedPosition, Quaternion.identity);
        }
    }

}


/*

    Created simple platform spawner

    TO DO
    - Constrict platforms to same x position as player
    - Define rules for platform generation
    - Implement rules for platform generation
    - Configure seed # to dictate platform generation

*/


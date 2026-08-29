using UnityEngine;

public class Controller_PlatformSpawner : MonoBehaviour
{

    public GameObject platformUnitPrefab;
    [Range(1, 100)]
    public int numPlatforms = 5;
    private float lastPlatformYPosition;
   
    public float platformXSpread = 0;
    public float platformYSpread = 5;
    public float platformZSpread = 10;

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
        float newPlatformYPosition = Random.Range(0, platformYSpread) + lastPlatformYPosition;
        Vector3 startPosition = new Vector3(Random.Range(-platformXSpread, platformXSpread), newPlatformYPosition, Random.Range(0, platformZSpread)) + transform.position;
        Vector3 updatedPosition = startPosition * numUnits;

        Instantiate(platformUnitPrefab, startPosition, Quaternion.identity);
        lastPlatformYPosition = startPosition.y;
        
        for (int i=0; i < numUnits; i++)
        {
            updatedPosition = new Vector3(updatedPosition.x, updatedPosition.y, updatedPosition.z + platformUnitPrefab.transform.localScale.z);
            Instantiate(platformUnitPrefab, updatedPosition, Quaternion.identity);
        }
    }

        // Platform should only generate in increments of 5 units above the last platform
        

}


/*

    Created simple platform spawner

    TO DO
    - Constrict platforms to same x position as player
    - Define rules for platform generation
    - Implement rules for platform generation
    - Configure seed # to dictate platform generation

*/


using System;
using UnityEngine;

public class SeedManager : MonoBehaviour
{
    
    public String stringSeed;
    private int seedId;
    public bool isRandom;

    public void generateSeed()
    {
        if (!isRandom)
        {
            seedId = stringSeed.GetHashCode();
        }
        else
        {
            seedId = UnityEngine.Random.Range(0, 999999);
        }
        
        UnityEngine.Random.InitState(seedId);
    }

    public void Awake()
    {
        generateSeed();
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{

    public static event Action statsChanged;
    public static event Action chestChanged;
    public static event Action<Slime> slimeDroped;
    public static event Action chestDamaged;
    public static event Action<string> collectionComplete;

    public static void OnStatsChanged()
    {
        statsChanged?.Invoke();
    }
    public static void OnChestChanged() 
    { 
        chestChanged?.Invoke(); 
    }
    public static void OnSlimeDroped(Slime slime)
    {
        if (slime != null)
        {
            slimeDroped?.Invoke(slime);
        }
    }
    public static void OnChestHit() 
    {
        
        chestDamaged?.Invoke();
    }
    public static void OnCollectionComplete(string rarity)
    {
        collectionComplete?.Invoke(rarity);
    }
}

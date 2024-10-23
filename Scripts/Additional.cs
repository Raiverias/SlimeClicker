using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Additional : MonoBehaviour
{
    private static Collection collection;
    private void Awake()
    {
        collection = GetComponent<Collection>();
    }
    public static bool CollectionCheck(Slime slime) 
    {
        if (collection.slimes.Contains(slime)) 
        {
            return true;
        }
        else { return false; }
    }
   
}

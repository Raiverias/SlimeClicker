using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetLanguage();
    public string currentLanguage;
    public static Language Instance;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
            currentLanguage = GetLanguage();
        }
        else { Destroy(gameObject); }
    }

}

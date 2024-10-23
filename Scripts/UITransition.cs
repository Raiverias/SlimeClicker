using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UITransition : MonoBehaviour
{
    public Transform collectionWindow;
    public GameObject mainWindow;
    CollectionUI ui;



    private void Awake()
    {
        ui = GetComponent<CollectionUI>();
        
        
    }

    public void ToCollection() 
    {
        mainWindow.SetActive(false);
        //collectionWindow.localPosition = new Vector2(0, 0);
    }
    public void FromCollection() 
    {
        mainWindow.SetActive(true);
        //collectionWindow.localPosition = new Vector2(1920, 0);
    }
    #region
    /*public void OnEnable()
    {

        collectionWindow.localPosition = new Vector2(0, 0);
        collectionWindow.LeanMoveLocalX(0, 0).setEaseOutExpo().delay = 0.1f;
        ui.UpdateUI();
        
    }
    public void OnDisable() 
    {
        collectionWindow.localPosition = new Vector2(+Screen.width, 0);
        collectionWindow.LeanMoveLocalX(0, 0).setEaseInExpo();
        
    }*/
    #endregion
}

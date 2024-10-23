using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionSlot : MonoBehaviour
{
    private Color common;
    private Color uncommon;
    private Color rare;
    private Color epic;
    private Color legendary;

    public Image image;
    public Image frame;
    public int id;
    private bool isOwned { get; set; }
    private void Awake()
    {
        Events.slimeDroped += OwnershipCheck;
    }
    public void LoadUI(Slime slime)
    {

        image.sprite = Resources.Load<Sprite>(slime.sprite_path);
        ChangeFrame(slime);
        id = slime.id;

    }
    public void OwnershipCheck(Slime slime) 
    {
        if (slime.id == id && image != null) 
        {
            image.color = Color.white;
            isOwned = true;
            Events.slimeDroped -= OwnershipCheck;
        }
        
    }
    private void ChangeFrame(Slime slime) 
    {
        ColorUtility.TryParseHtmlString("#FFFFFF", out common);
        ColorUtility.TryParseHtmlString("#3AD660", out uncommon);
        ColorUtility.TryParseHtmlString("#3AB0D6", out rare);
        ColorUtility.TryParseHtmlString("#C03AD6", out epic);
        ColorUtility.TryParseHtmlString("#D6893A", out legendary);
        
        switch (slime.rarity)
        {
            
            case ("COMMON"):
                frame.color = common;
                break;
            case ("UNCOMMON"):
                frame.color = uncommon;
                break;
            case ("RARE"):
                frame.color = rare;
                break;
            case ("EPIC"):
                frame.color = epic;
                break;
            case ("LEGENDARY"):
                frame.color = legendary;
                break;
        }
    }
    

}

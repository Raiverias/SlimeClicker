using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;


public class DropUI : MonoBehaviour
{
    private Color common;
    private Color uncommon;
    private Color rare;
    private Color epic;
    private Color legendary;


    float timer = 3f;
    public Image image;
    public Image frame;
    public GameObject text_new;
    public int id;

    
    public void LoadUI(Slime slime)
    {
        
        if (Resources.Load<Sprite>(slime.sprite_path) != null)
        {
            
            image.sprite = Resources.Load<Sprite>(slime.sprite_path);
            ChangeFrame(slime);
            id = slime.id;
            if (Additional.CollectionCheck(slime)) { text_new.SetActive(false); } else { text_new.SetActive(true); }
            
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
    private void FixedUpdate()
    {
        float fade_timer = 0.8f;
        timer -= Time.deltaTime;
        if (timer < 2)
        {
            GetComponent<Image>().CrossFadeAlpha(0, fade_timer, true);
            image.CrossFadeAlpha(0, fade_timer, true);
            frame.CrossFadeAlpha(0, fade_timer, true);
            
        }
        if (timer < 0) { Destroy(gameObject); ; }
    }
   
    private void OnDestroy()
    {
        image.sprite = null;
    }

}

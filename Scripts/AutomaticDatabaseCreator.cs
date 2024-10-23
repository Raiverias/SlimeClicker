using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class AutomaticDatabaseCreator : MonoBehaviour
{
    private GameData gameData;
    [SerializeField] private List<Sprite> common_slime_sprites;
    [SerializeField] private List<Sprite> uncommon_slime_sprites;
    [SerializeField] private List<Sprite> rare_slime_sprites;
    [SerializeField] private List<Sprite> epic_slime_sprites;
    [SerializeField] private List<Sprite> legendary_slime_sprites;
    private Slime slime;
    private string path = "Sprites/Slimes";
    private void Awake()
    {
        
        gameData = SaveSystem.Instance.gameData;
        common_slime_sprites = Resources.LoadAll<Sprite>(path+"/Common").ToList();
        uncommon_slime_sprites = Resources.LoadAll<Sprite>(path + "/Uncommon").ToList();
        rare_slime_sprites = Resources.LoadAll<Sprite>(path + "/Rare").ToList();
        epic_slime_sprites = Resources.LoadAll<Sprite>(path + "/Epic").ToList();
        legendary_slime_sprites = Resources.LoadAll<Sprite>(path + "/Legendary").ToList();
        LoadSlimes();
    }
    private void LoadSlimes() 
    {
        Debug.Log("init");
        int id = 0;
        foreach (Sprite item in common_slime_sprites)
        {
           
            slime = new Slime();
            id++;
            slime.sprite_path = path + "/Common/" + item.name;
            slime.id = id;
            slime.rarity = "COMMON";
            if (!gameData.slimeDatabase.common.Contains(slime) && gameData.slimeDatabase.common != null) { gameData.slimeDatabase.common.Add(slime); }
            
        }
        foreach (Sprite item in uncommon_slime_sprites)
        {
            slime = new Slime();
            id++;
            slime.sprite_path = path + "/Uncommon/" + item.name;
            slime.id = id;
            slime.rarity = "UNCOMMON";
            
            if (!gameData.slimeDatabase.uncommon.Contains(slime) && gameData.slimeDatabase.uncommon != null) { gameData.slimeDatabase.uncommon.Add(slime);}
        }
        foreach (Sprite item in rare_slime_sprites)
        {
            slime = new Slime();
            id++;
            slime.sprite_path = path + "/Rare/" + item.name;
            slime.id = id;
            slime.rarity = "RARE";
            
            if (!gameData.slimeDatabase.rare.Contains(slime) && gameData.slimeDatabase.rare != null) { gameData.slimeDatabase.rare.Add(slime);}
        }
        foreach (Sprite item in epic_slime_sprites)
        {
            slime = new Slime();
            id++;
            slime.sprite_path = path + "/Epic/" + item.name;
            slime.id = id;
            slime.rarity = "EPIC";
            gameData.slimeDatabase.epic.Add(slime);
            if (!gameData.slimeDatabase.epic.Contains(slime) && gameData.slimeDatabase.epic != null) { gameData.slimeDatabase.epic.Add(slime); }
        }
        foreach (Sprite item in legendary_slime_sprites)
        {
            slime = new Slime();
            id++;
            slime.sprite_path = path + "/Legendary/" + item.name;
            slime.id = id;
            slime.rarity = "LEGENDARY";
            
            if (!gameData.slimeDatabase.legendary.Contains(slime) && gameData.slimeDatabase.legendary != null) { gameData.slimeDatabase.legendary.Add(slime); }
        }
    }

    /*private bool isExists(Sprite slime, List<Sprite> sprites) 
    {
        if (sprites.Contains(slime)){  return true; } return false;
    }*/
}

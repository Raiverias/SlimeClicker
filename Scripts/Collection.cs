using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Collection : MonoBehaviour
{
    GameData gameData;
    public List<Slime> slimes = new List<Slime>();
    public SlimeDatabase slimeDatabase = new SlimeDatabase();
    bool is_common_completed;
    bool is_uncommon_completed;
    bool is_rare_completed;
    bool is_epic_completed;
    bool is_legendary_completed;

    
    private void Awake()
    {
        Events.slimeDroped += Add;
        
        

    }
    private void Start()
    {
        gameData = SaveSystem.Instance.gameData;
        Debug.Log(gameData.ToString());
        LoadCollection();
    }

    public void LoadCollection()
    {
        if (gameData.slimesInCollection != null)
        {
            slimeDatabase = gameData.slimesInCollection;
        }
    }

    public void Add(Slime slime)
    {

        if (slime != null && !isExists(slime))
        {
            slimes.Add(slime);
            switch (slime.rarity)
            {
                case ("COMMON"):
                    slimeDatabase.common.Add(slime);
                    if (slimeDatabase.common.Count == gameData.slimeDatabase.common.Count && is_common_completed == false) { Events.OnCollectionComplete("COMMON"); is_common_completed = true; Debug.Log(slime.rarity); }
                    break;
                case ("UNCOMMON"):
                    slimeDatabase.uncommon.Add(slime);
                    if (slimeDatabase.uncommon.Count == gameData.slimeDatabase.uncommon.Count && is_uncommon_completed == false) { Events.OnCollectionComplete("UNCOMMON"); is_uncommon_completed = true; Debug.Log(slime.rarity); }
                    break;
                case ("RARE"):
                    slimeDatabase.rare.Add(slime);
                    if (slimeDatabase.rare.Count == gameData.slimeDatabase.rare.Count && is_rare_completed == false) { Events.OnCollectionComplete("RARE"); is_rare_completed = true; Debug.Log(slime.rarity); }
                    break;
                case ("EPIC"):
                    slimeDatabase.epic.Add(slime);
                    if (slimeDatabase.epic.Count == gameData.slimeDatabase.epic.Count && is_epic_completed == false) { Events.OnCollectionComplete("EPIC"); is_epic_completed = true; Debug.Log(slime.rarity); }
                    break;
                case ("LEGENDARY"):
                    slimeDatabase.legendary.Add(slime);
                    if (slimeDatabase.legendary.Count == gameData.slimeDatabase.legendary.Count && is_legendary_completed == false) { Events.OnCollectionComplete("LEGENDARY"); is_legendary_completed = true; Debug.Log(slime.rarity); }
                    break;



            }
            SaveCollection();
        }

    }
    private void SaveCollection()
    {
        gameData.slimesInCollection = slimeDatabase;
    }
    private bool isExists(Slime slime)
    {
        if (slimes.Contains(slime)) { return true; }
        else { return false; }
    }
    private void OnDisable()
    {
        Events.slimeDroped -= Add;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Completion : MonoBehaviour
{
    public Slider slider;
    GameData gameData;
    [SerializeField] private Collection collection;
    [SerializeField] private int common_count;
    [SerializeField] private int uncommon_count;
    [SerializeField] private int rare_count;
    [SerializeField] private int epic_count;
    [SerializeField] private int legendary_count;

    private void Start()
    {
        gameData = SaveSystem.Instance.gameData;
        collection = GetComponent<Collection>();
        common_count = gameData.slimeDatabase.common.Count;
        uncommon_count = gameData.slimeDatabase.uncommon.Count;
        rare_count= gameData.slimeDatabase.rare.Count;
        epic_count = gameData.slimeDatabase.epic.Count;
        legendary_count = gameData.slimeDatabase.legendary.Count;
    }
    public void UpdateUI(string rarity) 
    {
        switch (rarity)
        {
            case ("COMMON"):
                slider.maxValue = common_count;
                slider.value = collection.slimeDatabase.common.Count; 
                break;
            case ("UNCOMMON"):
                slider.maxValue = uncommon_count;
                slider.value = collection.slimeDatabase.uncommon.Count;
                break;
            case ("RARE"):
                slider.maxValue = rare_count;
                slider.value = collection.slimeDatabase.rare.Count;
                break;
            case ("EPIC"):
                slider.maxValue = epic_count;
                slider.value = collection.slimeDatabase.epic.Count;
                break;
            case ("LEGENDARY"):
                slider.maxValue = legendary_count;
                slider.value = collection.slimeDatabase.legendary.Count;
                break;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectionUI : MonoBehaviour
{
    GameData gameData;
    
    public GameObject common_holder;
    public GameObject uncommon_holder;
    public GameObject rare_holder;
    public GameObject epic_holder;
    public GameObject legendary_holder;
    public GameObject collectionSlotPrefab;
    public RectTransform all_slots_holder;
    [SerializeField] List<GameObject> common_slots = new List<GameObject>();
    [SerializeField] List<GameObject> uncommon_slots = new List<GameObject>();
    [SerializeField] List<GameObject> rare_slots = new List<GameObject>();
    [SerializeField] List<GameObject> epic_slots = new List<GameObject>();
    [SerializeField] List<GameObject> legendary_slots = new List<GameObject>();
    public CollectionSlot slot;
    

    public Completion progressBar;
    private List<GameObject> previous;
    private GameObject previous_holder;

    public string collection_state;
    private void Start()
    {
        gameData = SaveSystem.Instance.gameData;
        //collection_state = game_data.stats.collection_state;
        previous = new List<GameObject>();
        previous_holder = new GameObject();
        InitUI();
    }
    
    public void InitUI() 
    {
        foreach (Slime slime in gameData.slimeDatabase.common)
        {
            
            collectionSlotPrefab.GetComponent<CollectionSlot>().LoadUI(slime);
            InitSlot(slime);
            common_slots.Add(Instantiate(collectionSlotPrefab, all_slots_holder));
        }
        foreach (Slime slime in gameData.slimeDatabase.uncommon)
        {

            collectionSlotPrefab.GetComponent<CollectionSlot>().LoadUI(slime);
            InitSlot(slime);
            uncommon_slots.Add(Instantiate(collectionSlotPrefab, all_slots_holder));
        }
        foreach (Slime slime in gameData.slimeDatabase.rare)
        {

            collectionSlotPrefab.GetComponent<CollectionSlot>().LoadUI(slime);
            InitSlot(slime);
            rare_slots.Add(Instantiate(collectionSlotPrefab, all_slots_holder));
        }
        foreach (Slime slime in gameData.slimeDatabase.epic)
        {

            collectionSlotPrefab.GetComponent<CollectionSlot>().LoadUI(slime);
            InitSlot(slime);
            epic_slots.Add(Instantiate(collectionSlotPrefab, all_slots_holder));
        }
        foreach (Slime slime in gameData.slimeDatabase.legendary)
        {

            collectionSlotPrefab.GetComponent<CollectionSlot>().LoadUI(slime);
            InitSlot(slime);
            legendary_slots.Add(Instantiate(collectionSlotPrefab, all_slots_holder));
        }
        if(collection_state!= null) { ManageUI(collection_state); } else { ManageUI("COMMON"); }
        


    }
    private void InitSlot(Slime slime) 
    {
        Additional.CollectionCheck(slime);
    }
   
    public void ManageUI(string rarity)
    {
        
        switch (rarity)
        {
            case "COMMON":
                if(previous != null) { SlotsToBack(previous, previous_holder); }
                foreach (GameObject slot in common_slots)
                {
                    slot.transform.SetParent(common_holder.transform);
                    common_holder.SetActive(true);
                    
                }
                collection_state = rarity;
                progressBar.UpdateUI(rarity);
                
                previous = common_slots;
                previous_holder = common_holder;
                
                break;
            case "UNCOMMON":
                if (previous != null) { SlotsToBack(previous,previous_holder); }
                foreach (GameObject slot in uncommon_slots)
                {
                    slot.transform.SetParent(uncommon_holder.transform);
                    uncommon_holder.SetActive(true);
                    
                }
                collection_state = rarity;
                progressBar.UpdateUI(rarity);
                previous = uncommon_slots;
                previous_holder = uncommon_holder;
                break;
            case "RARE":
                if (previous != null) { SlotsToBack(previous, previous_holder); }
                foreach (GameObject slot in rare_slots)
                {
                    slot.transform.SetParent(rare_holder.transform);
                    rare_holder.SetActive(true);
                    
                }
                collection_state = rarity;
                progressBar.UpdateUI(rarity);
                previous = rare_slots;
                previous_holder = rare_holder;
                break;
            case "EPIC":
                if (previous != null) { SlotsToBack(previous, previous_holder); }
                foreach (GameObject slot in epic_slots)
                {
                    slot.transform.SetParent(epic_holder.transform);
                    epic_holder.SetActive(true);
                    
                }
                collection_state = rarity;
                progressBar.UpdateUI(rarity);
                previous = epic_slots;
                previous_holder = epic_holder;
                break;
            case "LEGENDARY":
                if (previous != null) { SlotsToBack(previous, previous_holder); }
                foreach (GameObject slot in legendary_slots)
                {
                    slot.transform.SetParent(legendary_holder.transform);
                    legendary_holder.SetActive(true);
                    
                }
                collection_state = rarity;
                progressBar.UpdateUI(rarity);
                previous = legendary_slots;
                previous_holder = legendary_holder; 
                break;

        }
    }
    private void SlotsToBack(List<GameObject> slots, GameObject holder) 
    {
        
        foreach (GameObject slot in slots)
        {
            slot.transform.SetParent(all_slots_holder);
            slot.transform.position = all_slots_holder.position;
        }
        holder.SetActive(false);
    }
}

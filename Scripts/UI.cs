using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{

    GameData data;
   
    [SerializeField] CollectionUI collectionUI;
    Completion completion;
    public GameObject auth;
    public Slider hitBar;
    public GameObject drop_prefab;
    public Transform drop_holder;
    public Chest chest;
    public Image chest_gfx;

    private void Awake()
    {
        
        completion = GetComponent<Completion>();
        Events.chestChanged += UpdateChestGFX;
        Events.chestDamaged += UpdateUI;
        Events.slimeDroped += UpdateDrop;

    }
    private void Start()
    {

        AuthButton();
        data = SaveSystem.Instance.gameData;
        hitBar.maxValue = data.chest_max_hp;
        hitBar.value = data.chest_hp;
        if(data.current_chest != null) { chest_gfx.sprite = data.current_chest; }
        

    }
    private void AuthButton() { if (SaveSystem.Instance.isAuth == true) { auth.SetActive(false); }}
    
    private void UpdateUI()
    {
        hitBar.value = data.chest_hp;

    }
    private void UpdateDrop(Slime slime)
    {
        completion.UpdateUI(collectionUI.collection_state);
        if (slime.sprite_path != null)
        {
            drop_prefab.GetComponent<DropUI>().LoadUI(slime);
            Instantiate(drop_prefab, drop_holder);

            
        }

    }

    public void UpdateChestGFX()
    {
        int rand = UnityEngine.Random.Range(0, chest.sprites.Count);

        if (chest.sprites[rand] != null) { chest_gfx.sprite = chest.sprites[rand]; }

        SaveChest();


    }
    private void SaveChest()
    {
        data.current_chest = chest_gfx.sprite;
    }
    private void OnDisable()
    {
        Events.chestChanged -= UpdateChestGFX;
        Events.chestDamaged -= UpdateUI;
        Events.slimeDroped -= UpdateDrop;
    }
}

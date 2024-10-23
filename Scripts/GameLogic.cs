using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameData data;
    public Chest chest;
    public MouseDown mouseDown;

    private void Start()
    {
        data = SaveSystem.Instance.gameData;
        mouseDown = GetComponent<MouseDown>();
        Events.collectionComplete += MultiplierChange;
        

    }

    public void Hit()
    {
        if (mouseDown.on_cooldown != true)
        {

            data.chest_hp -= 1;
            if (data.chest_hp <= 0)
            {
                data.chest_hp = data.chest_max_hp;
                Events.OnChestChanged();
            }
            Events.OnChestHit();
        }
    }
    private void MultiplierChange(string rarity)
    {
        data.double_drop_chance += data.double_drop_multiplier;
    }



    private void OnDisable()
    {
        Events.collectionComplete -= MultiplierChange;
    }
}

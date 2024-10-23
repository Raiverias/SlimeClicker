using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropSystem : MonoBehaviour
{
    GameData data;
    SlimeDatabase database;


    private void Start()
    {
        data = SaveSystem.Instance.gameData;
        database = data.slimeDatabase;
        Events.chestChanged += CheckDrop;
        Events.chestChanged += DoubleDropCheck;


    }
    private void CheckDrop()
    {
        int rand = Random.Range(0, 100);



        if (rand <= data.legendary_chance) { DropLegendary(); }
        else if (rand <= data.epic_chance) { DropEpic(); }
        else if (rand <= data.rare_chance) { DropRare(); }
        else if (rand <= data.uncommon_chance) { DropUncommon(); }
        else if (rand <= data.common_chance) { DropCommon(); }
    }
    private void DoubleDropCheck()
    {

        int rand = Random.Range(0, 100);
        if (rand <= data.double_drop_chance) { CheckDrop(); Debug.Log("Double Drop"); }
    }

    public void DropCommon() { Events.OnSlimeDroped(database.common[Random.Range(0, database.common.Count)]); }
    public void DropUncommon() { Events.OnSlimeDroped(database.uncommon[Random.Range(0, database.uncommon.Count)]); }
    public void DropRare() { Events.OnSlimeDroped(database.rare[Random.Range(0, database.rare.Count)]); }
    public void DropEpic() { Events.OnSlimeDroped(database.epic[Random.Range(0, database.epic.Count)]); }
    public void DropLegendary() { Events.OnSlimeDroped(database.legendary[Random.Range(0, database.legendary.Count)]); }


    private void OnDisable()
    {
        Events.chestChanged -= CheckDrop;
        Events.chestChanged -= DoubleDropCheck;
    }

}

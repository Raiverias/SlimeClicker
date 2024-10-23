using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    
    [SerializeField] private int _chest_hp = 20;
    [SerializeField] private int _chest_max_hp = 20;
    [SerializeField] private Sprite _currentChest;
    [SerializeField] private SlimeDatabase _slimeDatabase;
    [SerializeField] private SlimeDatabase _slimesInCollection;
    public float musicVolume = 1;
    public float sfxVolume = 1;
    public bool IsFirstLaucnh;
    


    
    public int chest_hp { get { return _chest_hp; } set { _chest_hp = value; } }
    public int chest_max_hp { get { return _chest_max_hp; } }
    public SlimeDatabase slimesInCollection{ get { return _slimesInCollection; } set { _slimesInCollection = value; } }
    public Sprite current_chest { get { return _currentChest; } set { _currentChest = value; } }
    
    public SlimeDatabase slimeDatabase
    {
        get { return _slimeDatabase; }
        set { _slimeDatabase = value; }
    }

    [SerializeField] private int _common_chance = 80;
    [SerializeField] private int _uncommon_chance = 60;
    [SerializeField] private int _rare_chance = 35;
    [SerializeField] private int _epic_chance = 10;
    [SerializeField] private int _legendary_chance = 2;
    [SerializeField] private int _double_drop_chance = 2;
    [SerializeField] private int _double_drop_multiplier = 4;

    public int common_chance { get { return _common_chance; } }
    public int uncommon_chance { get { return _uncommon_chance; } }
    public int rare_chance { get { return _rare_chance; } }
    public int epic_chance { get { return _epic_chance; } }
    public int legendary_chance { get { return _legendary_chance; } }

    public int double_drop_chance { get { return _double_drop_chance; } set { _double_drop_chance = value; } }
    public int double_drop_multiplier { get { return _double_drop_multiplier; } }




}


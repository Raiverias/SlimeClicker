using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Slime 
{
    [SerializeField] private string _sprite_path;
    [SerializeField] private int _id;
    [SerializeField] private string _rarity;

    public string sprite_path { get { return _sprite_path; } set { _sprite_path = value; } }
    public int id { get { return _id; } set { _id = value; } }
    public string rarity { get { return _rarity; } set { _rarity = value; } }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


public class Chest : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites = new List<Sprite>();
    
    private string sprites_file_path = "Sprites/Chests";

    private void Awake()
    {
        sprites = Resources.LoadAll<Sprite>(sprites_file_path).ToList();
    }


    public List<Sprite> sprites { get { return _sprites; } set {  _sprites = value; } }
    
    


}

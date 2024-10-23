using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private float saveTimer = 10f;
    private float advTimer = 210f;

    public static SaveSystem Instance;
   
    public GameData gameData;
    public GameData standard_data;
    [DllImport("__Internal")]
    private static extern void SaveData(string data);
    [DllImport("__Internal")]
    private static extern void LoadData();
    [DllImport("__Internal")]
    public static extern void ShowAdv();
    [DllImport("__Internal")]
    private static extern void Auth();
    [DllImport("__Internal")]
    private static extern void GameIsReady();
    [DllImport("__Internal")]
    private static extern bool AuthCheck();
    public bool isAuth;

    [SerializeField] public SlimeDatabase slimeDatabase = new SlimeDatabase();

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }

#if !UNITY_EDITOR
        
        Events.chestChanged += Save;
        LoadData();
        isAuth = AuthCheck();
        
#endif

    }
#if !UNITY_EDITOR
    private void FixedUpdate()
    {
        if (saveTimer <= 0) { Save(); saveTimer = 10f; }
        else { saveTimer -= Time.fixedDeltaTime; }
        
        
    }
#endif
    private void Start()
    {
#if !UNITY_EDITOR
        GameIsReady();
        Time.timeScale = 0;
        ShowAdvertisment();
        Time.timeScale = 1;
#endif
    }

    private void Load(string value)
    {
        if (standard_data.slimeDatabase != JsonUtility.FromJson<GameData>(value).slimeDatabase)
        {
            gameData = standard_data;
        }
        else 
        { 
            gameData = JsonUtility.FromJson<GameData>(value);
            Debug.Log(value);
        }
        Debug.Log("Load");
        
        
    }
    public void Authorize() { Time.timeScale = 0; Auth(); Time.timeScale = 1; }
    private void Save()

    {
        string jsonData = JsonUtility.ToJson(gameData);
        SaveData(jsonData);
        Debug.Log("Save");
    }
    private void ShowAdvertisment() { Time.timeScale = 0; ShowAdv(); Time.timeScale = 1; }
#if !UNITY_EDITOR
    private void OnDisable()
    {
        Events.chestChanged -= Save;
    }
#endif
}
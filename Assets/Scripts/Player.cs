using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private int exp = 0;
    [SerializeField] private int req_exp = 1000;
    [SerializeField] private int levelBase = 100;
    [SerializeField] private List<GameObject> items = new List<GameObject>();
    private int level = 1;

    private string path;
  

    public int Req_exp { get => req_exp; set => req_exp = value; }
    public int Exp { get => exp; set => exp = value; }
    public int LevelBase { get => levelBase; set => levelBase = value; }
    public List<GameObject> Items { get => items; set => items = value; }
    public int Level { get => level; set => level = value; }


    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/player.dat";
        Load();
    }

    public void AddExp(int exp)
    {
        this.exp += Mathf.Max(0, exp);
        InitLevelData();
        Save();
    }

    public void AddItem(GameObject item)
    {
        items.Add(item);
        Save();
    }

    private void InitLevelData()
    {
        level = (exp / levelBase) + 1;
        req_exp = levelBase * level;
    }

    private void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        PlayerData data = new PlayerData(this);
        bf.Serialize(file, data);
        file.Close();
    }

    private void Load()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            exp = data.Exp;
            req_exp = data.RequiredExp;
            levelBase = data.LevelBase;
            level = data.Level;

            //Load items/enemy
        }
        else
        {
            InitLevelData();
        }
    }

}

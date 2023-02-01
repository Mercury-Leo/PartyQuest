using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{

    private int exp;
    private int req_exp;
    private int levelBase;
    private int level;
    private List<GameObject> items;

    public int Exp { get => exp; set => exp = value; }
    public int RequiredExp { get => req_exp; set => req_exp = value; }
    public int LevelBase { get => levelBase; set => levelBase = value; }
    public int Level { get => level; set => level = value; }
    public List<GameObject> Items { get => items; set => items = value; }

    public PlayerData(Player player)
    {
        this.exp = player.Exp;
        this.req_exp = player.Req_exp;
        this.levelBase = player.LevelBase;
        this.level = player.Level;
        this.items = player.Items;
        /*
        foreach (GameObject itemsObj in player.Items)
        {
            Enemy enemy = itemsObj.GetComponent<Enemy>();//should be ITEMS ofcourse and not enemy
            if(enemy != null)
            {
                EnemyData data = new EnemyData(enemy);
                items.Add(data);
            }
        } */
    }
}

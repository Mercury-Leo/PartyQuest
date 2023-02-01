using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyData 
{

    private float spawnRate;
    private float catchRate;
    private int attack;
    private int defenece;
    private int hp;
    private string crySound;

    public EnemyData(Enemy enemy)
    {
        this.SpawnRate = enemy.SpawnRate;
        this.CatchRate = enemy.CatchRate;
        this.Attack = enemy.Attack;
        this.Defenece = enemy.Defenece;
        this.Hp = enemy.Hp;
        this.CrySound = enemy.CrySound.name;
    }

    public float SpawnRate { get => spawnRate; set => spawnRate = value; }
    public float CatchRate { get => catchRate; set => catchRate = value; }
    public int Attack { get => attack; set => attack = value; }
    public int Defenece { get => defenece; set => defenece = value; }
    public int Hp { get => hp; set => hp = value; }
    public string CrySound { get => crySound; set => crySound = value; }
}

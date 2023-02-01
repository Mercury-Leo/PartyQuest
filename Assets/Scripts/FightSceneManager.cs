using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSceneManager : PartyQuestSceneManager
{
    public override void enemyTapped(GameObject Enemy)
    {
        print("enemy Tapped!");
    }

    public override void playerTapped(GameObject player)
    {
        print("player Tapped!");
    }

}

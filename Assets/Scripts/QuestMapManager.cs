using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestMapManager : PartyQuestSceneManager
{
    public override void enemyTapped(GameObject Enemy)
    {
        //SceneManager.LoadScene(PartyQuestConst.SCENE_FIGHT, LoadSceneMode.Additive);
        List<GameObject> list = new List<GameObject>();
        list.Add(Enemy);
        SceneTransitionManager.Instance.GoToScene(PartyQuestConst.SCENE_FIGHT, list);
    }

    public override void playerTapped(GameObject player)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

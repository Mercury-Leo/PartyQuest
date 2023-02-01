using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemyFactory : Singleton<EnemyFactory>
{

    [SerializeField] private Enemy[] availableEnemies;
    [SerializeField] private float waitTime = 180f;
    [SerializeField] private int startingEnemies = 5;
    [SerializeField] private float minRange = 5f;
    [SerializeField] private float maxRange = 50f;

    private List<Enemy> liveEnemies = new List<Enemy>();
    private Enemy selectedEnemy;
    private Player player;

    public List<Enemy> LiveEnemies { get => liveEnemies; set => liveEnemies = value; }
    public Enemy SelectedEnemy { get => selectedEnemy; set => selectedEnemy = value; }

    private void Awake()
    {
        Assert.IsNotNull(availableEnemies);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.CurrentPlayer;
        Assert.IsNotNull(player);
        for(int i = 0; i < startingEnemies; i++)
        {
            InstantiateEnemy();
        }
        StartCoroutine(GenerateEnemy());
    }

    public void EnemyWasSelected(Enemy enemy)
    {
        selectedEnemy = enemy;
    }

    private IEnumerator GenerateEnemy()
    {
        while (true)
        {
            InstantiateEnemy();
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void InstantiateEnemy()
    {
        int index = Random.Range(0, availableEnemies.Length);
        float x = player.transform.position.x + GenerateRange();
        float y = player.transform.position.y;
        float z = player.transform.position.z + GenerateRange();
        LiveEnemies.Add(Instantiate(availableEnemies[index], new Vector3(x, y, z), Quaternion.identity));
    }

    private float GenerateRange()
    {
        float randomNum = Random.Range(minRange, maxRange);
        bool isPos = Random.Range(0, 10) < 5;
        return randomNum * (isPos ? 1 : -1);
    }

}

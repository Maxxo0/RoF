using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] bool spawn1;
    [SerializeField] bool spawn2;
    [SerializeField] bool spawn3;

    public int firstRange;
    public int secondRange;

    [SerializeField] GameObject enemy1, enemy2, enemy3;

    [List][SerializeField] GameObject[] enemies1;
    [List][SerializeField] GameObject[] enemies2;
    [List][SerializeField] GameObject[] enemies3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.stateS == 1) { firstRange = 0; secondRange = 2; }
        if (GameManager.Instance.stateS == 2) { firstRange = 2; secondRange = 4; }
        if (GameManager.Instance.stateS == 3) { firstRange = 4; secondRange = 6; }
        if (GameManager.Instance.stateS == 4) { firstRange = 6; secondRange = 8; }
        if (GameManager.Instance.stateS == 5) { firstRange = 8; secondRange = 10; }
        if (GameManager.Instance.stateS == 6) { firstRange = 10; secondRange = 12; }
        if (GameManager.Instance.stateS == 7) { firstRange = 12; secondRange = 14; }

    }

    public void SpawnEnemies()
    {
        if (spawn1 == true)
        {
            int eN1 = Random.Range(firstRange, secondRange);
            enemy1 = enemies1[eN1];
            Enemy enemy = enemy1.GetComponent<Enemy>();
            enemy.enemyT = Enemy.EnemyType.Enemy1;
            GameManager.Instance.maxEnemies++;
            GameManager.Instance.canE1 = true;
            Instantiate(enemy1, transform.position, enemy1.transform.rotation); Debug.Log("1");


        }
        if (spawn2 == true)
        {
            int eN2 = Random.Range(firstRange, secondRange);
            enemy2 = enemies2[eN2];
            Enemy enemy = enemy2.GetComponent<Enemy>();
            enemy.enemyT = Enemy.EnemyType.Enemy2;
            GameManager.Instance.maxEnemies++;
            GameManager.Instance.canE2 = true;
            Instantiate(enemy2, transform.position, enemy2.transform.rotation); Debug.Log("2");


        }
        if (spawn3 == true)
        {
            int eN3 = Random.Range(firstRange, secondRange);
            enemy3 = enemies3[eN3];
            Enemy enemy = enemy3.GetComponent<Enemy>();
            enemy.enemyT = Enemy.EnemyType.Enemy3;
            GameManager.Instance.maxEnemies++;
            GameManager.Instance.canE3 = true;
            Instantiate(enemy3, transform.position, enemy2.transform.rotation); Debug.Log("3");


        }
    }
}

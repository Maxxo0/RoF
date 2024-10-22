using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] bool spawn1;
    [SerializeField] bool spawn2;
    [SerializeField] bool spawn3;

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
        
    }

    public void SpawnEnemies()
    {
        if (spawn1 == true)
        {
            int eN1 = Random.Range(0, enemies1.Length);
            enemy1 = enemies1[eN1];
            Instantiate(enemy1, transform.position, Quaternion.identity); Debug.Log("1");
        }
        if (spawn2 == true)
        {
            int eN2 = Random.Range(0, enemies2.Length);
            enemy2 = enemies2[eN2];
            Instantiate(enemy2, transform.position, Quaternion.identity); Debug.Log("2");
        }
        if (spawn3 == true)
        {
            int eN3 = Random.Range(0, enemies3.Length);
            enemy3 = enemies3[eN3];
            Instantiate(enemy3, transform.position, Quaternion.identity); Debug.Log("3");
        }
    }
}

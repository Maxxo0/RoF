using Maxxo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    BattleSceneManager battleSceneManager;
    public EnemyClass enemyC;
    public enum EnemyClass { spider, skeleton, }

    public enum EnemyType { Enemy1, Enemy2, Enemy3 };
    public EnemyType enemyT;
    public int eAction;


    private void Awake()
    {
        battleSceneManager = FindObjectOfType<BattleSceneManager>();


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void Attack()
    {

    }
}

using Maxxo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    BattleSceneManager battleSceneManager;
    public EnemyClass enemyC;
    public enum EnemyClass { Spider, Skeleton, BigSpider, Mimic }

    public Turn enemyT;
    public enum Turn { Enemy1, Enemy2, Enemy3 }
    public int eAction;
    public bool eCanAct;


    private void Awake()
    {
        battleSceneManager = FindObjectOfType<BattleSceneManager>();


    }

    // Start is called before the first frame update
    void Start()
    {
        eCanAct = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (eCanAct == true ) { }
    }

    
    void Attack()
    {

    }
}

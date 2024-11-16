using Maxxo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    BattleSceneManager battleSceneManager;
    public EnemyClass enemyC;
    public enum EnemyClass { Spider, Skeleton, BigSpider, Mimic }

    public EnemyType enemyT;
    public enum EnemyType { Enemy1, Enemy2, Enemy3 }
    public int eAction;
    public bool eCanAct;
    public int eDamage;
   


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
        if (eAction > 4) { eAction = 0; }

        if (eCanAct)
        {
            if (GameManager.Instance.turn == GameManager.Turn.Enemy1 && enemyT == EnemyType.Enemy1) { EnemyAction(); }
        }
    }

    public void EnemyAction() 
    {
        switch (enemyC)
        {
            case EnemyClass.Spider:
                if (eAction >= 0) 
                {
                    eCanAct = false;
                    eAction++;
                    int randomHit = Random.Range(0, 10);
                    if (randomHit > 8) { Stun(); }
                    else { Attack(); }
                }
                break;
        }
    }


    public IEnumerator CTurn()
    {
        yield return new WaitForSeconds(1);
        battleSceneManager.ChangeTurn();


        yield return null;
    }

    public void Attack()
    {
        GameManager.Instance.healthPlayer.TakeDMG(eDamage);
        StartCoroutine(CTurn());
    }

    public void Stun()
    {
        GameManager.Instance.pStun = true;
    }

    public void BuffDamage()
    {

    }

    public void Defend()
    {

    }
}

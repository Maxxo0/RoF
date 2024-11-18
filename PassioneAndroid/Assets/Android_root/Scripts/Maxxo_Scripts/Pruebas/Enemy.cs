using Maxxo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    BattleSceneManager battleSceneManager;
    public EnemyClass enemyC;
    public enum EnemyClass { Spider, Skeleton, Rat, Mimic, Demon, Worm, Eye, Drake }

    public EnemyType enemyT;
    [SerializeField] Animator animator;
    public enum EnemyType { Enemy1, Enemy2, Enemy3 }
    public int eAction;
    public bool eCanAct;
    public bool isDig;
    public int eDamage;
    public int eArmor;
    HealtManager enemyHealth;
   


    private void Awake()
    {
        battleSceneManager = FindObjectOfType<BattleSceneManager>();
        enemyHealth = GetComponent<HealtManager>();
        animator = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        isDig = false;
        eCanAct = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (eAction > 4) { eAction = 0; }

        if (eCanAct)
        {
            if (GameManager.Instance.turn == GameManager.Turn.Enemy1 && enemyT == EnemyType.Enemy1) { EnemyAction(); }
            if (GameManager.Instance.turn == GameManager.Turn.Enemy2 && enemyT == EnemyType.Enemy2) { EnemyAction(); }
            if (GameManager.Instance.turn == GameManager.Turn.Enemy3 && enemyT == EnemyType.Enemy3) { EnemyAction(); }
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
                    if (randomHit > 8) { eCanAct = false; animator.SetTrigger("Stun"); }
                    else { eCanAct = false;  animator.SetTrigger("Attack"); }
                }
                break;
            case EnemyClass.Skeleton:
                if (eAction == 0 || eAction == 2 || eAction == 4) 
                {
                    eCanAct = false;
                    eAction++;
                    animator.SetTrigger("Attack");
                
                }
                else
                {
                    eCanAct = false;
                    eAction++;
                    Defend();
                }
                break;
            case EnemyClass.Rat:
                if (eAction >= 0)
                {
                    eCanAct = false;
                    eAction++;
                    int randomHit = Random.Range(0, 10);
                    if (randomHit > 8) { eCanAct = false; eAction++; animator.SetTrigger("Attack"); PoisonAttack(); }
                    else { eCanAct = false; eAction++; animator.SetTrigger("Attack"); }
                }
                break;
            case EnemyClass.Mimic:
                if (eAction >= 0) 
                {
                    eCanAct = false;
                    eAction++;
                    int randomHit = Random.Range(0, 10);
                    if (randomHit > 8) { eCanAct = false; ; animator.SetTrigger("Attack"); Stun(); }
                    else { eCanAct = false; ; animator.SetTrigger("Attack"); }

                }
                break;
            case EnemyClass.Eye:
                if (eAction >= 0) 
                {
                    eCanAct = false;
                    eAction++;
                    int randomHit = Random.Range(0, 10);
                    if (randomHit > 8) { eCanAct = false;  TakeEvassion(); }
                    else { eCanAct = false; ; TrueDamage(); }
                }
                break;
            case EnemyClass.Demon:
                if (eAction == 0 || eAction == 2 || eAction == 3 || eAction == 4)
                {
                    eCanAct = false;
                    eAction++;
                    animator.SetTrigger("Attack");

                }
                else { eCanAct = false; eAction++; BuffDamage(); }
                break;
            case EnemyClass.Worm:
                if (eAction >= 0) 
                {
                    if (!isDig)
                    {
                        eCanAct = false;
                        eAction++;
                        animator.SetTrigger("Attack");

                    }
                    else { eCanAct = false; eAction++; animator.SetBool("Exit", true); }
                }
                break;
            case EnemyClass.Drake:
                if (eAction >= 0) 
                {
                    Attack();
                }
                break;
        }
    }


    public IEnumerator CTurn()
    {
        yield return new WaitForSeconds(1);
        battleSceneManager.ChangeTurn();
        eCanAct = true;

        yield return null;
    }

    public void Attack()
    {
        Debug.Log("Ataque Enemigo");
        HealtManager healthPlayer = GameManager.Instance.player.GetComponent<HealtManager>();
        healthPlayer.TakeDMG(eDamage);
        StartCoroutine(CTurn());
        
    }

    public void PoisonAttack()
    {
        Debug.Log("Enevenenamiento");
        StartCoroutine(CTurn());
        //GameManager.Instance.healthPlayer.TakeDMG(eDamage);
    }

    public void TrueDamage()
    {
        Attack();
        Debug.Log("Daño Verdadero");
        StartCoroutine(CTurn());
        //GameManager.Instance.healthPlayer.TakeDMG(eDamage);
    }

    public void TakeEvassion()
    {
        Debug.Log("Evade");
        StartCoroutine(CTurn());
    }

    public void Stun()
    {
        Debug.Log("Stun");
        GameManager.Instance.pStun = true;
        StartCoroutine(CTurn());
    }

    public void BuffDamage()
    {
        Debug.Log("Buff Damage");
        StartCoroutine(CTurn());
    }

    public void Defend()
    {
        Debug.Log("Armor");
        enemyHealth.ArmorUp(eArmor);
        StartCoroutine(CTurn());

    }

    public void Dig()
    {
        Debug.Log("Dig");
        animator.SetBool("Exit", false);
        isDig = true;
        StartCoroutine(CTurn());
    }

    public void ExitDig()
    {
        Debug.Log("ExitDig");
        animator.SetBool("Exit", false);
        isDig = false;
        StartCoroutine(CTurn());
    }

    public void PassTurn()
    {
        StartCoroutine(CTurn());
    }
}

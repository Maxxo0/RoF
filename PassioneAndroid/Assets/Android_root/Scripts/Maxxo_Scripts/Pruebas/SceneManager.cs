using Maxxo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private static SceneManager instance;
    public static SceneManager Instance
    {
        get
        {
            if (instance == null)
            {

                Debug.Log("SceneManager is null!");
            }
            return instance;
        }
    }

    BattleSceneManager battleSceneManager;
    [SerializeField] GameObject deathKnight, necromancer;
    [SerializeField] GameObject introPanel, mapPanel, characterSelectPanel, rewardPanel, playerUI;
    [SerializeField] GameObject fprefab1, fprefab2, fprefab3, fprefab4, fprefab5;
    [SerializeField] GameObject enemy1, enemy2, enemy3;
    [SerializeField] GameObject eSpawn1, eSpawn2, eSpawn3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }

        battleSceneManager = FindObjectOfType<BattleSceneManager>();
    }

    public void SelectBattleType()
    {
        StartCoroutine(LoadBattle());
    }

    public IEnumerator LoadBattle()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //StartCoroutine(sceneFader.UI_Fade());
        yield return new WaitForSeconds(1);

        /*mapScene.SetActive(false);
        chestScene.SetActive(false);
        restScene.SetActive(false);
        playerIcon.SetActive(true);*/

        /*if (e == "enemy")*/
        battleSceneManager.StartHallwayFight();
        /*else if (e == "elite")
            battleSceneManager.StartEliteFight();*/

        //fade from black
        yield return new WaitForSeconds(1);
        Cursor.lockState = CursorLockMode.None;
    }

    public void GoCharacterSelect()
    {
        introPanel.SetActive(false);
        characterSelectPanel.SetActive(true);

    }

    public void SelectDeathKnight()
    {
        characterSelectPanel.SetActive(false);
        deathKnight.SetActive(true);
        GameManager.Instance.actualClass = GameManager.CharacterClass.deathknight;
        mapPanel.SetActive(true);

    }

    public void SelectNecromancer()
    {
        characterSelectPanel.SetActive(false);
        necromancer.SetActive(true);
        GameManager.Instance.actualClass = GameManager.CharacterClass.necromancer;
        mapPanel.SetActive(true);
    }

    public void SelectLevel()
    {
        StartCoroutine(LoadBattle());
        int escenary;
        int enemies;
        
        enemies = Random.Range(1, 4);
        
        escenary = Random.Range(1, 6);
        Debug.Log(escenary);
        if (escenary == 1) { fprefab1.SetActive(true); }
        if (escenary == 2) { fprefab2.SetActive(true); }
        if (escenary == 3) { fprefab3.SetActive(true); }
        if (escenary == 4) { fprefab4.SetActive(true); }
        if (escenary == 5) { fprefab5.SetActive(true); }

        if (enemies == 1 )  { EnemySpawner enemySpawner1 = eSpawn1.GetComponent<EnemySpawner>(); enemySpawner1.SpawnEnemies();  } 
       


        if (enemies == 2 ) 
        {
            EnemySpawner enemySpawner1 = eSpawn1.GetComponent<EnemySpawner>(); enemySpawner1.SpawnEnemies();
            EnemySpawner enemySpawner2 = eSpawn2.GetComponent<EnemySpawner>(); enemySpawner2.SpawnEnemies();
        }
        

        if (enemies == 3)
        {
            EnemySpawner enemySpawner1 = eSpawn1.GetComponent<EnemySpawner>(); enemySpawner1.SpawnEnemies();
            EnemySpawner enemySpawner2 = eSpawn2.GetComponent<EnemySpawner>(); enemySpawner2.SpawnEnemies();
            EnemySpawner enemySpawner3 = eSpawn3.GetComponent<EnemySpawner>(); enemySpawner3.SpawnEnemies();
        }

        mapPanel.SetActive(false);

    }
}

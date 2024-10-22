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
    [SerializeField] Transform eSpawn1, eSpawn2, eSpawn3;

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
        int lowEnemies;
        enemies = Random.Range(1, 4);
        lowEnemies = Random.Range(1, 3);
        escenary = Random.Range(1, 6);
        Debug.Log(escenary);
        if (escenary == 1) { fprefab1.SetActive(true); }
        if (escenary == 2) { fprefab2.SetActive(true); }
        if (escenary == 3) { fprefab3.SetActive(true); }
        if (escenary == 4) { fprefab4.SetActive(true); }
        if (escenary == 5) { fprefab5.SetActive(true); }

        if (enemies == 1 && lowEnemies == 1)  { Instantiate(enemy1, eSpawn1.position, Quaternion.identity); Debug.Log("1/1"); } 
        if (enemies == 1 && lowEnemies == 2)  { Instantiate(enemy2, eSpawn1.position, Quaternion.identity); Debug.Log("1/2"); }

        if (enemies == 2 && lowEnemies == 1) { Instantiate(enemy1, eSpawn1.position, Quaternion.identity); Instantiate(enemy1, eSpawn2.position, Quaternion.identity); Debug.Log("2/1"); }
        if (enemies == 2 && lowEnemies == 2) { Instantiate(enemy2, eSpawn1.position, Quaternion.identity); Instantiate(enemy2, eSpawn2.position, Quaternion.identity); Debug.Log("2/2"); }

        if (enemies == 3)
        {
            Debug.Log("Boss");
            Instantiate(enemy3, eSpawn3.position, Quaternion.identity);
            Instantiate(enemy1, eSpawn1.position, Quaternion.identity);
            Instantiate(enemy2, eSpawn2.position, Quaternion.identity);
        }

        mapPanel.SetActive(false);

    }
}

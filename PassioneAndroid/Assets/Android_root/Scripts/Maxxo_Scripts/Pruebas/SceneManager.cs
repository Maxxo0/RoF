using Maxxo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Enumeración para las clases de personaje
    public enum Classes
    {
        deathKnight = 0,
        necromancer = 1
    };

    // Singleton para el SceneManager
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

    // Cámara
    [Header("Cámaras")]
    [SerializeField] private GameObject baseCam;
    [SerializeField] private GameObject mapCam;

    // Referencia al BattleSceneManager
    private BattleSceneManager battleSceneManager;

    // Personajes
    [Header("Personajes")]
    public GameObject deathKnight;
    public GameObject necromancer;

    // Paneles de UI
    [Header("Paneles de UI")]
    [SerializeField] private GameObject introPanel;
    [SerializeField] private GameObject mapPanel;
    [SerializeField] private GameObject characterSelectPanel;
    [SerializeField] private GameObject rewardPanel;
    [SerializeField] private GameObject playerUI;

    // Prefabs
    [Header("Prefabs")]
    [SerializeField] private GameObject fprefab1;
    [SerializeField] private GameObject fprefab2;
    [SerializeField] private GameObject fprefab3;
    [SerializeField] private GameObject fprefab4;
    [SerializeField] private GameObject fprefab5;

    // Enemigos
    [Header("Enemigos")]
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;

    // Puntos de aparición de enemigos
    [Header("Puntos de aparición")]
    [SerializeField] private GameObject eSpawn1;
    [SerializeField] private GameObject eSpawn2;
    [SerializeField] private GameObject eSpawn3;

    // Estado de los enemigos
    [Header("Estado de Enemigos")]
    public bool enemyT1;
    public bool enemyT2;
    public bool enemyT3;

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
        yield return new WaitForSeconds(1);
        battleSceneManager.StartHallwayFight();

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

    public void OnCharacterSelect(int classIndex)
    {
        Classes selectedClass = (Classes)classIndex;
        SelectCharacter(selectedClass);
    }
    void SelectCharacter(Classes selectedClass)
    {
        characterSelectPanel.SetActive(false);
        switch (selectedClass) 
        {
            case Classes.deathKnight:
                deathKnight.SetActive(true);
                GameManager.Instance.player = deathKnight;
                GameManager.Instance.actualClass = GameManager.CharacterClass.deathknight;
                break;
            case Classes.necromancer:
                necromancer.SetActive(true);
                GameManager.Instance.player = necromancer;
                GameManager.Instance.actualClass = GameManager.CharacterClass.necromancer;
                break;
        }
        baseCam.SetActive(false);
        mapCam.SetActive(true);
        //mapPanel.SetActive(true);
    }

    public void SelectLevel()
    {
        StartCoroutine(LoadBattle());
        int escenary = Random.Range(1, 6);
        int enemies = Random.Range(1, 4);

        Debug.Log(escenary);

        // Activar prefab según el escenario seleccionado
        switch (escenary)
        {
            case 1: fprefab1.SetActive(true); break;
            case 2: fprefab2.SetActive(true); break;
            case 3: fprefab3.SetActive(true); break;
            case 4: fprefab4.SetActive(true); break;
            case 5: fprefab5.SetActive(true); break;
        }
        baseCam.SetActive(true);
        mapCam.SetActive(false);
        

        // Activar enemigos según la cantidad seleccionada
        if (enemies >= 1) eSpawn1.GetComponent<EnemySpawner>().SpawnEnemies();
        if (enemies >= 2) eSpawn2.GetComponent<EnemySpawner>().SpawnEnemies();
        if (enemies == 3) eSpawn3.GetComponent<EnemySpawner>().SpawnEnemies();

        //mapPanel.SetActive(false);
        
    }

    public void RewardPanel()
    {
        battleSceneManager.OffCard();
        rewardPanel.SetActive(true);
    }

    public void GoMap()
    {
        rewardPanel.SetActive(false);
        baseCam.SetActive(false);
        mapCam.SetActive(true);
    }
}

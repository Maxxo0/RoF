using Maxxo;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private GameObject playerUID;
    [SerializeField] private GameObject characterSelectPanel;
    [SerializeField] private GameObject rewardPanel;
    [SerializeField] private GameObject playerUI;
    [SerializeField] GameObject lose;
    [SerializeField] GameObject win;
    public Image hpE1, hpE2, hpE3;
    public TextMeshProUGUI energyText;
 
    

    // Prefabs
    [Header("Prefabs")]
    [SerializeField] private GameObject fprefab1;
    [SerializeField] private GameObject fprefab2;
    [SerializeField] private GameObject fprefab3;
    [SerializeField] private GameObject fprefab4;
    [SerializeField] private GameObject fprefab5;

    // Enemigos
    [Header("Enemigos")]
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    // Puntos de aparición de enemigos
    [Header("Puntos de aparición")]
    public GameObject eSpawn1;
    public GameObject eSpawn2;
    public GameObject eSpawn3;

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

    private void Update()
    {
        if (GameManager.Instance.stateS > 7) { Win(); }
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
        //mapPanel.SetActive(true);

    }

    public void SelectNecromancer()
    {
        characterSelectPanel.SetActive(false);
        necromancer.SetActive(true);
        GameManager.Instance.actualClass = GameManager.CharacterClass.necromancer;
        //mapPanel.SetActive(true);
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
        fprefab1.SetActive(false);
        fprefab2.SetActive(false);
        fprefab3.SetActive(false);
        fprefab4.SetActive(false);
        fprefab5.SetActive(false);

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
        playerUID.SetActive(true);
        //hpbars.SetActive(true);
        //spawns.SetActive(true);

        // Activar enemigos según la cantidad seleccionada
        if (enemies >= 1) eSpawn1.GetComponent<EnemySpawner>().SpawnEnemies();
        if (enemies >= 2) eSpawn2.GetComponent<EnemySpawner>().SpawnEnemies();
        if (enemies == 3) eSpawn3.GetComponent<EnemySpawner>().SpawnEnemies();

        //mapPanel.SetActive(false);
        
    }

    public void RewardPanel()
    {
        battleSceneManager.OffCard();
        //hpbars.SetActive(false);
        rewardPanel.SetActive(true);
        playerUID.SetActive(false);
        GameManager.Instance.player.GetComponent<ItemManager>().ActivarItemAleatorio();
    }

    public void GoMap()
    {
        playerUID.SetActive(false);
        //hpbars.SetActive(false);
        rewardPanel.SetActive(false);
        baseCam.SetActive(false);
        mapCam.SetActive(true);
    }

    public void Lose()
    {
        lose.SetActive(true);
    }

    public void Win()
    {
        win.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
    
}

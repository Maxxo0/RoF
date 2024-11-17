using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {

                Debug.Log("GameManager is null!");
            }
            return instance;
        }
    }


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
    }

    public List<ScriptableCard> playerDeck = new List<ScriptableCard>();
    public List<ScriptableCard> cardLibrary = new List<ScriptableCard>();
    public GameObject target;
    //public List<Relic> relics = new List<Relic>();
    //public List<Relic> relicLibrary = new List<Relic>();
    public Turn turn;
    public enum Turn { Player, Enemy1, Enemy2, Enemy3 };
    public int floorNumber = 1;
    public int goldAmount;
    public enum CharacterClass { deathknight, necromancer }
    
    public CharacterClass actualClass;
    public int maxEnemies = 3;
    public int deathEnemies = 0;
    public bool canE1, canE2, canE3;
    public HealtManager healthPlayer;
    public bool pStun;
    public int stateS;


    


}

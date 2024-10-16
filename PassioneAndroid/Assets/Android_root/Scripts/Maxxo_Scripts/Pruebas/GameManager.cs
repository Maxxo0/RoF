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

    public Character character;
    public List<ScriptableCard> playerDeck = new List<ScriptableCard>();
    public List<ScriptableCard> cardLibrary = new List<ScriptableCard>();
    //public List<Relic> relics = new List<Relic>();
    //public List<Relic> relicLibrary = new List<Relic>();
    public int floorNumber = 1;
    public int goldAmount;
    public enum CharacterClass { deathknight, necromancer }

    public CharacterClass actualClass;

    


}

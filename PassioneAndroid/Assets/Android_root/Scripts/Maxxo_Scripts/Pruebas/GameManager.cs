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

    [SerializeField] GameObject introPanel, mapPanel, characterSelectPanel, rewardPanel, playerUI;


    public CharacterClass characterClass;
    public enum CharacterClass { deathknight, necromancer }

    public CharacterClass actualClass;

    public void GoCharacterSelect()
    {
        introPanel.SetActive(false);
        characterSelectPanel.SetActive(true);

    }

    public void  SelectDeathKnight()
    {
        characterSelectPanel.SetActive(false);

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [Header("Player Stats")]
    public int health;
    public int energy;
   
    

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.actualClass == GameManager.CharacterClass.deathknight)
        {
            health = 100;
            energy = 3;
            
        }
        if (GameManager.Instance.actualClass == GameManager.CharacterClass.necromancer) 
        {
            health = 50;
            energy = 4;
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }

}

using Maxxo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRay : MonoBehaviour
{

    BattleSceneManager battleSceneManager;

    // Start is called before the first frame update

    private void Awake()
    {
        battleSceneManager = FindObjectOfType<BattleSceneManager>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Stationary )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Enemy")
                {
                    GameManager.Instance.target = hit.collider.gameObject;
                    Debug.Log("Enemigo");

                }
            }
        }
    }
}

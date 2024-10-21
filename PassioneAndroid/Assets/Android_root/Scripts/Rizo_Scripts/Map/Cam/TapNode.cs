using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapNode : MonoBehaviour
{
    [SerializeField] GameObject[] objectToActivate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) 
            {
                if (hit.transform.tag == "Node") 
                {
                    ObjectToActivate();
                    hit.collider.GetComponent<NodeRute>().NextFase();

                }
            }
        }   
    }

    void ObjectToActivate(bool desactive=true) 
    {

        foreach (GameObject obj in objectToActivate) 
        {
            obj.SetActive(desactive);
        }

    }

    public void ReturnToMap() 
    {
        ObjectToActivate(false);
    }
}

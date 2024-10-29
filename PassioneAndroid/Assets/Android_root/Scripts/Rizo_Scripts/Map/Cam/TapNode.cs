using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapNode : MonoBehaviour
{
    [SerializeField] GameObject[] objectToActivate;
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

    void ObjectToActivate(bool active=true) 
    {

        foreach (GameObject obj in objectToActivate) 
        {
            obj.SetActive(active);
        }

    }

    public void ReturnToMap() 
    {
        ObjectToActivate(false);
    }
}

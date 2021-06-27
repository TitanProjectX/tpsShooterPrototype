using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_modelzom_detect : MonoBehaviour
{
    //AI_modelzom AI_unitone;
    public float AI_area;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AI_area);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "AI_unitone")
        {
            Debug.Log("Detected");
        }
    }
}

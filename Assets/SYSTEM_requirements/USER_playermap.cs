using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USER_playermap : MonoBehaviour
{
    public Camera PlayerMap;
    private Transform player;
    private USER_playercontrol Client_userplayercontrol;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Client_userplayercontrol = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_playercontrol>();
    }

    // Update is called once per frame
    void Update()
    {
       // PlayerMap.transform.LookAt(player);
        // calcualte the which parametete goes to 
        if (Input.GetKey(KeyCode.W))
        {
            PlayerMap.transform.position += transform.forward * Client_userplayercontrol.Client_movementspeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            PlayerMap.transform.position += transform.forward * -1 * Client_userplayercontrol.Client_movementspeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            PlayerMap.transform.position += transform.right * -1 * Client_userplayercontrol.Client_movementspeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            PlayerMap.transform.position += transform.right * Client_userplayercontrol.Client_movementspeed * Time.deltaTime;
        }
    }
}

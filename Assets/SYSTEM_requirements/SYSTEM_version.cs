using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SYSTEM_version : MonoBehaviour
{
    // Start is called before the first frame update
    public int system_version;
    public int game_version;
    void Start()
    {
        //as default version
        system_version = 1;
        game_version = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(system_version < 2)
        {
            Debug.Log("system has been modified");
            game_version++;
        }
    }
}

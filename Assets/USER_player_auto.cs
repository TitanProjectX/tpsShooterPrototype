using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USER_player_auto : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 copy_transform_rotation;
    public Vector3 current_Transform_rotation;
    public Transform inverse_transform_rotation;
    public Transform reverse_transform_rotation;


    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        // inverse_transform_rotation.transform.rotation = Quaternion.Euler(-reverse_transform_rotation.position);
        inverse_transform_rotation.position *= -reverse_transform_rotation.transform.position.x;
    }
}

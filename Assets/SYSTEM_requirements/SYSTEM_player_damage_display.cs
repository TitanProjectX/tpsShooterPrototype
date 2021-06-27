using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SYSTEM_player_damage_display : MonoBehaviour
{
    // Start is called before the first frame update
    public Text player_damage_view;
    public Camera main_camera;
    public Transform _object;
    void Start()
    {
        main_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player_damage_view.text = "1";
    }

    // Update is called once per frame
    void Update()
    {
        _object.LookAt(_object.transform.position + main_camera.transform.rotation * Vector3.forward,
       main_camera.transform.rotation * Vector3.up);
    }
}

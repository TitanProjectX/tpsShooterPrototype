using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SYSTEM_damage_display : MonoBehaviour
{
    public Text damage_view;
    public Camera main_camera;
    public Transform _object;
    // Start is called before the first frame update
    void Start()
    {
        main_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        damage_view.text = "1";
    }

    // Update is called once per frame
    void Update()
    {
        _object.LookAt(_object.transform.position + main_camera.transform.rotation * Vector3.forward,
            main_camera.transform.rotation * Vector3.up);

    }
}

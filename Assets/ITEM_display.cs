using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ITEM_display : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera main_camera;
    public Transform _object;
    void Start()
    {
        main_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        _object.LookAt(_object.transform.position + main_camera.transform.rotation * Vector3.forward,
         main_camera.transform.rotation * Vector3.up);
    }
}

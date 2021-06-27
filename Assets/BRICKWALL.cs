using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BRICKWALL : MonoBehaviour
{
    // Start is called before the first frame update
    // this is for testing purpose nothing else.
    public float brick_health;
    public Slider brick_health_display;

    public Camera main_camera;
    public Transform _object;
    
   
    void Start()
    {
        brick_health_display = GameObject.FindWithTag("brickhealth").GetComponent<Slider>();
        main_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        brick_health_display.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        _object.LookAt(_object.transform.position + main_camera.transform.rotation * Vector3.forward,
           main_camera.transform.rotation * Vector3.up);
        if(brick_health_display.value <= 0f)
        {
          //  Destroy(GameObject.Find("brick").gameObject);
            DestroyImmediate(GameObject.Find("brick").gameObject);
        }
    }
}

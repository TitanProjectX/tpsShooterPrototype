using System.Collections;
using UnityEngine;

public class USER_playercontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Original_Y;
    public Transform Copy_Y;
    public Transform Sync_Locked_camera_position_01;
    public Transform Sync_Locked_camera_position_02;


    // Animating Directions
    [Header("DIRECTION_LISTS")]
    public Transform Client_West_North;
    public Transform Client_East_North;
    public Transform Client_West_South;
    public Transform Client_East_South;
    public Transform Client_North;
    public Transform Client_South;
    public Transform Client_West;
    public Transform Client_East;

    public Transform Client_front;

    public float Client_animation_turnspeed;
    public float Client_position_set;
    public bool lock_Client_animation;
    public bool look_front;

    public bool look_Client_West_North;
    public bool look_Client_East_North;
    public bool look_Client_West_South;
    public bool look_Client_East_South;
    public bool look_Client_North;
    public bool look_Client_South;
    public bool look_Client_West;
    public bool look_Client_East;

    public Transform Sync_avatar_postion01;
    public Transform Avatar;
    public Transform Avatar_obj;

    public bool Client_cam_allow_change_01;
    public bool Client_cam_allow_change_02;

    public Transform camera_obj;

    public Transform Client_obj;
    private Transform Client_playervision;
    public Rigidbody Client_rb;
    public USER_inputcontrol __user_inputcontrol;
    private USER_guninfo Client_guninfo;
    // values
    [Header("Values")]
    public float Client_movementspeed;
    private float Client_movementspeed_value;
    public float Client_jumpspeed;
    public float Client_jumplimits;
    // private float Client_gravity;
    public float ClientSystem_jumptimeline;
    public float ClientSystem_jumptime_addition;
    public bool ClientSystem_jump_boolean_01;
    public bool ClientSystem_jump_boolean_02;
    public bool ClientSystem_jump_control_01;
    public bool ClientSystem_jump_control_02;
    [Header("Defaults Settings")]
    public float Client_Acceleration_time;
    public float Client_Acceleration_addition;
    public bool Client_Acceleration_boolean_01;
    public bool Client_Acceleration_control_01;
    public bool Client_Crouch_boolean_01;
    public bool Client_Crouch_boolean_02;
    void Start()
    {
        Sync_Locked_camera_position_01 = GameObject.FindGameObjectWithTag("Sync_Camera").GetComponent<Transform>();
        Sync_Locked_camera_position_02 = GameObject.FindGameObjectWithTag("Sync_Camera_02").GetComponent<Transform>();
        camera_obj = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        Client_rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        Client_obj = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Client_playervision = GameObject.FindGameObjectWithTag("Client_playervision").GetComponent<Transform>();
        Client_guninfo = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_guninfo>();
    
        //Client_obj = GetComponent<Transform>();
        // creat something that checks out the source code for optimazation.
        //  Client_movementspeed = 0.0f;
        //  ClientSystem_jumptimeline = 0.0f;
        ClientSystem_jumptime_addition = 0.5f;
        ClientSystem_jump_control_02 = false;
        Client_Crouch_boolean_01 = false;
        Client_Acceleration_time = 2f;
        Client_Acceleration_addition = 3.8f;

        // disabling default animations for client animation
        // animations are unlocked for default.
        lock_Client_animation = true;
        look_Client_East = false;
        look_Client_East_North = false;
        look_Client_East_South = false;
        look_Client_North = false;
        look_Client_South = false;
        look_Client_West = false;
        look_Client_West_North = false;
        look_Client_West_South = false;
        look_front = false;

        ClientSystem_jump_control_01 = false;
        ClientSystem_jump_boolean_01 = true;
        Client_movementspeed_value = 2f;
        Client_movementspeed = Client_movementspeed_value;
        Client_jumpspeed = 250;
        Client_jumplimits = 0.15f;
       
        //   Client_gravity = 6;

        Client_Acceleration_control_01 = true;
        Client_cam_allow_change_01 = true;
        Client_cam_allow_change_02 = false;
    }

    // Update is called once per frame


    void Update()
    {
        Vector3 smooth_x = Vector3.MoveTowards(Avatar.transform.position, Sync_avatar_postion01.transform.position, Client_position_set);

        Avatar.transform.position = smooth_x;
       // Avatar.transform.position = new Vector3(Sync_avatar_postion01.transform.position.x,
       // Sync_avatar_postion01.transform.position.y,
       // Sync_avatar_postion01.transform.position.z
       // );



        Avatar.transform.rotation = Quaternion.Euler(Avatar.transform.rotation.x, Client_obj.transform.localEulerAngles.y, Avatar.transform.rotation.z);
        if(look_front == true)
        {
            // to make it smoothely
            Vector3 dir = Client_front.transform.position - Avatar_obj.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(Avatar_obj.transform.rotation, lookRotation, Time.deltaTime * Client_animation_turnspeed).eulerAngles;
            Avatar_obj.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
         //   Avatar_obj.LookAt(Client_front, Vector3.up);
        }
        if (lock_Client_animation == true)
        {

            if (look_Client_South == true)
            {
                Vector3 dir = Client_South.transform.position - Avatar_obj.transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(Avatar_obj.transform.rotation, lookRotation, Time.deltaTime * Client_animation_turnspeed).eulerAngles;
                Avatar_obj.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                //  Avatar_obj.LookAt(Client_South, Vector3.up);
            }
            if (look_Client_North == true)
            {
                Vector3 dir = Client_North.transform.position - Avatar_obj.transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(Avatar_obj.transform.rotation, lookRotation, Time.deltaTime * Client_animation_turnspeed).eulerAngles;
                Avatar_obj.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                //  Avatar_obj.LookAt(Client_North, Vector3.up);
            }
            if (look_Client_West == true)
            {
                Vector3 dir = Client_West.transform.position - Avatar_obj.transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(Avatar_obj.transform.rotation, lookRotation, Time.deltaTime * Client_animation_turnspeed).eulerAngles;
                Avatar_obj.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                //   Avatar_obj.LookAt(Client_West, Vector3.up);
            }
            if (look_Client_East == true)
            {
                Vector3 dir = Client_East.transform.position - Avatar_obj.transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(Avatar_obj.transform.rotation, lookRotation, Time.deltaTime * Client_animation_turnspeed).eulerAngles;
                Avatar_obj.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                //  Avatar_obj.LookAt(Client_East, Vector3.up);
            }
            if (look_Client_East_North == true)
            {
                Vector3 dir = Client_East_North.transform.position - Avatar_obj.transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(Avatar_obj.transform.rotation, lookRotation, Time.deltaTime * Client_animation_turnspeed).eulerAngles;
                Avatar_obj.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                //  Avatar_obj.LookAt(Client_East_North, Vector3.up);
            }
            if (look_Client_West_North == true)
            {
                Vector3 dir = Client_West_North.transform.position - Avatar_obj.transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(Avatar_obj.transform.rotation, lookRotation, Time.deltaTime * Client_animation_turnspeed).eulerAngles;
                Avatar_obj.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                //  Avatar_obj.LookAt(Client_West_North, Vector3.up);
            }
            if (look_Client_East_South == true)
            {
                Vector3 dir = Client_East_South.transform.position - Avatar_obj.transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(Avatar_obj.transform.rotation, lookRotation, Time.deltaTime * Client_animation_turnspeed).eulerAngles;
                Avatar_obj.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                //  Avatar_obj.LookAt(Client_East_South, Vector3.up);
            }
            if (look_Client_West_South == true)
            {
                Vector3 dir = Client_West_South.transform.position - Avatar_obj.transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(Avatar_obj.transform.rotation, lookRotation, Time.deltaTime * Client_animation_turnspeed).eulerAngles;
                Avatar_obj.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
                //  Avatar_obj.LookAt(Client_West_South, Vector3.up);
            }
        }
        if (Client_cam_allow_change_01 == true)
        {

            camera_obj.transform.position = new Vector3(Sync_Locked_camera_position_01.transform.position.x,
                Sync_Locked_camera_position_01.transform.position.y,
                Sync_Locked_camera_position_01.transform.position.z);
            //Debug.Log(transform.position.x);
            //  Locked_camera_obj.transform.position = Locked_camera_position;

           // Locked_camera_obj.transform.position.y = Locked_camera_position.y;
            //  Locked_camera_obj.transform.position = new Vector3(Locked_camera_obj.transform.position.x 
            //      ,Locked_camera_obj.transform.position.y 
            //      ,Locked_camera_obj.transform.position.z) ;
        }
        if(Client_cam_allow_change_02 == true)
        {
            camera_obj.transform.position = new Vector3(Sync_Locked_camera_position_02.transform.position.x,
               Sync_Locked_camera_position_02.transform.position.y,
               Sync_Locked_camera_position_02.transform.position.z);
        }
       // Debug.Log(Original_Y.rotation.eulerAngles.y);
      //  Debug.Log(Original_Y.rotation.y);
        //Copy_Y.transform.rotation = Quaternion.Euler(Copy_Y.transform.rotation.x, Original_Y.rotation.eulerAngles.y, Copy_Y.rotation.z);
        if (Client_Crouch_boolean_01 == true)
        {
            Client_movementspeed = 1f;
            // Client_movementspeed_value = 0f;
        }

        // WASD defaults 1f is 0.5f
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //Client_playervision.transform.position += new UnityEngine.Vector3(0f, -0.5f, 0f);
            //__user_inputcontrol.Client_primary_normalsight = true;
            //__user_inputcontrol.Client_priamry_runsight = false;
            StartCoroutine(Client_crouchup_wait_time(0.02f, 0.1f));
                StopCoroutine(Client_crouchdown_wait_time(0.02f, 0.1f));
                Client_Crouch_boolean_01 = true;
                __user_inputcontrol._Client_recoilup_count = Client_guninfo.Client_changed_recoilup_count;
                __user_inputcontrol.Client_recoil_downcount = Client_guninfo.Client_changed_recoil_downcount;
            
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            //__user_inputcontrol.Client_primary_normalsight = false;
            //__user_inputcontrol.Client_priamry_runsight = true;
            //Client_playervision.transform.position += new UnityEngine.Vector3(0f, 0.5f, 0f);
            StartCoroutine(Client_crouchdown_wait_time(0.02f, 0.1f));
                StopCoroutine(Client_crouchup_wait_time(0.02f, 0.1f));
                //  Client_playervision.transform.position = new UnityEngine.Vector3(Client_playervision.transform.position.x, 0f, Client_playervision.transform.position.z);
                Client_Crouch_boolean_01 = false;
                __user_inputcontrol._Client_recoilup_count = Client_guninfo.Client_normal_changed_recoilup_count;
                __user_inputcontrol.Client_recoil_downcount = Client_guninfo.Client_normal_changed_recoil_downcount;
            
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //__user_inputcontrol.Client_primary_normalsight = true;
            //__user_inputcontrol.Client_priamry_runsight = false;
            __user_inputcontrol._Client_recoilup_count = Client_guninfo.Client_changed_recoilup_count;
            __user_inputcontrol.Client_recoil_downcount = Client_guninfo.Client_changed_recoil_downcount;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //__user_inputcontrol.Client_primary_normalsight = false;
            //__user_inputcontrol.Client_priamry_runsight = true;
            __user_inputcontrol._Client_recoilup_count = Client_guninfo.Client_normal_changed_recoilup_count;
            __user_inputcontrol.Client_recoil_downcount = Client_guninfo.Client_normal_changed_recoil_downcount;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.LeftControl))
        {
            Client_playervision.transform.position += new UnityEngine.Vector3(0f, -0.5f, 0f);
            Client_Crouch_boolean_01 = true;
            __user_inputcontrol._Client_recoilup_count = Client_guninfo.Client_changed_recoilup_count;
            __user_inputcontrol.Client_recoil_downcount = Client_guninfo.Client_changed_recoil_downcount;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && Input.GetKeyUp(KeyCode.LeftControl))
        {
            Client_playervision.transform.position += new UnityEngine.Vector3(0f, 0.5f, 0f);
            Client_Crouch_boolean_01 = false;
            __user_inputcontrol._Client_recoilup_count = Client_guninfo.Client_normal_changed_recoilup_count;
            __user_inputcontrol.Client_recoil_downcount = Client_guninfo.Client_normal_changed_recoil_downcount;
        }
        // input W cases
        if (Input.GetKey(KeyCode.W))
        {
            look_Client_North = true;


            __user_inputcontrol.Client_primary_normalsight = false;
            __user_inputcontrol.Client_priamry_runsight = true;
            Client_Acceleration_boolean_01 = true;
            Client_obj.transform.position += transform.forward * Client_movementspeed * Time.deltaTime;
            Debug.Log("Client_Object: forward");
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            look_Client_West_North = true;

            Client_Acceleration_boolean_01 = true;
            Client_obj.transform.position += transform.forward * Client_movementspeed  * Time.deltaTime;
            Client_obj.transform.position += transform.right * -1  * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            look_Client_East_North = true;

            Client_Acceleration_boolean_01 = true;
            Client_obj.transform.position += transform.forward * Client_movementspeed * Time.deltaTime;
            Client_obj.transform.position += transform.right  * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.W) || (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.A)) || (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.D)))
        {
            look_Client_North = false;
            look_Client_West_North = false;
            look_Client_East_North = false;


            __user_inputcontrol.Client_primary_normalsight = true;
            __user_inputcontrol.Client_priamry_runsight = false;
            Client_Acceleration_control_01 = true;
            Client_Acceleration_boolean_01 = false;
            Client_movementspeed = Client_movementspeed_value;
        }


        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            look_Client_North = true;

            __user_inputcontrol.Client_primary_normalsight = false;
            __user_inputcontrol.Client_priamry_runsight = true;
            Client_Acceleration_boolean_01 = false;
            Client_obj.transform.position += transform.forward * Client_movementspeed * Time.deltaTime;
            Client_movementspeed = 1f;
            Debug.Log("Client_Object: forward");
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            look_Client_West_North = true;

            Client_Acceleration_boolean_01 = false;
            Client_obj.transform.position += transform.forward * Client_movementspeed * Time.deltaTime;
            Client_obj.transform.position += transform.right * -1  * Time.deltaTime;
            Client_movementspeed = 1f;

        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            look_Client_East_North = true;

            __user_inputcontrol.Client_primary_normalsight = true;
            __user_inputcontrol.Client_priamry_runsight = false;
            Client_Acceleration_boolean_01 = false;
            Client_obj.transform.position += transform.forward * Client_movementspeed * Time.deltaTime;
            Client_obj.transform.position += transform.right  * Time.deltaTime;
            Client_movementspeed = Client_movementspeed_value;
        }
        // WASD 2
        if (Input.GetKey(KeyCode.S))
        {
            look_Client_South = true;
            // move down
            __user_inputcontrol.Client_primary_normalsight = false;
            __user_inputcontrol.Client_priamry_runsight = true;
            Client_Acceleration_boolean_01 = true;
            Client_obj.transform.position += transform.forward * -1 * Client_movementspeed * Time.deltaTime;
            Debug.Log("Client_Object: down");
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            look_Client_West_South = true;

            Client_Acceleration_boolean_01 = true;
            Client_obj.transform.position += transform.forward * -1 * Client_movementspeed * Time.deltaTime;
            Client_obj.transform.position += transform.right * -1   * Time.deltaTime;
        }
       else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            look_Client_East_South = true;

            Client_Acceleration_boolean_01 = true;
            Client_obj.transform.position += transform.forward * -1 * Client_movementspeed * Time.deltaTime;
            Client_obj.transform.position += transform.right * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.S) || (Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.A)) || (Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.D)))
        {
            look_Client_South = false;
            look_Client_East_South = false;
            look_Client_West_South = false;

            __user_inputcontrol.Client_primary_normalsight = true;
            __user_inputcontrol.Client_priamry_runsight = false;
            Client_Acceleration_control_01 = true;
            Client_Acceleration_boolean_01 = false;
            Client_movementspeed = Client_movementspeed_value;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            // move down
            look_Client_South = true;

            __user_inputcontrol.Client_primary_normalsight = false;
            __user_inputcontrol.Client_priamry_runsight = true;
            Client_Acceleration_boolean_01 = false;
            Client_obj.transform.position += transform.forward * -1 * Client_movementspeed * Time.deltaTime;
            Client_movementspeed = 1f;
            Debug.Log("Client_Object: down");
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            look_Client_West_South = true;

            Client_Acceleration_boolean_01 = false;
            Client_obj.transform.position += transform.forward * -1 * Client_movementspeed * Time.deltaTime;
            Client_obj.transform.position += transform.right * -1 * Time.deltaTime;
            Client_movementspeed = 1f;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            look_Client_East_South = true;

            __user_inputcontrol.Client_primary_normalsight = true;
            __user_inputcontrol.Client_priamry_runsight = false;
            Client_Acceleration_boolean_01 = false;
            Client_obj.transform.position += transform.forward * -1 * Client_movementspeed * Time.deltaTime;
            Client_obj.transform.position += transform.right  * Time.deltaTime;
            Client_movementspeed = 1f;
        }
        // WASD 3
        if (Input.GetKey(KeyCode.A))
        {
            look_Client_West = true;

            // move left
            __user_inputcontrol.Client_primary_normalsight = false;
            __user_inputcontrol.Client_priamry_runsight = true;
            Client_Acceleration_boolean_01 = true;
            Client_obj.transform.position += transform.right * -1 * Client_movementspeed * Time.deltaTime;
            Debug.Log("Client_Object: left");
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            look_Client_West_North = true;

            Client_Acceleration_boolean_01 = true;
            Client_obj.transform.position += transform.forward * Client_movementspeed * Time.deltaTime;
            Client_obj.transform.position += transform.right * -1 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            look_Client_West_North = true;

            Client_Acceleration_boolean_01 = true;
            Client_obj.transform.position += transform.right * -1 * Client_movementspeed * Time.deltaTime;
            Client_obj.transform.position += transform.forward * -1 * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.S)))
        {
            look_Client_West = false;
            look_Client_West_North = false;
            look_Client_West_South = false;

            __user_inputcontrol.Client_primary_normalsight = true;
            __user_inputcontrol.Client_priamry_runsight = false;
            Client_Acceleration_control_01 = true;
            Client_Acceleration_boolean_01 = false;
            Client_movementspeed = Client_movementspeed_value;
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            look_Client_West = true;
            // move left
            __user_inputcontrol.Client_primary_normalsight = false;
            __user_inputcontrol.Client_priamry_runsight = true;
            Client_Acceleration_boolean_01 = false;
            Client_obj.transform.position += transform.right * -1 * Client_movementspeed * Time.deltaTime;
            Debug.Log("Client_Object: left");
            Client_movementspeed = 1f;
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            look_Client_West_North = true;

            Client_Acceleration_boolean_01 = false;
            Client_obj.transform.position += transform.forward * Client_movementspeed * Time.deltaTime;
            Client_obj.transform.position += transform.right * -1  * Time.deltaTime;
            Client_movementspeed = 1f;
        }
       else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            look_Client_West_North = true;

            __user_inputcontrol.Client_primary_normalsight = true;
            __user_inputcontrol.Client_priamry_runsight = false;
            Client_Acceleration_boolean_01 = false;
            Client_obj.transform.position += transform.right * -1 * Client_movementspeed * Time.deltaTime;
            Client_obj.transform.position += transform.forward * -1  * Time.deltaTime;
            Client_movementspeed = 1f;
        }
        // WASD 4
        if (Input.GetKey(KeyCode.D))
        {
            look_Client_East = true;
            //move right
            __user_inputcontrol.Client_primary_normalsight = false;
            __user_inputcontrol.Client_priamry_runsight = true;
            Client_Acceleration_boolean_01 = true;
            Client_obj.transform.position += transform.right * Client_movementspeed * Time.deltaTime;
            Debug.Log("Client_Object: right");
        }
       else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            look_Client_East_North = true;

            Client_Acceleration_boolean_01 = true;
            Client_obj.transform.position += transform.right * Client_movementspeed  * Time.deltaTime;
            Client_obj.transform.position += transform.forward * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            look_Client_East_South = true;

            Client_Acceleration_boolean_01 = true;
            Client_obj.transform.position += transform.right * Client_movementspeed  * Time.deltaTime;
            Client_obj.transform.position += transform.forward * -1   * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.D) && Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.D) && Input.GetKeyUp(KeyCode.S)))
        {
            look_Client_East = false;
            look_Client_East_South = false;
            look_Client_East_North = false;

            __user_inputcontrol.Client_primary_normalsight = true;
            __user_inputcontrol.Client_priamry_runsight = false;
            Client_Acceleration_control_01 = true;
            Client_Acceleration_boolean_01 = false;
            Client_movementspeed = Client_movementspeed_value;
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            look_Client_East = true;
            //move right
            __user_inputcontrol.Client_primary_normalsight = false;
            __user_inputcontrol.Client_priamry_runsight = true;
            Client_Acceleration_boolean_01 = false;
            Client_obj.transform.position += transform.right * Client_movementspeed * Time.deltaTime;
            Debug.Log("Client_Object: right");
            Client_movementspeed = 1f;
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            look_Client_East_North = true;

            Client_Acceleration_boolean_01 = false;
            Client_obj.transform.position += transform.right * Client_movementspeed * Time.deltaTime;
            Client_obj.transform.position += transform.forward  * Time.deltaTime;
            Client_movementspeed = 1f;
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            look_Client_East_South = true;

            __user_inputcontrol.Client_primary_normalsight = true;
            __user_inputcontrol.Client_priamry_runsight = false;
            Client_Acceleration_boolean_01 = false;
            Client_obj.transform.position += transform.right * Client_movementspeed * Time.deltaTime;
            Client_obj.transform.position += transform.forward * -1  * Time.deltaTime;
            Client_movementspeed = 1f;
        }
        // this input goes down instantly.
        if (Input.GetKeyDown(KeyCode.Space) && ClientSystem_jump_boolean_01 == true)
        {
            ClientSystem_jump_control_01 = true;
            //ClientSystem_jump_boolean_01 = false;
        }

       // if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) { Debug.Log("UP, LEFT"); }
       // if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) { Debug.Log("UP, RIGHT"); }
       //if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) { Debug.Log("DOWN, LEFT"); }
       //if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) { Debug.Log("DOWN, RIGHT"); }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
        {
            Debug.Log("WASD Sametime not allowed");
            Client_movementspeed = 0f;
        }
        else if (Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("WASD Movement Speed Restored.");
            Client_movementspeed = Client_movementspeed_value;
        }
        if (Client_Acceleration_boolean_01 == true)
        {
            //Client_Acceleration_control_01 = true;
            if (Client_Acceleration_control_01 == true)
            {

                Client_movementspeed += Client_Acceleration_addition * Time.deltaTime;
                if (Client_movementspeed > 6f)
                {
                    Debug.Log("PointAccessed");

                    Client_Acceleration_control_01 = false;
                    Client_Acceleration_boolean_01 = false;
                }
            }
            // do i actually need this 
        }


        // make timer system.
        // this method has lots of problems it doesnt feel right .
        // crouch needs timer system.
        if (ClientSystem_jump_control_01 == true)
        {
            ClientSystem_jumptimeline += ClientSystem_jumptime_addition * Time.deltaTime;
            ClientSystem_jump_control_02 = true;
        //    Client_Crouch_boolean_02 = fals;
            if (ClientSystem_jump_control_02 == true)
            {
                // replace this ? may be using what methods we used to ?
                //Client_rb.useGravity = false;
                Client_rb.mass = 50;
               Client_rb.AddForce(transform.up * Client_jumpspeed);
               
                // Client_obj.transform.position += UnityEngine.Vector3.up * Client_jumpspeed * Time.deltaTime;
            }
            if (ClientSystem_jumptimeline > Client_jumplimits)
            {
                //Client_rb.useGravity = true;
              //  Client_Crouch_boolean_02 = true;
               // Client_rb.mass = 50;
                ClientSystem_jump_control_02 = false;
                ClientSystem_jump_control_01 = false;
                ClientSystem_jumptimeline = 0f;

            }
        }
    }
   
    private void OnTriggerEnter(Collider Client_col01)
    {
        if (Client_col01.gameObject.tag == "Ground")
        {
            ClientSystem_jump_boolean_01 = true;
        }
    }

    private void OnTriggerExit(Collider Client_col02)
    {
        ClientSystem_jump_boolean_01 = false;
    }

    public IEnumerator Client_crouchup_wait_time(float crouch_wait, float decrement)
    {
     
        for (int i = 0; i < 5; i++)
        {
            Client_playervision.transform.position += new UnityEngine.Vector3(0f, -decrement, 0f);
            yield return new WaitForSeconds(crouch_wait);
        }
       
    }
    public IEnumerator Client_crouchdown_wait_time(float crouch_wait, float incerement)
    {
        for(int i = 0; i < 5; i ++)
        {
            Client_playervision.transform.position += new UnityEngine.Vector3(0f, incerement, 0f);
            yield return new WaitForSeconds(crouch_wait);
        }
    }
}

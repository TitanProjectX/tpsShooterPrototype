using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
//[Header("Clinet_type")]
//public enum Client_shootingtypes{_semi, _auto, _burst };

public class USER_inputcontrol : MonoBehaviour
{
    public Transform Client_obj;
    public Slider GUI_USER_display;
    public Slider GUI_USER_display02;
    public float Client_health;

    public Text GUI_USER_text_display;
    public Text GUI_USER_text_display02;
    
   // public Transform Sync_Camera;
    // public Transform Client_view; Client_effect 
    private Transform ray_view;
    private Transform ray_view_y;
    private Transform ray_view_yn;
    private Transform ray_view_x;
    private Transform ray_view_xn;
    [Header("USER Effect prefab settings")]
    public GameObject Client_effect01;
    public GameObject Client_effect02;
    public LineRenderer Client_RenderEffect01;
    public Transform Client_RenderTransform01;
    public bool Client_RenderAlpha_boolean01;
    public float Client_RenderAlpha;
    public float Client_RenderAlphaSpeed;


    [Header("USER Client recoil system settings")]
    public GameObject Client_recoil_system_cam;
    private bool Client_recoil_boolean01;
    public float Client_recoil_limits;
    public float Client_recoil_speed;
    public float Client_recoil_realnumber;
    public float Client_recoildown_number;
    public int Client_bullet_count;
    public float Client_recoildown_number02;
    public int ClientSystem_CloneCount;
    public bool Client_mouseclick_active;
    public float Client_mouseclickcount;
    private float Client_recoil_testnum01;
    private float Client_recoil_testnum02;
    public float _Client_recoilup_count;
    public float Client_recoil_downcount;
    [Header("USER Client recoil adavanced X AND Y settings")]
    public int _Client_default_recoilX_1 = 0;
    public int _Client_default_recoilX_2 = 0;

    public int _Client_default_recoilY_1 = 0;
    public int _Client_default_recoilY_2 = 0;

    public bool _Client_randomshootreset_1;
    public bool _Client_randomshootreset_2;
    public bool _Client_randomshootreset_3;
    public bool _Client_randomshootreset_4;
    // first version recoil system
    // this position only takes cares positive float x positive;
    public float[] Client_default_recoilSetsX_1 = {
           0f, 0f, 0f, 0f, 0f, 1f, 0f, 1f, 0f, 1f,
        2f, 0f, 2f, 0f, 2f, 0f, 2f, 0f, 2f ,0f,
        1f, 0f, 1f, 0f, 1f, 0f, 1f, 0f, 1f, 0f, 1f
    };
    // this position only takes cares negative float numbers;
    public float[] Client_default_recoilSetsX_2 = {
        0f, 0f, 0f, 0f, 0f, 0f, 1f, 0f, 1f, 0f,
        0f, 2f, 0f, 2f, 0f, 2f, 0f, 2f, 0f ,2f,
        0f, 1f, 0f, 1f, 0f, 1f, 0f, 1f, 0f, 1f, 0f
    };
    // this position only takes cares positive float numbers;
    public float[] Client_default_recoilSetsY_1 = {
         0f, 0f, 0f, 0f, 0f, 1f, 0f, 1f, 0f, 1f,
        2f, 0f, 2f, 0f, 2f, 0f, 2f, 0f, 2f ,0f,
        1f, 0f, 1f, 0f, 1f, 0f, 1f, 0f, 1f, 0f, 1f
    };
    // this position only takes cares negative float numbers;
    public float[] Client_default_recoilSetsY_2 = {
         0f, 0f, 0f, 0f, 0f, 0f, 1f, 0f, 1f, 0f,
        0f, 2f, 0f, 2f, 0f, 2f, 0f, 2f, 0f ,2f,
        0f, 1f, 0f, 1f, 0f, 1f, 0f, 1f, 0f, 1f, 0f
    };
    // new client_primary systems
    private float[] Client_primary_recoilSetsX =
    {
        0f,0f,0f,0f,1f,0f,1f,0f,0f,2f,0f,1f,0f,0f,0f,1f,2f,1f,0f,0f,0f,0f,0f,1f,2f,1f,0f,0f,0f,0f,0f
    };

    private float[] Client_primary_recoilSetsXN =
    {
        0f,0f,0f,1f,0f,0f,0f,1f,0f,0f,2f,0f,3f,1f,0f,0f,0f,0f,0f,2f,3f,2f,0f,0f,0f,0f,0f,1f,3f,2f,0f
    };

    private float[] Client_primary_recoilSetsY =
    {
        0f,0f,0f,1f,1f,2f,2f,2f,3f,2f,4f,4f,3f,4f,5f,6f,7f,8f,9f,8f,9f,10f,11f,12f,13f,13f,12f,12f,13f,13f,14f
    };
    private float[] Client_primary_recoilSetsYN =
    {
        0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f
    };

    private float[] Client_sight_reocoil_Sets =
    {
        1f,3f,1f,3f,1f,3f,2f,6f,2f,6f,2f,6f,2f,6f,5f,9f,5f,9f,5f,9f,5f,15f,18f,15f,18f,15f,18f,15f,18f,15f,18f
    };

    // running systems
    private float[] Client_sight_run_recoil_Sets =
    {
        2f,6f,2f,6f,2f,6f,2f,6f,5f,9f,5f,9f,5f,9f,5f,15f,18f,15f,18f,15f,18f,15f,18f,15f,18f,15f,18f,15f,18f,0f
    };
    private float[] Client_primary_run_recoilSetsX =
    {
        1f,0f,1f,0f,0f,2f,0f,1f,0f,0f,0f,1f,2f,1f,0f,0f,0f,0f,0f,1f,2f,1f,0f,0f,0f,0f,0f,0f,0f,0f,0f
    };
    private float[] Client_primary_run_recoilSetsXN =
    {
        0f,0f,0f,1f,0f,0f,2f,0f,3f,1f,0f,0f,0f,0f,0f,2f,3f,2f,0f,0f,0f,0f,0f,1f,3f,2f,0f,1f,3f,2f,0f
    };
    private float[] Client_primary_run_recoilSetsY =
    {
        1f,2f,2f,2f,3f,2f,4f,4f,3f,4f,5f,6f,7f,8f,9f,8f,9f,10f,11f,12f,13f,13f,12f,12f,13f,13f,14f,12f,13f,13f
    };
    private float[] Client_primary_run_recoilSetsYN =
    {
        0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f
    };

    public bool Client_primary_normalsight = false;
    public bool Client_priamry_runsight = false;

    
    public float client_uprecoil;
    public float client_siderecoil;
    [Header("USER sound settings")]
    public AudioSource Client_Pistol;
    public AudioSource Client_Punch;
    public AudioSource[] sound_manager;

    [Header("Advanced Customized settings")]
    public float Client_GunRange;
    public int ClientSystem_QuadCount;
    public int Client_Sight_division;
    public int Client_Sight_view_difference;
    public int Client_zoomin_max;
    public int Client_zoomout_min;
    public float Client_zoomin_max_increment;
    public float Client_zoomout_min_decrement;
    //experimental
    public USER_mousecontrol user_mousecontrol;
    public TEST_model test;
    public AI_modelzom AI_UNIT;
    public AI_modelelite AI_UNITELITE;
    public AI_modelway AI_UNITWAY;
    private float[] array;
    [SerializeField]
    public float client_timer, client_totaltimer, client_timerlimits, client_timerspeed;
    public bool client_timerboolean01;

    //Job 1: Client_reocoil_system.

    // private bool Client_recoil_boolean02;
    // private float Client_recoil_timer;

    // Start is called before the first frame update

    //Jon 0: recoil random shots x and y must be recorded during the shotting process. 30 rounds
   
    // public float[] Client_recoilSetsX_1_reset = {
    //    0f, 0f, 0f, 0f, 0f, -1f, 0f, -1f, 0f, -1f,
    //     -2f, 0f, -2f, 0f, -3f, 0f, -3f, 0f, -3f ,0f,
    //     -4f, 0f, -4f, 0f, -4f, 0f, -5f, 0f, 0f, 0f, 0f
    // };
    // public float[] Client_recoilSetsX_2_reset = {
    //     0f, 0f, 0f, 0f, 0f, 0f, -1f, 0f, -1f, 0f,
    //     0f, -2f, 0f, -2f, 0f, -3f, 0f, -3f, 0f ,-3f,
    //     0f, -4f, 0f, -4f, 0f, -5f, 0f, 0f, 0f, 0f, 0f
    // };
    // public float[] Client_recoilnegativeSetsX =
    //  {
    //      0f, 0f, 0f, 0f ,0f, 0f, 1f, 0f ,1f ,0f ,
    //     1f, 0f, 2f, 0f ,2f, 0f, 2f, 0f ,3f ,0f ,
    //      3f, 0f, 4f, 0f, 4f, 0f, 4f, 5f ,0f, 5f, 0f, 0f
    // };
    // public float[] Client_recoilnegativeSetsY =
    //  {
    //      0f, 0f, 0f, 0f ,0f, 0f, 1f, 0f ,1f ,0f ,
    //      1f, 0f, 2f, 0f ,2f, 0f, 2f, 0f ,3f ,0f ,
    //      3f, 0f, 4f, 0f, 4f, 0f, 4f, 5f ,0f, 5f, 0f, 0f
    //  };


    // Job 2: semi auto burst
    public int burst_count;
    public int Client_gunmodeswitch = 0;
    public Text Client_gunstatus;
    public Text Client_gunammo;
    public int Client_gunammoamount;
    public bool Client_gun_semi;
    public bool Client_gun_auto;
    public bool Client_gun_burst;
    public bool Client_gunauto_toggle;
    public bool Client_gunburst_toggle;
    public int Client_gunburst_togglecount;
    public int Client_gunauto_togglecount;
    public bool Client_gunburst_toggle_0;
    public float Client_gunburst_cooltime;

    // Job 3: reloading system;
    public int Client_gunreloadswitch = 0;
    public Text Client_gunreload;
    public int Client_reloadcounts;
    //Job 4: shoot disappear
    public bool Client_gunshooteffect;
    public float Client_gunshootdisappear_rate;
    public float Client_quadcountdisappear_rate;
    public int Client_gunshootcounts;
    //Job 8: zoom in
    // public float Client_fieldofview;
    //Job 7: melee attack
    public int Client_meleecounts;
    public float Client_meleerange;

    //Job 11: Enemy health test
    public TextMesh Client_enemy;
    public int Enemy_health;
    public TextMesh Target;
    public int Target_Score;
    //Job 10: Combine gun system. you need to control firerate and 
    // public int Client_gundamage;
    public GameObject[] Gun_list;
    public GameObject[] Gun_rigid_list;

    // bring the gunstatus info
    private USER_guninfo Client_guninfo;
    public int Client_dropdowncounts;

    //Job 12: Switching guns
    public int[] savedclips;
    public int[] savedammo;
    public bool gundata_allow_01;
    public bool gundata_allow_02;
    public bool gundata_allow_03;
    
    //FPS 9: develop scroll weapon selections
    public int const_gunswitch = 3;
    //Put gameobjects before you put it on the coding.
    public GameObject[] const_gunswitch_pos;
    //Gun selection display
   //public Image gun_display01;
   //public Image gun_display02;
   //public Image gun_display03;
   //public Image gun_display04;

    private Image Sight_x;
    private Image Sight_xn;
    private Image Sight_y;
    private Image Sight_yn;

    // job unlimited transform bullet. this is for bullet effect collision.
    public Client_bulleteffect bullet_effect;
    private Transform Client_bulleteffect_position;
    public int Client_bulleteffect_force;

    // Job Sight Fire effect 
    public GameObject[] Effect_gameObject;
    public Transform Effect_transform_position;
    public int random_effect_selection_limits;
    // workflow

    // job sight Fire collision effect
    public GameObject[] Effect_collision_gameobject;
    public int random_effect_collision_limits;
    public float Effect_collision_disaapear_rate;
    // 1/23/2021
    public Transform Player_damage_display_pos;
    public Transform Player_damage_display_prefab;
    public Image gun_display;
    public Text gun_display_text;

    public Transform Client_shoot_pos;
    public ParticleSystem Client_shoot;
    public bool mouse_lock_boolean;
    // transform look position for locations;
    public USER_playercontrol USER_CONTROL;
 

    void Start()
    {
        GUI_USER_display02.maxValue = Client_health;  
        mouse_lock_boolean = true;
        Client_shoot.Stop();
        USER_CONTROL = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_playercontrol>();
      //  Sync_Camera = GameObject.FindGameObjectWithTag("Sync_Camera").GetComponent<Transform>();
        gun_display = GameObject.FindGameObjectWithTag("Gun_display01").GetComponent<Image>();
        gun_display_text = GameObject.FindGameObjectWithTag("Gun_display01_text").GetComponent<Text>();
        Player_damage_display_pos = GameObject.FindGameObjectWithTag("Client_damage_display").GetComponent<Transform>();
        Player_damage_display_prefab = GameObject.FindGameObjectWithTag("Client_damage_display_prefab").GetComponent<Transform>();
        gun_display.enabled = false;
        gun_display_text.enabled = false;
       Client_zoomin_max = 20;
        Client_zoomout_min = 20;
        // default systems for gun_display scale
        InvokeRepeating("Client_upgradegun", 0f, 0.01f);
        InvokeRepeating("Clinet_show_item_display", 0f, 0.01f);

       //gun_display01.rectTransform.localScale = new Vector3(1f, 1f, 0f);
       //gun_display02.rectTransform.localScale = new Vector3(1f, 1f, 0f);
       //gun_display03.rectTransform.localScale = new Vector3(1f, 1f, 0f);
       //gun_display04.rectTransform.localScale = new Vector3(1f, 1f, 0f);
        gundata_allow_01 = true;
        gundata_allow_02 = true;
        gundata_allow_03 = true;
 
        Target_Score = 0;
        Target.text = "Target Score: " + Target_Score;
        Enemy_health = 100;
        Client_enemy.text = "Testing NOW";
        Client_recoil_system_cam.transform.position += new UnityEngine.Vector3(0f, 0.09125f, 0f);
       // Client_meleerange = 3f;
        Client_guninfo = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_guninfo>();
     
        Client_meleecounts = 0;
        Client_gunshootcounts = 0;
     
        Client_gunshootdisappear_rate = 0.01f;
        Client_gunburst_cooltime = 0.6f;
        Client_gunshooteffect = false;
        Client_gunburst_togglecount = 0;
        Client_gunauto_togglecount = 0;

        Client_gunburst_toggle_0 = true;
        Client_gunammoamount = 0;
        Client_reloadcounts = 0;
        Client_recoildown_number02 = 0.1f;
        Client_GunRange = 100f;
        Client_RenderAlpha = 1f;

        // Client_effect lists
        Client_effect01 = GameObject.FindGameObjectWithTag("Effect");
        Client_effect02 = GameObject.FindGameObjectWithTag("Client_effect01");
        // Gunstatus infomation


        AI_UNIT = GameObject.FindGameObjectWithTag("AI_unitone").GetComponent<AI_modelzom>();
        AI_UNITELITE = GameObject.FindGameObjectWithTag("AI_unittwo").GetComponent<AI_modelelite>();
        AI_UNITWAY = GameObject.FindGameObjectWithTag("AI_unitthree").GetComponent<AI_modelway>();
        Client_RenderTransform01 = GameObject.FindGameObjectWithTag("RenderEffect01").GetComponent<Transform>();
        Client_obj = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // shooting layouts
        ray_view = GameObject.FindGameObjectWithTag("ray_view").GetComponent<Transform>();

        ray_view_y = GameObject.FindGameObjectWithTag("ray_view_y").GetComponent<Transform>();
        ray_view_yn = GameObject.FindGameObjectWithTag("ray_view_yn").GetComponent<Transform>();
        ray_view_x = GameObject.FindGameObjectWithTag("ray_view_x").GetComponent<Transform>();
        ray_view_xn = GameObject.FindGameObjectWithTag("ray_view_xn").GetComponent<Transform>();

        Sight_x = GameObject.FindGameObjectWithTag("sight_view_x").GetComponent<Image>();
        Sight_xn = GameObject.FindGameObjectWithTag("sight_view_xn").GetComponent<Image>();
        Sight_y = GameObject.FindGameObjectWithTag("sight_view_y").GetComponent<Image>();
        Sight_yn = GameObject.FindGameObjectWithTag("sight_view_yn").GetComponent<Image>();

        Client_RenderEffect01 = GameObject.FindGameObjectWithTag("RenderEffect01").GetComponent<LineRenderer>();
        Client_RenderEffect01.material = new Material(Shader.Find("Mobile/Particle/Additive"));
        test = GameObject.FindGameObjectWithTag("Test").GetComponent<TEST_model>();
     
        ClientSystem_CloneCount = -1;
        Client_RenderEffect01.enabled = false;
        Client_RenderAlpha_boolean01 = false;

        Client_gunstatus = GameObject.FindGameObjectWithTag("Client_gunstatus").GetComponent<UnityEngine.UI.Text>();
        Client_gunammo = GameObject.FindGameObjectWithTag("Client_gunammo").GetComponent<UnityEngine.UI.Text>();
        Client_gunreload = GameObject.FindGameObjectWithTag("Client_gunreload").GetComponent<UnityEngine.UI.Text>();
        //Job1 Client_reocoil_system testing out.
     
   
    }
 
    //Updating unity system
    void Update()
    {
        GUI_USER_display02.value = Client_health;
        GUI_USER_text_display.text = Client_gunammoamount.ToString();
        GUI_USER_display.value = Client_gunammoamount;
        GUI_USER_text_display02.text = Client_reloadcounts.ToString();
        //testing results.
        //Sight_x.transform.position += new UnityEngine.Vector3(0.1f, 0f, 0f);
        // Client_upgradegun();

        //Client_gunammo.text = "GUNAK _ammo: " + Client_gunammoamount + "\n";
        //Client_gunreload.text = "GUNAK_reloadcounts: " + Client_reloadcounts + "\n";
        //Target.text = "Target_Health: " + Target_Score;
        //Client_enemy.text = "Health: " + Enemy_health;

        Debug.Log("Client_1: " + _Client_default_recoilX_1);
        Debug.Log("Client_2: " + _Client_default_recoilX_2);
        Debug.Log("Client_y_1 " + _Client_default_recoilY_1);
        Debug.Log("Client_y_2 " + _Client_default_recoilY_2);
        // make it forcefully zero. i will find the solutions later.
        //testing input keys, you have to redevelop this core system
        //if (Input.GetKeyDown(KeyCode.Keypad1)) // these are just dummies
        //{
        //    Client_guninfo.Client_guninfotrasnfer("Client_gunM16");
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad2))
        //{
        //    Client_guninfo.Client_guninfotrasnfer("Client_gunUSP");
        //}
        // mouse wheel related numeracal keycode.

        

        if (Client_gunammoamount == 0)
        {
            Client_shoot.Stop();
            mouse_lock_boolean = false;
            Debug.Log("reached");
        }
        if (mouse_lock_boolean == true && Client_gun_auto == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Client_shoot.Play();

            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            Client_shoot.Stop();
            USER_CONTROL.lock_Client_animation = true;
            USER_CONTROL.look_front = false;
            
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            const_gunswitch_pos[3].SetActive(false);
            const_gunswitch_pos[2].SetActive(false);
            const_gunswitch_pos[1].SetActive(false);
            const_gunswitch_pos[0].SetActive(true);
            //unit 7 UI
            // testing unit for gun display scripts;

          //  gun_display01.rectTransform.localScale = new Vector3(1.2f, 1.2f, 0f);
          //  gun_display02.rectTransform.localScale = new Vector3(1f, 1f, 0f);
          //  gun_display03.rectTransform.localScale = new Vector3(1f, 1f, 0f);
          //  gun_display04.rectTransform.localScale = new Vector3(1f, 1f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            const_gunswitch_pos[3].SetActive(false);
            const_gunswitch_pos[2].SetActive(false);
            const_gunswitch_pos[0].SetActive(false);
            const_gunswitch_pos[1].SetActive(true);

         //   gun_display01.rectTransform.localScale = new Vector3(1f, 1f, 0f);
         //   gun_display02.rectTransform.localScale = new Vector3(1.2f, 1.2f, 0f);
         //   gun_display03.rectTransform.localScale = new Vector3(1f, 1f, 0f);
         //   gun_display04.rectTransform.localScale = new Vector3(1f, 1f, 0f);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            const_gunswitch_pos[3].SetActive(false);
            const_gunswitch_pos[1].SetActive(false);
            const_gunswitch_pos[0].SetActive(false);
            const_gunswitch_pos[2].SetActive(true);

          //  gun_display01.rectTransform.localScale = new Vector3(1f, 1f, 0f);
          //  gun_display02.rectTransform.localScale = new Vector3(1f, 1f, 0f);
          //  gun_display03.rectTransform.localScale = new Vector3(1.2f, 1.2f, 0f);
          //  gun_display04.rectTransform.localScale = new Vector3(1f, 1f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            const_gunswitch_pos[0].SetActive(false); // it will deactivate the necessary codes for gun scripts;
            const_gunswitch_pos[1].SetActive(false);
            const_gunswitch_pos[2].SetActive(false);
            const_gunswitch_pos[3].SetActive(true);

          //  gun_display01.rectTransform.localScale = new Vector3(1f, 1f, 0f);
          //  gun_display02.rectTransform.localScale = new Vector3(1f, 1f, 0f);
          //  gun_display03.rectTransform.localScale = new Vector3(1f, 1f, 0f);
          //  gun_display04.rectTransform.localScale = new Vector3(1.2f, 1.2f, 0f);
        }
        // mouse wheel system for this core system scripts
        // you need const integer value to make it reset.
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            // checking the game system for scrollwheel system gun switch system.
            if (const_gunswitch == 4)//4
            {
       
                const_gunswitch = -1;// -1
            }

            if (const_gunswitch == 3)
            {
                Debug.Log("Rested to 0");
                const_gunswitch_pos[0].SetActive(false); // it will deactivate the necessary codes for gun scripts;
                const_gunswitch_pos[1].SetActive(false);
                const_gunswitch_pos[2].SetActive(false);
                const_gunswitch_pos[3].SetActive(true);

              // gun_display01.rectTransform.localScale = new Vector3(1f, 1f, 0f);
              // gun_display02.rectTransform.localScale = new Vector3(1f, 1f, 0f);
              // gun_display03.rectTransform.localScale = new Vector3(1.2f, 1.2f, 0f);
              // gun_display04.rectTransform.localScale = new Vector3(1f, 1f, 0f);
            }
            else if (const_gunswitch == 2)
            {
                Debug.Log("current gun_ stauts :2");
                const_gunswitch_pos[3].SetActive(false);
                const_gunswitch_pos[1].SetActive(false);
                const_gunswitch_pos[0].SetActive(false);
                const_gunswitch_pos[2].SetActive(true);

             //  gun_display01.rectTransform.localScale = new Vector3(1f, 1f, 0f);
             //  gun_display02.rectTransform.localScale = new Vector3(1.2f, 1.2f, 0f);
             //  gun_display03.rectTransform.localScale = new Vector3(1f, 1f, 0f);
             //  gun_display04.rectTransform.localScale = new Vector3(1f, 1f, 0f);
            }
            else if (const_gunswitch == 1)
            {
                Debug.Log("Current gun_switch status :1");
                const_gunswitch_pos[3].SetActive(false);
                const_gunswitch_pos[2].SetActive(false);
                const_gunswitch_pos[0].SetActive(false);
                const_gunswitch_pos[1].SetActive(true);

              //  gun_display01.rectTransform.localScale = new Vector3(1.2f, 1.2f, 0f);
              //  gun_display02.rectTransform.localScale = new Vector3(1f, 1f, 0f);
              //  gun_display03.rectTransform.localScale = new Vector3(1f, 1f, 0f);
              //  gun_display04.rectTransform.localScale = new Vector3(1f, 1f, 0f);
            }
            else if (const_gunswitch == 0)
            {
                Debug.Log("Current gun_switch status :0");
                const_gunswitch_pos[3].SetActive(false);
                const_gunswitch_pos[2].SetActive(false);
                const_gunswitch_pos[1].SetActive(false);
                const_gunswitch_pos[0].SetActive(true);

              //  gun_display01.rectTransform.localScale = new Vector3(1f, 1f, 0f);
              //  gun_display02.rectTransform.localScale = new Vector3(1f, 1f, 0f);
              //  gun_display03.rectTransform.localScale = new Vector3(1f, 1f, 0f);
              //  gun_display04.rectTransform.localScale = new Vector3(1.2f, 1.2f, 0f);
            }

            const_gunswitch++;

        }
      // else if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
      // {
      //     if (const_gunswitch == 0)
      //     {
      //         const_gunswitch_pos[1].SetActive(false);
      //         const_gunswitch_pos[2].SetActive(false);
      //         const_gunswitch_pos[3].SetActive(false);
      //         const_gunswitch_pos[0].SetActive(true);
      //     }
      //     else if (const_gunswitch == 1)
      //     {
      //         const_gunswitch_pos[0].SetActive(false);
      //         const_gunswitch_pos[2].SetActive(false);
      //         const_gunswitch_pos[3].SetActive(false);
      //         const_gunswitch_pos[1].SetActive(true);
      //
      //
      //     }
      //     else if (const_gunswitch == 2)
      //     {
      //         const_gunswitch_pos[0].SetActive(false);
      //         const_gunswitch_pos[1].SetActive(false);
      //         const_gunswitch_pos[3].SetActive(false);
      //         const_gunswitch_pos[2].SetActive(true);
      //
      //     }
      //     else if (const_gunswitch == 3)
      //     {
      //         const_gunswitch_pos[0].SetActive(false);
      //         const_gunswitch_pos[1].SetActive(false);
      //         const_gunswitch_pos[2].SetActive(false);
      //         const_gunswitch_pos[3].SetActive(true);
      //
      //
      //     }
      //     // do not apply take away 
      //     if(const_gunswitch == -1)// -1
      //     {
      //     
      //         const_gunswitch = 4; //4
      //     }
      //     const_gunswitch--;
      // }
      //
        
             

        if (Input.GetKeyDown(KeyCode.V))
        {
            Client_melee_attack();
            Debug.Log("meleeattack");
        }

        // Reloading system
        if (Input.GetKeyDown(KeyCode.R))
        {
           
            if (_Client_default_recoilX_1 != 0 || _Client_default_recoilX_2 != 0)
            {
                
                Debug.Log("Bot");
                // recoil x and y values
                _Client_default_recoilX_1 = 0;
                _Client_default_recoilX_2 = 0;
                _Client_default_recoilY_1 = 0;
                _Client_default_recoilY_2 = 0;
                ray_view.transform.localEulerAngles = UnityEngine.Vector3.zero;
                ray_view_y.transform.localEulerAngles = UnityEngine.Vector3.zero;
                ray_view_yn.transform.localEulerAngles = UnityEngine.Vector3.zero;
                ray_view_x.transform.localEulerAngles = UnityEngine.Vector3.zero;
                ray_view_xn.transform.localEulerAngles = UnityEngine.Vector3.zero;
            
            }
            StartCoroutine(Client_gunreload_delay(0.5f));

          //  Client_gunreload_delay(0.5f);
            StopCoroutine(Client_gunreload_delay(0.5f));
        }
        
        // you need to develop semi auto burst system.1
        if (Input.GetKeyDown(KeyCode.C) && Client_gunmodeswitch == 0)
        {
            Client_gunstatus.text = "_semi";
            //Debug.Log("semi");
            Client_gunmodeswitch = 1;
            Client_gun_semi = true;
            Client_gun_auto = false;
            Client_gun_burst = false;
            // semi
        }
        else if (Input.GetKeyDown(KeyCode.C) && Client_gunmodeswitch == 1)
        {
            Client_gunstatus.text = "_auto";
            // Debug.Log("auto");
            Client_gunmodeswitch = 2;
            Client_gun_semi = false;
            Client_gun_auto = true;
            Client_gun_burst = false;
        }
        else if (Input.GetKeyDown(KeyCode.C) && Client_gunmodeswitch == 2)
        {
            Client_gunstatus.text = "_burst";
            // Debug.Log("burst");
            Client_gunmodeswitch = 3;
            Client_gun_semi = false;
            Client_gun_auto = false;
            Client_gun_burst = true;
        }
        else if (Client_gunmodeswitch == 3)
        {
            Debug.Log("reset");
            Client_gunmodeswitch = 0;
        }

     
        // recoil system step1

    
        if (Client_gun_semi == true && Client_gunammoamount >= 1)
        {
         
            if (Input.GetMouseButtonDown(0))
            {
                USER_CONTROL.lock_Client_animation = false;
                USER_CONTROL.look_front = true;


                _Client_randomshootreset_1 = true;
                _Client_randomshootreset_2 = false;
                _Client_randomshootreset_3 = true;
                _Client_randomshootreset_4 = true;

                // default x and y values
                _Client_default_recoilX_1 += 1;
                _Client_default_recoilX_2 += 1;
                _Client_default_recoilY_1 += 1;
                _Client_default_recoilY_2 += 1;
                Client_gunammoamount -= 1;
                StartCoroutine(Client_test_recoildown(0.1f, 0.01f, Client_recoil_downcount));
                Client_bullet_count += 1;
                Debug.Log("Client bullet count:" + Client_bullet_count);
                Client_Shoot();

                Client_test_recoilup(_Client_recoilup_count);

            }
            else if (Input.GetMouseButtonUp(0))
            {
                USER_CONTROL.lock_Client_animation = true;
                USER_CONTROL.look_front = false;

                _Client_randomshootreset_1 = false;
                _Client_randomshootreset_2 = true;
                _Client_randomshootreset_3 = false;
                _Client_randomshootreset_4 = false;

                //Client_Shoot();
                if (_Client_default_recoilX_1 != 0 || _Client_default_recoilX_2 != 0)
                {
                    Debug.Log("Bot");
                    // recoil x and y values
                    _Client_default_recoilX_1 = 0;
                    _Client_default_recoilX_2 = 0;
                    _Client_default_recoilY_1 = 0;
                    _Client_default_recoilY_2 = 0;
                    ray_view.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    ray_view_y.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    ray_view_yn.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    ray_view_x.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    ray_view_xn.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    Sight_xn.rectTransform.localPosition = new UnityEngine.Vector3(-Client_Sight_view_difference, 0f, 0f);
                    Sight_x.rectTransform.localPosition = new UnityEngine.Vector3(+Client_Sight_view_difference, 0f, 0f);
                    Sight_yn.rectTransform.localPosition = new UnityEngine.Vector3(0f, -Client_Sight_view_difference, 0f);
                    Sight_y.rectTransform.localPosition = new UnityEngine.Vector3(0f, +Client_Sight_view_difference, 0f);
                }
                // default x and y values
                _Client_default_recoilX_1 = 0;
                _Client_default_recoilX_2 = 0;
                _Client_default_recoilY_1 = 0;
                _Client_default_recoilY_2 = 0;

                Client_test_recoildown(0.1f, 0.01f, Client_recoil_downcount);
                Debug.Log("GetMouseButtonUp(0)");
                //testing quad fix
                QuadCount();
                StartCoroutine(SightCount_disappear(Client_gunshootdisappear_rate));
                StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                //SightCount_disappear(Client_gunshootdisappear_rate);
                // StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                // QuadCount_disappear(Client_quadcountdisappear_rate);


            }
        }
        else if (Client_gun_auto == true && Client_gunammoamount >= 1)
        {
         
            //auto function 
            if (Input.GetMouseButtonDown(0))
            {
                USER_CONTROL.lock_Client_animation = false;
                USER_CONTROL.look_front = true;

                Client_gunauto_toggle = true;
                _Client_randomshootreset_1 = true;
                _Client_randomshootreset_2 = false;
                _Client_randomshootreset_3 = true;
                _Client_randomshootreset_4 = true;


                if (Client_gunauto_toggle == true)
                {

                    StartCoroutine(Client_gunautomatic());
                    //  Client_gunautomatic();
                    if (Client_gunammoamount < 0)
                    {

                        // default x and y values
                        _Client_default_recoilX_1 = 0;
                        _Client_default_recoilX_2 = 0;
                        _Client_default_recoilY_1 = 0;
                        _Client_default_recoilY_2 = 0;

                        Client_gunauto_togglecount = 0;
                        Client_gunauto_toggle = false;
                    }
                   
                }


            }
            else if (Input.GetMouseButtonUp(0))
            {
                USER_CONTROL.lock_Client_animation = true;
                USER_CONTROL.look_front = false;

                _Client_randomshootreset_1 = false;
                _Client_randomshootreset_2 = true;
                _Client_randomshootreset_3 = false;
                _Client_randomshootreset_4 = false;

           
                if (_Client_default_recoilX_1 != 0 || _Client_default_recoilX_2 != 0)
                {
                    Debug.Log("Bot");
                    // recoil x and y values
                    USER_CONTROL.lock_Client_animation = true;
                    USER_CONTROL.look_front = false;

                    _Client_default_recoilX_1 = 0;
                    _Client_default_recoilX_2 = 0;
                    _Client_default_recoilY_1 = 0;
                    _Client_default_recoilY_2 = 0;
                    ray_view.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    ray_view_y.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    ray_view_yn.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    ray_view_x.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    ray_view_xn.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    Sight_xn.rectTransform.localPosition = new UnityEngine.Vector3(-Client_Sight_view_difference, 0f, 0f);
                    Sight_x.rectTransform.localPosition = new UnityEngine.Vector3(+Client_Sight_view_difference, 0f, 0f);
                    Sight_yn.rectTransform.localPosition = new UnityEngine.Vector3(0f, -Client_Sight_view_difference, 0f);
                    Sight_y.rectTransform.localPosition = new UnityEngine.Vector3(0f, +Client_Sight_view_difference, 0f);
                }
                StartCoroutine(SightCount_disappear(Client_gunshootdisappear_rate));
                StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                // SightCount_disappear(Client_gunshootdisappear_rate);
                // StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                // QuadCount_disappear(Client_quadcountdisappear_rate);
                Client_gunauto_togglecount = 0;
                Debug.Log("auto faulty");
                Client_gunauto_toggle = false;

           
            }
        }
        else if (Client_gun_burst == true && Client_gunammoamount >= 1)
        {
            //burst function
        
            if (Input.GetMouseButtonDown(0) && Client_gunburst_toggle_0 == true)
            {
                USER_CONTROL.lock_Client_animation = false;
                USER_CONTROL.look_front = true;

                Client_gunburst_toggle_0 = false;
                Client_gunburst_toggle = true;
                StartCoroutine(Client_gunburst());
                StartCoroutine(Client_gunburstboolwait(Client_gunburst_cooltime));
                if (Client_gunburst_toggle == true)
                {
                    Client_gunburst();
                    if (Client_gunammoamount < 0)
                    {
                        // default x and y values
                        _Client_default_recoilX_1 = 0;
                        _Client_default_recoilX_2 = 0;
                        _Client_default_recoilY_1 = 0;
                        _Client_default_recoilY_2 = 0;

                        Client_gunburst_togglecount = 0;
                        Client_gunburst_toggle = false;
                    }
                }

                // }   
            }
            else if (Input.GetMouseButtonUp(0))
            {
                USER_CONTROL.lock_Client_animation = true;
                USER_CONTROL.look_front = false;

                Client_gunburstboolwait(Client_gunburst_cooltime);
                Client_gunburst_togglecount = 0;
                Client_gunburst_toggle = false;
                Client_gun_auto = false;
                _Client_randomshootreset_1 = false;
                _Client_randomshootreset_2 = true;
                _Client_randomshootreset_3 = false;
                _Client_randomshootreset_4 = false;
                Client_Shoot();
                if (_Client_default_recoilX_1 != 0 || _Client_default_recoilX_2 != 0)
                {
                    Debug.Log("Bot");
                    // recoil x and y values
                    _Client_default_recoilX_1 = 0;
                    _Client_default_recoilX_2 = 0;
                    _Client_default_recoilY_1 = 0;
                    _Client_default_recoilY_2 = 0;
                    ray_view.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    ray_view_y.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    ray_view_yn.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    ray_view_x.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    ray_view_xn.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    Sight_xn.rectTransform.localPosition = new UnityEngine.Vector3(-Client_Sight_view_difference, 0f, 0f);
                    Sight_x.rectTransform.localPosition = new UnityEngine.Vector3(+Client_Sight_view_difference, 0f, 0f);
                    Sight_yn.rectTransform.localPosition = new UnityEngine.Vector3(0f, -Client_Sight_view_difference, 0f);
                    Sight_y.rectTransform.localPosition = new UnityEngine.Vector3(0f, +Client_Sight_view_difference, 0f);
                }
                StartCoroutine(SightCount_disappear(Client_gunshootdisappear_rate));
                StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                // SightCount_disappear(Client_gunshootdisappear_rate);
                // StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                // QuadCount_disappear(Client_quadcountdisappear_rate);


            }

        }
     
        if (Input.GetMouseButtonDown(2))
        {
         
            Debug.Log("Switching Controls");
        }

        // swithing controls between user inputs
        if (Input.GetMouseButtonDown(1))
        {
            _Client_recoilup_count = Client_guninfo.Client_changed_recoilup_count;
            Client_recoil_downcount = Client_guninfo.Client_changed_recoil_downcount;
            // changing gun positions
            USER_CONTROL.look_front = true;
            USER_CONTROL.lock_Client_animation = false;
            //Camera.main.fieldOfView = 40.0f + 1;
         
            StartCoroutine(Client_sight_zoomout(Client_zoomout_min, 0.001f));
            // StopCoroutine(Client_sight_zoomout(Client_zoomout_min, 0.1f));
            Debug.Log("Camera Zoom in");
        }
        else if (Input.GetMouseButtonUp(1))
        {
          
            _Client_recoilup_count = Client_guninfo.Client_normal_changed_recoilup_count;
            Client_recoil_downcount = Client_guninfo.Client_normal_changed_recoil_downcount;
            // changing gun positions
            USER_CONTROL.look_front = false;
            USER_CONTROL.lock_Client_animation = true;
            StartCoroutine(Client_sight_zoomin(Client_zoomin_max, 0.001f));
            Debug.Log(Input.mousePosition);
            Debug.Log("Camera Zoom out");
            // Camera.main.fieldOfView = 60.0f;
            StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
            //StopCoroutine(Client_sight_zoomin(Client_zoomin_max, 0.1f));
        }
        if (Client_RenderAlpha_boolean01 == true)
        {
            
            Client_RenderAlphaSpeed = 5f;
            Client_RenderAlpha -= Time.deltaTime * Client_RenderAlphaSpeed;
            Color startColor = Color.black;
            Color endColor = Color.white;
            startColor.a = Client_RenderAlpha;
            endColor.a = Client_RenderAlpha;
            Client_RenderEffect01.SetColors(startColor, endColor);
            if (Client_RenderAlpha < 0.0f)
            {
                Client_RenderAlpha = 1f;
                Client_RenderAlpha_boolean01 = false;
                ClientSystem_CloneCount = 0;
            }


        }


    }
    
    public void Client_Burstshoot()
    {

        Client_Pistol.Play();
        // setting this priority.
        Debug.DrawRay(ray_view.transform.position, transform.forward * Client_GunRange, Color.blue);
        int random_effect = Random.Range(0, random_effect_collision_limits);
        RaycastHit hit;
        Ray Origin = new Ray(ray_view.transform.position, ray_view.transform.forward);
        if (Physics.Raycast(Origin, out hit, Client_GunRange))
        {
            //new script version
            switch (hit.collider.tag)
            {
                case "Effect":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                         

                        Client_gunshootcounts += 1;
                        Debug.Log(hit.transform.name);
                       // Client_effect01 = GameObject.FindGameObjectWithTag("Effect");
                        Client_RenderEffect01.enabled = true;



                        //  Destroy(GameObject.Find("Sight(Clone)"), Client_quadcountdisappear_rate);
                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        break;
                    }
                case "Test":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        Client_gunshootcounts += 1;
                        Debug.Log(hit.transform.name);
                        test = GameObject.FindWithTag("Test").GetComponent<TEST_model>();
                        Client_effect01 = GameObject.FindGameObjectWithTag("Effect");
                        Instantiate(Client_RenderEffect01, Client_RenderTransform01.transform.position, Client_RenderTransform01.transform.rotation);
                        Instantiate(Client_effect01, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));

                        Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                        StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                       // test.Objecthit();
                        Client_RenderEffect01.enabled = true;
                        // Enemy_health -= Client_guninfo.Client_gundamage;
                        //Destroy(GameObject.Find("Sight(Clone)"), Client_quadcountdisappear_rate);
                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        break;
                    }
                case "Test_HEAD":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        Client_gunshootcounts += 1;
                        Debug.Log(hit.transform.name);
                        test = GameObject.FindWithTag("Test").GetComponent<TEST_model>();
                        Client_effect01 = GameObject.FindGameObjectWithTag("Effect");
                        Instantiate(Client_RenderEffect01, Client_RenderTransform01.transform.position, Client_RenderTransform01.transform.rotation);
                        Instantiate(Client_effect01, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));

                        Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                        StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                        //   test.Objecthit();
                        Client_RenderEffect01.enabled = true;
                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        break;
                    }
                        //  Enemy_health -= Client_guninfo.Client_gunciriticaldamage;
                        //  Destroy(GameObject.Find("Sight(Clone)"), Client_quadcountdisappear_rate);
                case "Target_head":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        Client_gunshootcounts += 1;
                        Debug.Log(hit.transform.name);
                        test = GameObject.FindWithTag("Test").GetComponent<TEST_model>();
                        Client_effect01 = GameObject.FindGameObjectWithTag("Effect");
                        Instantiate(Client_RenderEffect01, Client_RenderTransform01.transform.position, Client_RenderTransform01.transform.rotation);
                        Instantiate(Client_effect01, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));

                        Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                        StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                     //   test.Objecthit();
                        Client_RenderEffect01.enabled = true;
                        // Target_Score += Client_guninfo.Client_gunciriticaldamage;
                        //  Destroy(GameObject.Find("Sight(Clone)"), Client_quadcountdisappear_rate);
                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        break;
                    }
                case "Target_body":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        Client_gunshootcounts += 1;
                        Debug.Log(hit.transform.name);
                        test = GameObject.FindWithTag("Test").GetComponent<TEST_model>();
                        Client_effect01 = GameObject.FindGameObjectWithTag("Effect");
                        Instantiate(Client_RenderEffect01, Client_RenderTransform01.transform.position, Client_RenderTransform01.transform.rotation);
                        Instantiate(Client_effect01, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));

                        Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                        StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));

                        // test.Objecthit();
                        Client_RenderEffect01.enabled = true;
                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        //  Target_Score += Client_guninfo.Client_gundamage;
                        //Destroy(GameObject.Find("Sight(Clone)"), Client_quadcountdisappear_rate);
                        break;
                    }
                case "hitbox":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        Client_gunshootcounts += 1;
                        Debug.Log(hit.transform.name);
                        Client_effect01 = GameObject.FindGameObjectWithTag("Effect");
                        Client_RenderEffect01.enabled = true;
                        Instantiate(Client_RenderEffect01, Client_RenderTransform01.transform.position, Client_RenderTransform01.transform.rotation);
                        Instantiate(Client_effect01, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));

                        Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                        StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        // Destroy(GameObject.Find("Sight(Clone)"), Client_quadcountdisappear_rate);
                        break;
                    }
                case "AI_unitthree":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        AI_UNITWAY.AI_way_range += 5;
                        AI_UNITWAY.AI_way_boolean01 = true;
                        AI_UNITWAY.AI_way_ins_boolean01 = true;
                        AI_UNITWAY.AI_way_walkforward = true;
                        AI_UNITWAY.AI_way_backlookreset = false;
                        AI_UNITWAY.AI_way_boolean02 = false;
                        AI_UNITWAY.AI_way_boolean04 = false;
                        AI_UNITWAY.AI_way_health_value -= 0.04f;
                        Instantiate(AI_UNITWAY.AI_way_damage_display_prefab, AI_UNITWAY.AI_way_damage_display_pos);
                        AI_UNITWAY.AI_way_damage_display_pos.DetachChildren();
                        AI_UNITWAY.StartCoroutine(AI_UNITWAY.AI_way_damage_display_deletion(1f));
                        break;
                    }
                case "AI_unitone":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        AI_UNIT.AI_boolean01 = true;
                        AI_UNIT.AI_ins_boolean01 = true;
                        AI_UNIT.AI_walkforward = true;
                        AI_UNIT.AI_backlookreset = false;
                        AI_UNIT.AI_range += 5;
                        AI_UNIT.AI_boolean02 = false;
                        AI_UNIT.AI_boolean04 = false;
                        AI_UNIT.hitsound.Play();
                        AI_UNIT.AI_health_value -= 0.04f;
                        Instantiate(AI_UNIT.AI_damage_display_prefab, AI_UNIT.AI_damage_display);
                        AI_UNIT.AI_damage_display.DetachChildren();
                        AI_UNIT.StartCoroutine(AI_UNIT.AI_zom_damage_display_deletion(1f));
                        break;
                    }
                case "AI_unittwo":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        // AI_UNITELITE.hitsound.Play();
                        AI_UNITELITE.AI_ins_boolean01 = true;
                        AI_UNITELITE.AI_elite_walkforward = true;
                        AI_UNITELITE.AI_elite_backlookreset = false;
                        AI_UNITELITE.AI_elite_range += 5;
                        AI_UNITELITE.AI_elite_boolean01 = true;
                        AI_UNITELITE.AI_elite_boolean02 = false;
                        AI_UNITELITE.AI_elite_boolean04 = false;
                        Instantiate(AI_UNITELITE.AI_elite_damage_display_prefab, AI_UNITELITE.AI_elite_damage_display);
                        AI_UNITELITE.AI_elite_damage_display.DetachChildren();
                        AI_UNITELITE.AI_elite_health_value -= 0.04f;
                        break;
                    }
                case null:
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        Client_gunshootcounts += 1;
                    
                        Debug.Log(hit.transform.name);
                        Client_effect01 = GameObject.FindGameObjectWithTag("Effect");
                        Client_RenderEffect01.enabled = true;

                        Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                        StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        //Destroy(GameObject.Find("Sight(Clone)"), Client_quadcountdisappear_rate);
                        break;
                    }
                default:
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        Client_gunshootcounts += 1;
                        Client_RenderAlpha_boolean01 = true;
                        Client_RenderEffect01.SetPosition(0, Client_RenderTransform01.transform.position);
                        Client_RenderEffect01.SetPosition(1, hit.point);

                        Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                        StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        //Destroy(GameObject.Find("Sight(Clone)"), Client_quadcountdisappear_rate);
                        break;
                    }
            }
            Client_gunshootcounts += 1;
            Client_RenderAlpha_boolean01 = true;
            Instantiate(Client_effect01, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
            // job fixrate

            Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
            StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
            Client_RenderEffect01.SetPosition(0, Client_RenderTransform01.transform.position);
            Client_RenderEffect01.SetPosition(1, hit.point);
            // Destroy(GameObject.Find("Sight(Clone)"), Client_quadcountdisappear_rate);
            StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
            StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
        }
    }
    public void Clinet_show_item_display()
    {
        Debug.DrawRay(ray_view.transform.position, transform.forward * Client_meleerange, Color.red);
        RaycastHit hit;
        Ray Origin = new Ray(ray_view.transform.position, ray_view.transform.forward);
        if (Physics.Raycast(Origin, out hit, Client_meleerange))
        {
            switch (hit.collider.tag)
            {
                case "Client_teamone_gunAK47":
                    {

                        gun_display.enabled = true;
                        gun_display_text.enabled = true;
                        break;
                    }
                case "Client_teamone_gunUSP":
                    {
                        
                        break;
                    }

                case "Client_teamone_gunM16":
                    {
                        
                        break;
                    }

                case "Client_gunAKammo":
                    {

                        break;
                    }
                case null:
                    {
                        gun_display.enabled = false;
                        gun_display_text.enabled = false;


                        break;
                    }
                default:
                    {
                        gun_display.enabled = false;
                        gun_display_text.enabled = false;
                        break;
                    }
            }
        }
    }
    public void Client_upgradegun()
    {

        Debug.DrawRay(ray_view.transform.position, transform.forward * Client_meleerange, Color.black);

        RaycastHit hit;
        Ray Origin = new Ray(ray_view.transform.position, ray_view.transform.forward);
        Transform current_gun = GameObject.FindGameObjectWithTag("Client_gunswitch").transform;
        if (Physics.Raycast(Origin, out hit, Client_meleerange))
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                switch (hit.collider.tag)
                {
                    case "Client_teamone_gunAK47":
                        {
                            mouse_lock_boolean = true;
                            Client_guninfo.Client_guninfotrasnfer("Client_gunAK");
                            gun_switch("Client_teamone_gunAK47", "AK47_Rigid", "AK47_Rigid(Clone)", Gun_list[1]);
                            GUI_USER_display.maxValue = Client_gunammoamount;
                            break;
                        }
                    case "Client_teamone_gunUSP":
                        {
                           
                            Client_guninfo.Client_guninfotrasnfer("Client_gunUSP");
                            gun_switch("Client_teamone_gunUSP", "USP_Rigid", "USP_Rigid(Clone)", Gun_list[2]);
                            GUI_USER_display.maxValue = Client_gunammoamount;
                            break;
                        }
                  
                    case "Client_teamone_gunM16":
                        {
                            
                            Client_guninfo.Client_guninfotrasnfer("Client_gunM16");
                            gun_switch("Client_teamone_gunM16", "m16_Rigid", "m16_Rigid(Clone)", Gun_list[0]);
                            GUI_USER_display.maxValue = Client_gunammoamount;
                            break;
                        }
                   
                    case "Client_gunAKammo":
                        {
                          
                            break;
                        }
                    case null:
                        {
                            Client_Punch.Play();


                            Debug.Log(hit.transform.name);



                            break;
                        }
                    default:
                        {
                            Client_Punch.Play();



                            break;
                        }
                }
                Client_Punch.Play();
                Client_effect02 = GameObject.FindGameObjectWithTag("Client_effect01");
            }
        }
    }
    // gun switch functionality
    public void gun_switch(string destroy_firstgameObject , string delete_rigid, string delete_clone, GameObject change_gun)
    {
        // gun position settings
        Transform Client_gunswitch = GameObject.FindGameObjectWithTag("Client_gunswitch").transform;
        Transform Client_gundrop = GameObject.FindGameObjectWithTag("Client_gundrop").transform;
        if(GameObject.Find(delete_rigid) || GameObject.Find(delete_clone))
        {
            GameObject.Destroy(GameObject.FindGameObjectWithTag(destroy_firstgameObject).gameObject);
            Debug.Log("gun destoryed");
        }
        // if no gun
        if (GameObject.Find("empty"))
        {
            if (Client_gunswitch.GetChild(0).gameObject != null)
            {
                GameObject.Destroy(Client_gunswitch.GetChild(0).gameObject);
                Instantiate(change_gun, Client_gunswitch);
            }
        } // more than one gun

        // if the gun matches with this statements
        if (Client_gunswitch.GetChild(0).gameObject.tag == "Client_gunAK")
        {
            GameObject.Destroy(Client_gunswitch.GetChild(0).gameObject);
            Instantiate(change_gun, Client_gunswitch); // swtich gun
            Instantiate(Gun_rigid_list[1], Client_gundrop); // drop gun
            Gun_rigid_list[1].gameObject.tag = "Client_teamone_gunAK47";
            Client_gundrop.DetachChildren();
        }
        else if (Client_gunswitch.GetChild(0).gameObject.tag == "Client_gunM16")
        {
            GameObject.Destroy(Client_gunswitch.GetChild(0).gameObject);
            Instantiate(change_gun, Client_gunswitch); // swtich gun
            Instantiate(Gun_rigid_list[0], Client_gundrop); // drop gun
            Gun_rigid_list[0].gameObject.tag = "Client_teamone_gunM16";
            Client_gundrop.DetachChildren();
        }
        else if (Client_gunswitch.GetChild(0).gameObject.tag == "Client_gunUSP")
        {
            GameObject.Destroy(Client_gunswitch.GetChild(0).gameObject);
            Instantiate(change_gun, Client_gunswitch); // swtich gun
            Instantiate(Gun_rigid_list[2], Client_gundrop); // drop gun
            Gun_rigid_list[2].gameObject.tag = "Client_teamone_gunUSP";
            Client_gundrop.DetachChildren();
        }
    }
    public void Client_melee_attack()
    {

        Debug.DrawRay(ray_view.transform.position, transform.forward * Client_meleerange, Color.green);
        int random_effect = Random.Range(0, random_effect_collision_limits);
        RaycastHit hit;
        Ray Origin = new Ray(ray_view.transform.position, ray_view.transform.forward);
        if (Physics.Raycast(Origin, out hit, Client_meleerange))
        {
            switch (hit.collider.tag)
            {
                case "Effect":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        Client_Punch.Play();
                        Client_meleecounts += 1;
                        Debug.Log(hit.transform.name);
                        Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                        StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                        //Destroy(GameObject.Find("Punch(Clone)"), Client_quadcountdisappear_rate);
                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        break;
                    }
                case "Test":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        Client_Punch.Play();
                        Client_meleecounts += 1;
                        Debug.Log(hit.transform.name);
                        Client_effect02 = GameObject.FindGameObjectWithTag("Client_effect01");
                        Instantiate(Client_effect02, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));

                        Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                        StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        //   Enemy_health -= Client_guninfo.Client_gundamage;
                        // Destroy(GameObject.Find("Punch(Clone)"), Client_quadcountdisappear_rate);
                        break;
                    }
                case "Test_HEAD":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        Client_Punch.Play();
                        Client_meleecounts += 1;
                        Debug.Log(hit.transform.name);
                        Client_effect02 = GameObject.FindGameObjectWithTag("Client_effect01");
                        Instantiate(Client_effect02, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));

                        Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                        StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                        // Enemy_health -= Client_guninfo.Client_gunciriticaldamage;
                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        //  Destroy(GameObject.Find("Punch(Clone)"), Client_quadcountdisappear_rate);
                        break;
                    }
                case "Target_head":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        Client_Punch.Play();
                        Client_meleecounts += 1;
                        Debug.Log(hit.transform.name);
                        Client_effect02 = GameObject.FindGameObjectWithTag("Client_effect01");
                        Instantiate(Client_effect02, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));

                        Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                        StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                        //Target_Score += Client_guninfo.Client_gunciriticaldamage;

                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        break;
                    }
                case "Target_body":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        Client_Punch.Play();
                        Client_meleecounts += 1;
                        Debug.Log(hit.transform.name);
                        Client_effect02 = GameObject.FindGameObjectWithTag("Client_effect01");
                        Instantiate(Client_effect02, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));

                        Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                        StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));

                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        break;
                    }
                case "AI_unitthree":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        AI_UNITWAY.AI_way_range += 5;
                        AI_UNITWAY.AI_way_boolean01 = true;
                        AI_UNITWAY.AI_way_ins_boolean01 = true;
                        AI_UNITWAY.AI_way_walkforward = true;
                        AI_UNITWAY.AI_way_backlookreset = false;
                        AI_UNITWAY.AI_way_boolean02 = false;
                        AI_UNITWAY.AI_way_boolean04 = false;
                        AI_UNITWAY.AI_way_health_value -= 0.04f;
                        Instantiate(AI_UNITWAY.AI_way_damage_display_prefab, AI_UNITWAY.AI_way_damage_display_pos);
                        AI_UNITWAY.AI_way_damage_display_pos.DetachChildren();
                        AI_UNITWAY.StartCoroutine(AI_UNITWAY.AI_way_damage_display_deletion(1f));
                        break;
                    }
                case "AI_unitone":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        AI_UNIT.AI_boolean01 = true;
                        AI_UNIT.AI_ins_boolean01 = true;
                        AI_UNIT.AI_walkforward = true;
                        AI_UNIT.AI_range += 5;
                        AI_UNIT.AI_backlookreset = false;
                        AI_UNIT.AI_boolean02 = false;
                        AI_UNIT.AI_boolean04 = false;
                        AI_UNIT.hitsound.Play();
                        AI_UNIT.AI_health_value -= 0.04f;
                        Instantiate(AI_UNIT.AI_damage_display_prefab, AI_UNIT.AI_damage_display);
                        AI_UNIT.AI_damage_display.DetachChildren();
                        AI_UNIT.StartCoroutine(AI_UNIT.AI_zom_damage_display_deletion(1f));
                        break;
                    }
                case "AI_unittwo":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        AI_UNITELITE.AI_ins_boolean01 = true;
                        AI_UNITELITE.AI_elite_walkforward = true;
                        AI_UNITELITE.AI_elite_boolean01 = true;
                        AI_UNITELITE.AI_elite_range += 5;
                        AI_UNITELITE.AI_elite_backlookreset = false;
                        AI_UNITELITE.AI_elite_boolean02 = false;
                        AI_UNITELITE.AI_elite_boolean04 = false;
                        // AI_UNITELITE.hitsound.Play();
                        Instantiate(AI_UNITELITE.AI_elite_damage_display_prefab, AI_UNITELITE.AI_elite_damage_display);
                        AI_UNITELITE.AI_elite_damage_display.DetachChildren();
                        AI_UNITELITE.AI_elite_health_value -= 0.04f;
                        AI_UNITELITE.StartCoroutine(AI_UNITELITE.AI_damage_display_deletion(1f));
                        break;
                    }
                case "hitbox":
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        Client_Punch.Play();
                        Client_meleecounts += 1;
                        Debug.Log(hit.transform.name);
                        Client_effect02 = GameObject.FindGameObjectWithTag("Client_effect01");
                        Instantiate(Client_effect02, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));

                        Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                        StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));

                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        break;
                    }
                case null:
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        Client_Punch.Play();
                        Client_meleecounts += 1;
                        Debug.Log(hit.transform.name);
                        Client_effect02 = GameObject.FindGameObjectWithTag("Client_effect01");
                        Instantiate(Client_effect02, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));

                        Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                        StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));

                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        break;
                    }
                default:
                    {
                        Client_shoot_pos.LookAt(hit.point);
                        Client_Punch.Play();
                        Client_meleecounts += 1;

                        Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                        StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                        StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                        StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));

                        break;
                    }
            }
            Client_Punch.Play();
            Client_meleecounts += 1;
            Client_effect02 = GameObject.FindGameObjectWithTag("Client_effect01");
            Instantiate(Client_effect02, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));

            Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
            StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
            StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
            StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
            // Destroy(GameObject.Find("Punch(Clone)"), Client_quadcountdisappear_rate);
        }

    }
    public void Client_Shoot()
    {

        if (_Client_randomshootreset_4 == true)
        {
            StartCoroutine(Client_fire_effectinitialize(0.05f));
            StartCoroutine(Client_bullet_effectinitialize(1f));
            Client_Pistol.Play();
            Debug.DrawRay(ray_view.transform.position, transform.forward * Client_GunRange, Color.blue);
        }
        RaycastHit hit;
        int random_effect = Random.Range(0, random_effect_collision_limits);
        Client_gunshooteffect = false;
        Ray Origin = new Ray(ray_view.transform.position, ray_view.transform.forward);
        if (Physics.Raycast(Origin, out hit, Client_GunRange))
        {

            if (Client_gunauto_toggle == true)
            {
                if (_Client_randomshootreset_3 == true) // false
                {
                    // recoil x and y values
                    _Client_default_recoilX_1++;
                    _Client_default_recoilX_2++;
                    _Client_default_recoilY_1++;
                    _Client_default_recoilY_2++;
                }

                if (_Client_default_recoilX_1 == 30 && _Client_default_recoilX_2 == 30)
                {
                    // recoil x and y values
                    _Client_default_recoilX_1 -= 30;
                    _Client_default_recoilX_2 -= 30;
                    _Client_default_recoilY_1 -= 30;
                    _Client_default_recoilY_2 -= 30;
                }
                // make it hard codiing 1 2 3 4 5 6 all of it
                if (_Client_randomshootreset_2 == true)
                {
                    if (_Client_default_recoilX_1 != 0 && _Client_default_recoilX_2 != 0)
                    {
                        Debug.Log("Bot");
                        // recoil x and y values
                        _Client_default_recoilX_1 = 0;
                        _Client_default_recoilX_2 = 0;
                        _Client_default_recoilY_1 = 0;
                        _Client_default_recoilY_2 = 0;
                        ray_view.transform.localEulerAngles = UnityEngine.Vector3.zero;
                        ray_view_y.transform.localEulerAngles = UnityEngine.Vector3.zero;
                        ray_view_yn.transform.localEulerAngles = UnityEngine.Vector3.zero;
                        ray_view_x.transform.localEulerAngles = UnityEngine.Vector3.zero;
                        ray_view_xn.transform.localEulerAngles = UnityEngine.Vector3.zero;
                    }
                }
                // recoil?

                ray_view_y.transform.localEulerAngles = UnityEngine.Vector3.zero;
                ray_view_yn.transform.localEulerAngles = UnityEngine.Vector3.zero;
                ray_view_x.transform.localEulerAngles = UnityEngine.Vector3.zero;
                ray_view_xn.transform.localEulerAngles = UnityEngine.Vector3.zero;
                //  Sight_x.transform.position = new UnityEngine.Vector3(0f, 0f, 0f);
                //  Sight_xn.transform.position = new UnityEngine.Vector3(0f, 0f, 0f);
                //  Sight_y.transform.position = new UnityEngine.Vector3(0f, 0f, 0f);
                //  Sight_yn.transform.position = new UnityEngine.Vector3(0f, 0f, 0f);
              // Sight_xn.rectTransform.localPosition = UnityEngine.Vector3.zero;
              // Sight_x.rectTransform.localPosition = UnityEngine.Vector3.zero;
              // Sight_yn.rectTransform.localPosition = UnityEngine.Vector3.zero;
              // Sight_y.rectTransform.localPosition = UnityEngine.Vector3.zero;
                // recoil system multiplications 
                //    Client_recoil_increment(0.5f);
                // automization may be ?
                Client_primaryrecoil_increment(1f);
                //ray_view_y.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_default_recoilSetsX_2[_Client_default_recoilX_2], UnityEngine.Vector3.down);



                if (Client_primary_normalsight == true)
                {
                    float random_shoot = Random.Range(0.01f, 0.15f);
                    ray_view_y.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_primary_recoilSetsXN[_Client_default_recoilX_2] * random_shoot, UnityEngine.Vector3.down);
                    // something needs to be fixed reset needs
                    //  ray_view_yn.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_default_recoilSetsX_1[_Client_default_recoilX_1], UnityEngine.Vector3.up);
                    ray_view_yn.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_primary_recoilSetsX[_Client_default_recoilX_1] * random_shoot, UnityEngine.Vector3.up);
                    // ray_view_y make it seperate because it only allows too function at the same time;
                    // ray_view_x.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_default_recoilSetsY_2[_Client_default_recoilY_2], UnityEngine.Vector3.left);
                    ray_view_x.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_primary_recoilSetsYN[_Client_default_recoilY_2] * random_shoot, UnityEngine.Vector3.left);
                    // ray_view_xn.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_default_recoilSetsY_1[_Client_default_recoilY_1], UnityEngine.Vector3.left);
                    ray_view_xn.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_primary_recoilSetsY[_Client_default_recoilY_1] * random_shoot, UnityEngine.Vector3.left);

                    Sight_xn.rectTransform.localPosition += new UnityEngine.Vector3(-(Client_sight_reocoil_Sets[_Client_default_recoilY_1] * Client_Sight_division) - Client_Sight_view_difference, 0f, 0f);
                    Sight_x.rectTransform.localPosition += new UnityEngine.Vector3((Client_sight_reocoil_Sets[_Client_default_recoilY_2] * Client_Sight_division) + Client_Sight_view_difference, 0f, 0f);
                    Sight_yn.rectTransform.localPosition += new UnityEngine.Vector3(0f, -(Client_sight_reocoil_Sets[_Client_default_recoilX_1] * Client_Sight_division) - Client_Sight_view_difference, 0f);
                    Sight_y.rectTransform.localPosition += new UnityEngine.Vector3(0f, (Client_sight_reocoil_Sets[_Client_default_recoilX_2] * Client_Sight_division) + Client_Sight_view_difference, 0f);
                    //sight increments
                }
                if (Client_priamry_runsight == true)
                {
                    float random_shoot = Random.Range(0.01f, 0.15f);
                    //sight normal run
                    ray_view_y.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_primary_run_recoilSetsXN[_Client_default_recoilX_2] * random_shoot, UnityEngine.Vector3.down);
                    ray_view_yn.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_primary_run_recoilSetsX[_Client_default_recoilX_1] * random_shoot, UnityEngine.Vector3.up);
                    ray_view_x.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_primary_run_recoilSetsYN[_Client_default_recoilY_2] * random_shoot, UnityEngine.Vector3.left);
                    ray_view_xn.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_primary_run_recoilSetsY[_Client_default_recoilY_1] * random_shoot, UnityEngine.Vector3.left);

                    Sight_xn.rectTransform.localPosition += new UnityEngine.Vector3(-(Client_sight_run_recoil_Sets[_Client_default_recoilY_1] * Client_Sight_division) - Client_Sight_view_difference, 0f, 0f);
                    Sight_x.rectTransform.localPosition += new UnityEngine.Vector3((Client_sight_run_recoil_Sets[_Client_default_recoilY_2] * Client_Sight_division) + Client_Sight_view_difference, 0f, 0f);
                    Sight_yn.rectTransform.localPosition += new UnityEngine.Vector3(0f, -(Client_sight_run_recoil_Sets[_Client_default_recoilX_1] * Client_Sight_division) - Client_Sight_view_difference, 0f);
                    Sight_y.rectTransform.localPosition += new UnityEngine.Vector3(0f, (Client_sight_run_recoil_Sets[_Client_default_recoilX_2] * Client_Sight_division) + Client_Sight_view_difference, 0f);
                }
               
                    StartCoroutine(Client_sight_reset(0.01f,1f));
               
                //if(Sight_x.rectTransform.localPosition.x  > 1f)
                //{
                //    Debug.Log("sight_x < 0f");
                //}
                //if (Sight_yn.rectTransform.localPosition.y < -1f)
                //{
                //    Debug.Log("sight_yn < -1f");
                //}
                //if(Sight_y.rectTransform.localPosition.y > 1f)
                //{
                //    Debug.Log("sight_y < 0f");
                //}
                Debug.DrawRay(ray_view.transform.position, ray_view.transform.forward * Client_GunRange, Color.red);

            }

            if (_Client_randomshootreset_1 == true) //false
            {
                //new script version
                switch (hit.collider.tag)
                {
                    case "Effect":
                        {
                            Client_shoot_pos.LookAt(hit.point);
                            Client_gunshootcounts += 1;
                            Debug.Log(hit.transform.name);
                            //  Client_effect01 = GameObject.FindGameObjectWithTag("Effect");
                            Client_RenderEffect01.enabled = true;
                            Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                            StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                            StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                            StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                            break;
                        }
                    case "Test":
                        {
                            Client_shoot_pos.LookAt(hit.point);
                            Client_gunshootcounts += 1;
                            Debug.Log(hit.transform.name);
                            //   test = GameObject.FindWithTag("Test").GetComponent<TEST_model>();
                            // Client_effect01 = GameObject.FindGameObjectWithTag("Effect");
                            Instantiate(Client_RenderEffect01, Client_RenderTransform01.transform.position, Client_RenderTransform01.transform.rotation);
                            Instantiate(Client_effect01, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                            Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                            StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                            // test.Objecthit();
                            // Enemy_health -= Client_guninfo.Client_gundamage;
                            Client_RenderEffect01.enabled = true;
                            // Debug.Log("Sight Deleted");
                            StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                            StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));

                            break;
                        }
                    case "Test_HEAD":
                        {
                            Client_shoot_pos.LookAt(hit.point);
                            Client_gunshootcounts += 1;
                            Debug.Log(hit.transform.name);
                            // test = GameObject.FindWithTag("Test").GetComponent<TEST_model>();
                            // Client_effect01 = GameObject.FindGameObjectWithTag("Effect");
                            Instantiate(Client_RenderEffect01, Client_RenderTransform01.transform.position, Client_RenderTransform01.transform.rotation);
                            Instantiate(Client_effect01, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                            Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                            StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                            // test.Objecthit();
                            // Enemy_health -= Client_guninfo.Client_gunciriticaldamage;
                            Client_RenderEffect01.enabled = true;
                            StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                            StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));

                            break;
                        }
                    case "Target_head":
                        {
                            Client_shoot_pos.LookAt(hit.point);
                            Client_gunshootcounts += 1;
                            Debug.Log(hit.transform.name);
                            // test = GameObject.FindWithTag("Test").GetComponent<TEST_model>();
                            //Client_effect01 = GameObject.FindGameObjectWithTag("Effect");
                            Instantiate(Client_RenderEffect01, Client_RenderTransform01.transform.position, Client_RenderTransform01.transform.rotation);
                            Instantiate(Client_effect01, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                            Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                            StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                            //  test.Objecthit();
                            //  Target_Score += Client_guninfo.Client_gunciriticaldamage;
                            Client_RenderEffect01.enabled = true;
                            Debug.Log("Sight Deleted");
                            StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                            StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));

                            break;
                        }
                    case "Target_body":
                        {
                            Client_shoot_pos.LookAt(hit.point);
                            Client_gunshootcounts += 1;
                            Debug.Log(hit.transform.name);
                            // test = GameObject.FindWithTag("Test").GetComponent<TEST_model>();
                            // Client_effect01 = GameObject.FindGameObjectWithTag("Effect");
                            Instantiate(Client_RenderEffect01, Client_RenderTransform01.transform.position, Client_RenderTransform01.transform.rotation);
                            Instantiate(Client_effect01, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                            Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                            StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                            // test.Objecthit();
                            // Target_Score += Client_guninfo.Client_gundamage;
                            Client_RenderEffect01.enabled = true;
                            StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                            StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                            Debug.Log("Sight Deleted");


                            break;
                        }
                    case "AI_unitthree":
                        {
                            Client_shoot_pos.LookAt(hit.point);
                            AI_UNITWAY.AI_way_range += 5;
                            AI_UNITWAY.AI_way_boolean01 = true;
                            AI_UNITWAY.AI_way_ins_boolean01 = true;
                            AI_UNITWAY.AI_way_walkforward = true;
                            AI_UNITWAY.AI_way_backlookreset = false;
                            AI_UNITWAY.AI_way_boolean02 = false;
                            AI_UNITWAY.AI_way_boolean04 = false;
                            AI_UNITWAY.AI_way_health_value -= 0.04f;
                            Instantiate(AI_UNITWAY.AI_way_damage_display_prefab, AI_UNITWAY.AI_way_damage_display_pos);
                            AI_UNITWAY.AI_way_damage_display_pos.DetachChildren();
                            AI_UNITWAY.StartCoroutine(AI_UNITWAY.AI_way_damage_display_deletion(1f));
                            break;
                        }
                    case "AI_unitone":
                        {
                            Client_shoot_pos.LookAt(hit.point);
                            AI_UNIT.AI_boolean01 = true;
                            AI_UNIT.AI_ins_boolean01 = true;
                            AI_UNIT.AI_walkforward = true;
                            AI_UNIT.AI_range += 5;
                            AI_UNIT.AI_backlookreset = false;
                            AI_UNIT.AI_boolean02 = false;
                            AI_UNIT.AI_boolean04 = false;
                            AI_UNIT.hitsound.Play();
                            AI_UNIT.AI_health_value -= 0.04f;
                            Instantiate(AI_UNIT.AI_damage_display_prefab, AI_UNIT.AI_damage_display);
                            AI_UNIT.AI_damage_display.DetachChildren();
                            AI_UNIT.StartCoroutine(AI_UNIT.AI_zom_damage_display_deletion(1f));
                            break;
                        }
                    case "AI_unittwo":
                        {
                            Client_shoot_pos.LookAt(hit.point);
                            AI_UNITELITE.AI_ins_boolean01 = true;
                            AI_UNITELITE.AI_elite_walkforward = true;
                            AI_UNITELITE.AI_elite_backlookreset = false;
                            AI_UNITELITE.AI_elite_range += 5;
                            AI_UNITELITE.AI_elite_boolean01 = true;
                            AI_UNITELITE.AI_elite_boolean02 = false;
                            AI_UNITELITE.AI_elite_boolean04 = false;
                            // AI_UNITELITE.hitsound.Play();
                            Instantiate(AI_UNITELITE.AI_elite_damage_display_prefab, AI_UNITELITE.AI_elite_damage_display);
                            AI_UNITELITE.AI_elite_damage_display.DetachChildren();
                            AI_UNITELITE.StartCoroutine(AI_UNITELITE.AI_damage_display_deletion(1f));
                            AI_UNITELITE.AI_elite_health_value -= 0.04f;
                            break;
                        }
                    case "hitbox":
                        {
                            Client_shoot_pos.LookAt(hit.point);
                            Client_gunshootcounts += 1;
                            Debug.Log(hit.transform.name);
                            Client_effect01 = GameObject.FindGameObjectWithTag("Effect");
                            Client_RenderEffect01.enabled = true;
                            Instantiate(Client_RenderEffect01, Client_RenderTransform01.transform.position, Client_RenderTransform01.transform.rotation);
                            Instantiate(Client_effect01, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                            Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                            StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                            StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                            StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                            break;
                        }
                    case null:
                        {
                            Client_shoot_pos.LookAt(hit.point);
                            Client_gunshootcounts += 1;
                            Debug.Log(hit.transform.name);
                            Client_effect01 = GameObject.FindGameObjectWithTag("Effect");
                            Client_RenderEffect01.enabled = true;

                            StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                            StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                            StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                            break;
                        }
                    default:
                        {
                            Client_shoot_pos.LookAt(hit.point);
                            Client_gunshootcounts += 1;
                            Client_RenderAlpha_boolean01 = true;
                            Client_RenderEffect01.SetPosition(0, Client_RenderTransform01.transform.position);
                            Client_RenderEffect01.SetPosition(1, hit.point);

                            StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                            StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                            StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                            break;

                        }
                }
                Client_shoot_pos.LookAt(hit.point);
                Client_gunshootcounts += 1;
                Client_RenderAlpha_boolean01 = true;
                Instantiate(Client_effect01, hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                Instantiate(Effect_collision_gameobject[random_effect], hit.point, UnityEngine.Quaternion.LookRotation(-hit.normal * 2f));
                StartCoroutine(Client_fire_collision_effectinitialize(Effect_collision_disaapear_rate));
                Client_RenderEffect01.SetPosition(0, Client_RenderTransform01.transform.position);
                Client_RenderEffect01.SetPosition(1, hit.point);
                StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                StopCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));


            }
        }
  

    }

    // Debuging QuadCount system.
    public IEnumerator Player_display_deletion(float cooltime)
    {
        GameObject[] instance = GameObject.FindGameObjectsWithTag("Client_damage_display_prefab");
        for(int i = 0; i < instance.Length +1; i++)
        {
            yield return new WaitForSeconds(cooltime);
            Destroy(GameObject.Find("Player_Damage_view(Clone)"));
        }

    }
    public void QuadCount()
    {
        var QuadCount = GameObject.FindGameObjectsWithTag("Effect");
        for (var i = 0; i < QuadCount.Length - 1; i++)
        {
            Debug.Log("QuadCounting: " + i);
            ClientSystem_QuadCount = QuadCount.Length;
        }

    }
    public IEnumerator QuadCount_disappear(float cooltime)
    {
        GameObject[] instance = GameObject.FindGameObjectsWithTag("Effect");
        for (int i = 0; i < instance.Length; i++)
        {
            yield return new WaitForSeconds(cooltime);
            Debug.Log("QuadCounting: " + i);
           // ClientSystem_QuadCount = instance.Length;
            Destroy(GameObject.Find("Quad(1)(Clone)").gameObject);
        }
    }
    public IEnumerator SightCount_disappear(float cooltime)
    {
        var CloneCount = GameObject.FindGameObjectsWithTag("RenderEffect01");
        for (var i = 0; i < CloneCount.Length + Client_gunshootcounts; i++)
        {
            yield return new WaitForSeconds(cooltime);
            Debug.Log("Counting: " + i);
            //ClientSystem_QuadCount = QuadCount.Length;
            Destroy(GameObject.Find("Sight(Clone)"));
            Client_gunshootcounts -= 1;
        }
    }

    public IEnumerator PunchCount_disappear(float cooltime)
    {
        var PunchCount = GameObject.FindGameObjectsWithTag("Client_effect01");
        for (var i = 0; i < PunchCount.Length + Client_meleecounts; i++)
        {
            yield return new WaitForSeconds(cooltime);
            Debug.Log("Counting: " + i);
            //ClientSystem_QuadCount = QuadCount.Length;
            Destroy(GameObject.Find("Punch(Clone)"));
            Client_gunshootcounts -= 1;
        }

    }
    public void SightCloneCount()
    {
        var CloneCount = GameObject.FindGameObjectsWithTag("RenderEffect01");

        for (var i = 0; i < CloneCount.Length; i++)
        {

            //Destroy(GameObject.FindGameObjectWithTag("RenderEffect01"));
            //Debug.Log("ACTTTTTIVE");
        }
    }

    //recoil system
    //when the player gets damage
    public IEnumerator Client_getdamage(float up_recoilspeed, float down_recoilspeed, float delay_second, float recoil_downcount )
    {
        Debug.Log("works");
        Client_recoil_system_cam.transform.rotation *= UnityEngine.Quaternion.AngleAxis(up_recoilspeed, UnityEngine.Vector3.left);
      //  up_recoilspeed -= 1;
        while(recoil_downcount > 0f)
        {
            recoil_downcount--;
          // down_recoilspeed += 10;
            Client_recoil_system_cam.transform.rotation *= UnityEngine.Quaternion.AngleAxis(down_recoilspeed, UnityEngine.Vector3.right);
            yield return new WaitForSeconds(delay_second);
        }
    }
    public void Client_test_recoilup(float up_recoilspeed)
    {
        Client_recoil_system_cam.transform.rotation *= UnityEngine.Quaternion.AngleAxis(up_recoilspeed, UnityEngine.Vector3.left);
        Client_recoil_testnum01 -= up_recoilspeed;
        // Debug.Log("Client_test_recoilup:" + Client_recoil_testnum01);
    }
   public void Client_recoil_increment(float recoil_increment)
    {
        // recoil_increment source.
        Client_default_recoilSetsX_1[_Client_default_recoilX_1] *= recoil_increment;
        Client_default_recoilSetsX_2[_Client_default_recoilX_2] *= recoil_increment;
        Client_default_recoilSetsY_1[_Client_default_recoilY_1] *= recoil_increment;
        Client_default_recoilSetsY_2[_Client_default_recoilY_2] *= recoil_increment;
    }
    public void Client_primaryrecoil_increment(float recoil_increment)
    {
        Client_primary_recoilSetsX[_Client_default_recoilX_1] *= recoil_increment;
        Client_primary_recoilSetsXN[_Client_default_recoilX_2] *= recoil_increment;
        Client_primary_recoilSetsY[_Client_default_recoilY_1] *= recoil_increment;
        Client_primary_recoilSetsYN[_Client_default_recoilY_2] *= recoil_increment; 
    }
    public IEnumerator Client_test_recoildown(float down_recoilspeed, float delay_second, float recoil_downcount)
    {
        //you need to make it up smoothly this is not working.
        while (recoil_downcount > 0f)
        {
            recoil_downcount--;
            Client_recoil_testnum02 += down_recoilspeed;
            Client_recoil_system_cam.transform.rotation *= UnityEngine.Quaternion.AngleAxis(down_recoilspeed, UnityEngine.Vector3.right);
            yield return new WaitForSeconds(delay_second);
        }
    }
    public IEnumerator Client_sight_reset(float delay_speed, float down_decrement)
    {
        while (Sight_xn.rectTransform.localPosition.x < 0f)
        {
            Sight_x.rectTransform.localPosition -= new Vector3(down_decrement, 0f, 0f);
            Sight_xn.rectTransform.localPosition += new Vector3(down_decrement, 0f, 0f);
            Sight_y.rectTransform.localPosition -= new Vector3(0f, down_decrement, 0f);
            Sight_yn.rectTransform.localPosition += new Vector3(0f, down_decrement, 0f);
            yield return new WaitForSeconds(delay_speed);
        }
      
    }
    public IEnumerator Client_gunautomatic()
    {

        while (Client_gunauto_toggle == true && Client_gunammoamount >= 1)
        {
            Client_gunauto_togglecount += 1;
            Client_gunammoamount -= 1;
            Client_Shoot();
            Client_test_recoilup(_Client_recoilup_count);
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(Client_test_recoildown(0.1f, 0.01f, Client_recoil_downcount));
            Client_test_recoildown(0.1f, 0.01f, Client_recoil_downcount);
            StartCoroutine(SightCount_disappear(Client_gunshootdisappear_rate));
            SightCount_disappear(Client_gunshootdisappear_rate);
          // StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
          // QuadCount_disappear(Client_quadcountdisappear_rate);

        }


    }
    public IEnumerator Client_gunburst()
    {
        if (Client_gunburst_toggle == true && Client_gunammoamount >= 1)
        {
            if (Client_gunammoamount % burst_count == 0)
            {
                for (int i = 0; i < burst_count; i++)
                {

                   

                       Client_gun_auto = false;
                    Client_gunburst_togglecount += 1;
                    Client_gunammoamount -= 1;
                    Debug.Log("RecoilBulletCount: " + Client_gunburst_togglecount);
                    Client_Burstshoot();
                    Client_test_recoilup(_Client_recoilup_count);
                    yield return new WaitForSeconds(0.1f);
                    StartCoroutine(Client_test_recoildown(0.1f, 0.01f, Client_recoil_downcount));
                    Client_test_recoildown(0.1f, 0.01f, Client_recoil_downcount);
                    StartCoroutine(SightCount_disappear(Client_gunshootdisappear_rate));
                    SightCount_disappear(Client_gunshootdisappear_rate);
                  //  StartCoroutine(QuadCount_disappear(Client_quadcountdisappear_rate));
                  //  QuadCount_disappear(Client_quadcountdisappear_rate);
                }
            }
        }

    }
   

    // make it wait function for gun busrt
    public IEnumerator Client_gunburstboolwait(float waittime)
    {

        yield return new WaitForSeconds(waittime);
        Client_gunburst_toggle_0 = true;

    }
  

    public IEnumerator Client_gunreload_delay(float gunreleoad)
    {
       
        yield return new WaitForSeconds(gunreleoad);
        if (Client_reloadcounts > 0 && Client_gunammoamount == 0)
        {
            sound_manager[0].Play();
            Client_gunammoamount = Client_guninfo.Client_guninfoammo;
            mouse_lock_boolean = true;
            Client_reloadcounts -= 1;
        }
    }
   
    public IEnumerator Client_sight_zoomin(int zoom_timemax, float wait_fortime)
    {
        // Sync_Camera.transform.position = Sync_Camera.transform.position + Vector3.right * -1.5f;
        USER_CONTROL.Client_cam_allow_change_02 = false;
        USER_CONTROL.Client_cam_allow_change_01 = true;
        for (int i = 0; i < zoom_timemax; i++)
        {
            Camera.main.fieldOfView += Client_zoomin_max_increment;
            yield return new WaitForSeconds(wait_fortime);
        }
    }

    public IEnumerator Client_sight_zoomout(int zoom_timemin, float wait_fortime)
    {

        USER_CONTROL.Client_cam_allow_change_02 = true;
        USER_CONTROL.Client_cam_allow_change_01 = false;
        for (int i = 0; i < zoom_timemin; i++)
        {
            Camera.main.fieldOfView -= Client_zoomout_min_decrement;
            yield return new WaitForSeconds(wait_fortime);
        }
    }
    public IEnumerator Client_fire_effectinitialize(float wait_effect_time)
    {
        // automatic system required for this client system script settings
        int random_effect_selections = Random.Range(0, random_effect_selection_limits);
        Instantiate(Effect_gameObject[random_effect_selections], Effect_transform_position);
        yield return new WaitForSeconds(wait_effect_time);
        GameObject[] instance_effect = GameObject.FindGameObjectsWithTag("Client_FireEffect");
        for(int i =0; i < instance_effect.Length; i++)
        {
            Destroy(Effect_transform_position.GetChild(0).gameObject);
        }
    }
    public IEnumerator Client_fire_collision_effectinitialize(float wait_effect_time)
    {
        GameObject[] instance_collision_effect = GameObject.FindGameObjectsWithTag("Client_FireCollisionEffect");
        for(int i = 0; i < instance_collision_effect.Length; i++)
        {
            yield return new WaitForSeconds(wait_effect_time);
            Destroy(GameObject.Find("_effect_collision01(Clone)").gameObject);
        }
        
    }
    public IEnumerator Client_bullet_effectinitialize(float wait_effect_time)
    {

        int random_bullet_range = Random.Range(Client_bulleteffect_force, Client_bulleteffect_force +8);
        bullet_effect = GameObject.FindGameObjectWithTag("Client_bullet_prefab").GetComponent<Client_bulleteffect>();
        Client_bulleteffect_position = GameObject.FindGameObjectWithTag("Client_bullet_position").GetComponent<Transform>();
        // bullet_effect.Client_prefab = GameObject.FindGameObjectWithTag("Client_bullet_prefab").GetComponent<GameObject>();
        // bullet_effect.Client_rigid = GameObject.FindGameObjectWithTag("Client_bullet_prefab").GetComponent<Rigidbody>();
        //Client_bulleteffect_prefab = GameObject.FindGameObjectWithTag("Client_bullet_prefab").GetComponent<GameObject>();
        //Client_bulleteffect_rigid = GameObject.FindGameObjectWithTag("Client_bullet_prefab").GetComponent<Rigidbody>();
        //  Client_bulleteffect_prefab.AddComponent<Rigidbody>();
        //  Rigidbody bullet_prefab = Client_bulleteffect_prefab.GetComponent<Rigidbody>();
        // bullet_effect.Client_rigid.AddForce(Vector3.zero * 0f);


        Instantiate(bullet_effect.Client_prefab, Client_bulleteffect_position);
        // tag system doesnt work.
        //  bullet_effect.gameObject.tag = "instance";
        //bullet_effect.Client_rigid.useGravity = false;
        bullet_effect.Client_rigid.useGravity = true;
        bullet_effect.Client_prefab.transform.position = UnityEngine.Vector3.up * random_bullet_range * Time.deltaTime;
        // Client_obj.transform.position += UnityEngine.Vector3.up * Client_jumpspeed * Time.deltaTime;
        bullet_effect.Client_rigid.mass = 2;
        bullet_effect.Client_rigid.AddForce(transform.up * random_bullet_range);
        Client_bulleteffect_position.transform.DetachChildren();
        
        yield return new WaitForSeconds(wait_effect_time);
        GameObject[] instance = GameObject.FindGameObjectsWithTag("Client_bullet_prefab");
        for (int i = 0; i < instance.Length; i++)
        {
            Destroy(GameObject.Find("Bullet(Clone)").gameObject);
            Debug.Log("deleted");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_value : MonoBehaviour
{
    // all variable, integer  values should go here. USER CLIENT SYSTEM
    public USER_guninfo Client_userguninfo;
    public USER_inputcontrol Client_inputcontrol;
    public USER_mousecontrol Client_mousecontrol;
    public USER_playercontrol Client_playercontrol;
    public USER_playerfollow Client_playerfollow;
    public USER_playermap Client_playermap;
    public USER_player_auto Client_playerauto;
    public USER_status Client_status;

    // SYSTEM CLIENT 
    public SYSTEM_damage_display Client_damagedisplay;
    public SYSTEM_player_damage_display Client_playerdamagedisplay;
    public SYSTEM_soundmanager Client_soundmanager;
    public SYSTEM_startup Client_startup;
    public SYSTEM_version Client_version;
    // AI Models
    public AI_modelelite Ai_model_01;
    public AI_modelway Ai_model_02;
    public AI_modelzom Ai_model_03;
    public AI_modelzom_detect Ai_model_03_01;
    // Client sets
    public Client_bulleteffect Ai_bullet_effect;

    public string Target = "Player"; 
    void Start()
    {
        // getting system default values from each variable.
        // USER
        Client_userguninfo = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_guninfo>();
        Client_inputcontrol = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_inputcontrol>();
        Client_mousecontrol = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_mousecontrol>();
        Client_playercontrol = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_playercontrol>();
        Client_playerfollow = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_playerfollow>();
        Client_playermap = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_playermap>();
        Client_playerauto = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_player_auto>();
        Client_status = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_status>();

        // SYSTEM
        Client_damagedisplay = GameObject.FindGameObjectWithTag("AI_damage_display").GetComponent<SYSTEM_damage_display>();
        Client_playerdamagedisplay = GameObject.FindGameObjectWithTag("Client_damage_display").GetComponent<SYSTEM_player_damage_display>();
        //  Client_soundmanager = GameObject.FindGameObjectWithTag("").GetComponent<SYSTEM_soundmanager>();
        //  Client_startup = GameObject.FindGameObjectWithTag("").GetComponent<SYSTEM_startup>();
        //  Client_version = GameObject.FindGameObjectWithTag("").GetComponent<SYSTEM_version>();


        // AI MODELS
        Ai_model_01 = GameObject.FindGameObjectWithTag("AI_unittwo").GetComponent<AI_modelelite>();
        Ai_model_02 = GameObject.FindGameObjectWithTag("AI_unithree").GetComponent<AI_modelway>();
        Ai_model_03 = GameObject.FindGameObjectWithTag("AI_unitone").GetComponent<AI_modelzom>();
        // Ai_model_03_01 = GameObject.FindGameObjectWithTag("").GetComponent<AI_modelzom_detect>();

        // Client variables
        Ai_bullet_effect = GameObject.FindGameObjectWithTag("Client_bullet_prefab").GetComponent<Client_bulleteffect>();


        Ai_model_01.AI_elite_range = 12.52f;
        Ai_model_01.AI_elite_attackrange = 2.4f;
        Ai_model_01.AI_elite_dectectrange = 5.1f;
        Ai_model_01.AI_elite_turnspeed = 2f;
        Ai_model_01.AI_elite_movespeed = 2f;
        Ai_model_01.AI_elite_customize_movespeed = 2f;
        Ai_model_01._enemytag = Target;
        Ai_model_01.AI_elite_health = 1f;
        Ai_model_01.AI_elite_totalhealth = 1f;
        Ai_model_01.AI_elite_health_value = 1f;
        // Ai_model_01.AI_zom_melee_range = 2.11f
        Ai_model_02.AI_way_range = 12.52f;
        Ai_model_02.AI_way_attackrange = 2.4f;
        Ai_model_02.AI_way_detectrange = 5.1f;
        Ai_model_02.AI_way_turnspeed = 2f;
        Ai_model_02.AI_way_movespeed = 2f;
        Ai_model_02.AI_way_customize_movespeed = 2f;
        Ai_model_02._enemytag = Target;
        Ai_model_02.AI_way_health = 1f;
        Ai_model_02.AI_way_totalhealth = 1f;
        Ai_model_02.AI_way_health_value = 1f;

        Ai_model_03.AI_range = 12.52f;
        Ai_model_03.AI_attackrange = 2.4f;
        Ai_model_03.AI_Detectrange = 5.1f;
        Ai_model_03.AI_turnspeed = 2f;
        Ai_model_03.AI_movespeed = 2f;
        Ai_model_03.AI_customize_movespeed = 2f;
        Ai_model_03._enemytag = Target;
        Ai_model_03.AI_health = 1f;
        Ai_model_03.AI_totalhealth = 1f;
        Ai_model_03.AI_health_value = 1f;





    }

    // Update is called once per frame
    void Update()
    {



    }
}

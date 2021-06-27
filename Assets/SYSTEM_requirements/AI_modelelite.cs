using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AI_modelelite : MonoBehaviour
{

    public Camera AI_elite_main_camera;
    public Transform _AI_object;
    public Transform _AI_elite_detection;
    public Transform _AI_elite_attack_detection;
    public Transform _AI_elite_object;
    public float AI_elite_range;
    public float AI_elite_attackrange;
    public float AI_elite_dectectrange;
    public float AI_elite_turnspeed;
    public float AI_elite_movespeed;
    public float AI_elite_customize_movespeed;
    public string _enemytag;
    public bool AI_elite_speed_limit;

    [Header("AI_elite_actions")]
    public bool AI_elite_walkforward;
    public bool AI_elite_frontlookreset;
    public bool AI_elite_backlookreset;
    public bool AI_elite_lookatplayer;
    [Header("Other booleans")]
    public bool AI_elite_boolean01;
    public bool AI_elite_boolean02;
    public bool AI_elite_boolean03;
    public bool AI_elite_boolean04;

    public bool AI_ins_boolean01;

    public Transform AI_elite_reset_look;
    public Transform AI_elite_reset_front;
    public Slider AI_elite_health_display;
    public Text AI_elite_health_text_display;
    public Text AI_elite_gun_ammo_display;
    public float AI_elite_health;
    public float AI_elite_totalhealth;
    public float AI_elite_health_value;
    public AudioSource AI_hitsounds;
    // Shooting AI script
    public Transform AI_ray_view;
    public float AI_gunrange;
    // AI_Client_effect
    public LineRenderer AI_rendereffect;
    public Transform AI_rendereffect_obj;
    public bool AI_rendereffect_alpha_boolean;
    public float AI_rendereffect_alphaspeed;
    public float AI_renderalpha;
    public AudioSource AI_shootsound;
    public AudioSource AI_reloadsound;
    public bool AI_shootdelay;
    public bool AI_shootdealy_ins_boolean;
    public float AI_gundelayspeed;
    public int AI_gunammolimits;

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
    public Transform AI_ray_view_x;
    public Transform AI_ray_view_xn;
    public Transform AI_ray_view_y;
    public Transform AI_ray_view_yn;
    public int _Client_default_recoilX_1 = 0;
    public int _Client_default_recoilX_2 = 0;
    public int _Client_default_recoilY_1 = 0;
    public int _Client_default_recoilY_2 = 0;
    // bullet collision effects.
    public Client_bulleteffect bullet_effect;
    public Transform Client_bulleteffect_position;
    public int Clinet_bulleteffect_force;
    //damage display instatiation. position
    public Transform AI_elite_damage_display;
    public Transform AI_elite_damage_display_prefab;
    public USER_inputcontrol PLAYER;
    public bool randomshoot;
    public bool randomshoot_deac;
    public SYSTEM_player_damage_display PLAYER_DISPLAY;
    public BRICKWALL _BRICKWALL;

    // unlimited job
    public ParticleSystem AISHOOT;
    public Transform AISHOOT_transform;
    // Start is called before the first frame update
    void Start()
    {
        AISHOOT.Stop();
        InvokeRepeating("Client_AI_elite_targetupdate", 0f, 2f);
        InvokeRepeating("Client_AI_elite_attackupdate", 0f, 2f);
        PLAYER_DISPLAY = GameObject.FindGameObjectWithTag("Client_damage_display").GetComponent<SYSTEM_player_damage_display>();
        _BRICKWALL = GameObject.FindGameObjectWithTag("BRICK").GetComponent<BRICKWALL>();
        AI_elite_damage_display = GameObject.FindGameObjectWithTag("AI_damage_display").GetComponent<Transform>();
        AI_elite_damage_display_prefab = GameObject.FindGameObjectWithTag("AI_damage_display_prefab").GetComponent<Transform>();
        PLAYER = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_inputcontrol>();
        AI_ray_view_x = GameObject.FindGameObjectWithTag("Client_AI_ray_x").GetComponent<Transform>();
        AI_ray_view_xn = GameObject.FindGameObjectWithTag("Client_AI_ray_xn").GetComponent<Transform>();
        AI_ray_view_y = GameObject.FindGameObjectWithTag("Client_AI_ray_y").GetComponent<Transform>();
        AI_ray_view_yn = GameObject.FindGameObjectWithTag("Client_AI_ray_yn").GetComponent<Transform>();
        AI_rendereffect = GameObject.FindGameObjectWithTag("Client_AI_rendereffect").GetComponent<LineRenderer>();
        AI_rendereffect_obj = GameObject.FindGameObjectWithTag("Client_AI_rendereffect").GetComponent<Transform>();
        AI_renderalpha = 1f;
        AI_ray_view = GameObject.FindGameObjectWithTag("Client_AI_shoot").GetComponent<Transform>();
        AI_elite_main_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        AI_elite_reset_look = GameObject.FindWithTag("Client_elite_AI_reset_look").GetComponent<Transform>();
        AI_elite_reset_front = GameObject.FindWithTag("Client_elite_AI_reset_front").GetComponent<Transform>();
        AI_elite_health_display = GameObject.FindWithTag("Client_elite_AI_health").GetComponent<Slider>();
        AI_elite_backlookreset = true;
        AI_gunammolimits = 0;
      
    }

    // Update is called once per frame
    void Update()
    {

        _AI_object.LookAt(_AI_object.transform.position + AI_elite_main_camera.transform.rotation * Vector3.forward
            , AI_elite_main_camera.transform.rotation * Vector3.up);
        AI_elite_health_display.value = AI_elite_health_value;
        AI_elite_health = 1f;
        AI_elite_health_text_display.text = AI_elite_health_value.ToString();
        AI_elite_gun_ammo_display.text = AI_gunammolimits.ToString();
        if (AI_elite_health_value < 0f)
        {
            StartCoroutine(AI_damage_display_deletion(0.1f));
            Destroy(GameObject.FindGameObjectWithTag("AI_unittwo").gameObject);
        }



        if (_AI_elite_detection != null)
        {
            Debug.Log("detected");
            if (AI_elite_boolean01 == true)
            {
                AI_elite_walkforward = true;
                AI_elite_backlookreset = false;
                AI_elite_frontlookreset = false;
                AI_elite_lookatplayer = false;
                AI_shootdelay = false;
            }
        }
        if (_AI_elite_detection == null)
        {
            Debug.Log("not detected");
            if (AI_elite_boolean02 == true)
            {
                AI_elite_walkforward = false;
                AI_elite_backlookreset = true;
                AI_elite_frontlookreset = false;
                AI_elite_lookatplayer = false;
                AI_shootdelay = false;
            }
        }
        // all false
        if (AI_elite_boolean03 == true)
        {
            AI_elite_walkforward = false;
            AI_elite_backlookreset = false;
            AI_elite_frontlookreset = false;
            AI_elite_lookatplayer = true;
            AI_shootdelay = true;
        }
        if (AI_shootdelay == true && AI_shootdealy_ins_boolean == false)
        {
            AI_client_shoot();
            AI_shootdealy_ins_boolean = true;
            AI_gunammolimits += 1;
            if (randomshoot == true)
            {
                float random_gundelayshoot = Random.Range(0.1f, 1f);
                StartCoroutine(AI_client_waitforshoot(random_gundelayshoot));
            }
            if (randomshoot_deac == true)
            {
                StartCoroutine(AI_client_waitforshoot(AI_gundelayspeed));
            }
            // AI_client_waitforshoot(1f);
        }
        if (AI_elite_boolean04 == true)
        {

            AI_elite_walkforward = false;
            AI_elite_backlookreset = false;
            AI_elite_frontlookreset = true;
            AI_elite_lookatplayer = false;
            AI_shootdelay = false;
        }
        if (AI_elite_lookatplayer == true)
        {
            // AI_elite_movespeed = AI_elite_customize_movespeed;
            //
            // _AI_elite_object.transform.position += _AI_elite_object.transform.forward * Time.deltaTime * AI_elite_movespeed;
            // _AI_object.position += transform.forward *Time.de* 2;
            Vector3 dir = _AI_elite_detection.position - _AI_elite_object.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(_AI_elite_object.rotation, lookRotation, Time.deltaTime * AI_elite_turnspeed).eulerAngles;
            _AI_elite_object.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
        if (AI_elite_walkforward == true)
        {
            // this scru
            AISHOOT.Stop();
            AI_elite_movespeed = AI_elite_customize_movespeed;

            _AI_elite_object.transform.position += _AI_elite_object.transform.forward * Time.deltaTime * AI_elite_movespeed;
            // _AI_object.position += transform.forward *Time.de* 2;
            Vector3 dir = _AI_elite_detection.position - _AI_elite_object.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(_AI_elite_object.rotation, lookRotation, Time.deltaTime * AI_elite_turnspeed).eulerAngles;
            _AI_elite_object.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        }
        if (AI_elite_frontlookreset == true)
        {
            AISHOOT.Stop();
            // AI_movespeed = AI_customize_movespeed;
            //  _AI_object.transform.position += _AI_object.transform.forward * Time.deltaTime * AI_movespeed;
            Vector3 frontlookreset_position = AI_elite_reset_front.transform.position - _AI_elite_object.transform.position;
            Quaternion frontlookreset_rotation = Quaternion.LookRotation(frontlookreset_position);
            Vector3 otherfrontlookreset_rotation = Quaternion.Lerp(_AI_elite_object.rotation, frontlookreset_rotation, Time.deltaTime * AI_elite_turnspeed).eulerAngles;
            _AI_elite_object.rotation = Quaternion.Euler(0f, otherfrontlookreset_rotation.y, 0f);

        }
        if (AI_elite_backlookreset == true)
        {
            AISHOOT.Stop();
            AI_elite_movespeed = AI_elite_customize_movespeed;
            _AI_elite_object.transform.position += _AI_elite_object.transform.forward * Time.deltaTime * AI_elite_movespeed;
            Vector3 backlookreset_position = AI_elite_reset_look.transform.position - _AI_elite_object.transform.position;
            Quaternion backlookreset_rotation = Quaternion.LookRotation(backlookreset_position);
            Vector3 otherbacklookreset_rotation = Quaternion.Lerp(_AI_elite_object.rotation, backlookreset_rotation, Time.deltaTime * AI_elite_turnspeed).eulerAngles;
            _AI_elite_object.rotation = Quaternion.Euler(0f, otherbacklookreset_rotation.y, 0f);

        }
        if (AI_rendereffect_alpha_boolean == true)
        {
            AISHOOT.Play();
            AI_rendereffect_alphaspeed = 5f;
            AI_renderalpha -= Time.deltaTime * AI_rendereffect_alphaspeed;
            Color startColor = Color.black;
            Color endColor = Color.white;
            startColor.a = AI_renderalpha;
            endColor.a = AI_renderalpha;
            AI_rendereffect.SetColors(startColor, endColor);
            if (AI_renderalpha < 0.0f)
            {
                AI_renderalpha = 1f;
                AI_rendereffect_alpha_boolean = false;
            }


        }
       // if(AI_shoot_boolean01 == true)
       // {
       //     Debug.Log(ENDHITPOINT);
       //     Shoot_tracer_effect_prefab.LookAt(ENDHITPOINT);
       //     Shoot_tracer_effect_prefab.transform.position = Vector3.MoveTowards(Shoot_tracer_effect_prefab.transform.position, ENDHITPOINT, 20f);
       //     //DestroyImmediate(GameObject.Find("Cube"));
       // }

        
    }
    void Client_AI_elite_attackupdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemytag);
        float ai_shortest_distance = Mathf.Infinity;
        GameObject nearest_enenmy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance_enemy = Vector3.Distance(_AI_elite_object.transform.position, enemy.transform.position);
            if (distance_enemy < ai_shortest_distance)
            {
                ai_shortest_distance = distance_enemy;
                nearest_enenmy = enemy;
            }

        }

        if (nearest_enenmy != null && ai_shortest_distance <= AI_elite_attackrange)
        {
            /* not NULL !!! */
            _AI_elite_attack_detection = nearest_enenmy.transform;
            AI_ins_boolean01 = false;
            AI_elite_boolean01 = false;
            AI_elite_boolean02 = false;
            AI_elite_boolean03 = true;
            Debug.Log("attack");
           
        }
        else
        {
            _AI_elite_attack_detection = null;
            AI_ins_boolean01 = true;
            Debug.Log("null");
        }
    }
    void Client_AI_elite_targetupdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemytag);
        float ai_shortest_distance = Mathf.Infinity;
        GameObject nearest_enenmy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance_enemy = Vector3.Distance(_AI_elite_object.transform.position, enemy.transform.position);
            if (distance_enemy < ai_shortest_distance)
            {
                ai_shortest_distance = distance_enemy;
                nearest_enenmy = enemy;
            }

        }

        if (nearest_enenmy != null && ai_shortest_distance <= AI_elite_range)
        {
            /* not NULL !!! */
            _AI_elite_detection = nearest_enenmy.transform;
            if (AI_ins_boolean01 == true)
            {
                AI_elite_boolean01 = true;
            }
            AI_elite_boolean02 = false;
            AI_elite_boolean03 = false;
            AI_elite_boolean04 = false;
            
        }
        else
        {
            AI_elite_boolean01 = false;
            AI_elite_boolean02 = true;


            AI_elite_boolean03 = false;
            _AI_elite_detection = null;
        }

    }
    public IEnumerator AI_bullet_effectinitialize(float wait_cooltime)
    {
        int random_bullet_range = Random.Range(Clinet_bulleteffect_force, Clinet_bulleteffect_force + 8);
        bullet_effect = GameObject.FindGameObjectWithTag("Client_bullet_prefab").GetComponent<Client_bulleteffect>();
        Client_bulleteffect_position = GameObject.FindGameObjectWithTag("Client_AI_bulletposition").GetComponent<Transform>();
        Instantiate(bullet_effect.Client_prefab, Client_bulleteffect_position);
        bullet_effect.Client_rigid.useGravity = false;
        bullet_effect.Client_prefab.transform.position = UnityEngine.Vector3.up * random_bullet_range * Time.deltaTime;
        bullet_effect.Client_rigid.mass = 2;
        Client_bulleteffect_position.transform.DetachChildren();
        bullet_effect.Client_rigid.useGravity = true;
        yield return new WaitForSeconds(wait_cooltime);
        GameObject[] instance = GameObject.FindGameObjectsWithTag("Client_bullet_prefab");
        for (int i = 0; i < instance.Length; i++)
        {
            Destroy(GameObject.Find("Bullet(Clone)").gameObject);
            Debug.Log("deleted");
        }
    }
    public IEnumerator AI_damage_display_deletion(float cooltime)
    {
        GameObject[] instance = GameObject.FindGameObjectsWithTag("AI_damage_display_prefab");
        for (var i = 0; i < instance.Length +1; i++)
        {
            Debug.Log("DamageDisplay Deleted");
            yield return new WaitForSeconds(cooltime);
            Destroy(GameObject.Find("Damage_view(Clone)"));
        }
    }
    public IEnumerator AI_client_waitforshoot(float cooltime)
    {


             float random_shoot = Random.Range(0.1f, 1.5f);
            _Client_default_recoilX_1++;
            _Client_default_recoilX_2++;
            _Client_default_recoilY_1++;
            _Client_default_recoilY_2++;
            AI_ray_view_y.transform.localEulerAngles = UnityEngine.Vector3.zero;
            AI_ray_view_yn.transform.localEulerAngles = UnityEngine.Vector3.zero;
            AI_ray_view_x.transform.localEulerAngles = UnityEngine.Vector3.zero;
            AI_ray_view_xn.transform.localEulerAngles = UnityEngine.Vector3.zero;
 
            AI_ray_view_y.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_primary_recoilSetsXN[_Client_default_recoilX_2] * random_shoot, UnityEngine.Vector3.down);
            AI_ray_view_yn.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_primary_recoilSetsX[_Client_default_recoilX_1] * random_shoot, UnityEngine.Vector3.up);
            AI_ray_view_x.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_primary_recoilSetsYN[_Client_default_recoilY_2] * random_shoot, UnityEngine.Vector3.left);
            AI_ray_view_xn.transform.rotation *= UnityEngine.Quaternion.AngleAxis(Client_primary_recoilSetsY[_Client_default_recoilY_1] * random_shoot, UnityEngine.Vector3.left);
        yield return new WaitForSeconds(cooltime);
      
        if(AI_gunammolimits >= 30)
        {
            AISHOOT.Stop();
            AI_reloadsound.Play();
            int random = Random.Range(1, 4);
            _Client_default_recoilX_1 = 0;
            _Client_default_recoilX_2 = 0;
            _Client_default_recoilY_1 = 0;
            _Client_default_recoilY_2 = 0;
            AI_ray_view_y.transform.localEulerAngles = UnityEngine.Vector3.zero;
            AI_ray_view_yn.transform.localEulerAngles = UnityEngine.Vector3.zero;
            AI_ray_view_x.transform.localEulerAngles = UnityEngine.Vector3.zero;
            AI_ray_view_xn.transform.localEulerAngles = UnityEngine.Vector3.zero;
            yield return new WaitForSeconds(random);
            AI_gunammolimits = 0;
            
        }
        AI_shootdealy_ins_boolean = false;
        AI_client_shoot();
     
    }
  //  void GetEndHitPoint(Vector3 p)
  //  {
   //     ENDHITPOINT = p;
   // }
    void AI_client_shoot()
    {
        AI_shootsound.Play();
        StartCoroutine(AI_bullet_effectinitialize(1f));
        Debug.DrawRay(AI_ray_view.transform.position, transform.forward * AI_gunrange, Color.red);
        RaycastHit hit;
        Ray origin = new Ray(AI_ray_view.transform.position, AI_ray_view.transform.forward);
        if(Physics.Raycast(origin, out hit, AI_gunrange))
        {
            switch (hit.collider.tag)
            {
                case "BRICK":
                    {
                        //    AISHOOT.transform.LookAt(hit.point);

                        AISHOOT_transform.LookAt(hit.point);
                        AI_rendereffect_alpha_boolean = true;
                        AI_rendereffect.SetPosition(0, AI_rendereffect_obj.transform.position);
                        AI_rendereffect.SetPosition(1, hit.point);
                        _BRICKWALL.brick_health_display.value -= 0.01f;
                      // AISHOOT.Stop();
                        break;
                    }
                case "Player_obj":
                    {
                        //  AISHOOT.transform.LookAt(hit.point);
                        AISHOOT_transform.LookAt(hit.point);
                        Instantiate(PLAYER.Player_damage_display_prefab, PLAYER.Player_damage_display_pos);
                        PLAYER.StartCoroutine(PLAYER.Player_display_deletion(4f));
                        PLAYER.Player_damage_display_pos.DetachChildren();
                        AI_rendereffect_alpha_boolean = true;
                        AI_rendereffect.SetPosition(0, AI_rendereffect_obj.transform.position);
                        AI_rendereffect.SetPosition(1, hit.point);
                        PLAYER.StartCoroutine(PLAYER.Client_getdamage(1f, 0.1f, 0.01f, 10));
                        // AISHOOT.Stop();
                        Debug.Log(hit.transform.name);
                        PLAYER.Client_health -= 2;
                        break;
                    }
                default:
                    {
                        Debug.Log(hit.transform.name);
                        //   AISHOOT.transform.LookAt(hit.point);
                        AISHOOT_transform.LookAt(hit.point);
                        //    Instantiate(Shoot_tracer_effect_prefab, Shoot_tracer_pos);
                        //   Shoot_tracer_pos.DetachChildren();

                        //    GetEndHitPoint(hit.point);
                        //  Shoot_tracer_effect_prefab.transform.position = Vector3.zero;
                        //   DestroyImmediate(GameObject.Find("Cube(Clone)"));

                        AI_rendereffect_alpha_boolean = true;
                        AI_rendereffect.SetPosition(0, AI_rendereffect_obj.transform.position);
                        AI_rendereffect.SetPosition(1, hit.point);
                       // AISHOOT.Stop();

                        
                        break;
                    }
                    AI_rendereffect_alpha_boolean = true;
                    AI_rendereffect.SetPosition(0, AI_rendereffect_obj.transform.position);
                    AI_rendereffect.SetPosition(1, hit.point);

            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Client_elite_AI_reset_look")
        {
            AI_elite_boolean04 = true;
            Debug.Log("CheckPointReached");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Client_elite_AI_reset_look")
        {
            AI_elite_boolean04 = false;
        }
    }
    

    private void OnDrawGizmosSelected()
    {
        //player detection field
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, AI_elite_range);
        // player attacking field
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AI_elite_attackrange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AI_elite_dectectrange);
    }
}

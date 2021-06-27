using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AI_modelzom : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera main_camera;
    public Transform _object;
    public Transform _AI_detectection;
    public Transform _AI_attack_detection;
    //use ai this ai_object to rotate function
    public Transform _AI_object;
    public float AI_range;
    public float AI_attackrange;
    public float AI_Detectrange;

    public float AI_turnspeed;
    public float AI_movespeed;
    public float AI_customize_movespeed;
    public string _enemytag;
    public bool AI_speed_limit;


    [Header("AI_Actions")]
    public bool AI_walkforward;
    public bool AI_frontlookreset;
    public bool AI_backlookreset;
    public bool AI_lookatplayer;
    [Header("other booleans")]
    public bool AI_boolean01;
    public bool AI_boolean02;
    public bool AI_boolean03;
    public bool AI_boolean04;

    public bool AI_ins_boolean01;

    public Transform AI_reset_look;
    public Transform AI_reset_front;
    public Slider AI_health_display;
    public Text AI_health_text_display;
    public float AI_health;
    public float AI_totalhealth;
    // this is the one that takes lots of damage.
    public float AI_health_value;
    public AudioSource hitsound;

    public Transform AI_zom_ray_view;
    public float AI_zom_melee_range;
    public USER_inputcontrol PLAYER;
    public bool AI_melee_attack_boolean;
    public bool AI_melee_attack_ins_boolean;

    // AI_zom display functions.
    public Transform AI_damage_display;
    public Transform AI_damage_display_prefab;
    void Start()
    {
        AI_damage_display = GameObject.FindGameObjectWithTag("AI_zom_display_pos").GetComponent<Transform>();
        AI_damage_display_prefab = GameObject.FindGameObjectWithTag("AI_damage_display_prefab").GetComponent<Transform>();
        main_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        AI_zom_ray_view = GameObject.FindGameObjectWithTag("Client_AI_melee").GetComponent<Transform>();
        AI_reset_look = GameObject.FindWithTag("Client_AI_reset_look").GetComponent<Transform>();
        AI_reset_front = GameObject.FindWithTag("Client_AI_reset_front").GetComponent<Transform>();
        AI_health_display = GameObject.FindWithTag("Client_AI_health").GetComponent<Slider>();
        PLAYER = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_inputcontrol>();
        // default setup from AI SYSTEM IO
        AI_backlookreset = true;
        AI_melee_attack_ins_boolean = true;
        // the AI_backlookreset is false in default.
        // AI_backlookreset_other = true;
        InvokeRepeating("Client_AI_targetupdate", 0f, 2f);
        InvokeRepeating("Client_AI_attackupdate", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        _object.LookAt(_object.transform.position + main_camera.transform.rotation * Vector3.forward,
            main_camera.transform.rotation * Vector3.up);
        // basic formula for the health system.
        AI_health_display.value = AI_totalhealth;
        AI_health = 1f;

        // hundereths will be allowed.
        AI_totalhealth = AI_health_value;
        AI_health_text_display.text = AI_health_value.ToString();
        Debug.Log(AI_totalhealth);
        if (AI_health_value < 0f)
        {
            Destroy(GameObject.FindGameObjectWithTag("AI_unitone").gameObject);
        }
        // updating ai vision system from ai_range and attack_range. this is the problem that occurs bugs
      
        if (_AI_detectection != null)
        {
            Debug.Log("detected");
            if (AI_boolean01 == true)
            {
                AI_walkforward = true;
                AI_backlookreset = false;
                AI_frontlookreset = false;
                AI_lookatplayer = false;
            }
        }
        if (_AI_detectection == null)
        {
            Debug.Log("not detected");
            if (AI_boolean02 == true)
            {
                AI_walkforward = false;
                AI_backlookreset = true;
                AI_frontlookreset = false;
                AI_lookatplayer = false;
            }
        }
        // all false
        if(AI_boolean03 == true)
        {
            AI_walkforward = false;
            AI_backlookreset = false;
            AI_frontlookreset = false;
            AI_lookatplayer = true;
        }
        if(AI_melee_attack_boolean == true && AI_melee_attack_ins_boolean == true)
        {
            Debug.Log("works");
            StartCoroutine(AI_zom_delay_attack(3f));
           // AI_melee_attack_ins_boolean = true;
        }
        if(AI_boolean04 == true)
        {
            AI_walkforward = false;
            AI_backlookreset = false;
            AI_frontlookreset = true;
            AI_lookatplayer = false;
        }
        if (AI_lookatplayer == true)
        {
            // this scru
          //  AI_movespeed = AI_customize_movespeed;

          //  _AI_object.transform.position += _AI_object.transform.forward * Time.deltaTime * AI_movespeed;
            // _AI_object.position += transform.forward *Time.de* 2;
            Vector3 dir = _AI_detectection.position - _AI_object.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(_AI_object.rotation, lookRotation, Time.deltaTime * AI_turnspeed).eulerAngles;
            _AI_object.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        }

        if (AI_walkforward == true)
        {
            // this scru
            AI_movespeed = AI_customize_movespeed;

            _AI_object.transform.position += _AI_object.transform.forward * Time.deltaTime * AI_movespeed;
            // _AI_object.position += transform.forward *Time.de* 2;
            Vector3 dir = _AI_detectection.position - _AI_object.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(_AI_object.rotation, lookRotation, Time.deltaTime * AI_turnspeed).eulerAngles;
            _AI_object.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        }
        if (AI_frontlookreset == true)
        {
            // AI_movespeed = AI_customize_movespeed;
            //  _AI_object.transform.position += _AI_object.transform.forward * Time.deltaTime * AI_movespeed;
            Vector3 frontlookreset_position = AI_reset_front.transform.position - _AI_object.transform.position;
            Quaternion frontlookreset_rotation = Quaternion.LookRotation(frontlookreset_position);
            Vector3 otherfrontlookreset_rotation = Quaternion.Lerp(_AI_object.rotation, frontlookreset_rotation, Time.deltaTime * AI_turnspeed).eulerAngles;
            _AI_object.rotation = Quaternion.Euler(0f, otherfrontlookreset_rotation.y, 0f);

        }
        if (AI_backlookreset == true)
        {
            AI_movespeed = AI_customize_movespeed;
            _AI_object.transform.position += _AI_object.transform.forward * Time.deltaTime * AI_movespeed;
            Vector3 backlookreset_position = AI_reset_look.transform.position - _AI_object.transform.position;
            Quaternion backlookreset_rotation = Quaternion.LookRotation(backlookreset_position);
            Vector3 otherbacklookreset_rotation = Quaternion.Lerp(_AI_object.rotation, backlookreset_rotation, Time.deltaTime * AI_turnspeed).eulerAngles;
            _AI_object.rotation = Quaternion.Euler(0f, otherbacklookreset_rotation.y, 0f);

        }
      
    }
    //remember this is same as update() function
    void Client_AI_attackupdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemytag);
        float ai_shortest_distance = Mathf.Infinity;
        GameObject nearest_enenmy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance_enemy = Vector3.Distance(_AI_object.transform.position, enemy.transform.position);
            if (distance_enemy < ai_shortest_distance)
            {
                ai_shortest_distance = distance_enemy;
                nearest_enenmy = enemy;
            }

        }

        if (nearest_enenmy != null && ai_shortest_distance <= AI_attackrange)
        {
            /* not NULL !!! */
            AI_melee_attack_boolean = true;
            _AI_attack_detection = nearest_enenmy.transform;
            AI_ins_boolean01 = false;
            AI_boolean01 = false;
            AI_boolean02 = false;
            AI_boolean03 = true;
            Debug.Log("attack");
        }
        else
        {
            AI_melee_attack_boolean = false;
            _AI_attack_detection = null;
            AI_ins_boolean01 = true;
            Debug.Log("null");
        }
    }
    void Client_AI_targetupdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemytag);
        float ai_shortest_distance = Mathf.Infinity;
        GameObject nearest_enenmy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance_enemy = Vector3.Distance(_AI_object.transform.position, enemy.transform.position);
            if (distance_enemy < ai_shortest_distance)
            {
                ai_shortest_distance = distance_enemy;
                nearest_enenmy = enemy;
            }
           
        }

        if (nearest_enenmy != null && ai_shortest_distance <= AI_range)
        {
            /* not NULL !!! */
            _AI_detectection = nearest_enenmy.transform;
            if (AI_ins_boolean01 == true)
            {
                AI_boolean01 = true;
            }
            AI_boolean02 = false;
            AI_boolean03 = false;
            AI_boolean04 = false;
       
        }
        else
        {
            AI_boolean01 = false;
            AI_boolean02 = true;


            AI_boolean03 = false;
          _AI_detectection = null;
        }
      
    }
    public IEnumerator AI_zom_damage_display_deletion(float cooltime)
    {
        GameObject[] instance = GameObject.FindGameObjectsWithTag("AI_damage_display_prefab");
        for (var i = 0; i < instance.Length + 1; i++)
        {
            Debug.Log("DamageDisplay Deleted");
            yield return new WaitForSeconds(cooltime);
            Destroy(GameObject.Find("Damage_view(Clone)"));
        }
    }
    public IEnumerator AI_zom_delay_attack(float cooltime)
    {
        AI_melee_attack_ins_boolean = false;
        AI_zom_melee_attack();
        yield return new WaitForSeconds(cooltime);
        AI_melee_attack_ins_boolean = true;
    }
    void AI_zom_melee_attack()
    {
        Debug.DrawRay(AI_zom_ray_view.transform.position, transform.forward * AI_zom_melee_range, Color.red);
        RaycastHit hit;
        Ray origin = new Ray(AI_zom_ray_view.transform.position, AI_zom_ray_view.transform.forward);
        if (Physics.Raycast(origin, out hit, AI_zom_melee_range))
        {
            switch(hit.collider.tag)
            {
                case "Player_obj":
                    {
                        PLAYER.StartCoroutine(PLAYER.Client_getdamage(2.5f, 0.1f, 0.01f, 25));
                        PLAYER.Client_health -= 2;
                        break;
                    }
                default:
                    {

                        break;
                    }

            }


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Client_AI_reset_look")
        {
            AI_boolean04 = true;
            Debug.Log("CheckPointReached");
        }
    }
    private void OnTriggerExit(Collider other)
   {
       if(other.gameObject.tag == "Client_AI_reset_look")
       {
            AI_boolean04 = false;
       }
   }
  

    private void OnDrawGizmosSelected()
    {
        //player detection field
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, AI_range);
        // player attacking field
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AI_attackrange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AI_Detectrange);
    }
}

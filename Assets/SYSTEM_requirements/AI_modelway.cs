using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AI_modelway : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] waypoints;
    public int wavepointindex = 0;
    public Transform change_target;

    //AI basic forms
    public Camera main_camara;
    public Transform _way_object;
    public Transform _AI_way_detection;
    public Transform _AI_way_attack_detection;

    public Transform _AI_way_object;
    public float AI_way_range;
    public float AI_way_attackrange;
    public float AI_way_detectrange;

    public float AI_way_turnspeed;
    public float AI_way_movespeed;
    public float AI_way_customize_movespeed;
    public string _enemytag;
    public bool AI_way_speed_limits;

    [Header("AI_way actions")]
    public bool AI_way_walkforward;
    public bool AI_way_frontlookreset;
    public bool AI_way_backlookreset;
    public bool AI_way_lookatplayer;
    [Header("other booleans")]
    public bool AI_way_boolean01;
    public bool AI_way_boolean02;
    public bool AI_way_boolean03;
    public bool AI_way_boolean04;
    public bool AI_way_boolean05;


    public bool AI_way_ins_boolean01;
    public bool AI_way_ins_boolean02;

    public Transform AI_way_reset_look;
    public Transform AI_way_reset_front;
    public Slider AI_way_health_display;
    public Text AI_way_health_text_display;
    public float AI_way_health;
    public float AI_way_totalhealth;
    //this is the one that tkaes lots of damages
    public float AI_way_health_value;
    public AudioSource AI_way_hitsound;

    public Transform AI_way_ray_view;
    public float AI_way_melee_range;
    public USER_inputcontrol PLAYER;
    public bool AI_way_melee_attack_boolean;
    public bool AI_way_melee_attack_ins_boolean;

    public bool AI_way_follow_path;
    public bool AI_way_follow_goback;
    public Transform AI_way_follow_reset;
    public int AI_way_max_path;
    public Transform AI_way_damage_display_pos;
    public Transform AI_way_damage_display_prefab;
    private void Awake()
    {
        waypoints = new Transform[GameObject.FindGameObjectWithTag("waypoint").transform.childCount];
        for(int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = GameObject.FindGameObjectWithTag("waypoint").transform.GetChild(i);
        }
    }
    void Start()
    {
        AI_way_damage_display_pos = GameObject.FindGameObjectWithTag("AI_way_damage_display_pos").GetComponent<Transform>();
        AI_way_damage_display_prefab = GameObject.FindGameObjectWithTag("AI_damage_display_prefab").GetComponent<Transform>();
        AI_way_follow_reset = GameObject.FindGameObjectWithTag("AI_way_follow_reset").GetComponent<Transform>();
        main_camara = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        AI_way_ray_view = GameObject.FindGameObjectWithTag("AI_way_ray_view").GetComponent<Transform>();
        AI_way_health_display = GameObject.FindGameObjectWithTag("ai_healthdisplay").GetComponent<Slider>();
        AI_way_health_text_display = GameObject.FindGameObjectWithTag("ai_healthdisplay_text").GetComponent<Text>();
        //  AI_way_reset_look = GameObject.FindGameObjectWithTag("").GetComponent<Transform>();
        //  AI_way_reset_front = GameObject.FindGameObjectWithTag("").GetComponent<Transform>();

        PLAYER = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_inputcontrol>();
        // default setup AI SYSTEM IO
        AI_way_backlookreset = true;
        AI_way_melee_attack_ins_boolean = true;
        AI_way_boolean05 = true;
        AI_way_follow_path = true;
       // AI_way_follow_goback = true;
        InvokeRepeating("Client_AI_way_targetupdate", 0f, 2f);
        InvokeRepeating("Client_AI_way_attackupdate", 0f, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        _way_object.LookAt(_way_object.transform.position + main_camara.transform.rotation * Vector3.forward,
            main_camara.transform.rotation * Vector3.up);
        AI_way_health_display.value = AI_way_health_value;
        AI_way_health = 1f;


        AI_way_totalhealth = AI_way_health_value;
        AI_way_health_text_display.text = "1";// AI_way_health_value.ToString();
        Debug.Log(AI_way_totalhealth);
        if (AI_way_health_value < 0f)
        {
            DestroyImmediate(GameObject.FindGameObjectWithTag("AI_unitthree").gameObject);
        }
        if (_AI_way_detection != null)
        {
            Debug.Log("detected");
            if (AI_way_boolean01 == true)
            {
                AI_way_walkforward = true;
                AI_way_backlookreset = false;
              //  AI_way_frontlookreset = false;
                AI_way_lookatplayer = false;
            }
        }
        if (_AI_way_detection == null)
        {
            Debug.Log("Not detected");
            if (AI_way_boolean02 == true)
            {
                AI_way_walkforward = false;
                AI_way_backlookreset = true;
             //   AI_way_frontlookreset = false;
                AI_way_lookatplayer = false;

            }
        }
        if (AI_way_boolean03 == true)
        {
            AI_way_walkforward = false;
            AI_way_backlookreset = false;
           // AI_way_frontlookreset = false;
            AI_way_lookatplayer = true;
        }

        if (AI_way_melee_attack_boolean == true && AI_way_melee_attack_ins_boolean == true)
        {
            StartCoroutine(AI_way_delay_attack(2f));
            // needs to work out soon
        }

        if (AI_way_boolean04 == true)
        {
            AI_way_walkforward = false;
            AI_way_backlookreset = false;
           // AI_way_frontlookreset = true;
            AI_way_lookatplayer = false;

        }

        if (AI_way_lookatplayer == true)
        {
            //   AI_way_movespeed = AI_way_customize_movespeed;
            //   _AI_way_object.transform.position += _AI_way_object.transform.forward * Time.deltaTime * AI_way_movespeed;
            Vector3 dir = _AI_way_detection.position - _AI_way_object.transform.position;
            Quaternion lookrotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(_AI_way_object.rotation, lookrotation, Time.deltaTime * AI_way_turnspeed).eulerAngles;
            _AI_way_object.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
        // behaviours

        // these properties are based on AI Client System.
        if (AI_way_walkforward == true)
        {
            // this scru
            AI_way_movespeed = AI_way_customize_movespeed;

            _AI_way_object.transform.position += _AI_way_object.transform.forward * Time.deltaTime * AI_way_movespeed;
            // _AI_object.position += transform.forward *Time.de* 2;
            Vector3 dir = _AI_way_detection.position - _AI_way_object.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(_AI_way_object.rotation, lookRotation, Time.deltaTime * AI_way_turnspeed).eulerAngles;
            _AI_way_object.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        }
        // if (AI_way_frontlookreset == true)
        // {
        //     // AI_movespeed = AI_customize_movespeed;
        //     //  _AI_object.transform.position += _AI_object.transform.forward * Time.deltaTime * AI_movespeed;
        //     Vector3 frontlookreset_position = AI_way_reset_front.transform.position - _AI_way_object.transform.position;
        //     Quaternion frontlookreset_rotation = Quaternion.LookRotation(frontlookreset_position);
        //     Vector3 otherfrontlookreset_rotation = Quaternion.Lerp(_AI_way_object.rotation, frontlookreset_rotation, Time.deltaTime * AI_way_turnspeed).eulerAngles;
        //     _AI_way_object.rotation = Quaternion.Euler(0f, otherfrontlookreset_rotation.y, 0f);
        //
        // }
        if (AI_way_boolean05 == true && AI_way_ins_boolean02 == true)
        {


            if (waypoints.Length >= 0)
            {
                if (AI_way_follow_path == true)
                {
                    wavepointindex++;
                }
               // AI_way_follow_goback = false;
            }
            if (wavepointindex == AI_way_max_path)
            {
                AI_way_follow_path = false;
                AI_way_follow_goback = true;
            }
            if (AI_way_follow_goback == true)
            {
                Debug.Log("workedornot?");
                change_target = waypoints[wavepointindex];
                wavepointindex--;
            }
            AI_way_ins_boolean02 = false;

        }
       
        if (AI_way_backlookreset == true)
        {
            change_target = waypoints[wavepointindex];
            if (Vector3.Distance(_AI_way_object.transform.position, change_target.position) < 1f)
            {
                AI_way_ins_boolean02 = true;
                // AI_getnextwaypoints();
                // AI_way_boolean05 = false;
                Debug.Log("nextwavedetection allowed");
            }
          
           //ebug.Log(Vector3.Distance(_AI_way_object.transform.position, change_target.position));
            AI_way_movespeed = AI_way_customize_movespeed;
            _AI_way_object.transform.position += _AI_way_object.transform.forward * Time.deltaTime * AI_way_movespeed;
            Vector3 towards_position = change_target.transform.position - _AI_way_object.transform.position;
            Quaternion towards_rotation = Quaternion.LookRotation(towards_position);
            Vector3 othertowards_rotation = Quaternion.Lerp(_AI_way_object.rotation, towards_rotation, Time.deltaTime * AI_way_turnspeed).eulerAngles;
            _AI_way_object.rotation = Quaternion.Euler(0f, othertowards_rotation.y, 0f);

        }
    }
    void AI_getnextwaypoints()
    {
        if (AI_way_boolean05 == true)
        {
            // examples
            wavepointindex++;
            change_target = waypoints[wavepointindex];
            AI_way_movespeed = AI_way_customize_movespeed;
            Vector3 change_direction = change_target.position - transform.position;
            Quaternion change_lookrotation = Quaternion.LookRotation(change_direction);
            Vector3 change_rotation = Quaternion.Lerp(_AI_way_object.rotation, change_lookrotation, Time.deltaTime * AI_way_turnspeed).eulerAngles;
            _AI_way_object.rotation = Quaternion.Euler(0f, change_rotation.y, 0f);
        }

    }
    void Client_AI_way_attackupdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemytag);
        float ai_shortest_distance = Mathf.Infinity;
        GameObject nearest_enenmy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance_enemy = Vector3.Distance(_AI_way_object.transform.position, enemy.transform.position);
            if (distance_enemy < ai_shortest_distance)
            {
                ai_shortest_distance = distance_enemy;
                nearest_enenmy = enemy;
            }

        }

        if (nearest_enenmy != null && ai_shortest_distance <= AI_way_attackrange)
        {
            /* not NULL !!! */
            AI_way_melee_attack_boolean = true;
            _AI_way_attack_detection = nearest_enenmy.transform;
            AI_way_ins_boolean01 = false;
            AI_way_boolean01 = false;
            AI_way_boolean02 = false;
            AI_way_boolean03 = true;
            Debug.Log("attack");
        }
        else
        {
            AI_way_melee_attack_boolean = false;
            _AI_way_attack_detection = null;
            AI_way_ins_boolean01 = true;
            Debug.Log("null");
        }
    }
    void Client_AI_way_targetupdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemytag);
        float ai_shortest_distance = Mathf.Infinity;
        GameObject nearest_enenmy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance_enemy = Vector3.Distance(_AI_way_object.transform.position, enemy.transform.position);
            if (distance_enemy < ai_shortest_distance)
            {
                ai_shortest_distance = distance_enemy;
                nearest_enenmy = enemy;
            }

        }

        if (nearest_enenmy != null && ai_shortest_distance <= AI_way_range)
        {
            /* not NULL !!! */
            _AI_way_detection = nearest_enenmy.transform;
            if (AI_way_ins_boolean01 == true)
            {
                AI_way_boolean01 = true;
            }
            AI_way_boolean02 = false;
            AI_way_boolean03 = false;
            AI_way_boolean04 = false;

        }
        else
        {
            AI_way_boolean01 = false;
            AI_way_boolean02 = true;


            AI_way_boolean03 = false;
            _AI_way_detection = null;
        }

    }
    public IEnumerator AI_way_delay_attack(float cooltime)
    {
        AI_way_melee_attack_ins_boolean = false;
        AI_way_melee_attack();
        yield return new WaitForSeconds(cooltime);
        AI_way_melee_attack_ins_boolean = true;
    }

    public IEnumerator AI_way_damage_display_deletion(float cooltime)
    {
        GameObject[] instance = GameObject.FindGameObjectsWithTag("AI_damage_display_prefab");
        for (var i = 0; i < instance.Length + 1; i++)
        {
            Debug.Log("DamageDisplay Deleted");
            yield return new WaitForSeconds(cooltime);
            Destroy(GameObject.Find("Damage_view(Clone)"));
        }
    }
    void AI_way_melee_attack()
    {
        Debug.DrawRay(AI_way_ray_view.transform.position, transform.forward * AI_way_melee_range, Color.red);
        RaycastHit hit;
        Ray origin = new Ray(AI_way_ray_view.transform.position, AI_way_ray_view.transform.forward);
        if (Physics.Raycast(origin, out hit, AI_way_melee_range))
        {
            switch (hit.collider.tag)
            {
                case "Player_obj":
                    {
                        PLAYER.StartCoroutine(PLAYER.Client_getdamage(2.5f, 0.1f, 0.01f, 25));
                      
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
        if(other.gameObject.tag == "AI_way_follow_reset")
        {
            AI_way_follow_path = true;
            AI_way_follow_goback = false;
            wavepointindex++;
        }
       //if (other.gameObject.tag == "Client_AI_reset_look")
       //{
       //    AI_way_boolean04 = true;
       //    Debug.Log("CheckPointReached");
       //}
       //  PLAYER.Client_health -= 2;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Client_AI_reset_look")
        {
            AI_way_boolean04 = false;
        }
    }


    private void OnDrawGizmosSelected()
    {
        //player detection field
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, AI_way_range);
        // player attacking field
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AI_way_attackrange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AI_way_detectrange);
    }
}

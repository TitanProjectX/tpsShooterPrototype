using UnityEngine;

public class TEST_model : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject transform;
    private AudioSource audiosource;

    //experimental
    // public float timer;
    // public float totaltimer;
    // public float timerspeed;
    // public bool timer_boolean01;
    // public float timerlimits;
    void Start()
    {
        transform = GameObject.FindGameObjectWithTag("Test").GetComponent<GameObject>();
        audiosource = GameObject.FindGameObjectWithTag("Test").GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        //experimental
        //   if (timer_boolean01 == true)
        //   {
        //       totaltimer += timer * timerspeed * Time.deltaTime;
        //       
        //       if (totaltimer > timerlimits)
        //       {
        //           timer_boolean01 = false;
        //           timer = 0f;
        //       }
        //   }
    }
    public void Objecthit()
    {
        //transform.SetActive(false);
        audiosource.Play();
    }
}

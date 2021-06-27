using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SYSTEM_startup : MonoBehaviour
{
    // Start is called before the first frame update
    SYSTEM_version _systemver;
    public Button if_competitive;
    public Button if_casual;
    public Button if_betatest;
    public Text gameversion;
    public Image logo_appear;
    public Image logobackground;
    public float logo_alpharate;
    void Start()
    {
        logo_alpharate = 0.01f;
        gameversion = GameObject.FindGameObjectWithTag("Client_gameversion").GetComponent<Text>();
        logo_appear = GameObject.FindGameObjectWithTag("Client_logoloading").GetComponent<Image>();
        logobackground = GameObject.FindGameObjectWithTag("Client_logobackground").GetComponent<Image>();
        logo_appear.color = new Color(255f, 255f, 255f, 0f);
        gameversion.text = "Skyidea FPS Project Client_Version: ";
        gameversion.enabled = true;
        logo_appear.enabled = true;
        logobackground.enabled = true;
        StartCoroutine(logo_appear_active(0.01f));
        logo_appear_active(0.01f);

        Button play = if_competitive.GetComponent<Button>();
        play.onClick.AddListener(competitive_clicked);
        Button shop = if_casual.GetComponent<Button>();
        shop.onClick.AddListener(casual_clicked);
        Button options = if_betatest.GetComponent<Button>();
        options.onClick.AddListener(betatest_clicked);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator logo_appear_active(float time_rate)
    {
        for (int i = 0; i <= 400f; i++)
        {
            if (i == 400f)
            {
                for (int j = 0; j <= 400f; j++)
                {
                    if (j == 400f)
                    {
                        logo_appear.enabled = false;
                        gameversion.enabled = false;
                        logobackground.enabled = false;
                    }
                    Debug.Log(logo_appear.color.a);
                    logo_appear.color = new Color(255f, 255f, 255f, logo_appear.color.a - logo_alpharate);
                    yield return new WaitForSeconds(time_rate);
                }
            }
            Debug.Log(logo_appear.color.a);
            logo_appear.color = new Color(255f, 255f, 255f, logo_appear.color.a + logo_alpharate);
            yield return new WaitForSeconds(time_rate);

        }
    }
    public void competitive_clicked()
    {

    }
    public void casual_clicked()
    {

    }
    public void betatest_clicked()
    {
        SceneManager.LoadScene(1);
    }
}

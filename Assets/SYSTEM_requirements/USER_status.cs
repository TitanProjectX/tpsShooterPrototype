using UnityEngine;
using UnityEngine.UI;

public class USER_status : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Client_userhealth;
    public Text Client_userarmor;
    public Text Client_usercharactername;
    public int userhealth;
    public int userarmor;
    public string[] usercharactername;
    void Start()
    {
        usercharactername[0] = "Jett";
        usercharactername[1] = "Wave";
        usercharactername[2] = "Tommy";
        userhealth = 100;
        userarmor = 100;
        Client_userhealth = GameObject.FindGameObjectWithTag("Client_userhealth").GetComponent<UnityEngine.UI.Text>();
        Client_userarmor = GameObject.FindGameObjectWithTag("Client_userarmor").GetComponent<UnityEngine.UI.Text>();
        Client_usercharactername = GameObject.FindGameObjectWithTag("Client_usercharactername").GetComponent<UnityEngine.UI.Text>();

    }

    // Update is called once per frame
    void Update()
    {
      //  Client_userhealth.text = "_ClientHealth: " + userhealth;
      //  Client_userarmor.text = "_ClientArmor: " + userarmor;
      //  Client_usercharactername.text = "Character: " + usercharactername[2];
    }
}

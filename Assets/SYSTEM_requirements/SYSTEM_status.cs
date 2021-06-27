using System;
using UnityEngine;
using UnityEngine.UI;

public class SYSTEM_status : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Text ClientSystem_status_text01;
    public Text ClientSystem_gametime_text01;
    public float ClientSystem_deltatime;
    public float ClientSystem_gametime;
    public float ClientSystem_gametimedisplay;
    //eaxmple ref
    USER_playercontrol playercontrol;
    USER_inputcontrol inputcontrol;

    public bool ClientSystem_status_boolean01;
    public bool ClientSystem_status_boolean02;
    public InputField ClientSystem_console;
    public GameObject Console;
    public KeyCode consoleKey;





    void Start()
    {

        ClientSystem_console = Console.transform.Find("Console").GetComponent<InputField>();
        ClientSystem_gametime_text01 = GameObject.FindGameObjectWithTag("ClientSystem_gametime").GetComponent<UnityEngine.UI.Text>();
        ClientSystem_status_text01 = GameObject.FindGameObjectWithTag("Client_movementspeed").GetComponent<UnityEngine.UI.Text>();
        ClientSystem_status_text01.enabled = false;
        ClientSystem_status_boolean02 = true;
        ClientSystem_gametime = 1f;
        //playercontrol = GameObject.FindWithTag("Player").GetComponent<USER_playercontrol>();

    }

    // Update is called once per frame
    void Command(string cmd)
    {
        if (cmd == "status")
        {
            ClientSystem_status_boolean01 = true;
        }
        if (cmd == "hidestatus")
        {
            ClientSystem_status_boolean01 = false;
        }
        if (cmd == "cursor")
        {
            Cursor.visible = true;
        }
        if (cmd == "hidecursor")
        {
            Cursor.visible = false;
        }

    }
    void Update()
    {
        //showing current fps of this device.
        // ClientSystem_console = Console.transform.Find("Console").GetComponent<InputField>();
        ClientSystem_deltatime += (Time.deltaTime - ClientSystem_deltatime) * 0.1f;
        float fps = 1.0f / ClientSystem_deltatime;

        if (Input.GetKeyDown(consoleKey))
        {
            ClientSystem_console.Select();
            ClientSystem_console.ActivateInputField();

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Command(ClientSystem_console.text);
            ClientSystem_console.text = "";
            ClientSystem_console.Select();
            ClientSystem_console.ActivateInputField();
        }
        // Game Timeline
        ClientSystem_gametimedisplay += ClientSystem_gametime * Time.deltaTime;
        if (ClientSystem_status_boolean02 == true)
        {
            ClientSystem_gametime_text01.enabled = true;
            ClientSystem_gametime_text01.text = "ClientSystem_gametime:" + Math.Ceiling(ClientSystem_gametimedisplay).ToString() + "\n";

        }
        else
        {
           // ClientSystem_gametime_text01.enabled = false;
        }

        if (ClientSystem_status_boolean01 == true)
        {
            ClientSystem_status_text01 = GameObject.FindWithTag("Client_movementspeed").GetComponent<UnityEngine.UI.Text>();
            playercontrol = GameObject.FindWithTag("Player").GetComponent<USER_playercontrol>();
            inputcontrol = GameObject.FindWithTag("Player").GetComponent<USER_inputcontrol>();
            ClientSystem_status_text01.enabled = true;
            ClientSystem_status_text01.text = "Client_MovementSpeed:" + playercontrol.Client_movementspeed.ToString() + "\n"
                + "Client_jumpspeed:" + playercontrol.Client_jumpspeed.ToString() + "\n"
                + "Client_jumplimits:" + playercontrol.Client_jumplimits.ToString() + "\n"
                + "Client_Acceleration_time:" + playercontrol.Client_Acceleration_time.ToString() + "\n"
                + "Client_Acceleration_addition:" + playercontrol.Client_Acceleration_addition.ToString() + "\n"
                + "ClientSystem_jumptimeline" + playercontrol.ClientSystem_jumptimeline.ToString() + "\n"
                + "ClientSystem_FPS_STATUS:" + Math.Ceiling(fps).ToString() + "\n"
                + "Client_RenderAlpha:" + inputcontrol.Client_RenderAlpha.ToString() + "\n"
                + "Client_RenderAlphaSpeed:" + inputcontrol.Client_RenderAlphaSpeed.ToString() + "\n"
                + "Client_GunRange:" + inputcontrol.Client_GunRange.ToString() + "\n"
                 + "Client_MeleeRange:" + inputcontrol.Client_meleerange.ToString() + "\n"
                + "ClientSystem_QuadCount" + inputcontrol.ClientSystem_QuadCount.ToString() + "\n"
                + "ClientSystem_gametime:" + Math.Ceiling(ClientSystem_gametimedisplay).ToString() + "\n";

        }
        else
        {
            ClientSystem_status_text01 = GameObject.FindWithTag("Client_movementspeed").GetComponent<UnityEngine.UI.Text>();
            ClientSystem_status_text01.enabled = false;
        }
    }
}

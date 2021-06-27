using UnityEngine;

public class USER_guninfo : MonoBehaviour
{
    private USER_inputcontrol Client_inputcontrol;
    public int Client_gundamage;
    public int Client_gunciriticaldamage;
    public int Client_meleedamage;
    public int Client_meleecriticaldamage;
    public float Client_gunfirerate;
    public float Client_changed_recoil_downcount;
    public float Client_changed_recoilup_count;
    public float Client_normal_changed_recoil_downcount;
    public float Client_normal_changed_recoilup_count;
    public int Client_guninfoammo;
    public int Client_guninfoclip;
    // Start is called before the first frame update
    void Start()
    {
        //user settings defaults
        Client_guninfoammo = 0;
        Client_guninfoclip = 0;
        Client_gundamage = 3;
        Client_gunciriticaldamage = 7;
        Client_gunfirerate = 0f;
        Client_changed_recoilup_count = 1;
        Client_changed_recoil_downcount = 10f;
        Client_normal_changed_recoil_downcount = 10f;
        Client_normal_changed_recoilup_count = 1f;
        Client_inputcontrol = GameObject.FindGameObjectWithTag("Player").GetComponent<USER_inputcontrol>();
        Client_inputcontrol._Client_recoilup_count = Client_normal_changed_recoilup_count;
        Client_inputcontrol.Client_recoil_downcount = Client_normal_changed_recoil_downcount;
    }

    // Update is called once per frame

    public void Client_guninfotrasnfer(string gun_info)
    {
        if (gun_info == "Client_gunUSP")
        {
            Debug.Log("Client_guninfotransfered: " + gun_info);
            Client_gundamage = 2;
            Client_gunciriticaldamage = 5;
            Client_gunfirerate = 0.2f;
            // Client_recoil... Client_recoil_downcount, _Client_recoilup_count
            Client_changed_recoilup_count = 1f;
            Client_changed_recoil_downcount = 10f;
            // Client_changed_recoilup_count += Client_inputcontrol._Client_recoilup_count;
            // Client_changed_recoil_downcount += Client_inputcontrol.Client_recoil_downcount;
            Client_normal_changed_recoilup_count = 3f;
            Client_normal_changed_recoil_downcount = 30f;
            // is this going to be semi ? auto ? burst ?
            Client_inputcontrol.Client_gun_semi = true;
            Client_inputcontrol.Client_gun_auto = false;
            Client_inputcontrol.Client_gun_burst = false;
            //how many ammo needs ? gun clips ?
            Client_guninfoclip = 2;
            Client_guninfoammo = 8;
            Client_inputcontrol.Client_gunammoamount = Client_guninfoammo;// + Client_inputcontrol.savedammo[0];
            Client_inputcontrol.Client_reloadcounts = Client_guninfoclip;// + Client_inputcontrol.savedclips[0];
        }
        else if (gun_info == "Client_gunM16")
        {
            Debug.Log("Client_guninfotransfered: " + gun_info);
            Client_gundamage = 6;
            Client_gunciriticaldamage = 14;
            Client_gunfirerate = 0.2f;
            // Client_recoil... Client_recoil_downcount, _Client_recoilup_count
            Client_changed_recoilup_count = 1f;
            Client_changed_recoil_downcount = 10f;
            // Client_changed_recoilup_count += Client_inputcontrol._Client_recoilup_count;
            // Client_changed_recoil_downcount += Client_inputcontrol.Client_recoil_downcount;
            Client_normal_changed_recoilup_count = 4f;
            Client_normal_changed_recoil_downcount = 40f;
            // is this going to be semi ? auto ? burst ?
            Client_inputcontrol.Client_gun_semi = false;
            Client_inputcontrol.Client_gun_auto = false;
            Client_inputcontrol.Client_gun_burst = true;
            //how many ammo needs ? gun clips ?
            Client_guninfoclip = 2;
            Client_guninfoammo = 30;
            Client_inputcontrol.Client_gunammoamount = Client_guninfoammo; //+ Client_inputcontrol.savedammo[1];
            Client_inputcontrol.Client_reloadcounts = Client_guninfoclip;// + Client_inputcontrol.savedclips[1];
        }
        else if (gun_info == "Client_gunAK")
        {
            Debug.Log("Client_guninfotransfered: " + gun_info);
            Client_gundamage = 7;
            Client_gunciriticaldamage = 20;
            Client_gunfirerate = 0.2f;
            // Client_recoil... Client_recoil_downcount, _Client_recoilup_count
            Client_changed_recoilup_count = 0.3f;
            Client_changed_recoil_downcount = 3f;
            // Client_changed_recoilup_count += Client_inputcontrol._Client_recoilup_count;
            // Client_changed_recoil_downcount += Client_inputcontrol.Client_recoil_downcount;
            Client_normal_changed_recoilup_count = 1f;
            Client_normal_changed_recoil_downcount = 10f;
            // is this going to be semi ? auto ? burst ?
            Client_inputcontrol.Client_gun_semi = false;
            Client_inputcontrol.Client_gun_auto = true;
            Client_inputcontrol.Client_gun_burst = false;
            //how many ammo needs ? gun clips ?
            Client_guninfoclip = 10;
            Client_guninfoammo = 30;
            Client_inputcontrol.Client_gunammoamount = Client_guninfoammo; //+ Client_inputcontrol.savedammo[2];
            Client_inputcontrol.Client_reloadcounts = Client_guninfoclip;// + Client_inputcontrol.savedclips[2];

        }
        else
        {
            Debug.Log("Client_gun not found, ClientGUN: " + gun_info);
        }

    }
}

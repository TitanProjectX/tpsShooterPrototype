using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class USER_mousecontrol : MonoBehaviour
{
    // public Transform Original_Y;
    // public Transform Copy_Y;
    public Transform Client_obj;
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    //mouse sensivity settings make a bar to apply it.
    public float sensitivityX = 5.0F;
    public float sensitivityY = 5.0F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;

 
    //experimental

    void Start()
    {
        Client_obj = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Cursor.visible = false;
    }
    void Update()
    {
        //Copy_Y.transform.rotation = Quaternion.Euler(Copy_Y.transform.rotation.x, Original_Y.rotation.eulerAngles.y, Copy_Y.rotation.z);
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = Client_obj.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY; 
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            Client_obj.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            Client_obj.transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            Client_obj.transform.localEulerAngles = new Vector3(-rotationY, Client_obj.transform.localEulerAngles.y, 0);
        }
    }
}

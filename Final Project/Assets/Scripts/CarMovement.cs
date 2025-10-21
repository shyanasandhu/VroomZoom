using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public float delay = 3;
    public Transform camPosition;
    Vector3 moveDir;

    // Update is called once per frame
    void Update()
    {

        float h = 0f;
        float v = 0f;

        //moves right
        if(Input.GetKey(KeyCode.D)){
            //transform.localPosition += new Vector3(2,0,0) * Time.deltaTime;
            h = 1f;
        }
        
        //moves left
        if(Input.GetKey(KeyCode.A)){
            //transform.localPosition += new Vector3(-2,0,0) * Time.deltaTime;
            h = -1f;
        }

        //moves forward
        if(Input.GetKey(KeyCode.W)){
            //transform.localPosition += new Vector3(0,0,2) * Time.deltaTime;
            v = 1f;
        }
        
        //moves backward
        if(Input.GetKey(KeyCode.S)){
            //transform.localPosition += new Vector3(0,0, -2) * Time.deltaTime;
            v = -1f;
        }

        Vector3 mForward = camPosition.forward;
        Vector3 mRight = camPosition.right;

        mForward.y = 0f;
        mRight.y = 0f;

        moveDir = (mForward*v + mRight*h).normalized;

        transform.position += moveDir*7f*Time.deltaTime;
        
    }
}

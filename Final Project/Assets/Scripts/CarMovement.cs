using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CarMovement : MonoBehaviour
{
    //Horizontal position
    private float h;
    private const string HORIZONTAL = "Horizontal";

    //Vertical position
    private float v;
    private const string VERTICAL = "Vertical";

    //Is player currently breaking
    private bool breaking;

    //Calling wheel colliders
    [SerializeField] private WheelCollider frontLWCollider;
    [SerializeField] private WheelCollider frontRWCollider;
    [SerializeField] private WheelCollider backLWCollider;
    [SerializeField] private WheelCollider backRWCollider;

    //Calling wheels
    [SerializeField] private Transform frontLWTransform;
    [SerializeField] private Transform frontRWTransform;
    [SerializeField] private Transform backLWTransform;
    [SerializeField] private Transform backRWTransform;


    //Force
    [SerializeField] private float mForce;
    [SerializeField] private float bForce;
    
    //Float vals
    private float breakingF;
    private float sAngle;
    private float currSAngle;


    [SerializeField] private float maxSAngle;


    public GameObject SF;
    [SerializeField] public int count = 0;
    public float delay = 5;
    public Timer timer;
    private bool lapT = false;
    [SerializeField] public int laps = 0;


    private void FixedUpdate()
    {
        gInput();
        motor();
        steering();
        wheels();
    }

    private void gInput(){
        h = Input.GetAxis(HORIZONTAL);
        v = Input.GetAxis(VERTICAL);

        breaking = Input.GetKey(KeyCode.Space);


    }

    private void motor(){
        //All wheel drive
        frontLWCollider.motorTorque = v * mForce;
        frontRWCollider.motorTorque = v * mForce;
        backLWCollider.motorTorque = v * mForce;
        backRWCollider.motorTorque = v * mForce;

        breakingF = breaking ? bForce : 0f;

        //if(breaking){
            frontLWCollider.brakeTorque = breakingF;
            frontRWCollider.brakeTorque = breakingF;
            backLWCollider.brakeTorque = breakingF;
            backRWCollider.brakeTorque = breakingF;
        //}
    }

    private void steering(){
        currSAngle = maxSAngle * h;
        frontLWCollider.steerAngle = currSAngle;
        frontRWCollider.steerAngle = currSAngle;

    

    }

    private void wheels(){
        updateSWheel(frontLWCollider, frontLWTransform);
        updateSWheel(frontRWCollider, frontRWTransform);
        updateSWheel(backLWCollider, backLWTransform);
        updateSWheel(backRWCollider, backRWTransform);

    }

    private void updateSWheel(WheelCollider wCollider, Transform wTransform){
        Vector3 pos;
        Quaternion rotate;

        wCollider.GetWorldPose(out pos, out rotate);

        wTransform.position = pos;
        wTransform.rotation = rotate;

    }

        void OnTriggerEnter(Collider other){
            if(other.CompareTag("SFLine") && !lapT){
                count++;
                lapT = true;

                /*if(count == 1){
                    timer.sTimer();
                    return;
                }

                if(count > 1 && laps < 3){
                    timer.recordLap();
                    timer.rTime();
                    laps++;
                }

                if(laps == 3){
                    StartCoroutine(RunEnd(delay));
                    timer.endL();
                }*/

                if(laps > 0 && laps < 3){
                        timer.recordLap();
                    }

                if(count % 2 == 0 && count < 4){
                    timer.sTimer();
                }else if(count % 2 == 1){
                    laps++;

                    timer.rTime();
                }else if(count == 4){
                    StartCoroutine(RunEnd(delay));
                    timer.endL();
                }

                //timer.rTime();
        
            }
        }

        void OnTriggerExit(Collider other){
            if(other.CompareTag("SFLine")){
                lapT = false;
            }
        }
        IEnumerator RunEnd(float delay){
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("LapTimes");
        }
}

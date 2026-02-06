using UnityEngine;

public class CarControllinScript : MonoBehaviour
{
    [SerializeField]private WheelCollider FrontLeftWheelCollider;
    [SerializeField]private WheelCollider FrontRightWheelCollider;
    [SerializeField]private WheelCollider RearLeftWheelCollider;
    [SerializeField]private WheelCollider RearRightWheelCollider;
    [SerializeField]private Transform FrontLeftWheelTransform;
    [SerializeField]private Transform FrontRightWheelTransform;
    [SerializeField]private Transform RearLeftWheelTransform;
    [SerializeField]private Transform RearRightWheelTransform;
    [SerializeField]private Transform carCentreofmass;
    [SerializeField]private  Rigidbody rigidbody;
    [SerializeField]private float motorforce =100f;  
    [SerializeField]private float steeringAngle =30f;  
    [SerializeField]private float brakeforce =1000f;  
    private float verticalInput;
    private float horizontalInput;


    void Start()
    {
        rigidbody.centerOfMass=carCentreofmass.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MotorForce();
        UpdateWheels();
        GetInput();
        Steering();
        ApplyBrakes();
        PowerStering();
    }
    void GetInput()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");


    }
    void ApplyBrakes()
    {
        if (Input.GetKey(KeyCode.Space))
        {
          FrontLeftWheelCollider.brakeTorque = brakeforce;
          FrontRightWheelCollider.brakeTorque = brakeforce;
          RearLeftWheelCollider.brakeTorque = brakeforce;
          RearRightWheelCollider.brakeTorque = brakeforce; 
        }
        else
        {
          FrontLeftWheelCollider.brakeTorque = 0f;
          FrontRightWheelCollider.brakeTorque = 0f;
          RearLeftWheelCollider.brakeTorque = 0f;
          RearRightWheelCollider.brakeTorque = 0f;
            
        }
        
    }
    void MotorForce()
    {
        FrontLeftWheelCollider.motorTorque=motorforce * verticalInput;
        FrontRightWheelCollider.motorTorque=motorforce  * verticalInput;
    }
    void Steering()
    {
        FrontLeftWheelCollider.steerAngle = steeringAngle*horizontalInput;
        FrontRightWheelCollider.steerAngle = steeringAngle*horizontalInput;

    }
    void PowerStering()
    {
        if (horizontalInput == 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0f,0f,0f), Time.deltaTime );
        }
       
    }
    void UpdateWheels()
    {
        RotateWheel(FrontLeftWheelCollider,FrontLeftWheelTransform);
        RotateWheel(FrontRightWheelCollider,FrontRightWheelTransform);
        RotateWheel(RearLeftWheelCollider,RearLeftWheelTransform);
        RotateWheel(RearRightWheelCollider,RearRightWheelTransform);
    }
    void RotateWheel(WheelCollider wheelCollider,Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos,out rot);
        transform.position = pos;
        transform.rotation = rot;
    }
}

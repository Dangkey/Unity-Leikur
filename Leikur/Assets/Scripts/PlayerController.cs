using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float sensitivity = 3f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

   void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        
        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        motor.Move(velocity);

        //Get Mouse rotation for the y axis
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0) * sensitivity;

        //Apply Rotation
        motor.Rotate(rotation);


        //Camera Rotation
        //Get Mouse rotation for the y axis
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0, 0) * sensitivity;

        //Apply Camera Rotation
        motor.RotateCamera(cameraRotation);

    }
}

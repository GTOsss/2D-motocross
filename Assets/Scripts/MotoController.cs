using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MotoController : MonoBehaviour {

    float timer;
    Vector3 vectorA;

    public float Acceleration = 400;
    public float rotationValue = 100;
    public Transform obj1;
    public Transform obj2;
    public Rigidbody2D obj1R;

    WheelJoint2D[] Wheels;
    JointMotor2D Wheel1;
    JointMotor2D Wheel2;
    float rotationValueS = 100;

    static MotoController example;
    public static MotoController motoController { get { return example; } }

    static bool DownEscape = false;
    public static bool downEscape { get { return DownEscape; } }

    void Awake()
    {
        example = this;
        DownEscape = false;
    }

    void Start()
    {
        Wheels = gameObject.GetComponents<WheelJoint2D>();
        Wheel1 = Wheels[0].motor;
        Wheel2 = Wheels[1].motor;
    }

    void FixedUpdate()
    {
        if (timer < Time.time)
        {
            timer = Time.time + 0.05f;
            Vector3 vector = transform.position + ((transform.position - vectorA) * 4.4f);
            vectorA = transform.position;
        }
    }

    void Update()
    {
        Wheel1.motorSpeed = 0;
        Wheel2.motorSpeed = 0;
        Wheels[0].motor = Wheel1;
        Wheels[1].motor = Wheel2;
        ClickHandler();
    }


    void ClickHandler()
    {
        MenuClick();

        if(!Finish.IsFinish)
        {
            GasClick();
            RotationClick();
        }
    }

    void MenuClick()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            DownEscape = true;
            SceneManager.LoadScene(0);
        }
    }

    void GasClick()
    {
        if (Input.GetKey(KeyCode.D))
            Gas(KeyCode.D, 0);
        else if (Input.GetKey(KeyCode.A))
            Gas(KeyCode.A, 0);
    }

    void RotationClick()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Rotation(KeyCode.W, 0);
            return;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Rotation(KeyCode.S, 0);
            return;
        }

        rotationValueS = 0;
    }

    void Gas(KeyCode key, byte stat)
    {

        if (key == KeyCode.D && stat == 0)
        {
            Wheel1.motorSpeed = Acceleration * -1;
            Wheel2.motorSpeed = Acceleration * -1;
            Wheels[0].motor = Wheel1;
            Wheels[1].motor = Wheel2;
        }
        else if (key == KeyCode.A && stat == 0)
        {
            Wheel1.motorSpeed = Acceleration / 4;
            Wheel2.motorSpeed = Acceleration / 4;
            Wheels[0].motor = Wheel1;
            Wheels[1].motor = Wheel2;
        }
    }

    void Rotation(KeyCode key, byte stat)
    {

        if (key == KeyCode.W && stat == 0)
        {
            if (rotationValueS < 200)
                rotationValueS += 200 * Time.deltaTime;

            float pX = obj1.transform.position.x,
                    pY = obj1.transform.position.y,
                    pZ = obj1.transform.position.z;

            float cosX = Mathf.Cos((gameObject.transform.eulerAngles.z + 90) * Mathf.PI / 180);
            float sinY = Mathf.Sin((gameObject.transform.eulerAngles.z + 90) * Mathf.PI / 180);

            obj1R.AddForce(new Vector2(cosX * 1000, sinY * 1000), ForceMode2D.Impulse);

        }
        else if (key == KeyCode.S && stat == 0)
        {
            if (rotationValueS > -200)
                rotationValueS -= 200 * Time.deltaTime;

            float pX = obj2.transform.position.x,
                    pY = obj2.transform.position.y,
                    pZ = obj2.transform.position.z;

            float cosX = Mathf.Cos((gameObject.transform.eulerAngles.z + 90) * Mathf.PI / 180) * -1;
            float sinY = Mathf.Sin((gameObject.transform.eulerAngles.z + 90) * Mathf.PI / 180) * -1;

            obj1R.AddForce(new Vector2(cosX * 1000, sinY * 1000), ForceMode2D.Impulse);

        }
    }

    public void Stop()
    {
        Wheel1.motorSpeed = 0;
        Wheel2.motorSpeed = 0;
        Wheels[0].motor = Wheel1;
        Wheels[1].motor = Wheel2;
    }
}

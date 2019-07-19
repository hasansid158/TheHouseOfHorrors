using UnityEngine;
using System.Collections;

public class PlayerControling : MonoBehaviour
{

    CharacterController controller;
    Vector3 Move, camPos;
    float moveX, moveZ, speed = 3.5f;
    public static float mouseY, mouseX;
    public GameObject cam;
    public float MouseSpeed;
    bool camOn, runSound, walkSound;
    public GameObject headbob;
    public static bool animStart;
    public GameObject RunNwalkSound;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        controller = GetComponent<CharacterController>();
        camPos = new Vector3(0f, 0.68f, 0f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.touchCount <= 0)
        {
            mouseY += Input.GetAxis("Mouse Y") * MouseSpeed;
            mouseX = Input.GetAxis("Mouse X") * MouseSpeed;
            mouseY = Mathf.Clamp(mouseY, -90, 90);

            transform.Rotate(0f, mouseX, 0f);
            cam.transform.localRotation = Quaternion.Euler(-mouseY, 0f, 0f);
        }


        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        if (MobileAnalog.analogMov != Vector3.zero)
        {
            Move = MobileAnalog.analogMov;
        }

        else
        {
            Move = new Vector3(moveX, 0f, moveZ);
        }

        Move = transform.rotation * Move;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (walkSound == false)
            {
                RunNwalkSound.GetComponent<AudioSource>().pitch = 1f;
                RunNwalkSound.GetComponent<AudioSource>().volume = 0.2f;
                RunNwalkSound.GetComponent<AudioSource>().Play();
            }
            walkSound = true;
        }

        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            walkSound = false;
            RunNwalkSound.GetComponent<AudioSource>().Stop();
        }

        if (!TouchSprint.Run)
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                if (runSound == false)
                {
                    RunNwalkSound.GetComponent<AudioSource>().pitch = 1.55f;
                    RunNwalkSound.GetComponent<AudioSource>().volume = 0.2f;
                    RunNwalkSound.GetComponent<AudioSource>().Play();
                }
                walkSound = true;
                runSound = true;
                animStart = true;
                headbob.GetComponent<Animation>().Play("HeadBob");
                speed = 6f;
            }

            else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.W))
            {
                walkSound = false;
                runSound = false;
                RunNwalkSound.GetComponent<AudioSource>().Stop();
                headbob.GetComponent<Animation>().Stop("HeadBob");
                gameObject.transform.GetChild(0).transform.localPosition = camPos;
                speed = 3.5f;
                animStart = false;
            }

            controller.SimpleMove(Move * speed);
        }
    }
}

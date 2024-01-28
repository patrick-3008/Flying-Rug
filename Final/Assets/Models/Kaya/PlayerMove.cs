using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


public class PlayerMove : MonoBehaviour
{
    public CharacterController charController;

    private float gravityY = 0.0f;

    private bool isJumping, isGrounded;

    public Camera camera;
    public Animator kayaAnim;

    public Camera MinimapCamera;
    public Object staff;
    public GameObject kayaRightHand;

    public bool isStaffPickedUp;
    public float timeRemaining = 360.0f;

    public Material daySkybox;
    public Material nightSkybox;

    public static bool win;


    void Start()
    {
        RenderSettings.skybox = daySkybox;
        isStaffPickedUp = false;
        isGrounded = true;
        charController = GetComponent<CharacterController>();
        kayaAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (timeRemaining > 0 && !win)
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.4f);
            timeRemaining -= 1.0f * Time.deltaTime;
            kayaAnim.SetBool("isDead", false);
        }
        else
            kayaAnim.SetBool("isDead", true);


        float dX = Input.GetAxis("Horizontal");
        float dY = Input.GetAxis("Vertical");

        Vector3 nonNormalizedMovementVector = new Vector3(dX, 0, dY);

        Vector3 movementVector = nonNormalizedMovementVector;
        movementVector = Quaternion.AngleAxis(camera.transform.eulerAngles.y, Vector3.up) * movementVector;

        movementVector.Normalize();


        gravityY += Physics.gravity.y * Time.deltaTime;

        if (charController.isGrounded)
        {
            gravityY = -0.5f;

            isGrounded = true;
            kayaAnim.SetBool("isGrounded", true);

            isJumping = false;
            kayaAnim.SetBool("isJumping", false);

            kayaAnim.SetBool("isFalling", false);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                gravityY = 7.0f;
                isJumping = true;
                kayaAnim.SetBool("isJumping", true);
            }
        }
        else
        {
            isGrounded = false;
            kayaAnim.SetBool("isGrounded", false);

            if (isJumping && gravityY < 0 || gravityY < -2)
                kayaAnim.SetBool("isFalling", true);
        }



        if (movementVector != Vector3.zero)
        {
            Quaternion rotationDirection = Quaternion.LookRotation(movementVector, Vector3.up);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotationDirection, 360 * Time.deltaTime);


            if (Input.GetKey(KeyCode.LeftShift))
                kayaAnim.SetFloat("IWR", 1.0f, 0.5f, Time.deltaTime);
            else
                kayaAnim.SetFloat("IWR", 0.5f, 0.5f, Time.deltaTime);
        }
        else
        {
            kayaAnim.SetFloat("IWR", 0.0f, 0.5f, Time.deltaTime);
        }

        if (isGrounded == false)
        {
            Vector3 airMove;
            if (isJumping)
                airMove = movementVector * kayaAnim.GetFloat("IWR") * 4.0f;
            else
                airMove = movementVector * kayaAnim.GetFloat("IWR") * 2.0f;
            airMove.y = gravityY;
            charController.Move(airMove * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (MinimapCamera.isActiveAndEnabled)
                MinimapCamera.enabled = false;
            else
                MinimapCamera.enabled = true;
        }

    }

    private void OnAnimatorMove()
    {
        if (isGrounded)
        {
            Vector3 _move = kayaAnim.deltaPosition;
            _move.y = gravityY * Time.deltaTime;
            charController.Move(_move);
        }
    }

    void PickupStaff()
    {
        staff.GetComponent<Rigidbody>().isKinematic = true;
        staff.GetComponent<Rigidbody>().useGravity = false;
        staff.GetComponent<MagicStaffController>().transform.position = kayaRightHand.transform.position;
        staff.GetComponent<MagicStaffController>().transform.rotation = Quaternion.Euler(95, -100, 0);
        staff.GetComponent<MagicStaffController>().transform.SetParent(kayaRightHand.transform);

        RenderSettings.skybox = nightSkybox;
        DynamicGI.UpdateEnvironment();
        Debug.Log("Changed to night");
    }
}

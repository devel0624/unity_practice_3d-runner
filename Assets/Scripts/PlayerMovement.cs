using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigid;

    public Transform camPos;
    public float movePower;
    public float jumpPower;

    public float elapsedTime;

    public float mouseX;
    public float mouseY;

    public float camRotSpeed;

    public Camera cam;

    public bool isRun;
    public Animator animator;

    private void Start()
    {
        cam = Camera.main;
        animator = GetComponent<Animator>();
        elapsedTime = 1;
    }

    private void Update()
    {
        if (GameManager.instance.isOver || GameManager.instance.isPause)
        {
            return;
        }


        elapsedTime += Time.deltaTime;

        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");

        cam.transform.rotation = Quaternion.Euler(mouseY * camRotSpeed, mouseX * camRotSpeed, 0);
        transform.rotation = Quaternion.Euler(0, mouseX * camRotSpeed, 0);

        isRun = false;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movePower);
            isRun = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movePower);
            isRun = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movePower);
            isRun = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * movePower);
            isRun = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && elapsedTime > 1)
        {
            rigid.AddForce(jumpPower * Vector3.up, ForceMode.Impulse);
            animator.SetTrigger("isJump");
            elapsedTime = 0;
        }

        animator.SetBool("isRun", isRun);
    }
    private void LateUpdate()
    {
        if (GameManager.instance.isOver || GameManager.instance.isPause)
        {
            return;
        }

        cam.transform.position = camPos.position;
    }
}
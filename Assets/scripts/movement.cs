using UnityEngine;
using System.Collections;
public class movement : MonoBehaviour
{

    [Header("Movement Params")]
    public float runSpeed = 1.1f;

    public Transform orientation;
    // components attached to player
    float TotalCooldown = 1;
    float ActualCooldown = 1;
    bool OnCooldown = true;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    private Rigidbody rb;
    // other

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        MyInput();

    }

    private void FixedUpdate()
    {
        if (ActualCooldown > 0)
        {
            OnCooldown = true;
            ActualCooldown -= Time.deltaTime;
        }
        else if (ActualCooldown <= 0)
        {
            OnCooldown = false;
        }
        if (OnCooldown == false)
        {
            ActualCooldown = TotalCooldown;
            MovePlayer();
        }
        
    }


    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.gameObject.transform.position = rb.gameObject.transform.position + moveDirection *1.1f;
    }

}

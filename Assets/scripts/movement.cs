using UnityEngine;
using System.Collections;
using System;
public class movement : MonoBehaviour
{

    [Header("Movement Params")]
    public float runSpeed = 1.1f;

    public Transform orientation;
    // components attached to player
    float TotalCooldown = 0.5f;
    float ActualCooldown = 1;
    bool OnCooldown = false;

    float horizontalInput;
    float verticalInput;
    RaycastHit hit;
    Vector3 moveDirection;
    private Rigidbody rb;
    statuses StatusesOnPlayer;

    [SerializeField] GlobalData data;

    [SerializeField] Transform whereToGo;
    // other
    private void Start()
    {
        StatusesOnPlayer = statuses.instance;
    }

    public void makeWorldTurnAround(int time)
    {
        data.changeTime(time);
        StatusesOnPlayer.CheckYourTime(time);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        MovePlayer();

    }

    private void MovePlayer()
    {
        if (verticalInput == 0)
            horizontalInput = Input.GetAxisRaw("Horizontal");
        //Was made to defer player from moving in diagonals
        if ( horizontalInput == 0 )
            verticalInput = Input.GetAxisRaw("Vertical");

        transform.position = Vector3.MoveTowards(transform.position, whereToGo.position, (runSpeed * 2) * Time.deltaTime);

        if (Vector3.Distance(transform.position, whereToGo.position) == 0f)
        {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            if (Physics.Raycast(whereToGo.transform.position, (moveDirection * 1.1f), out hit, 1.1f))
            {

                if (hit.collider.tag == "walkingGround")
                {
                    whereToGo.transform.position = whereToGo.transform.position + moveDirection * 1.1f;
                }
            }
        }
    }

}

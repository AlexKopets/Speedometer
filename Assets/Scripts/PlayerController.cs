using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float horsePower = 0;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float foewardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        foewardInput = Input.GetAxis("Vertical");
        // Move the vehicle forward
        //transform.Translate(Vector3.forward*Time.deltaTime*speed*foewardInput);
        playerRb.AddRelativeForce(Vector3.forward*foewardInput*horsePower);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
    }
    private void Update()
    {
        speed = Mathf.Round(playerRb.velocity.magnitude*3.6f);
        speedometerText.SetText("Speed: " + speed+"kph");
        rpm = Mathf.Round((speed%30)*40);
        rpmText.SetText("RPM: " + rpm);

    }
}

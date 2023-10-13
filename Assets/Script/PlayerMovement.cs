using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float movementSpeed;
    private float dirX, dirY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");

        Vector3 pos = new Vector3(dirX, dirY, 0);


        transform.Translate(pos * movementSpeed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5f, 5f), Mathf.Clamp(transform.position.y, -5f, 5f), 0);
    }
    /*
        private void FixedUpdate()
        {
            Vector3 initpos = transform.position;

            Debug.Log(dirX + " : " + dirY);
            if(( initpos.x + dirX > -3f && initpos.x + dirX < 3f) && (initpos.y + dirY > -3f && initpos.y + dirY < 3f))
                rb.velocity = new Vector3(dirX, dirY, rb.velocity.y);
        }*/
}

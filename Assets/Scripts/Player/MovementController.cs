using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [SerializeField] float movementSpeed = 5f;
    CharacterController controller = null;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontalMovement = movementSpeed * Input.GetAxis("Horizontal");
        float verticalMovement = movementSpeed * Input.GetAxis("Vertical");

        Vector3 motion = new Vector3(horizontalMovement, 0, verticalMovement);

        motion = transform.TransformVector(motion);

        if (motion.x > movementSpeed) motion.x = movementSpeed;
        if (motion.x < -movementSpeed) motion.x = -movementSpeed;

        if (motion.z > movementSpeed) motion.z = movementSpeed;
        if (motion.z < -movementSpeed) motion.z = -movementSpeed;

        controller.Move(motion * Time.deltaTime);

        Debug.Log(controller.velocity);
    }
}

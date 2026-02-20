using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam05 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;


    // Exam 05 ...
    public int maxBulletCount = 10;
    public float bulletRegenerateCooldown = 1f;
    // ...
    public int currentBullet = 0;
    public float nextTimeRegenBullet = 0f;

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
        currentBullet = maxBulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (shootAction.triggered && currentBullet > 0)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            currentBullet -= 1;
            nextTimeRegenBullet = Time.time + bulletRegenerateCooldown;
        }

        if (Time.time >= nextTimeRegenBullet && currentBullet <= 0)
        {
            currentBullet = maxBulletCount;
        }

    }
}

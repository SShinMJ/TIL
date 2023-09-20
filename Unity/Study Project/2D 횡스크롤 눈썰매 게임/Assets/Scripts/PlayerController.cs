using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 0.5f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] float baseSpeed = 0f;
    [SerializeField] float jumpPower = 20f;
    Rigidbody2D rb2D;

    [SerializeField] ParticleSystem snowParticle;
    private ParticleSystem.MainModule particleMainModule;
    [SerializeField] SurfaceEffector2D surfaceEffector;

    bool canMove = true;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        baseSpeed = surfaceEffector.speed;
    }

    void Update()
    {
        if(canMove)
        {
            RotatePlayer();

            BoostPlayer();

            JumpPlayer();
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Force를 주면 넘어지기 쉽다.
            rb2D.AddTorque(torqueAmount * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddTorque(-torqueAmount * Time.deltaTime);
        }
    }

    void BoostPlayer()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            surfaceEffector.speed += boostSpeed;
        }
        else
        {
            surfaceEffector.speed = baseSpeed;
        }
    }

    void JumpPlayer()
    {
        if(GetComponent<CrashDetector>().isGround)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Vector2 jumpDir = Vector2.up * jumpPower;
                rb2D.AddForce(jumpDir);
            }
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
}

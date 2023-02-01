using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;

    private SoundsHandler soundsHandler;

    private readonly float loadMin = -0.1f;
    private float load;

    private float force;

    //for cd on jump
    private float waitTime;
    private float timer;

    private float lastClicked = 0;

    private bool paralyzed;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        soundsHandler = GetComponent<SoundsHandler>();

        load = loadMin;
        force = 0.3f;

        waitTime = 0.5f;
        timer = waitTime;

        paralyzed = false;
    }

    void FixedUpdate()
    {
        TryJump();
        Gravitation();  
    }

    void Gravitation()
    {
        if (load != loadMin)
        {
            load -= 0.01f;
            if (load < loadMin)
                load = loadMin;
        }

        transform.position += new Vector3(0, load / 5);
    }

    void TryJump()
    {
        if (paralyzed)
            return;

        bool NotHolded() => lastClicked == 0;

        if (Input.GetAxis("Jump") == 1f && waitTime <= timer && NotHolded())
        {
            timer = 0;
            Jump();
        }

        lastClicked = Input.GetAxis("Jump");
        timer += Time.deltaTime;
    }

    void Jump()
    {
        load += force;
        playerAnim.SetTrigger("TrFlutter");
        soundsHandler.PlayFlutter();
    }

    public void OnColl()
    {
        paralyzed = true;
        playerAnim.SetTrigger("TrDying");
        soundsHandler.PlayHit();
        GetComponent<ParticleSystem>().Play();
    }
}

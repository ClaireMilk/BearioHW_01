using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseUnit : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator anim;
    private SpriteRenderer sr;
    public float jumpHeight;

    public float m_moveSpeed;
    public float m_rayLength;
    public float m_xOffset;
    public GameObject DeadZone;
    public GameObject loseUI;
    public GameObject winUI;
    public GameObject Crown;

    protected int score;
    protected int score2;

    public Text cherryNumber;
    public Text bananaNumber;

    public AudioSource getFruit;
    public AudioSource death;
    public AudioSource winAudio;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        loseUI.SetActive(false);
        winUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Movement and anction change animation
    protected void Move(float direction)
    {
        rb.velocity = new Vector2(direction * m_moveSpeed, rb.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(direction));

    }

    protected bool isGround(float offsetX)
    {
        Vector2 rayStart = new Vector2(transform.position.x + offsetX, transform.position.y);
        Debug.DrawRay(rayStart, Vector2.down * m_rayLength);
        RaycastHit2D ray = Physics2D.Raycast(rayStart, Vector2.down, m_rayLength);

        if (ray.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void Win()
    {
        Time.timeScale = 0;
        winUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        winAudio.Play();
    }
    public void Die()
    {
        Time.timeScale = 0;
        loseUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        death.Play();
    }
    public void Restart()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GetAudio()
    {
        getFruit.Play();
    }
}

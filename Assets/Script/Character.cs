using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : BaseUnit
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move(0.6f);

        if (isGround(m_xOffset) || isGround(-m_xOffset))
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
            anim.SetBool("Jump", false);
        }
        else
        {
            anim.SetBool("Jump", true);
        }

        cherryNumber.text = (score).ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cherry")
        {
            score++;
            Debug.Log(score);
            Destroy(collision.gameObject);
            GetAudio();
        }
        if (collision.gameObject.tag == "Banana" || collision.gameObject == DeadZone)
        {
            Die();
        }
        if (collision.gameObject == Crown)
        {
            Win();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Die();
        }
    }
}

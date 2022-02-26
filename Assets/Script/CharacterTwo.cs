using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTwo : BaseUnit
{
    public Transform player1;
    private Vector3 exchange;

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
            if (Input.GetKeyDown(KeyCode.Q))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
            anim.SetBool("Jump", false);
        }
        else
        {
            anim.SetBool("Jump", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            exchange = transform.position;
            transform.position = player1.position;
            player1.position = exchange;
        }

        bananaNumber.text = (score2).ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Banana")
        {
            score2++;
            Debug.Log(score2);
            Destroy(collision.gameObject);
            GetAudio();
        }
        if (collision.gameObject.tag == "Cherry" || collision.gameObject == DeadZone)
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

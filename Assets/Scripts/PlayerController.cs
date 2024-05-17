using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isFacedRight = true;
    [SerializeField] private bool onGround = false;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0)
            {
                isFacedRight = true;
                _rb.AddForce(Vector2.right*speed);
                //transform.Translate(Vector2.right*speed*Time.deltaTime);
                _sprite.flipX = !isFacedRight;
            }
                

        if(Input.GetAxis("Horizontal") < 0)
            {
                isFacedRight = false;
                _rb.AddForce(Vector2.left*speed);
                //transform.Translate(Vector2.left*speed*Time.deltaTime);
                _sprite.flipX = !isFacedRight;
            }
        if((Input.GetKeyDown(KeyCode.Space)) && onGround)
            {
                _rb.AddForce(new Vector2(0, jumpForce));
                SetOnGround(false);
            }
        Debug.Log("pos - " + transform.position.x + " time - " + Time.time);
    }
    public void SetOnGround(bool state)
    {
        onGround = state;
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    public float movementSpeed = 0.1f;
    public Animator animator;

    private float horizontalMove;
    private float verticalMove;
    

    private Vector3 _moveDir;

    private Rigidbody2D _rBody;
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _rBody = gameObject.GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //QualitySettings.vSyncCount = 1;
    }

    void Update ()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        if (verticalMove > 0 || horizontalMove > 0 || horizontalMove < 0 || verticalMove < 0)
        {
            animator.SetBool("isAnim", true);
            if (horizontalMove < 0)
                _spriteRenderer.flipX = true;
            else
            {
                _spriteRenderer.flipX = false;
            }

        }
        else 
        {
            animator.SetBool("isAnim", false);
        }

        _moveDir = new Vector3(horizontalMove, verticalMove).normalized;
        animator.SetFloat("speed", horizontalMove + verticalMove);
    }

    void FixedUpdate ()
    {
        //_rBody.MovePosition(transform.position + _moveDir * movementSpeed * Time.deltaTime);
        _rBody.velocity = _moveDir * movementSpeed;
    }
}

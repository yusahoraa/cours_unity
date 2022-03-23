using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D _playerRB;

    [SerializeField]
    private float _movementForce = 100f;

    [SerializeField]
    private float _jumpForce = 100f;

    private bool _grounded;

    // Start is called before the first frame update
    void Start()
    {
        _grounded = true;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalMovement = 0;
        float verticalMovement = 0;

        #region jump

        if (Input.GetKeyDown(KeyCode.UpArrow) && _grounded == true)
        {
            verticalMovement += _jumpForce;
            _grounded = false;
        }

        #endregion

        #region input horizontaux

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalMovement -= _movementForce;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalMovement += _movementForce;
        }

        #endregion

        Vector2 newVelocity = new Vector2(horizontalMovement, _playerRB.velocity.y + verticalMovement);

        _playerRB.velocity = newVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("colision");
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("colision avec le sol");
            _grounded = true;
        }
    }
}


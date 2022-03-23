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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float horizontalMovement = 0;
        float verticalMovement = 0;

        #region jump

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            verticalMovement += _jumpForce;
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
}


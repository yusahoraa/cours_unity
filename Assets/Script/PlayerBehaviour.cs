using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _playerRB;
    [SerializeField]
    private float _movementForce;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private int _totalRemainingJump;
    [SerializeField]
    private int _coinCounter;
    [SerializeField]
    Text _TextScoreUi;

    private enum _playerState { isGrounded, isJumping };
    private _playerState _currentState = _playerState.isGrounded;
    private int _currentRemainingJump;



    // Start is called before the first frame update
    void Start()
    {
        _currentRemainingJump = _totalRemainingJump;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalMovement = 0;
        float verticalMovement = 0;

        if (Input.GetKeyDown(KeyCode.UpArrow) && _currentRemainingJump > 0)
        {
            verticalMovement += _jumpForce;
            _currentRemainingJump--;
            _currentState = _playerState.isJumping;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalMovement += _movementForce;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalMovement -= _movementForce;
        }

        Vector2 newVelocity = new Vector2(horizontalMovement, _playerRB.velocity.y + verticalMovement);

        _playerRB.velocity = newVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _currentRemainingJump = _totalRemainingJump;
            _currentState = _playerState.isGrounded;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _coinCounter++;
        Debug.Log("pièce ramasser : " + _coinCounter);
        _TextScoreUi.text ="pièce ramasser : " + _coinCounter.ToString();
    }
}
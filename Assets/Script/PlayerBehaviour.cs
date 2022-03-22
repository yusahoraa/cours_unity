using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _playerTransform.position += new Vector3(0.1f,0,0);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _playerTransform.position += new Vector3(-0.1f, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            _playerTransform.position += new Vector3(0, 0.1f, 0);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _playerTransform.position += new Vector3(0, -0.1f, 0);
        }

    }
    // test de com pour git
}

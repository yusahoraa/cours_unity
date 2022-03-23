using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private int _coinsCollected;
    public int CoinsCollected { get => _coinsCollected; }

    public Action OnCoinCollected;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddACoin()
    {
        _coinsCollected++;
        Debug.Log($"pièces ramasser : {_coinsCollected}");  
        OnCoinCollected.Invoke();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerUiManager : MonoBehaviour
{
    public static PlayerUiManager Instance;
    [Header("NETWORK JOIN")] 
    [SerializeField] private bool startGameAsClient;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!startGameAsClient) return;
        startGameAsClient = false;
        NetworkManager.Singleton.Shutdown();
        NetworkManager.Singleton.StartClient();
    }
}

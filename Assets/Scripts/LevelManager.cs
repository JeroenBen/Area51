using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private static LevelManager _instance;
    [SerializeField]
    private Player _player;
    public Player Player
    {
        get
        {
            return _player;
        }
    }

    public static LevelManager Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null) {
            _instance = this;
        }
        
    }
}
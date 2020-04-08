using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private static LevelManager _instance;
    [SerializeField]
    private Player _player;

    public List<Enemy> enemies;
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
        print("Added Instance");
            _instance = this;
    }
}
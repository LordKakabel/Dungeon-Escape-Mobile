using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton Pattern

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("GameManager is null!");
            return _instance;
        }
    }

    #endregion

    public bool HasCastleKey { get; set; }
    public Player Player { get; private set; }

    private void Awake()
    {
        _instance = this;

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (!Player)
            Debug.LogError(name + ": Player GameObject not found!");
    }

}

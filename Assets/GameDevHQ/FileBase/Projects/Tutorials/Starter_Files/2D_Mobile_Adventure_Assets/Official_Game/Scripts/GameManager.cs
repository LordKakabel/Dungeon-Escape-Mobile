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

    private void Awake()
    {
        _instance = this;

        /*if (!_playerCurrencyCountText)
            Debug.LogError(name + ": Player Currency Count Text object is not assigned!");

        if (!_selectionImage)
            Debug.LogError(name + ": Selection Image transform not assigned!");*/
    }

}

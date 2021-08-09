using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _shopPlayerCurrencyCountText = null;
    [SerializeField] private Text _HUDPlayerCurrencyCountText = null;
    [SerializeField] RectTransform _selectionImage = null;
    [SerializeField] GameObject[] _healthBars = new GameObject[0];

    private Player _player;

    #region Singleton Pattern

    private static UIManager _instance;
    public static UIManager Instance 
    { 
        get { 
            if (_instance == null)
                Debug.LogError("UIManager is null!");
            return _instance;
        }
    }

    #endregion

    private void Awake()
    {
        _instance = this;

        if (!_shopPlayerCurrencyCountText)
            Debug.LogError(name + ": Player Currency Count Text object is not assigned!");

        if (!_selectionImage)
            Debug.LogError(name + ": Selection Image transform not assigned!");
    }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        if (!_player)
            Debug.LogError(name + ": Player object not found!");
    }

    public void UpdateCurrencyDisplay()
    {
        _shopPlayerCurrencyCountText.text = "Diamonds: " + _player.Diamonds() + " D";
        _HUDPlayerCurrencyCountText.text = _player.Diamonds() + " D";
    }

    public void UpdateSelection(int yPos)
    {
        _selectionImage.anchoredPosition = new Vector2(_selectionImage.anchoredPosition.x, yPos);
    }

    public void UpdateHealth(int healthRemaining)
    {
        for (int i = 0; i < _healthBars.Length; i++)
        {
            if (i < healthRemaining)
            {
                _healthBars[i].SetActive(true);
            }
            else
            {
                _healthBars[i].SetActive(false);
            }
        }
    }
}

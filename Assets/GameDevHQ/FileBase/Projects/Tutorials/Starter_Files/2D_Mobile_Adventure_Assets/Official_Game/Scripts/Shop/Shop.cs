using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject _shopPanel = null;
    [SerializeField] private int[] _itemCosts = new int[0];

    private int _currentlySelectedItem = 0;

    private void Awake()
    {
        if (!_shopPanel)
            Debug.LogError(name + ": Shop Panel object not assigned!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (!player) return;
            _shopPanel.SetActive(true);

            UIManager.Instance.UpdateCurrencyDisplay();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        // 0 = sword, 1 = boots, 2 = Key

        _currentlySelectedItem = item;

        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateSelection(100);
                break;
            case 1:
                UIManager.Instance.UpdateSelection(0);
                break;
            case 2:
                UIManager.Instance.UpdateSelection(-100);
                break;
            default:
                break;
        }
    }

    public void Buy()
    {
        Player player = FindObjectOfType<Player>();
        if (!player) {
            Debug.LogError(name + ": Player object not found!");
            return;
        }

        if (player.Diamonds() >= _itemCosts[_currentlySelectedItem])
        {
            player.AddDiamonds(-_itemCosts[_currentlySelectedItem]);
            
            UIManager.Instance.UpdateCurrencyDisplay();
            
            Debug.Log("You bought " + _currentlySelectedItem + " for " + _itemCosts[_currentlySelectedItem]);

            switch (_currentlySelectedItem)
            {
                case 2:
                    GameManager.Instance.HasCastleKey = true;
                    break;
                default:
                    break;
            }

            _shopPanel.SetActive(false);
        }
        else
        {
            _shopPanel.SetActive(false);
            Debug.Log("Not enough diamonds...shop closed!");
        }
    }
}

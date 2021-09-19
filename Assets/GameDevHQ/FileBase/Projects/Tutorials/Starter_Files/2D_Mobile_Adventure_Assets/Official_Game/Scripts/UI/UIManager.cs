using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _shopPlayerCurrencyCountText = null;
    [SerializeField] private Text _HUDPlayerCurrencyCountText = null;
    [SerializeField] RectTransform _selectionImage = null;
    [SerializeField] GameObject[] _healthBars = new GameObject[0];
    [SerializeField] GameObject _key = null;
    [SerializeField] GameObject _objective = null;
    [SerializeField] float _messageDisplayDuration = 3f;
    [SerializeField] GameObject _winPanel = null;
    [SerializeField] GameObject _pausePanel = null;
    [SerializeField] GameObject _resumeButton = null;


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

        if (!_key)
            Debug.LogError(name + ": Key image GameObject not assigned!");

        if (!_objective)
            Debug.LogError(name + ": Objective text GameObject not assigned!");

        if (!_winPanel)
            Debug.LogError(name + ": Win panel GameObject not assigned!");

        if (!_pausePanel)
            Debug.LogError(name + ": Pause panel GameObject not assigned!");

        if (!_resumeButton)
            Debug.LogError(name + ": Resume button GameObject not assigned!");
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

    public void BoughtKey()
    {
        _key.SetActive(true);
    }

    public bool HasKey()
    {
        return _key.activeSelf;
    }

    public void DisplayObjective()
    {
        _objective.SetActive(true);
        StartCoroutine(FadeMessage(_objective));
    }

    private IEnumerator FadeMessage(GameObject gameObj)
    {
        yield return new WaitForSeconds(_messageDisplayDuration);
        gameObj.SetActive(false);
    }

    public void Win()
    {
        _winPanel.SetActive(true);

        // Pause
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
		Application.Quit();
        #endif
    }

    public void TogglePause()
    {
        if (_winPanel.activeSelf)
        {
            _resumeButton.SetActive(false);
        }
        else
        {
            _pausePanel.SetActive(!_pausePanel.activeSelf);

            if (_pausePanel.activeSelf)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}

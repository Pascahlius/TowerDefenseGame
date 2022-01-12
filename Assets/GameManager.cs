using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public TMP_Text _coinsLabel;
    int coins = 0;
    int health = 3;
    public TMP_Text _healthLabel;
    public GameObject[] _healthDiamonds;
    public Canvas _looseScreen;
    public TMP_Text _waveLabel;
    int wave;
    Color waveColor;
    public AudioSource musicSource;
    public static GameManager singleton;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetWave(0);
        waveColor = _waveLabel.color;
    }

    

    // Update is called once per frame
    void Update()
    {
        ShowCoins();
        ShowHealth();
        ShowLooseScreen();

        

        waveColor = Color.Lerp(Color.white, Color.grey, Mathf.PingPong(Time.time, 1));

        _waveLabel.color = waveColor;
    }
    
    private void SetWave(int value)
    {
        wave = value;
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetCoins(int value)
    {
        coins = value;
    }

    public int GetCoins()
    {
        return coins;
    }

    public void ShowCoins()
    {
        _coinsLabel.text = "Coins: " + coins;
    }

    public void DeIncreaseHealth(int value)
    {
        health += value;
    }

    public void ShowHealth()
    {
        switch (health)
        { case 3:
                _healthLabel.text = "<3 <3 <3";
                break;
            case 2: _healthLabel.text = "<3 <3";
                Destroy(_healthDiamonds[0]);
                break;
            case 1: _healthLabel.text = "<3";
                Destroy(_healthDiamonds[1]);
                break;
            case 0:
                _healthLabel.text = "";
                Destroy(_healthDiamonds[2]);
                break;
        }
            
        
        
    }

    public int GetHealth()
    {
        return health;
    }

    public void ShowWave()
    {
        _waveLabel.text = "Wave: " + wave;
    }

    public void ShowLooseScreen()
    {
        if (health <= 0)
        {
            _looseScreen.gameObject.SetActive(true);
            StartCoroutine(volumeDowner());
            Time.timeScale = 0.2f;
        }else { _looseScreen.gameObject.SetActive(false); }
    }

    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public IEnumerator volumeDowner()
    {
        while(musicSource.volume > 0)
        {
            musicSource.volume -= 0.001f;
            yield return new WaitForSeconds(0.001f);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    public bool IsPaused { get { return isPaused; } }

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] private int playerMoney = 2000;
    [SerializeField] private TextMeshProUGUI playerMoneyText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DrawMoneyUI();
    }
    public void Pause()
    {
        isPaused = true;
    }
    public void Resume()
    {
        isPaused = false;
    }

    private void DrawMoneyUI()
    {
        playerMoneyText.text = playerMoney.ToString();
    }

    public bool Buy(int price)
    {
        if (playerMoney >= price)
        {
            playerMoney -= price;
            DrawMoneyUI();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Sell(int price) 
    {
        playerMoney += price;
        DrawMoneyUI();
        return true;
    }
}

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
    [SerializeField] private TextMeshProUGUI adviceText;
    [SerializeField] private GameObject advice;
    [SerializeField] private float adviceTimer;
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
            StartCoroutine(ShowAdvice("You don't have enough money!"));
            return false;
        }
    }
    public bool Sell(int price,int id) 
    {
        for(int index = 0; index < ClothesManager.Instance.PlayerClothController.ActualClothes.Length; index++)
        {
            if(id == ClothesManager.Instance.PlayerClothController.ActualClothes[index])
            {
                StartCoroutine(ShowAdvice("You are wearing it, you can't sell it!"));
                return false;
            }
        }
        playerMoney += price;
        DrawMoneyUI();
        return true;
    }

    IEnumerator ShowAdvice(string content)
    {
        advice.SetActive(true);
        adviceText.text = content;
        yield return new WaitForSeconds(adviceTimer);
        advice.SetActive(false);
    }
}

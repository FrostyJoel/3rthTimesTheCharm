using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int totalMoney;
    public int totalTimeLeft;
    public int waveCounter;
    static public int gameSpeed = 1;
    bool ableToSell;
    int tempSpeed = 1;

    public GameObject menuScreen;
    public GameObject menu;
    public GameObject optionScreen;
    public GameObject selectedTower;
    int selectedSellPrice;
    public Text money;
    public Text timeLeft;
    public Text gameOver;
    public Text waveAmount;
    public Text enemyAmount;
    public Text baseAmount;
    public Text fastForward;
    public Text sellTower;

    private void Update()
    {
        if(gameSpeed >= 1)
        {
            fastForward.text = "Speed:\n" + gameSpeed.ToString();
        }
        else
        {
            fastForward.text = "Speed:\n" + tempSpeed.ToString();
        }
        if(selectedTower == null)
        {
            sellTower.text = "Sell:";
        }
        enemyAmount.text = "Enemies Left:\n" + GameObject.FindGameObjectsWithTag("Enemy").Length.ToString();
        money.text = "Drachma: " + totalMoney.ToString();
        timeLeft.text = "Time Until Next Wave: " + totalTimeLeft.ToString();
    }

    public void Pause(Text pauseButtonText)
    {
        if(gameSpeed > 0)
        {
            pauseButtonText.text = "Res";
            tempSpeed = gameSpeed;
            gameSpeed = 0;
        }
        else
        {
            pauseButtonText.text = "Pause";
            gameSpeed = tempSpeed;
        }
    }

    public void FastForward()
    {
        if (gameSpeed > 0 && gameSpeed < 3)
        {
            gameSpeed++;
        }
        else if(gameSpeed != 0)
        {
            gameSpeed = 1;
        }
    }
    public void Menu()
    {
        Time.timeScale = 0;
        menuScreen.SetActive(true);
    }
    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        gameOver.text = "Game over";
    }

    public void UpdateTower(int sellprice)
    {
        if(sellprice > 0)
        {
            selectedSellPrice = sellprice;
            sellTower.text = "Sell:\n" + "Drachma: " + sellprice.ToString();
            ableToSell = true;
        }
        else
        {
            sellTower.text = "Sell:";
            ableToSell = false;
        }
    }

    public void Sell()
    {
        if (ableToSell)
        {
            RangeManager rangeMan = GameObject.FindGameObjectWithTag("RangeManager").GetComponent<RangeManager>();
            rangeMan.ResetRanges();
            Destroy(selectedTower);
            totalMoney += selectedSellPrice;
            selectedSellPrice = 0;
        }
    }

    public void UpdateWave(int wave)
    {
        waveAmount.text = "Wave: " + wave.ToString();
    }

    public void UpdateBase(float health)
    {
        if (health <= 0)
        {
            baseAmount.text = "Base Health:\n" + "You Died";
        }
        else
        {
            baseAmount.text = "Base Health:\n" + Mathf.RoundToInt(health).ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveManager : MonoBehaviour
{
    public static MoveManager instance;

    public Text moveCounterText;

    public Image bloodMeterImage;
    public Sprite[] bloodMeter;
    // array contains all sprites of blood meter

    public int currentMoves;
    public int maxMoves;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "WinScene")
        {
            maxMoves = 0;
        }
        currentMoves = 0;

        UpdateUI();
    }

    public void AddMove()
    {
        if (currentMoves < maxMoves)
        {
            currentMoves++;
            UpdateUI();
        }
    }

    public void DecreaseMoves(int _movesDecreased)
    {
        currentMoves -= _movesDecreased;
        if (currentMoves < 0)
        {
            currentMoves = 0;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        moveCounterText.text = "Move " + currentMoves.ToString() + "/" + maxMoves.ToString();

        // Calculates which blood meter image to use based on current move percentage out of max moves
        if (maxMoves > 0)
        {
            int bloodMeterIndex = (9 * currentMoves) / maxMoves;
            bloodMeterImage.sprite = bloodMeter[bloodMeterIndex];
        }
    }
}

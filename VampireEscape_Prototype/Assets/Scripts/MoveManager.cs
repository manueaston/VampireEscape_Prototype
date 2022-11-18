using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MoveManager : MonoBehaviour
{
    public static MoveManager instance;
    public UnityEvent TimerDelay;
    public Text moveCounterText;

    // Reset text stuff
    public Text resetText;
    private ResetTextScript resetTextScript;

    public Image bloodMeterImage;
    public Sprite[] bloodMeter;
    // array contains all sprites of blood meter

    // Screen Fade
    public Image blackSquare;
    private Color squareColour;

    public int currentMoves;
    public int maxMoves;

    //Audio Controller for glass break
    public AudioSource audioGlassSource;
    public AudioClip audioGlassClip;
    [Range(0, 1)] public float volumeGlass;


    //Audio Controller for heavy breathing
    public AudioSource audioBreathSource;
    public AudioClip audioBreathClip;
    [Range(0, 2)] public float volumeBreath;
    private void Awake()
    {
        instance = this;
        resetTextScript = resetText.GetComponent<ResetTextScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Setup Ausio component
        audioGlassSource = GetComponent<AudioSource>();
        audioBreathSource = GetComponent<AudioSource>();

        // set fade in square to alpha = 1
        squareColour = blackSquare.GetComponent<Image>().color;
        squareColour = new Color(squareColour.r, squareColour.g, squareColour.b, 1.0f);
        blackSquare.GetComponent<Image>().color = squareColour;
        // fade in
        StartCoroutine(ScreenFadeIn());

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
            TimerDelay.Invoke();
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
        moveCounterText.text = (maxMoves - currentMoves).ToString();

        // Calculates which blood meter image to use based on current move percentage out of max moves
        if (maxMoves > 0)
        {
            int bloodMeterIndex = (9 * currentMoves) / maxMoves;
            bloodMeterImage.sprite = bloodMeter[bloodMeterIndex];

            //these will play breathing and glass break sounds according to the animation change in the ui.
            if(bloodMeterImage.sprite == bloodMeter[7])
            {
                audioBreathSource.PlayOneShot(audioBreathClip, volumeBreath);
            }

            if (bloodMeterImage.sprite == bloodMeter[9])
            {
                audioGlassSource.PlayOneShot(audioGlassClip, volumeGlass);
            }
        }
    }

    public IEnumerator ScreenFadeOut(float _FadeSpeed = 0.25f)
    {
        Color squareColour = blackSquare.GetComponent<Image>().color;
        float fadeAmount;

        // Jitter reset text
        resetTextScript.StartJitter();

        while (blackSquare.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = squareColour.a + (_FadeSpeed * Time.deltaTime);
            squareColour = new Color(squareColour.r, squareColour.g, squareColour.b, fadeAmount);
            blackSquare.GetComponent<Image>().color = squareColour;
            yield return null;
        }
    }

    public IEnumerator ScreenFadeIn(float _FadeSpeed = 1.0f)
    {
        squareColour = blackSquare.GetComponent<Image>().color;
        float fadeAmount;

        while (blackSquare.GetComponent<Image>().color.a > 0)
        {
            fadeAmount = squareColour.a - (_FadeSpeed * Time.deltaTime);
            squareColour = new Color(squareColour.r, squareColour.g, squareColour.b, fadeAmount);
            blackSquare.GetComponent<Image>().color = squareColour;
            yield return null;
        }
    }
}

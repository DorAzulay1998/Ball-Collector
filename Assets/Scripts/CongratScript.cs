using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CongratScript : MonoBehaviour
{
    public TextMeshProUGUI textText;
    public ParticleSystem SparksParticles;

    [SerializeField] List<string> TextToDisplay;

    private float RotatingSpeed;
    private float timeToNextText;

    private int currentText;

    // Start is called before the first frame update
    void Start()
    {
        timeToNextText = 0.0f;
        currentText = 0;

        RotatingSpeed = 1.0f;

        TextToDisplay = new List<string>(); // Initialize the list
        TextToDisplay.Add("Congratulation");
        TextToDisplay.Add("All Errors Fixed");
    }

    // Update is called once per frame
    void Update()
    {
        SparksParticles.Play();
        timeToNextText += Time.deltaTime;

        if (currentText < TextToDisplay.Count && timeToNextText > 1f)
        {
            textText.text = TextToDisplay[currentText];
            currentText++;
            timeToNextText = 0f; // Reset the timer
        }
       
    }
}
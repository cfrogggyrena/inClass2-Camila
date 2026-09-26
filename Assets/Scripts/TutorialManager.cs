using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel; //define panel obj
    public TMP_Text tutorialText; //define text 

    private int currentStep = 0; //define steps (will be 3 max)

    //define for sound 
    //public AudioClip clickSound;

    private string[] instructions =
    {
        "Welcome! You can use WASD to move",
        "You can also use space to jump (im lying)",
        "Collect the coins to wins (there is no coins, youre trapped!)"
    };

    void Start()
    {
        //only doing this to restart playerpref after testing. 
        //PlayerPrefs.DeleteKey("TutorialDone");


        if (PlayerPrefs.GetInt("TutorialDone", 0) == 1) 
        {
            tutorialPanel.SetActive(false); //if tutorial is done the panel dissappears 
        }
        else
        {
            tutorialText.text = instructions[0]; 
        }
    }

    //function for the next instruction text
    public void NextInstruction()
    {
        //for audio
        //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().PlayOneShot(clickSound);


        currentStep++; //step text increases (goes to the next) 

        if (currentStep < instructions.Length)
        {
            tutorialText.text = instructions[currentStep]; //as long as the instruction text lenght is still not done, will display current step 
        }

        else 
        {
            //else it will take the tutorial as done and pass and panel disappears
            tutorialPanel.SetActive(false);

            PlayerPrefs.SetInt("TutorialDone", 1);
            PlayerPrefs.Save();
        }
    }
}
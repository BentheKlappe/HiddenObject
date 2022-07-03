using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //referencing text fields for points
    public Text currentPointsText;
    public Text highscoreText;

    int points = 0;
    int highScore = 0;

    //variables for adding time bonus
    public float timeBonus = 90;

    //keeping track of total amount of items left in game
    public int totalAmountOfItems = 6;

    //get the overlay screen and set highscores there too
    public GameObject overlayScreen;

    public Text overlayHighScoreText;
    public Text overlayPointsText;
    public Text newHighscore;

    void Start()
    {
        //setting the highscore
        highScore = PlayerPrefs.GetInt("highScore", 0);

        //setting the text boxes
        currentPointsText.text = points.ToString() + " points";
        highscoreText.text = "Highscore: " + highScore.ToString();

        overlayHighScoreText.text = "Highscore: " + highScore.ToString();

        newHighscore.text = " ";
    }

    private void Update()
    {
        if(totalAmountOfItems > 0)
        {
            //higher bonus if you click faster
            timeBonus -= Time.deltaTime;
        }
    }

    public void addPoints()
    {
        //take a point off of total points
        totalAmountOfItems -= 1;

        //add the points to the total score based on how fast it was clicked
        points += (70 + (Mathf.RoundToInt(timeBonus)));
        currentPointsText.text = points + " points";

        //check to see how many items are left in the screen
        if (totalAmountOfItems == 0)
        {
            timeBonus = 0;

            //if the highscore is lower than amount of points earned, update the highscore
            if (highScore < points)
            {
                PlayerPrefs.SetInt("highScore", points);
            }
            overlayScreenUI();
        }

    }
    private void overlayScreenUI()
    {
        //give a feedback screen
        overlayScreen.SetActive(true);

        //show the earned points that round
        overlayPointsText.text = "Scored points: " + points.ToString();
        
        //if the highscore is lower than amount of points earned, update the highscore
        if (highScore < points)
        {
            overlayHighScoreText.text = "Highscore: " + highScore.ToString();
            
            PlayerPrefs.SetInt("overlayHighScore", points);
            newHighscore.text = "You got a new highscore!";
        }
    }

}

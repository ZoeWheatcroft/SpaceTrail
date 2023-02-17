using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;
using UnityEngine.UI;

public class ShipControls : MonoBehaviour
{

    public Text paceText;
    public Text rationsText;
    public Text lifesupText;
    public Text milesTraveledText;
    public Text dateText;
    public Text weightText;
    public Text foodText;
    public Text healthText;
    public Text fuelText;

    public GameObject extendedOptions;
    public GameObject map;

    public float pace;
    public float rations;
    public float lifesup;
    
    private float fuel;
    public float food;
    private float distanceToDest;
    private float date;
    private float weight;
    private float milesTraveled;
    private bool resting;

    private bool player1_alive = true;
    private int player1_health;

    private bool player2_alive = true;
    private int player2_health;

    private bool player3_alive = true;
    private int player3_health;

    private bool player4_alive = true;
    private int player4_health;

    private bool player5_alive = true;
    private int player5_health;



    //NEXT LANDMARK ALSO NEEDS TO BE ADDED


    // Start is called before the first frame update
    void Start()
    {
        pace = 3;
        paceText.text = paceCheck();

        rations = 3;
        rationsText.text = rationsCheck();

        lifesup = 3;
        lifesupText.text = lifesupCheck();

        food = 100;

        milesTraveledText.text = "MILES\n" + "TRAVELED:\n" + milesTraveled.ToString() + "K";
        foodText.text = "FOOD: " + food.ToString() + " POUNDS";
    }


    public void increasePace()
    {
        if (pace < 4)
        {
            pace += 1;
        }
        paceText.text = paceCheck();
    }
    public void decreasePace()
    {
        if (pace > 1)
        {
            pace -= 1;
        }
        paceText.text = paceCheck();
    }
    public string paceCheck()
    {
        if (pace == 1)
        {
            return "PACE: \nGRUELING";
        }
        else if (pace == 2)
        {
            return "PACE: \nSTRENUOUS";
        }
        else if (pace == 3)
        {
            return "PACE: \nSTEADY";
        }
        else
        {
            return "PACE: \nWARP DRIVE";
        }

    }


    public void increaseRations()
    {
        if (rations < 4)
        {
            rations += 1;
        }
        rationsText.text = rationsCheck();
    }
    public void decreaseRations()
    {
        if (rations > 1)
        {
            rations -= 1;
        }
        rationsText.text = rationsCheck();
    }
    public string rationsCheck()
    {
        if (rations == 1)
        {
            return "RATIONS: \nBARE BONES";
        }
        else if (rations == 2)
        {
            return "RATIONS: \nMEAGER";
        }
        else if (rations == 3)
        {
            return "RATIONS: \nFILLING";
        }
        else
        {
            return "RATIONS: \nXXX THICC";
        }

    }


    public void increaseLifeSup()
    {
        if (lifesup < 4)
        {
            lifesup += 1;
        }
        lifesupText.text = lifesupCheck();
    }
    public void decreaseLifeSup()
    {
        if (lifesup > 1)
        {
            lifesup -= 1;
        }
        lifesupText.text = lifesupCheck();
    }
    public string lifesupCheck()
    {
        if (lifesup == 1)
        {
            return "LIFE SUPPORT: \nCRUMBLING";
        }
        else if (lifesup == 2)
        {
            return "LIFE SUPPORT: \nSCRAPPING BY";
        }
        else if (lifesup == 3)
        {
            return "LIFE SUPPORT: \nSURVIVNG";
        }
        else
        {
            return "LIFE SUPPORT: \nTHRIVING";

        }

    }

    public void rest()
    {
        date += 1;
        resting = true;
        updateDatapad();
        resting = false;
    }

    private void heal(int player)
    {
        if (player > 0)
        {
            if (resting == true)
            {
                switch (rations)
                {
                    case 1:
                        player += Random.Range(1, 2);
                        break;
                    case 2:
                        player += Random.Range(1, 5);
                        break;
                    case 3:
                        player += Random.Range(5, 10);
                        break;
                    case 4:
                        player += Random.Range(10, 15);
                        break;
                }
            }
            else
            {
                switch (rations)
                {
                    case 1:
                        player += Random.Range(1, 2);
                        break;
                    case 2:
                        player += Random.Range(1, 5);
                        break;
                    case 3:
                        player += Random.Range(1, 7);
                        break;
                    case 4:
                        player += Random.Range(5, 10);
                        break;
                }
            }

        }
        if (player > 100)
        {
            player = 100;
        }
    }

    private void eat(bool player)
    {
        if (player)
        {
            if (rations == 1)
            {
                food = food - 1;
            }
            else
            {
                food = food - (Mathf.RoundToInt(Mathf.Pow(rations, 2)) / 2);
            }
        }
    }

    private void updateDatapad()
    {
        #region Healing
        heal(player1_health);
        heal(player2_health);
        heal(player3_health);
        heal(player4_health);
        heal(player5_health);
        #endregion

        #region Eat
        eat(player1_alive);
        eat(player2_alive);
        eat(player3_alive);
        eat(player4_alive);
        eat(player5_alive);
    #endregion

        milesTraveledText.text = "MILES\n" + "TRAVELED:\n" + milesTraveled.ToString() + "K";
        foodText.text = "FOOD: " + food.ToString() + " POUNDS";

    }

    private void milestoneCheck()
    {
        //switch case w/mileage to see if there are milestones like asteroid belts, trading post, etc
    }

    private void eventCheck()
    {
        //generate random number to see if an event will occur
    }

    private void 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Space bar hit");
            date += 1;
            milesTraveled = milesTraveled + 10 * pace;
            //implement a check to see if any encounters are happening, ie asteroid belt, landmark or event
            
            //update data map
            updateDatapad();
        }

        if (Input.GetKeyDown("return"))
        {
            Debug.Log("Enter hit");
            if (extendedOptions.activeSelf)
            {
                extendedOptions.SetActive(false);
            }
            else
            {
                extendedOptions.SetActive(true);
            }
            
        }
        if (Input.GetKeyDown("escape"))
        {
            extendedOptions.SetActive(false);
            map.SetActive(false);
        }
    }
}
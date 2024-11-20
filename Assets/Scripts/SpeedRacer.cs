using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRacer : MonoBehaviour
{
    public string carModel = "GTR R35";
    public string engineType = "V6, Twin Turbo";
    public int carWeight = 1609;
    public int yearMade = 2009;
    public float maxAcceleration = 0.98f; 
    public bool isCarTypeSedan = false;
    public bool hasFrontEngine = true;
    public string carMaker;

    public class Fuel
    {
        public int fuelLevel;

        public Fuel(int amount)
        {
            fuelLevel = amount;
        }
        
    }
    public Fuel carFuel = new Fuel(100);

    void Start()
    {
        Debug.Log("The racer model is " + carModel +", the car maker is "+ carMaker+", it has " + engineType +"engine.");

        CheckWeight();
        if (yearMade <= 2009)
        {
            Debug.Log("The car was introduced in " + yearMade);
            int carAge = CalculateAge(yearMade);
            Debug.Log("The car is " + carAge + " years old.");
        }
        else
        {
            Debug.Log("The car was introduced in the 2010's.");
            Debug.Log("The car's maximum acceleration is " + maxAcceleration+" m/s2");
        }

        Debug.Log(CheckCharacteristics());
    }
    void CheckWeight()
    {
        if (carWeight < 1500)
        {
            Debug.Log(carModel + " weighs less than 1500 kg.");
        }
        else
        {
            Debug.Log(carModel + " weighs over 1500 kg.");
        }

    }
    int CalculateAge(int year)
    {
        return 2023 - year;
    }
    string CheckCharacteristics()
    {
        if (isCarTypeSedan)
        {
            return "The car is a sedan.";
        }
        else if (hasFrontEngine)
        {
            return "The car isn't a sedan, but it has a front engine.";
        }
        else
        {
            return "The car is neither a sedan nor does it have a front engine.";
        }
    }
    void ConsumeFuel()
    {
        carFuel.fuelLevel -= 10;
    }
    void CheckFuelLevel()
    {
        switch (carFuel.fuelLevel)
        {
            case 70:
                Debug.Log("Fuel level is nearing two-thirds.");
                break;
            case 50:
                Debug.Log("Fuel level is at half amount.");
                break;
            case 10:
                Debug.Log("Warning! Fuel level is critically low.");
                break;
            default:
                Debug.Log("Nothing to report about the fuel level.");
                break;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ConsumeFuel();
            CheckFuelLevel();
        }
    }
}

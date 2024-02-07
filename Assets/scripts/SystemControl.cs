

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class SystemControl : MonoBehaviour
{
    //var ig
    public bool running;

    //gui not gooey
    public TextMeshProUGUI humansText;
    public TextMeshProUGUI CO2Text;
    public TextMeshProUGUI O2Text;
    public TextMeshProUGUI plantsText;

    public Slider thermometer;

    //Temperary
    public TextMeshProUGUI powerPercent;

    //normal varibles hahhahahahah
    public float humans = 100;
    public float plants = 30000;
    public float co2 = 1;
    public float o2 = 21;
    public float temperate = 70;
    public float desiredTemp = 70;
    public float power = 0;

    // Looks Vars
    public int humansShow;
    public int plantsShow;

    // temp vars
    public float temp;

    // Start is called before the first frame update
    void Start()
    {
        running = false;
        humans = 100;
        plants = 30000;
        co2 = 1;
        o2 = 21;
        temperate = 70;
        desiredTemp = 70;
        power = 0;
        Status();
    }

    public void ComputerSystem() 
    {
        UpdateStatus();
        Status();
    }


    public void Status()
    {
        humansShow = (int)humans;
        plantsShow = (int)plants;
        humansText.text = "Humans Exsisting: " + humansShow.ToString();
        plantsText.text = "Alive Plants: " + plantsShow.ToString();
        O2Text.text = "CO2 Level: " + co2.ToString("F3") + "%";
        CO2Text.text = "O2 Level: " + o2.ToString("F3") + "%";
        thermometer.value = (float)temperate;
        powerPercent.text = "Power Level: " + power.ToString("F2") + "%";



    }

    // Update is called once per frame


    /*
     * _____________________________________________________
     * Adding Power and Adding Temp Regulations
     * Power Is from generator needs humans to operate
     * generator upgrades at human numbers
     * Temp Relies on power needs to be set down and up by player
     * 35f-100f for plants to survive
     * 30-110 for humans to survive
     * 95-109 heat stroke 110-140 intense heat stroke passing out
     * 
     * Add happiness, and mourning for the thousands that will inevitbly die
     * 
     * Add clock
     * 
     * _____________________________________________________
     */


    public void UpdateStatus()
    {
        //Algarithms
        o2 = (plants / humans) / 14.25f;
        co2 = (humans * 300) / plants;

        if (co2 < 1)
        {
            plants -= (1 - co2) * 1000;
        }

        if (plants / humans < 300)
        {
            plants += ((plants/1000) + (co2/100) * humans) - (((o2/100) * 0.2f) * humans);
        }

        if (o2 < 18)
        {
            temp = Random.Range(humans * 0.05f, humans * 0.15f);
            humans -= temp;
        }

        if (o2 > 25)
        {
            temp = Random.Range(humans * 0.01f, humans * 0.05f);
            humans -= temp;
        }




    }

    public void StartButton()
    {
        if (!running)
        {
            running=true;
            InvokeRepeating("ComputerSystem", 1.0f, 1.0f);
        }

    }

    public void ResetButton()
    {
        SceneManager.LoadScene("SpacePandas");

    }


    public void PlusHumans10Button()
    {
        humans += 10;

    }


    public void PlusHumans50Button()
    {
        humans += 50;

    }
}



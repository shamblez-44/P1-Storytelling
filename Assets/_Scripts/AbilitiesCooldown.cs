using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesCooldown : MonoBehaviour
{
    public Image abilityImage1;
    public Image abilityImage2;
    public float cooldown1 = 0;
    public float cooldown2 = 0;
    bool isCooldown1 = false;
    bool isCooldown2 = false;
    public KeyCode ability1;
    public LaserEyes laser;
    public Teleportation teleportation;
    public AbilitySwitch abilitySwitch;
    public int currentAbility = 0;
    public Image HighlightT;
    public Image HighlightL;
    
    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        cooldown1 = laser.cooldown;
        cooldown2 = teleportation.cooldown;
        HighlightL.fillAmount = 0;
        HighlightT.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        Ability2();
        currentAbility = abilitySwitch.selectedAbility;
    }
    void Ability1()
    {
        if(Input.GetMouseButtonDown(0) && isCooldown1 == false && currentAbility == 0)
        {
            isCooldown1 = true;
            abilityImage1.fillAmount = 1;
        }

        if(isCooldown1)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown1 = false;
            }
        }
        if(currentAbility == 0)
        {
            HighlightL.fillAmount = 1;
            HighlightT.fillAmount = 0;
        }
    }
    void Ability2()
    {
        if (Input.GetMouseButtonDown(0) && isCooldown2 == false && currentAbility == 1)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
        }

        if (isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
        if (currentAbility == 1)
        {
            HighlightL.fillAmount = 0;
            HighlightT.fillAmount = 1;
        }

    }
}

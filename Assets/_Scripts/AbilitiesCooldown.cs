using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesCooldown : MonoBehaviour
{
    public Image abilityImage1;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode ability1;
    public LaserEyes laser;
    
    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        cooldown1 = laser.cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
    }
    void Ability1()
    {
        if(Input.GetMouseButtonDown(0) && isCooldown == false)
        {
            isCooldown = true;
            abilityImage1.fillAmount = 1;
        }

        if(isCooldown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}

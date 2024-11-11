using UnityEngine;

public class AbilitySwitch : MonoBehaviour
{
    public int selectedAbility = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        selectAbility();
    }

    // Update is called once per frame
    void Update()
    {

        int previousSelectedAbility = selectedAbility;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedAbility >= transform.childCount -1) 
            { 
                selectedAbility = 0;
            }
            else
            {
                selectedAbility++;
            }
        if (previousSelectedAbility != selectedAbility)
            {
                selectAbility();
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedAbility <= 0)
            {
                selectedAbility = transform.childCount -1;
            }
            else
            {
                selectedAbility--;
            }
        if (previousSelectedAbility != selectedAbility)
            {
                selectAbility();
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedAbility = 0;
            selectAbility();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedAbility = 1;
            selectAbility();
        }
    }

    void selectAbility()
    {
        int i = 0;
        foreach (Transform ability in transform)
        {
            if (i == selectedAbility)
                ability.gameObject.SetActive(true);
            else
                ability.gameObject.SetActive(false);
            i++;
        }
    }
}

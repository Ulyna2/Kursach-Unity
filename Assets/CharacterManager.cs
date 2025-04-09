using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject panelCharacter;
    public int count;

    public void CharacterOne()
    {
        count = 1;
        ResultCharacter();
    }
    public void CharacterTwo()
    {
        count = 2;
        ResultCharacter();
    }
    public void CharacterThree()
    {
        count = 3;
        ResultCharacter();
    }
    public void CharacterFour()
    {
        count = 4;
        ResultCharacter();
    }
    public void ResultCharacter()
    {
        if (count == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hero1");
        }
        if (count == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hero2");
        }
        if (count == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hero3");
        }
        if (count == 4)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hero4");
        }
        panelCharacter.SetActive(false);    
    }
}

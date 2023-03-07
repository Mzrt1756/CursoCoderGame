using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : Character
{

    public void CheckMana()
    {
        if (GameManager.instance._remainingMana <= 0)
        {

            GameManager.instance._remainingMana = 0;
        }
    }

}

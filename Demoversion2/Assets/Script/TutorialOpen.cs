using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOpen : MonoBehaviour
{
    public GameObject Tutorial;
    public void OpenPanel()
    {
        if(Tutorial != null)
        {
            bool isActive = Tutorial.activeSelf;

            Tutorial.SetActive(!isActive);
        }
    }
}

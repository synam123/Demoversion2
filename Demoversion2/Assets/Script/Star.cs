using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    public GameObject pnlStart;
    public bool pause = false;

    void Start()
    {
        pnlStart.SetActive(false);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            pnlStart.SetActive(true);

            Time.timeScale = 0;
        }

    }
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            pnlStart.SetActive(false);
        }
    }
    public void resume()
    {

        Time.timeScale = 1;
        //    Destroy(this.gameObject1);


    }


    public void quit()
    {
        Application.Quit();
    }

}

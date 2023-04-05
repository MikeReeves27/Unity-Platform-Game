using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int cornTotal;

    [SerializeField] private TextMeshProUGUI cornText;

    private GameObject portal;

    private void Start()
    {
        // Hide portal at start of level
        portal = GameObject.Find("Portal");
        portal.SetActive(false);

        // Get number of corn for level and display it on screen
        cornTotal = GameObject.Find("Corn").transform.hierarchyCount - 1;
        cornText.text = "<sprite=\"corn\" name=\"corn\"> " + cornTotal.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Once player touches corn, destroy corn object and update score display
        if (collision.gameObject.CompareTag("Corn"))
        {
            Destroy(collision.gameObject);
            cornTotal--;
            cornText.text = "<sprite=\"corn\" name=\"corn\"> " + cornTotal.ToString();

            // Once all corn are collected, reveal portal
            if (cornTotal == 0)
            {
                portal.SetActive(true);
            }
        }
    }

}

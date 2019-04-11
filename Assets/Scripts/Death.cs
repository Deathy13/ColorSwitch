using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch
{
    public class Death : MonoBehaviour
    {
        public GameObject button;
        public Player alive;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            alive.playerAlive = false;
            button.SetActive(true);
            Destroy(collision.gameObject);
        }

    }
}
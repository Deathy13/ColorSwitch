using UnityEngine;

namespace ColorSwitch
{
    public class FollowPlayer : MonoBehaviour
    {

        public Transform player;
        public Player alive;

        void Update()
            
        {
            if(alive.playerAlive)
            {
                Vector3 camPos = transform.position;
                Vector3 playerPos = player.position;
                if (playerPos.y > camPos.y)
                {
                    transform.position = new Vector3(camPos.x, playerPos.y, camPos.z);
                }
            }
            
        }
    }
}

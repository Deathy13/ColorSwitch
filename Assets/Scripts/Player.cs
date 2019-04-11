using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ColorSwitch
{
    public class Player : MonoBehaviour
    {
        public float jumpForce = 10f;
        public int score;
        public int color;
        public bool playerAlive;
        public Rigidbody2D rigid;
        public SpriteRenderer rend;
        public GameObject winText, loseText,mainMenuButton;
        public Text scoreText;
        public int index;


        public Color[] colors = new Color[4];

        public UnityEvent onGameOver;

        private Color currentColor;
        SpriteRenderer spriteRend;





        private void Awake()
        {
            playerAlive = true;
        }

        void Start()
        {
            RandomizeColor();

            rend = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {

            scoreText.text = "Score :" + score.ToString();
            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            {
                rigid.velocity = Vector2.up * jumpForce;
            }
            if(score == 4)
            {
                winText.SetActive(true);
                mainMenuButton.SetActive(true);
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            spriteRend = col.GetComponent<SpriteRenderer>();
            if (col.name == "ColorChanger")
            {
                RandomizeColor();
                Destroy(col.gameObject);

                return;
            }

            if (col.name == "Star")
            {
                // Add score
                score++;
                Destroy(col.gameObject);
                return;
            }


            if (spriteRend != null &&
               spriteRend.color != rend.color)
            {

                Debug.Log("GAME OVER!");
                playerAlive = false;
                Destroy(this.gameObject);
                loseText.SetActive(true);
                mainMenuButton.SetActive(true);
                onGameOver.Invoke();
            }
            
        }

        void RandomizeColor()
        {
            /* 
             * generate random color 
             * While random color is the same
             *  generate new random color
             *  
             *  set color to randomColor
             */

            // Generate a random color
            Color randomColor = colors[index];

            // Find a unique color
            while (randomColor == rend.color)
            {
                index = Random.Range(0, 4);
                randomColor = colors[index];
            }

            // Assign the random color
            rend.color = randomColor;


        }
    }
}
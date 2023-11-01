using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private bool isOnGround = true;

    Rigidbody rb;
    [SerializeField] float movementSpeed = 2.5f;
    [SerializeField] float jumpForce = 2.5f;
    // Double jump: Số lần nhảy
    private const int MAX_JUMP = 2;
    //Số bước nhảy hiện tại
    private int currentJump = 0;
    // Tính điểm
    public Text score;
    public AudioSource gameOver, winGame, jump, eatStar, soundTrack, soundReset, gate;
    private int point = 0;

    //Tính điểm trên màn hình Over Game
    public Text pointsOverGame;
    public Text pointsWinGame;
    public GameObject overMenu;
    // Reset Game: khi rơi khỏi bề mặt
    private float y = -2f;
    public GameObject winMenu;
    public GameObject win;

    [System.Obsolete]
    public void GameOver()
    {
        Time.timeScale = 0f; // *Note:...
        overMenu.SetActive(true);
        pointsOverGame.text = point.ToString();
        FindObjectOfType<PauseGame>().isGameOver = true; // Đặt giá trị biến isGameOver thành true
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        point = 0;
        Show();
        Time.timeScale = 1f;
        win.GetComponent<Renderer>().enabled = false;
        overMenu.SetActive(false);
        winMenu.SetActive(false);
    }

    [System.Obsolete]
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
        Jump();
        ResetGames();
        Show();
        MenuPaused();
    }

    [System.Obsolete]
    public void MenuPaused()
    {
        if (Input.GetKeyDown(KeyCode.Escape))

        {
            //soundTrack.Pause();
            if (FindObjectOfType<PauseGame>().isPaused)
            {
                FindObjectOfType<PauseGame>().ResumeGame();
            }
            else
            {
                FindObjectOfType<PauseGame>().PauseGames();
            }
        }

    }
    private bool IsPausedSound = false;

    [System.Obsolete]
    public void ResetGames()
    {

        if (transform.position.y <= y && IsPausedSound == false)
        {
            IsPausedSound = true;
            soundReset.Play();
            GameOver();
        }

        //Tính điểm trên màn hình Over Game
    }

    public void Jump()
    {
        if (transform.position.y >= 0)
        {
            if (Input.GetButtonDown("Jump") && (isOnGround || MAX_JUMP > currentJump))
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                isOnGround = false;
                currentJump++;
                jump.Play();
            }
        }

    }
    private void FixedUpdate()
    {
        Show();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            eatStar.Play();
            point += 1;
            WinPoint();
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            if (point >= 13)
            {
                WinGame();
                winGame.Play();
            }
        }

    }
    public void WinPoint()
    {
        if (point >= 13) // Số điểm sẽ win game
        {
            win.GetComponent<Renderer>().enabled = true;
        }
    }
    public void WinGame()
    {
        Time.timeScale = 0f; // *Note:...
        winMenu.SetActive(true);
        pointsWinGame.text = point.ToString() + " Stars";
    }

    // nhận những vật thể KHÔNG đánh dấu Is Trigger
    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            this.enabled = false;
            gameOver.Play();
            GameOver();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {

            isOnGround = true;
            currentJump = 0;

        }
        if (collision.gameObject.CompareTag("Waypoint"))
        {

            Travel();
        }
    }
    private void Travel()
    {
        transform.position = new Vector3(-0.12f, 0.5f, -0.11f);
        gate.Play();
    }
    // Hiển thị điểm số
    private void Show()
    {
        score.text = point.ToString();
    }
}

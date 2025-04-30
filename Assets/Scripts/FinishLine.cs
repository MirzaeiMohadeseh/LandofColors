using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FinishLine : MonoBehaviour
{
    public GameObject pauseMenu; // اشاره به منوی پاز در Inspector
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextLevel);
           
        }
        if (other.gameObject.CompareTag("Player") && SceneManager.GetActiveScene().name == "level3")
        {
            Time.timeScale = 0f; // توقف بازی
            pauseMenu.SetActive(true); // نمایش منوی پاز
            Cursor.visible = true; // نشان دادن موس
            Debug.Log("Finish Line Reached in Level 3!");
        }
    }
}

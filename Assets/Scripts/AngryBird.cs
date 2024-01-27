using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This component lets the player pull the ball and release it.
 */
public class AngryBird : MonoBehaviour
{
    [SerializeField] Rigidbody2D hook = null; // The hook from where the bird is launched
    [SerializeField] float releaseTime = .15f; // Time to release the bird after mouse release
    [SerializeField] float maxDragDistance = 5f; // Maximum distance the bird can be dragged

    private bool isReleased = false; // Flag to check if the bird has been released
    private bool isMousePressed = false; // Flag to check if mouse button is pressed

    private Rigidbody2D rb; // Reference to the Rigidbody2D component of the bird

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component of the bird
    }

    void Update()
    {
        if (isMousePressed)
        {
            // If mouse is pressed, drag the bird within max drag distance
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
            {
                Vector2 direction = (mousePos - hook.position).normalized;
                rb.position = hook.position + direction * maxDragDistance;
            }
            else
                rb.position = mousePos;
        }

        if (isReleased)
        {
            // Check if all objects in the scene are static and restart scene if true
            CheckPigCount();
            if (IsSceneStatic())
            {
                RestartScene();
            }
        }
    }

    private void OnMouseDown()
    {
        isMousePressed = true;
        rb.isKinematic = true; // Make the Rigidbody2D kinematic to hold its position
    }

    private void OnMouseUp()
    {
        isMousePressed = false;
        rb.isKinematic = false; // Make the Rigidbody2D non-kinematic to enable physics
        StartCoroutine(ReleaseBall());
    }

    IEnumerator ReleaseBall()
    {
        // Wait a short time, to let the physics engine operate the spring and give some initial speed to the ball.
        yield return new WaitForSeconds(releaseTime);
        isReleased = true; // Set the release flag to true
        GetComponent<SpringJoint2D>().enabled = false; // Disable the spring joint after release
    }

    private bool IsSceneStatic()
    {
        // Check if all Rigidbody2D objects in the scene are sleeping (static)
        Rigidbody2D[] rigidbodies = FindObjectsOfType<Rigidbody2D>();
        foreach (var rb in rigidbodies)
        {
            if (!rb.IsSleeping())
            {
                return false; // If any object is not sleeping, return false
            }
        }
        return true; // If all objects are sleeping, return true
    }

    private void RestartScene()
    {
        // Restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Restart the game if the bird hits the boundary
        if (other.CompareTag("boundary"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart game
        }
    }

    private void CheckPigCount()
    {
        // Check the count of pigs in the scene and move to level 2 if there are none left
        GameObject[] pigs = GameObject.FindGameObjectsWithTag("pig");
        if (pigs.Length == 0)
        {
            MoveToNextLevel();
        }
    }

    private void MoveToNextLevel()
    {
        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

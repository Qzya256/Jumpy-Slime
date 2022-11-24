using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private Transform slimTransform;
    [SerializeField] private Animator GameOverAnimator;
    [SerializeField] private GameObject GameOverText;
    [SerializeField] private GameObject ControlButtons;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            other.transform.position = slimTransform.position;
            other.gameObject.SetActive(false);
            slimTransform.gameObject.SetActive(true);
            GameOverAnimator.SetBool("Run", true);
            GameOverText.SetActive(true);
            ControlButtons.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject hazard, score_text, restart_text, game_over_text;

    bool game_over, restart;

    [SerializeField]
    Vector3 spawn_value;

    [SerializeField]
    int hazard_count;
    int score;

    [SerializeField]
    float spawn_wait, start_wait, wave_wait;

    private void Start()
    {
        score = 0;
        game_over = false;
        restart = false;
        restart_text.GetComponent<Text>().text = "";
        game_over_text.GetComponent<Text>().text = "";
        update_score();
        StartCoroutine(spawn_waves());
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    IEnumerator spawn_waves()
    {
        while (true)
        {
            yield return new WaitForSeconds(start_wait);
            for (int i = 0; i < hazard_count; i++)
            {
                Vector3 spawn_position = new Vector3(Random.Range(-spawn_value.x, spawn_value.x), spawn_value.y, spawn_value.z);
                Quaternion spawn_rotation = Quaternion.identity;
                Instantiate(hazard, spawn_position, spawn_rotation);
                yield return new WaitForSeconds(spawn_wait);
            }
            yield return new WaitForSeconds(wave_wait);
            if (game_over)
            {
                restart_text.GetComponent<Text>().text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    void update_score()
    {
        score_text.GetComponent<Text>().text = "Score : " + score;
    }

    public void add_score(int new_score)
    {
        score += new_score;
        update_score();
    }

    public void game_over_fun()
    {
        game_over_text.GetComponent<Text>().text = "Game over!";
        game_over = true;
    }
}

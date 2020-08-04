using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    [SerializeField]
    GameObject explosion, player_explosion;

    GameController game_controller;

    [SerializeField]
    int score_value;

    private void Start()
    {
        GameObject game_controller_object = GameObject.FindGameObjectWithTag("GameController");
        if (game_controller_object)
        {
            game_controller = game_controller_object.GetComponent<GameController>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Boundary") && !other.CompareTag("Enemy"))
        {
            if (explosion)
            {
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
            if(other.CompareTag("Player"))
            {
                Instantiate(player_explosion, other.gameObject.transform.position, other.gameObject.transform.rotation);
                game_controller.game_over_fun();
            }
            else
            {
                game_controller.add_score(score_value);
            }
        }
    }
}

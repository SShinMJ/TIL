using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalInManager : MonoBehaviour
{
    [SerializeField] ParticleSystem goalInParticle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            goalInParticle.Play();

            GameManager.instance.GoalIn();
        }
    }

}

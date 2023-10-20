using UnityEngine;

public class ThundererAttack : MonoBehaviour
{

    private GameObject player;
    private Move move;
    Animator animator;

    public void MoveToThePlayer()
    {
        if (player == null)
        {
            return;
        }
        Vector3 direction = player.transform.position - transform.forward;
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > 3.5)
        {
            direction.Normalize();
            if (transform.position.x < player.transform.position.x + 0.1f)
            {
                move.MoveRight();

                // transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 3 * Time.deltaTime);
                animator.SetBool("run", true);
            }
            else if (transform.position.x > player.transform.position.x - 0.1f)
            {
                move.MoveLeft();
                animator.SetBool("run", true);
            }
            else
            {

            }

        }
        else
        {
            animator.SetBool("run", false);
        }

    }

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();


        move = GetComponent<Move>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        MoveToThePlayer();
    }
}

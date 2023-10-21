using UnityEngine;

public class ThundererAttack : MonoBehaviour
{

    private GameObject player;
    private Move move;
    Animator animator;
    private float duration;
    private bool animationComplete;
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
            if (transform.position.x < player.transform.position.x - 0.3f)
            {
                move.MoveRight();

                // transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 3 * Time.deltaTime);
                animator.SetBool("run", true);
            }
            else if (transform.position.x > player.transform.position.x + 0.3f)
            {
                move.MoveLeft();
                animator.SetBool("run", true);
            }
            else
            {

                animator.SetBool("run", false);
            }

        }
        else
        {
            defend();
            //PlayAnimation("defend", 2f);
            //animator.Play("defend", -1, 0f);
        }

    }

    public int AttackStrategy()
    {
        return 1;
    }

    public void attack2()
    {
        animator.SetBool("attack2", true);
    }
    public void attack3()
    {
        animator.SetBool("attack3", true);
    }
    public void spAttack()
    {
        animator.SetBool("spAttack", true);
    }
    public void defend()
    {
        animator.SetBool("defend", true);
        // animator.Play("defend", -1, 0f);

    }

    void PlayAnimation(string animation, float duration)
    {
        if (animationComplete)
        {
            this.duration = duration;
            animationComplete = false;

            //  animator.Play(animation, -1, 0f);
        }
        else
        {
            this.duration -= Time.deltaTime;

        }
        if (duration <= 0)
        {
            animationComplete = true;
            animator.SetBool(animation, false);
        }
        // Play the "YourAnimationName" animation
        // animator.SetTrigger(animation);

        // Wait for the specified duration
        //yield return new WaitForSeconds(duration);

        // After the duration, transition back to the "Idle" state
        animator.SetTrigger("Idle");
    }




    // Start is called before the first frame update
    void Start()
    {
        animationComplete = true;
        animator = GetComponent<Animator>();
        animator.SetBool("run", true);

        move = GetComponent<Move>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        //MoveToThePlayer();
    }
}

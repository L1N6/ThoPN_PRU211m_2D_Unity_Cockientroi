using System.Reflection;
using UnityEngine;

public class ThundererAttack : MonoBehaviour
{

    private GameObject player;
    private Move move;
    Animator animator;
    private float duration;
    private bool animationComplete;
    bool isInAction = false;

    // Start is called before the first frame update
    void Start()
    {
        animationComplete = true;
        animator = GetComponent<Animator>();
        // animator.SetBool("run", true);

        move = GetComponent<Move>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (isInAction == false)
        {
            nextAction(animator);
        }
        //MoveToThePlayer();
    }



    public void nextAction(Animator animator)
    {
        int s = ActionStrategy();
        isInAction = true;
        switch (s)
        {
            case 0:
                AttackDistance(3f, animator, "Attack1");
                break;
            case 1:
                AttackDistance(5.5f, animator, "Attack3");
                //Attack3(animator);
                break;
            case 2:
                AttackDistance(5.5f, animator, "SpAttack");
                break;
            case 3:
                //Restreat
                Retreat(animator);
                break;
        }
    }

    public void AttackDistance(float fixedDistance, Animator animator, string typeAttack)
    {
        Vector3 direction = player.transform.position - transform.forward;
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > fixedDistance)
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
                move.RollLeft();
                animator.SetBool("run", true);
            }
            else
            {
                move.RollRight();
                animator.SetBool("run", false);
            }

        }
        else
        {
            MethodInfo methodInfo = this.GetType().GetMethod(typeAttack, BindingFlags.Public | BindingFlags.Instance);

            if (methodInfo != null)
            {
                // Invoke the method if found
                methodInfo.Invoke(this, new object[] { animator });
            }

            //Attack3(animator);
            //animator.SetTrigger("atk2");
            // animator.SetBool("run", false);

            //PlayAnimation("defend", 2f);
            //animator.Play("defend", -1, 0f);
        }
    }


    public void Attack3(Animator animator)
    {
        //animator.SetBool("attack3", true);
        animator.Play("3_atk", -1, 0f);

    }

    public void Attack2(Animator animator)
    {
        animator.SetTrigger("atk2");
    }
    public void Attack1(Animator animator)
    {
        animator.SetTrigger("atk1");
    }

    public void SpAttack(Animator animator)
    {
        animator.SetTrigger("sp_atk");
    }

    public void Retreat(Animator animator)
    {
        if (player.transform.position.x < transform.position.x)
        {
            move.RollRight();
        }
        else
        {
            move.RollLeft();
        }

    }

    public int ActionStrategy()
    {
        return (int)Random.Range(0, 4);
    }

    public void ResetIsAction()
    {
        isInAction = false;
    }

}

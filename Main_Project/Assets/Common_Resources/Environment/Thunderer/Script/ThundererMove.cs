using System.Reflection;
using UnityEngine;

public class ThundererMove : StateMachineBehaviour
{
    GameObject player;
    GameObject thunderer;
    Move move;
    Rigidbody2D rb;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        player = GameObject.FindGameObjectWithTag("Toad");
        thunderer = GameObject.FindGameObjectWithTag("Thunderer");
        rb = animator.GetComponent<Rigidbody2D>();
        move = thunderer.GetComponent<Move>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {





    }
    public void nextAction(Animator animator)
    {
        int s = thunderer.GetComponent<ThundererAttack>().ActionStrategy();
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
        Vector3 direction = player.transform.position - thunderer.transform.forward;
        float distance = Vector3.Distance(thunderer.transform.position, player.transform.position);
        if (distance > fixedDistance)
        {
            direction.Normalize();
            if (thunderer.transform.position.x < player.transform.position.x - 0.3f)
            {
                move.MoveRight();

                // transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 3 * Time.deltaTime);
                animator.SetBool("run", true);
            }
            else if (thunderer.transform.position.x > player.transform.position.x + 0.3f)
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
        if (player.transform.position.x < thunderer.transform.position.x)
        {
            move.RollRight();
        }
        else
        {
            move.RollLeft();
        }

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.ResetTrigger("atk1");
        ////animator.ResetTrigger("sp_trigger");
        //animator.ResetTrigger("atk2");
        //animator.ResetTrigger("3_atk");
        //animator.ResetTrigger("roll");

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

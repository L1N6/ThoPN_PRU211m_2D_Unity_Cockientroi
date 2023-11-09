using UnityEngine;

public class Roll : StateMachineBehaviour
{
    GameObject player;
    GameObject thunderer;
    Move move;
    Rigidbody2D rb;
    HPControl health;
    bool isRolling = false;
    float RollUnitPerSecond = 10f;
    int EnemyHP = 10;
    int PlayerHP = 3;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        player = GameObject.FindGameObjectWithTag("Toad");
        thunderer = GameObject.FindGameObjectWithTag("Thunderer");
        health = thunderer.GetComponent<HPControl>();
        rb = animator.GetComponent<Rigidbody2D>();
        move = thunderer.GetComponent<Move>();
        EnemyHP = health.GetHealth();
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (EnemyHP <= 8 && PlayerHP >= 2)
        {

            Retreat(animator);


        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("roll");
        move.ResetRolling();

    }
    public void Retreat(Animator animator)
    {
        if (thunderer.transform.position.x < player.transform.position.x)
        {
            RollLeft(animator);
        }
        else
        {
            RollRight(animator);
        }

    }

    public void RollRight(Animator animator)
    {

        //isFlipped = false;

        thunderer.transform.position = new Vector3(thunderer.transform.position.x + 1 * RollUnitPerSecond * Time.deltaTime, thunderer.transform.position.y, thunderer.transform.position.z);

        //transform.localScale = flipped;

    }

    public void RollLeft(Animator animator)
    {
        //isFlipped = true;
        thunderer.transform.position = new Vector3(thunderer.transform.position.x + (-1) * RollUnitPerSecond * Time.deltaTime, thunderer.transform.position.y, thunderer.transform.position.z);



        //transform.localScale = flipped;


    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()

}

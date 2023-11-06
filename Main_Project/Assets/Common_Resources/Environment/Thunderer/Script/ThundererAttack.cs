using System.Collections;
using System.Reflection;
using UnityEngine;

public class ThundererAttack : MonoBehaviour
{

    private GameObject player;
    private Move move;
    Animator animator;
    private float duration;
    private bool animationComplete;
    bool wantMove = true;
    bool wantAtk = true;
    float timer1 = 0;
    FireFatherOfBullet fireBullet;
    HPControl health;
    // Start is called before the first frame update
    void Start()
    {
        fireBullet = transform.GetChild(0).GetComponent<FireFatherOfBullet>();
        animationComplete = true;
        animator = GetComponent<Animator>();
        // animator.SetBool("run", true);
        health = GetComponent<HPControl>();
        move = GetComponent<Move>();
        player = GameObject.FindGameObjectWithTag("Toad");

    }

    // Update is called once per frame
    void Update()
    {
        if (wantMove == true)
        {

            MoveToDistance(3f, animator, "");
        }
        else if (wantAtk == true)
        {
            wantAtk = false;
            if (animationComplete == true)
            {
                MentalDecision();
            }
        }
        else
        {
            DoSomeThing();
        }
        //MoveToThePlayer();
    }


    public void MentalDecision()
    {
        int EnemyHP = health.GetHealth();
        int PlayerHP = 3;
        float retreatProbability = 0.3f;
        if (EnemyHP <= 8 && PlayerHP >= 2)
        {
            if (Random.Range(0f, 1f) <= retreatProbability)
            {
                transform.Rotate(0f, 180f, 0f);
                animator.Play("roll", -1, 0f);
            }
            else
            {
                attackRandom(animator);
            }
        }
        else
        {
            attackRandom(animator);
        }
    }

    public void DoSomeThing()
    {
        if (wantAtk == false && wantAtk == false)
        {
            timer1 += Time.deltaTime;
            if (timer1 >= 2)
            {
                timer1 = 0;
                wantMove = true;
                wantAtk = true;
            }
        }
    }

    public float GetPlayerDistance()
    {
        if (player != null)
            return Vector3.Distance(transform.position, player.transform.position);
        else
            return 0f;
    }

    public void MoveToDistance(float fixedDistance, Animator animator, string typeAttack)
    {
        if (GetPlayerDistance() > fixedDistance)
        {
            //direction.Normalize();
            if (transform.position.x < player.transform.position.x - 0.3f)
            {
                move.MoveRight();
                animator.SetBool("run", true);
            }
            else if (transform.position.x > player.transform.position.x + 0.3f)
            {
                move.MoveLeft();
                animator.SetBool("run", true);
            }
            else
            {
                //move.RollRight();

            }

        }
        else
        {
            wantMove = false;
            animator.SetBool("run", false);
        }
    }
    public void attackRandom(Animator animator)
    {
        int s = ActionStrategy();

        switch (s)
        {
            case 0:
                MoveDistance(3f, animator, "Attack1");
                break;
            case 1:
                MoveDistance(5.5f, animator, "Attack3");
                //Attack3(animator);
                break;
            case 2:
                MoveDistance(5.5f, animator, "SpAttack");
                break;
            case 3:
                StartCoroutine(FireBulletDuration(3f, 0.2f));

                break;
        }
    }

    public void MoveDistance(float fixedDistance, Animator animator, string typeAttack)
    {
        //Vector3 direction = player.transform.position - transform.forward;
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > fixedDistance)
        {
            //direction.Normalize();
            if (transform.position.x < player.transform.position.x - 0.3f)
            {
                animator.SetBool("run", true);
                move.MoveRight();
                //animator.SetBool("run", true);
            }
            else if (transform.position.x > player.transform.position.x + 0.3f)
            {
                animator.SetBool("run", true);
                move.MoveLeft();
                //animator.SetBool("run", true);
            }
            else
            {
                animator.SetBool("run", false);
                //move.RollRight();
                //animator.SetBool("run", false);
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

    IEnumerator FireBulletDuration(float totaDuration, float duration)
    {
        float timer = 0f;

        while (timer < totaDuration)
        {
            timer += Time.deltaTime;
            if (timer - duration >= 0.2)
            {
                duration = timer;
                fireBullet.FireBullet();
            }
            yield return null;
        }
    }
    //public void Retreat(Animator animator)
    //{
    //    if (transform.position.x < player.transform.position.x)
    //    {
    //        move.RollLeft();
    //    }
    //    else
    //    {
    //        move.RollRight();
    //    }

    //}

    public int ActionStrategy()
    {
        return (int)Random.Range(0, 4);
    }



}

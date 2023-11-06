using UnityEngine;

public class ToadAttack : MonoBehaviour
{
    Animator animator;
    public LayerMask attackMask;
    float immortalTime = 0f;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKey(KeyCode.E))
            {
                animator.Play("TongueToad", -1, 0f);
            }
        


    }
    public void Attack(int TypeAttack)
    {
        
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        if (immortalTime == 0f) { }
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<HPControl>().TakeDamage(1);
        }
    }


    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}

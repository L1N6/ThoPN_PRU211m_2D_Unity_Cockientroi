using UnityEngine;

public class atkArea_1 : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 2;
    public LayerMask attackMask;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<Heath>().TakeDamage(1);
        }
    }
    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (gameObject.active == true && collider.gameObject.tag.Equals("Enemy")) ;
    //    {
    //        string s = collider.gameObject.tag;
    //        Heath heath = collider.GetComponent<Heath>();
    //        heath.TakeDamage();

    //    }
    //}

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }




}

using UnityEngine;

public class atkArea_1 : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 2;
    private AudioManager audioManager;
    public LayerMask attackMask;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    private void Start()
    {
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
    }
    public void Attack(int TypeAttack, AudioClip Audio)
    {
        switch (TypeAttack)
        {
            case 0:
                attackOffset = new Vector3(1.19f, 1.71f, 0);
                attackRange = 1.72f;
                break;
            case 1:
                // audioManager.PlaySFX(Audio);
                attackOffset = new Vector3(5.8f, 1.71f, 0);
                attackRange = 2.45f;
                break;

        }
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

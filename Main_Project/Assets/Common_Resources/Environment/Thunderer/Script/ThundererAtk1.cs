using UnityEngine;

public class ThundererAtk1 : MonoBehaviour
{
    private GameObject attackArea = default;
    private float attackDuration = 3f;
    private float timer = 0;
    private bool attacking = true;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (attacking == false && timer > attackDuration)
        {
            Debug.Log("Attack is ready!");
            attacking = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && attacking == true)
        {
            Attack();
        }
    }
    private void Attack()
    {
        attackArea.SetActive(attacking);
    }
}

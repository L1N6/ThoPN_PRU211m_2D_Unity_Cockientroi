using UnityEngine;

public class atkArea_1 : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 1;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (gameObject.active == true && collider.gameObject.tag.Equals("Enemy")) ;
        {
            string s = collider.gameObject.tag;
            Heath heath = collider.GetComponent<Heath>();
            heath.TakeDamage();

        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

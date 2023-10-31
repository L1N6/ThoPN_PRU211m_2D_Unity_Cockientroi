using UnityEngine;

public class FireFatherOfBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject frog;
    void Start()
    {

    }

    public void FireButtet()
    {
        GameObject newObject = Instantiate(bullet, transform.position, Quaternion.identity);
        FatherOfBulletMove FOB = newObject.GetComponent<FatherOfBulletMove>();
        if (FOB != null)
        {
            FOB.intitalFatherOfBullet(new Vector3(Random.Range(frog.transform.position.x - 4f, frog.transform.position.x + 4f), Random.Range(3.5f, 4.1f)));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

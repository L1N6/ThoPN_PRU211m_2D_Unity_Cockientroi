using UnityEngine;

public class FatherOfBulletMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float maxY = 4f;
    private float minY = 2f;
    private float maxX = 17f;
    private float minX = -9f;
    [SerializeField] private float count = 0f;
    private GameObject frog;
    [SerializeField] private float rotationModifier = 0;
    private Vector3 startPosition;
    private Vector3 controlpoint;
    private Vector3 endPosition;
    private Animator animator;
    private bool explosion = false;

    public void intitalFatherOfBullet(Vector3 destination)
    {
        endPosition = destination;
    }
    void Start()
    {
        frog = GameObject.FindGameObjectWithTag("Enemy");
        //endPosition = new Vector3(9.5f, 3.9f);
        animator = GetComponent<Animator>();
        startPosition = transform.position;
        controlpoint = new Vector3(((transform.position.x + endPosition.x) / 2), 4);
    }

    Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p2;

        return p;
    }

    private void FixedUpdate()
    {
        if (frog != null)
        {
            Vector3 vectorToTarget = frog.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 20 * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {


        //if (Mathf.Abs(transform.position.x - endPosition.x) <= 0.05 && Mathf.Abs(transform.position.y - endPosition.y) <= 0.05 && explosion == false)
        //{
        //    //Vector3 directionToTarget = frog.transform.position;
        //    //Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);
        //    //transform.rotation = rotationToTarget;

        //}
        //else
        //{

        //}
        if (count <= 1.0f)
        {

            count += 1.0f * (Time.deltaTime * 0.4f);
            Vector3 position = CalculateBezierPoint(count, startPosition, controlpoint, endPosition);

            // Move the object to the calculated position
            transform.position = position;
            //Vector3 m1 = Vector3.Lerp(transform.position, new Vector3(1, 4), count);
            //Vector3 m2 = Vector3.Lerp(new Vector3(1, 4), new Vector3(9.5f, 3.9f), count);
            //gameObject.transform.position = Vector3.Lerp(m1, m2, count);
        }
        else
        {
            if (explosion == false)
            {
                animator.Play("bulletBlast", -1, 0f);
                explosion = true;
            }
            count += Time.deltaTime;
            if (count >= 1.70f) { Destroy(gameObject); }

        }

    }
}

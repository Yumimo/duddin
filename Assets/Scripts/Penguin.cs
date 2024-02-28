using UnityEngine;

public class Penguin : MonoBehaviour
{
    Animator animController;
    public float range =3;
    public float cooldown = 1.5f;
    public Transform player;

    private float cooldownTimer = 0;
    void Start()
    {
        animController = GetComponent<Animator>();
    }

    public void RemoveControls()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().isTrigger = true;
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        cooldown = Mathf.Max(0, cooldown);
        if (Vector2.Distance(transform.position, player.position) < range)
        {
            if (cooldownTimer >= cooldown)
            {
                animController.SetTrigger("attack");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}

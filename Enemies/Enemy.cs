using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    [SerializeField]
    private EnemyBlueprint thisEnemy;

    private void Start()
    {
        target = Waypoints.points[0];
    }
    public void TakeDamage(float amount)
    {
        thisEnemy.health -= amount;
        if (thisEnemy.health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        PlayerStats.Money = PlayerStats.Money + thisEnemy.worth;
        PlayerStats.moneyChange = true;
        Destroy(gameObject);
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * thisEnemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2)
        {
            transform.LookAt(target);
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            PlayerStats.Lives -= thisEnemy.damageOnPlayer;
            PlayerStats.obtainedDamage = true;
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];

        // Hier aktualisierst du die Blickrichtung des Feindes
        Vector3 dir = target.position - transform.position;
        transform.LookAt(target.position + dir.normalized);
    }

}
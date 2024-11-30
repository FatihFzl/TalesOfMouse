

public class Enemy : Character
{
    public override float MaxHealth { get; set; }
    public override float CurrentHealth { get; set; }
    
    public override void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }

    public override void Attack()
    {
        
    }

    public override void Die()
    {
        
    }
}

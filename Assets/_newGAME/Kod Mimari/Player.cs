
public class Player : Character
{
    public override float MaxHealth { get; set; }
    public override float CurrentHealth { get; set; }
    
    
    private float _moveSpeed;
    private float _rotationSpeed;
    private float _slideSpeed;
    private float slideDistance;
    // mouseInput ve mousePosition
    
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

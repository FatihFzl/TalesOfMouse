public abstract class Character
{
   public abstract float MaxHealth { get; set; }
   public abstract float CurrentHealth { get; set; }
   //Attack power

   public abstract void TakeDamage(float damage);
   public abstract void Attack();
   public abstract void Die();
}

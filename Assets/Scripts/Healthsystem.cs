using System;

public class Healthsystem
{
   private int health;
   private int healthMax;

   public event EventHandler HealthChanged;
   public event EventHandler Dead;

   public Healthsystem(int healthMax)
   {
   	this.healthMax = healthMax;
   	health = healthMax;
   }

   public float GetHealthpercent(){
   	return(float)health / healthMax;
   }

   public void Damage(int amount)
   {
   	health -= amount;
   	if(health<0)
   	{
   		health = 0;
   	}
      if(HealthChanged != null) HealthChanged(this, EventArgs.Empty);
   }

}

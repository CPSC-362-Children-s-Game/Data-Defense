using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthsystem
{
   private:
   int health;
   int healthMax;

   public event Eventhandler HealthChanged;
   public event Eventhandler Dead;

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

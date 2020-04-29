//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HealthBar : MonoBehaviour
//{
//    public Healthsystem healthsystem;

//    private void Update()
//    {
        
//    }

//    public void setup(Healthsystem healthsystem)
//    {
//        this.healthsystem = healthsystem;

//        healthsystem.HealthChanged += Healthsystem_HealthChanged;

//        updatehealthbar();
//    }

//    private void Healthsystem_HealthChanged(object sender, System.EventArgs e)
//    {
//        updatehealthbar();
//    }

//    private void updatehealthbar()
//    {
//        transform.Find("Bar").localScale = new Vector3(healthsystem.GetHealthpercent(), 1);
//    }
//}

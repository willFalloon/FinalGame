using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    [SerializeField] PointHUD pointHUD;

    
    public void AddPoints(int points)
    {
        
      
            pointHUD.Points += points;
        
    }
}
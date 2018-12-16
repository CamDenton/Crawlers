using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Special
{
    void Activate();
    void Cancel();
    IEnumerator Ongoing(float cooldown); 

}

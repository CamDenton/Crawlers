using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IStunnable
{
    void Stun(float duration);
    IEnumerator StunReturn(float durationR);

}

public interface IKnockable
{
    void Knockback(float strength);
}

public interface IExplosive
{
    void Explode(float strength);
}

public interface ICloakable
{
    void Cloak(float duration);
    IEnumerator Visible(float durationV); 
}

public interface IBurnable
{
    void Burn(float duration);
    void Burning();
    
}

public interface IFreezeable
{
    void Freeze(float duration);
    IEnumerator Defrost(float durationR);
}

public interface IPoisonable
{
    void Poison(float duration, int power);
    IEnumerator Curing(float durationR, int powerR); 
}

public interface IPowerable
{
    void PowerUp(float duration, int power);
    IEnumerator PowerReturn(float durationR);
}

public interface IDebufferable
{
    void Debuff(float duration);
    IEnumerator Rebuff(float durationR);
}

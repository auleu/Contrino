using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int level = 1;
    public int strength = 10;
    public int dexterity = 10;
    public int constitution = 10;
    public int mind = 10;
    public int xp = 0;

    public struct Stats
    {
        public float baseValue;
        public float strMod;
        public float dexMod;
        public float conMod;
        public float mindMod;
        public float total;
    }

    void Start()
    {
        Stats hp;
        Stats hpRegenRate;
        Stats hpRegenDelay;
        Stats stamina;
        Stats staminaRegenRate;
        Stats staminaRegenDelay;
        Stats meleeDmg;
        Stats speed;
        Stats defense;
        Stats dodge;
        Stats accuracy;
        Stats jump;
        Stats critChance;
        Stats insight;
        Stats will;

        hp.baseValue = 50f;
        hp.strMod = 1.5f;
        hp.dexMod = 0.25f;
        hp.conMod = 3f;
        hp.mindMod = 0.25f;
        hp.total = hp.baseValue + (hp.strMod * strength) + (hp.dexMod + dexterity) + (hp.conMod * constitution) + (hp.mindMod * mind);

        hpRegenRate.baseValue = 0.75f;
        hpRegenRate.strMod = 0.25f;
        hpRegenRate.dexMod = 0.05f;
        hpRegenRate.conMod = 0.25f;
        hpRegenRate.mindMod = 0.05f;
        hpRegenRate.total = hpRegenRate.baseValue + (hpRegenRate.strMod * strength) + (hpRegenRate.dexMod * dexterity) + (hpRegenRate.conMod * constitution) + (hpRegenRate.mindMod * mind);

        hpRegenDelay.baseValue = 10f;
        hpRegenDelay.strMod = -0.25f;
        hpRegenDelay.dexMod = 0f;
        hpRegenDelay.conMod = -0.5f;
        hpRegenDelay.mindMod = 0f;
        hpRegenDelay.total = hpRegenDelay.baseValue + (hpRegenDelay.strMod * strength) + (hpRegenDelay.dexMod * dexterity) + (hpRegenDelay.conMod * constitution) + (hpRegenDelay.mindMod * mind);

        stamina.baseValue = 30f;
        stamina.strMod = 0.5f;
        stamina.dexMod = 1f;
        stamina.conMod = 1.5f;
        stamina.mindMod = 0.25f;
        stamina.total = stamina.baseValue + (stamina.strMod * strength) + (stamina.dexMod * dexterity) + (stamina.conMod * constitution) + (stamina.mindMod * mind);

        staminaRegenRate.baseValue = 1f;
        staminaRegenRate.strMod = 0.25f;
        staminaRegenRate.dexMod = 1f;
        staminaRegenRate.conMod = 1f;
        staminaRegenRate.mindMod = 0.25f;
        staminaRegenRate.total = staminaRegenRate.baseValue + (staminaRegenRate.strMod * strength) + (staminaRegenRate.dexMod * dexterity) + (staminaRegenRate.conMod * constitution) + (staminaRegenRate.mindMod * mind);

        staminaRegenDelay.baseValue = 3f;
        staminaRegenDelay.strMod = -0.25f;
        staminaRegenDelay.dexMod = -0.25f;
        staminaRegenDelay.conMod = -0.05f;
        staminaRegenDelay.mindMod = -0.05f;
        staminaRegenDelay.total = staminaRegenDelay.baseValue + (staminaRegenDelay.strMod * strength) + (staminaRegenDelay.dexMod * dexterity) + (staminaRegenDelay.conMod * constitution) + (staminaRegenDelay.mindMod * mind);

        meleeDmg.baseValue = 10f;
        meleeDmg.strMod = 2.5f;
        meleeDmg.dexMod = 0.25f;
        meleeDmg.conMod = 0f;
        meleeDmg.mindMod = 0.25f;
        meleeDmg.total = meleeDmg.baseValue + (meleeDmg.strMod * strength) + (meleeDmg.dexMod * dexterity) + (meleeDmg.conMod * constitution) + (meleeDmg.mindMod * mind);

        speed.baseValue = 12f;
        speed.strMod = 0.25f;
        speed.dexMod = 1f;
        speed.conMod = 0.25f;
        speed.mindMod = 0f;
        speed.total = speed.baseValue + (speed.strMod * strength) + (speed.dexMod * dexterity) + (speed.conMod * constitution) + (speed.mindMod * mind);

        defense.baseValue = 10f;
        defense.strMod = 2.5f;
        defense.dexMod = 0.5f;
        defense.conMod = 2.5f;
        defense.mindMod = 0.25f;
        defense.total = defense.baseValue + (defense.strMod * strength) + (defense.dexMod * dexterity) + (defense.conMod * constitution) + (defense.mindMod * mind);

        dodge.baseValue = 20f;
        dodge.strMod = 0f;
        dodge.dexMod = 2f;
        dodge.conMod = 0f;
        dodge.mindMod = 0.65f;
        dodge.total = dodge.baseValue + (dodge.strMod * strength) + (dodge.dexMod * dexterity) + (dodge.conMod * constitution) + (dodge.mindMod * mind);

        accuracy.baseValue = 45f;
        accuracy.strMod = 0.25f;
        accuracy.dexMod = 2f;
        accuracy.conMod = 0.25f;
        accuracy.mindMod = 1.5f;
        accuracy.total = accuracy.baseValue + (accuracy.strMod * strength) + (accuracy.dexMod * dexterity) + (accuracy.conMod * constitution) + (accuracy.mindMod * mind);

        jump.baseValue = 10f;
        jump.strMod = 0.75f;
        jump.dexMod = 0.5f;
        jump.conMod = 0.2f;
        jump.mindMod = 0f;
        jump.total = jump.baseValue + (jump.strMod * strength) + (jump.dexMod * dexterity) + (jump.conMod * constitution) + (jump.mindMod * mind);

        critChance.baseValue = 7f;
        critChance.strMod = 0.5f;
        critChance.dexMod = 1f;
        critChance.conMod = 0f;
        critChance.mindMod = 2.5f;
        critChance.total = critChance.baseValue + (critChance.strMod * strength) + (critChance.dexMod * dexterity) + (critChance.conMod * constitution) + (critChance.mindMod * mind);

        insight.baseValue = 10f;
        insight.strMod = 0f;
        insight.dexMod = 0f;
        insight.conMod = 0f;
        insight.mindMod = 1f;
        insight.total = insight.baseValue + (insight.strMod * strength) + (insight.dexMod * dexterity) + (insight.conMod * constitution) + (insight.mindMod * mind);

        will.baseValue = 0f;
        will.strMod = 0.25f;
        will.dexMod = 0.2f;
        will.conMod = 0.5f;
        will.mindMod = 3f;
        will.total = will.baseValue + (will.strMod * strength) + (will.dexMod * dexterity) + (will.conMod * constitution) + (will.mindMod * mind);
    }
}

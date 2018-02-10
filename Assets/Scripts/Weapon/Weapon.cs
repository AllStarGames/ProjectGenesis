using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
[System.Serializable]
public class Weapon : Equipment
{
    public enum Classification
    {
        Axe,
        Bow,
        Cannon,
        Fist,
        Knife,
        Mace,
        Pistol,
        Polearm,
        Rifle,
        Sword,
        Staff,
        TwoHandedAxe,
        TwoHandedSword,
        TwoHandedMace,
        Wand
    }
    public enum WeaponType
    {
        Melee,
        Ranged
    }


    public bool hybrid;
    public string[] augments;
    public Classification weaponClass;
    public Classification secondaryWeaponClass;
    public DamageType damageType;
    public DamageType secondaryDamageType;
    public string[] enchantments;
    [Range(10.0f, 100.0f)]
    public float accuracy;
    [Range(10.0f, 100.0f)]
    public float secondaryAccuracy;
    [Range(0.1f, 100.0f)]
    public float criticalChance;
    [Range(0.1f, 100.0f)]
    public float secondaryCriticalChance;
    public float criticalMulitplier;
    public float secondaryCriticalMultiplier;
    public float damage;
    public float secondaryDamage;
    public float range;
    public float secondaryRange;
    public float speed;
    public float secondarySpeed;
    public int numAugmentSlots;
    public int numEnchantmentSlots;
    public WeaponType weaponType;
    public WeaponType secondaryWeaponType;

    private bool secondaryMode;


    //public Augment[] Augments()
    //{
    //    return augments;
    //}
    public bool Hybrid()
    {
        return hybrid;
    }
    public bool InRange(Transform me, Transform target)
    {
        UpdateMode(Vector3.Distance(me.position, target.position));

        if (secondaryMode)
        {
            return Vector3.Distance(me.position, target.position) <= secondaryRange;
        }
        return Vector3.Distance(me.position, target.position) <= range;
    }
    public bool SecondaryMode()
    {
        return secondaryMode;
    }
    public Classification WeaponClass()
    {
        return weaponClass;
    }
    public Classification SecondaryWeaponClass()
    {
        return secondaryWeaponClass;
    }
    public DamageType PrimaryDamageType()
    {
        return damageType;
    }
    public DamageType SecondaryDamageType()
    {
        return secondaryDamageType;
    }
    //public Enchantment[] Enchantments()
    //{
    //    return enchantments;
    //}
    public float Accuracy()
    {
        return accuracy;
    }
    public float CalculateSpeed()
    {
        float totalSpeed = 0.0f;

        if(secondaryMode)
        {
            totalSpeed = secondarySpeed;

            switch (secondaryWeaponClass)
            {
                case Classification.Axe:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().axeSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Bow:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().bowSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Cannon:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().cannonSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Knife:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().knifeSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Mace:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().maceSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Pistol:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().pistolSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Polearm:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().polearmSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Rifle:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().rifleSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Sword:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().swordSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Staff:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().staffSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.TwoHandedAxe:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().twoHandedAxeSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.TwoHandedMace:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().twoHandedMaceSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.TwoHandedSword:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().twoHandedSwordSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Fist:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().fistSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Wand:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().wandSkill.CurrentSpeedBonus() * 0.01f;
                    break;
            }
        }
        else
        {
            totalSpeed = speed;

            switch (weaponClass)
            {
                case Classification.Axe:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().axeSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Bow:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().bowSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Cannon:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().cannonSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Knife:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().knifeSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Mace:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().maceSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Pistol:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().pistolSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Polearm:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().polearmSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Rifle:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().rifleSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Sword:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().swordSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Staff:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().staffSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.TwoHandedAxe:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().twoHandedAxeSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.TwoHandedMace:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().twoHandedMaceSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.TwoHandedSword:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().twoHandedSwordSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Fist:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().fistSkill.CurrentSpeedBonus() * 0.01f;
                    break;
                case Classification.Wand:
                    totalSpeed -= PlayerManager.GetPlayerWeaponSkills().wandSkill.CurrentSpeedBonus() * 0.01f;
                    break;
            }
        }

        return totalSpeed;
    }
    public float CalculateDamage()
    {
        float totalAccuracy = 0.0f;
        float totalCritChance = 0.0f;
        float totalDamage = 0.0f;
        float chance = Random.Range(0.0f, 100.0f);

        if(secondaryMode)
        {
            totalAccuracy += secondaryAccuracy;
            totalCritChance += secondaryCriticalChance;

            switch (secondaryWeaponClass)
            {
                case Classification.Axe:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().axeSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().axeSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().axeSkill.CurrentDamageBonus();
                    break;
                case Classification.Bow:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().bowSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().bowSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().bowSkill.CurrentDamageBonus();
                    break;
                case Classification.Cannon:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().cannonSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().cannonSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().cannonSkill.CurrentDamageBonus();
                    break;
                case Classification.Knife:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().knifeSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().knifeSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().knifeSkill.CurrentDamageBonus();
                    break;
                case Classification.Mace:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().maceSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().maceSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().maceSkill.CurrentDamageBonus();
                    break;
                case Classification.Pistol:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().pistolSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().pistolSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().pistolSkill.CurrentDamageBonus();
                    break;
                case Classification.Polearm:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().polearmSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().polearmSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().polearmSkill.CurrentDamageBonus();
                    break;
                case Classification.Rifle:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().rifleSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().rifleSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().rifleSkill.CurrentDamageBonus();
                    break;
                case Classification.Sword:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().swordSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().swordSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().swordSkill.CurrentDamageBonus();
                    break;
                case Classification.Staff:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().staffSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().staffSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().staffSkill.CurrentDamageBonus();
                    break;
                case Classification.TwoHandedAxe:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().twoHandedAxeSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().twoHandedAxeSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().twoHandedAxeSkill.CurrentDamageBonus();
                    break;
                case Classification.TwoHandedMace:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().twoHandedMaceSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().twoHandedMaceSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().twoHandedMaceSkill.CurrentDamageBonus();
                    break;
                case Classification.TwoHandedSword:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().twoHandedSwordSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().twoHandedSwordSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().twoHandedSwordSkill.CurrentDamageBonus();
                    break;
                case Classification.Fist:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().fistSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().fistSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().fistSkill.CurrentDamageBonus();
                    break;
                case Classification.Wand:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().wandSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().wandSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().wandSkill.CurrentDamageBonus();
                    break;
            }

            if (chance > totalAccuracy)
            {
                return 0.0f;
            }
            chance = Random.Range(0.0f, 100.0f);
            if (chance <= totalCritChance)
            {
                totalDamage += (secondaryDamage * secondaryCriticalMultiplier);
            }
            totalDamage += secondaryDamage;
        }
        else
        {
            totalAccuracy += accuracy;
            totalCritChance += criticalChance;

            switch (weaponClass)
            {
                case Classification.Axe:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().axeSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().axeSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().axeSkill.CurrentDamageBonus();
                    break;
                case Classification.Bow:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().bowSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().bowSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().bowSkill.CurrentDamageBonus();
                    break;
                case Classification.Cannon:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().cannonSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().cannonSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().cannonSkill.CurrentDamageBonus();
                    break;
                case Classification.Knife:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().knifeSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().knifeSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().knifeSkill.CurrentDamageBonus();
                    break;
                case Classification.Mace:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().maceSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().maceSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().maceSkill.CurrentDamageBonus();
                    break;
                case Classification.Pistol:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().pistolSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().pistolSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().pistolSkill.CurrentDamageBonus();
                    break;
                case Classification.Polearm:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().polearmSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().polearmSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().polearmSkill.CurrentDamageBonus();
                    break;
                case Classification.Rifle:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().rifleSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().rifleSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().rifleSkill.CurrentDamageBonus();
                    break;
                case Classification.Sword:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().swordSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().swordSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().swordSkill.CurrentDamageBonus();
                    break;
                case Classification.Staff:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().staffSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().staffSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().staffSkill.CurrentDamageBonus();
                    break;
                case Classification.TwoHandedAxe:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().twoHandedAxeSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().twoHandedAxeSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().twoHandedAxeSkill.CurrentDamageBonus();
                    break;
                case Classification.TwoHandedMace:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().twoHandedMaceSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().twoHandedMaceSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().twoHandedMaceSkill.CurrentDamageBonus();
                    break;
                case Classification.TwoHandedSword:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().twoHandedSwordSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().twoHandedSwordSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().twoHandedSwordSkill.CurrentDamageBonus();
                    break;
                case Classification.Fist:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().fistSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().fistSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().fistSkill.CurrentDamageBonus();
                    break;
                case Classification.Wand:
                    totalAccuracy += PlayerManager.GetPlayerWeaponSkills().wandSkill.CurrentAccuracyBonus() * 0.1f;
                    totalCritChance += PlayerManager.GetPlayerWeaponSkills().wandSkill.CurrentCriticalChanceBonus();
                    totalDamage += PlayerManager.GetPlayerWeaponSkills().wandSkill.CurrentDamageBonus();
                    break;
            }

            if (chance > totalAccuracy)
            {
                return 0.0f;
            }
            chance = Random.Range(0.0f, 100.0f);
            if (chance <= totalCritChance)
            {
                totalDamage += (damage * criticalMulitplier);
            }
            totalDamage += damage;
        }
        
        return totalDamage;
    }
    public float CriticalChance()
    {
        return criticalChance;
    }
    public float CriticalMultiplier()
    {
        return criticalMulitplier;
    }
    public float Damage()
    {
        return damage;
    }
    public float Range()
    {
        return range;
    }
    public float Speed()
    {
        return speed;
    }
    public float SecondaryAccuracy()
    {
        return secondaryAccuracy;
    }
    public float SecondaryCriticalChance()
    {
        return secondaryCriticalChance;
    }
    public float SecondaryCriticalMultiplier()
    {
        return secondaryCriticalMultiplier;
    }
    public float SecondaryDamage()
    {
        return secondaryDamage;
    }
    public float SecondaryRange()
    {
        return secondaryRange;
    }
    public float SecondarySpeed()
    {
        return secondarySpeed;
    }
    public int NumAugmentSlots()
    {
        return numAugmentSlots;
    }
    public int NumEnchantmentSlots()
    {
        return numEnchantmentSlots;
    }
    public void GrantClassExperience(int value)
    {
        if(secondaryMode)
        {
            switch (secondaryWeaponClass)
            {
                case Weapon.Classification.Axe:
                    PlayerManager.GetPlayerWeaponSkills().axeSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Bow:
                    PlayerManager.GetPlayerWeaponSkills().bowSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Cannon:
                    PlayerManager.GetPlayerWeaponSkills().cannonSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Knife:
                    PlayerManager.GetPlayerWeaponSkills().knifeSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Mace:
                    PlayerManager.GetPlayerWeaponSkills().maceSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Pistol:
                    PlayerManager.GetPlayerWeaponSkills().pistolSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Polearm:
                    PlayerManager.GetPlayerWeaponSkills().polearmSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Rifle:
                    PlayerManager.GetPlayerWeaponSkills().rifleSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Staff:
                    PlayerManager.GetPlayerWeaponSkills().staffSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Sword:
                    PlayerManager.GetPlayerWeaponSkills().swordSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.TwoHandedAxe:
                    PlayerManager.GetPlayerWeaponSkills().twoHandedAxeSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.TwoHandedMace:
                    PlayerManager.GetPlayerWeaponSkills().twoHandedMaceSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.TwoHandedSword:
                    PlayerManager.GetPlayerWeaponSkills().twoHandedSwordSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Fist:
                    PlayerManager.GetPlayerWeaponSkills().fistSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Wand:
                    PlayerManager.GetPlayerWeaponSkills().wandSkill.GrantExperience(value);
                    break;
            }
        }
        else
        {
            switch (weaponClass)
            {
                case Weapon.Classification.Axe:
                    PlayerManager.GetPlayerWeaponSkills().axeSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Bow:
                    PlayerManager.GetPlayerWeaponSkills().bowSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Cannon:
                    PlayerManager.GetPlayerWeaponSkills().cannonSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Knife:
                    PlayerManager.GetPlayerWeaponSkills().knifeSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Mace:
                    PlayerManager.GetPlayerWeaponSkills().maceSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Pistol:
                    PlayerManager.GetPlayerWeaponSkills().pistolSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Polearm:
                    PlayerManager.GetPlayerWeaponSkills().polearmSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Rifle:
                    PlayerManager.GetPlayerWeaponSkills().rifleSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Staff:
                    PlayerManager.GetPlayerWeaponSkills().staffSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Sword:
                    PlayerManager.GetPlayerWeaponSkills().swordSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.TwoHandedAxe:
                    PlayerManager.GetPlayerWeaponSkills().twoHandedAxeSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.TwoHandedMace:
                    PlayerManager.GetPlayerWeaponSkills().twoHandedMaceSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.TwoHandedSword:
                    PlayerManager.GetPlayerWeaponSkills().twoHandedSwordSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Fist:
                    PlayerManager.GetPlayerWeaponSkills().fistSkill.GrantExperience(value);
                    break;
                case Weapon.Classification.Wand:
                    PlayerManager.GetPlayerWeaponSkills().wandSkill.GrantExperience(value);
                    break;
            }
        }
        
    }
    public void IsHybrid(bool value)
    {
        hybrid = value;
    }
    public void IsIndestructable(bool value)
    {
        indestructable = value;
    }
    public void UpdateMode(float distance)
    {
        if(hybrid)
        {
            //primarry range is greater
            if(range >= secondaryRange)
            {
                //do range check
                if (distance <= range && distance > secondaryRange)
                {
                    secondaryMode = false;
                }
                else
                {
                    secondaryMode = true;
                }
            }
            else
            {
                if(distance <= secondaryRange && distance > range)
                {
                    secondaryMode = true;
                }
                else
                {
                    secondaryMode = false;
                }
            }
        }
        else
        {
            secondaryMode = false;
        }
    }
    public WeaponType PrimaryWeaponType()
    {
        return weaponType;
    }
    public WeaponType SecondaryWeaponType()
    {
        return secondaryWeaponType;
    }
}*/
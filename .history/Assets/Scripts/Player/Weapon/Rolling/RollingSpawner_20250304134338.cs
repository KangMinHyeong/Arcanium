using UnityEngine;

public class RollingSpawner : WeaponBase
{
    GameObject Rollings;

    int RollingNumber = 3;

    protected override void Start()
    {
        base.Start();

        bRunning = false;
        SpwanRolling(RollingNumber);
    }

    void SpwanRolling(int SpawnNum)
    {
        if(Rollings) Destroy(Rollings);

        Rollings = new GameObject("Root");

        for(int i = 0; i<SpawnNum; i++)
        {
            AddLocation_X[i] = FMath::Cos(Degree * i); AddLocation_Y[i] =  FMath::Sin(Degree * i);
            FVector AddLocation = FVector(AddLocation_X[i], AddLocation_Y[i], 0.0f) * Distance;

            auto ClutchTrigger = GetWorld()->SpawnActor<AClutchTrigger>(ClutchTriggerClass, GetActorLocation() + AddLocation, GetActorRotation(), SpawnParams);
            if(ClutchTrigger) 
            {
                ClutchTrigger->SetOwner(this); 
                ClutchTrigger->AttachToComponent( ClutchRoot, FAttachmentTransformRules ::KeepWorldTransform);
                ClutchTrigger->SetClutchSphere(Wide/2.0f);
                ClutchTrigger->SetDestroy(DestroyTime);
                ClutchTrigger->SetSlowPercent(SlowPercent);
                ClutchTrigger->SetSkill(SkillAbilityData, SkillComp.Get());
            }
        }
    }

    protected override bool EnhanceWeapon()
    {
        bool check = base.EnhanceWeapon();
        if(!check) return false;

        // To Do : 강화 적용 (외형 및 능력치)
        switch (weaponState)
        {
        case WeaponState.Level_1:
            break;

        case WeaponState.Level_2:
            WeaponData.WeaponATK += 5;
            break;

        case WeaponState.Level_3:
            WeaponData.WeaponATK += 15;
            break;
        }
        
        return check;
    }

    protected override void AttackTrigger()
    {
        Debug.Log("AttackTrigger");
    }
}

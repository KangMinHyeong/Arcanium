using UnityEngine;

public class RollingSpawner : WeaponBase
{
    [SerializeField] GameObject RollingRoot;
    [SerializeField] GameObject RollingPrefab;
    [SerializeField] float Distance = 2.0f;

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
        
        float Degree = 360.0f / SpawnNum;
        for(int i = 0; i<SpawnNum; i++)
        {
            float AddLocation_X = Mathf.Cos(Degree * i);
            float AddLocation_Y = Mathf.Sin(Degree * i);
            Vector3 AddLocation = new Vector3(AddLocation_X, 0.0f, AddLocation_Y) * Distance;

            var ClutchTrigger = GetWorld()->SpawnActor<AClutchTrigger>(ClutchTriggerClass, GetActorLocation() + AddLocation, GetActorRotation(), SpawnParams);
            Instantiate()
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

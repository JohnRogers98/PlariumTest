using System;

public class Body
{
    public Int32 Health { get; private set; }

    public Single Speed { get; private set; }

    public void InitializeStates(BodyLevel level)
    {
        if (level == BodyLevel.LevelOne)
        {
            Health = 2;
            Speed = GameData.tankSpeed;
        }
        if (level == BodyLevel.LevelTwo)
        {
            Health = 4;
            Speed = GameData.tankSpeed / 1.5f;
        }
        if (level == BodyLevel.LevelThree)
        {
            Health = 6;
            Speed = GameData.tankSpeed / 2f;
        }
    }

    public Boolean DecreaseHealth(Int32 damage)
    {
        Boolean isAlive = false;

        Health -= damage;

        if (Health > 0)
        {
            isAlive = true;
        }
        return isAlive;
    }
}


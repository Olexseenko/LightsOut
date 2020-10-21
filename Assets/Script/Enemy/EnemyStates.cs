using System.Collections.Generic;

public class EnemyStates
{
    public enum State
    {
        PATROL,
        FREE_PATROL,
        CHASE,
        ATTACK,
        SEEK,
        IDLE
    }

    public static Dictionary<State, string> StatesNames = new Dictionary<State, string> {
        { State.PATROL, "PATROL"},
        { State.FREE_PATROL, "FREE_PATROL"},
        { State.CHASE, "CHASE"},
        { State.ATTACK, "ATTACK"},
        { State.SEEK, "SEEK"},
        { State.IDLE, "IDLE"}
    };
}

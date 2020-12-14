using System;
using System.Collections.Generic;
using UnityEngine;

public static class Command
{
    public const int COMMAND_MOVE = 0;
    public const int COMMAND_PHOTOSYNTHESIS = 1;
    public const int COMMAND_COPY = 2;
    public const int COMMAND_ATTACK = 3;

    public const int directionsAmount = 8;

    public static readonly Vector2[] spin = new Vector2[] {
        new Vector2(1,0),   // right
        new Vector2(-1,0),  // left
        new Vector2(0,1),   // up
        new Vector2(0,-1),  // down
        new Vector2(1,1),   // up right
        new Vector2(-1,-1), // down left
        new Vector2(1,-1),  // down right
        new Vector2(-1,1)   // up left
    };
}

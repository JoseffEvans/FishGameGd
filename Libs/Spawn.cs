using Godot;
using System;

public class Spawn { 
    readonly Main Main;
    readonly Random Random;
    const int FromBorder = 120;

    public Spawn(Main main) {
        Main = main;
        Random = new Random();
    }

    public SpawnInfo OffScreenSpawn(Sprite2D fish) {
        var viewport = Main.GetViewport().GetVisibleRect().Size;
        var rect = fish.GetRect();

        var side = Random.Next(2) == 0;
        var left = -FromBorder - rect.Size.X;
        var right = FromBorder + viewport.X + rect.Size.X;
        var y = Random.Next((int)viewport.Y);

        return new SpawnInfo {
            Left = side,
            SpawnPoint = new Vector2(side ? left : right,y),
            Goal = new Vector2(side ? right : left,y)
        };
    }
}

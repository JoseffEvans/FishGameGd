using Godot;

public class Resources {
    private PackedScene _enemy;
    private const string EnemyLocation = "res://Fish/EnemyFish.tscn";
    public PackedScene Enemy {
        get => _enemy ??= (PackedScene)ResourceLoader.Load(EnemyLocation);
    }
    public EnemyFish NewEnemy() => (EnemyFish)Enemy.Instantiate();

    private PackedScene _fish;
    private const string FishLocation = "res://Fish/Fish.tscn";
    public PackedScene Fish {
        get => _fish ??= (PackedScene)ResourceLoader.Load(FishLocation);
    }
    public Fish NewFish() => (Fish)Fish.Instantiate();


    public Resources() { }

}

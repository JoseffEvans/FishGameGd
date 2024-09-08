using Godot;

public class MouseControl {

    readonly Main Main;
    Vector2 PrevPos;

    public MouseControl(Main main) {
        Main = main;
        PrevPos = CalcLockPosition();
    }

    public Vector2 CalcLockPosition() =>
        Main.GetViewport().GetVisibleRect().Size / 2;

    public Vector2 CalcMovementAndReset() {
        var movement = Main.GetViewport().GetMousePosition() - PrevPos;
        var mouseLock = CalcLockPosition();

        Input.WarpMouse(mouseLock);
        PrevPos = mouseLock;

        return movement;
    }
}

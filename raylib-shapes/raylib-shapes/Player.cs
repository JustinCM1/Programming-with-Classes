using Raylib_cs;
using System.Numerics;
class Player: GameObject {

    Texture2D texture;

    public Player() {
        
        var image = Raylib.LoadImage("link.png");
        this.texture = Raylib.LoadTextureFromImage(image);
        Raylib.UnloadImage(image);
    }

    public Rectangle Rect() {
        return new Rectangle(Position.X, Position.Y, 50, 53);
    }

    public override void Move()
    {
        // Reset the velocity every frame unless keys are being pressed
        var velocity = new Vector2();
        var movementSpeed = 3;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
            velocity.X = movementSpeed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
            velocity.X = -movementSpeed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) {
            velocity.Y = -movementSpeed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) {
            velocity.Y = movementSpeed;
        }

        Velocity = velocity;

        base.Move();
    }

    public override void Draw() {
        Raylib.DrawTexture(this.texture, (int)Position.X, (int)Position.Y, Color.WHITE);
    }
}
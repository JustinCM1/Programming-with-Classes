using Raylib_cs;
using System.Numerics;

class ShapeLand {

    Random Rdm = new Random();

    private Vector2 RandomPosition(int height, int width) {
        var x = Rdm.Next(0, width);
        var y = Rdm.Next(0, height);
        return new Vector2(x, y);
    }

    private int RdmNum() {
        return Rdm.Next(25, 100);
    }

    public void Play() {
        var ScreenHeight = 720;
        var ScreenWidth = 1280;

        Raylib.InitWindow(ScreenWidth, ScreenHeight, "Shape Land");
        Raylib.SetTargetFPS(60);

        var Player = new Player();
        var Title = new GameText("Link! Please find the area of all the shapes. -Zelda", Color.WHITE);
        var Objects = new List<GameObject>();
        var CountOfEachShape = 10;

        Player.Position = new Vector2(ScreenWidth / 2, ScreenHeight - 100);
        Title.Position = new Vector2(20);

        for (int i = 0; i < CountOfEachShape; i++) {
            var square = new GameSquare(RdmNum(), Color.GREEN);
            square.Position = RandomPosition(ScreenHeight, ScreenWidth);
            Objects.Add(square);

            var circle = new GameCircle(RdmNum(), Color.RED);
            circle.Position = RandomPosition(ScreenHeight, ScreenWidth);
            Objects.Add(circle);

            var rectangle = new GameRectangle(RdmNum(), RdmNum(), Color.BLUE);
            rectangle.Position = RandomPosition(ScreenHeight, ScreenWidth);
            Objects.Add(rectangle);
        }

        Objects.Add(Player);
        Objects.Add(Title);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            // Draw all of the objects in their current location
            foreach (var obj in Objects) {
                obj.Draw();
            }

            // Check if link is on any of the shapes
            foreach (var obj in Objects) {
                if (obj is Shape) {
                    var shape = (Shape)obj;
                    if (Raylib.CheckCollisionRecs(Player.Rect(), shape.CollisionRect())) {
                        var message = $"The area of this {shape.Name()} is {shape.Area()}";
                        Raylib.DrawText(message, 100, 100, 20, Color.WHITE);
                    }
                }
            }

            Raylib.EndDrawing();

            // Move all of the objects to their next location
            foreach (var obj in Objects) {
                obj.Move();
            }
        }

        Raylib.CloseWindow();
    }
}
using System;
using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;


namespace PerilousMobile
{
    public partial class Game
    {

        public int blockSize = 20;

        public SKPath blockPath = new SKPath();
        public SKPath playerPath = new SKPath();
        public SKPath exitPath = new SKPath();
        public SKPath monsterPath = new SKPath();
        public SKPath weaponPath = new SKPath();
        public SKPath princessPath = new SKPath();
        public SKPath foodPath = new SKPath();
        public SKPath puzzlePath = new SKPath();
        public SKPath lootPath = new SKPath();

        public SKPaint blockPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Black
        };

        public SKPaint playerPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.LightGoldenrodYellow
        };

        public SKPaint exitPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.LightGreen
        };

        public SKPaint monsterPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Red
        };

        public SKPaint weaponPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Red
        };

        public SKPaint princessPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.White
        };

        public SKPaint foodPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.LawnGreen
        };

        public SKPaint puzzlePaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Blue
        };

        public SKPaint lootPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Gold
        };

        public void SkiaSetup() 
        {
            // square
            blockPath.MoveTo(0, 0);
            blockPath.LineTo(0, blockSize);
            blockPath.LineTo(blockSize, blockSize);
            blockPath.LineTo(blockSize, 0);
            blockPath.Close();

            // triangle
            playerPath.MoveTo(0, 0);
            playerPath.LineTo(blockSize, 0);
            playerPath.LineTo(blockSize/2, blockSize);
            playerPath.Close();

            // triangle
            princessPath.MoveTo(0, 0);
            princessPath.LineTo(blockSize, 0);
            princessPath.LineTo(blockSize / 2, blockSize);
            princessPath.Close();

            // triangle
            monsterPath.MoveTo(0, 0);
            monsterPath.LineTo(blockSize, 0);
            monsterPath.LineTo(blockSize / 2, blockSize);
            monsterPath.Close();

            // square
            exitPath.MoveTo(0, 0);
            exitPath.LineTo(0, blockSize);
            exitPath.LineTo(blockSize, blockSize);
            exitPath.LineTo(blockSize, 0);
            exitPath.Close();

            // circle
            weaponPath.AddCircle(blockSize/2, blockSize/2, blockSize/2, SKPathDirection.Clockwise);
            weaponPath.Close();

            // circle
            foodPath.AddCircle(blockSize / 2, blockSize / 2, blockSize / 2, SKPathDirection.Clockwise);
            foodPath.Close();

            // circle
            lootPath.AddCircle(blockSize / 2, blockSize / 2, blockSize / 2, SKPathDirection.Clockwise);
            lootPath.Close();

            // diamond
            puzzlePath.MoveTo(blockSize * 0.5f, 0);
            puzzlePath.LineTo(blockSize, blockSize * 0.5f);
            puzzlePath.LineTo(blockSize * 0.5f, blockSize);
            puzzlePath.LineTo(0, blockSize * 0.5f);
            puzzlePath.Close();
        }


        public void DrawMap(SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.CornflowerBlue);
            // work out how many blocks we can fit across/down the grid, and set our scaling factor
            canvas.Scale((1.0f * (e.Info.Width/blockSize)/blockSize), 
                (1.0f * (e.Info.Height/blockSize)/blockSize));

            canvas.Save();

            for (int y = 0; y < yDim; y++)
            {
                for (int x = 0; x < xDim; x++)
                {
                    canvas.Save();
                    canvas.Translate(x * blockSize, y * blockSize);

                    if ((x == xPlayer) && (y == yPlayer))
                    {
                        canvas.DrawPath(playerPath, playerPaint); 
                    }
                    else
                    if (App.game.PlayerCanSeeLocation(x, y))
                    {
                        switch (map[x, y]) {
                            case MapContent.ClearSpace:
                                // nothing to do
                                break;
                            case MapContent.InvalidSpace: 
                                canvas.DrawPath(blockPath, blockPaint);
                                break;
                            case MapContent.PrincessSpace:
                                canvas.DrawPath(princessPath, princessPaint);
                                break;
                            case MapContent.ExitSpace:
                                canvas.DrawPath(exitPath, exitPaint);
                                break;
                            case MapContent.LootSpace:
                                canvas.DrawPath(lootPath, lootPaint);
                                break;
                            case MapContent.PuzzleSpace:
                                canvas.DrawPath(puzzlePath, puzzlePaint);
                                break;
                            case MapContent.MonsterSpace:
                                canvas.DrawPath(monsterPath, monsterPaint);
                                break;
                            case MapContent.WeaponSpace:
                                canvas.DrawPath(weaponPath, weaponPaint);
                                break;
                            case MapContent.FoodSpace:
                                canvas.DrawPath(foodPath, foodPaint);
                                break;
                        }
                    }
                    else
                    {
                        canvas.DrawPath(blockPath, blockPaint);
                    }
                    canvas.Restore();
                }
            }

            canvas.Restore();

        }

    }

}

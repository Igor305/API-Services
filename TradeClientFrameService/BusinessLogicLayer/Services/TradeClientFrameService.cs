using BusinessLogicLayer.Services.Interfaces;
using System.Drawing;

namespace BusinessLogicLayer.Services
{
    public class TradeClientFrameService : ITradeClientFrameService
    {
        public void Drawtext()
        {
            Bitmap b = new Bitmap(450, 150);
            using (Graphics g = Graphics.FromImage(b))
            {
                Font font = new Font("Arial", 21);
                SolidBrush drawBrush = new SolidBrush(Color.Gray);

                float x = 35;
                float y = 0;

                g.Clear(Color.White);
                g.DrawString("Месяц", font, drawBrush,x,y);

                Pen pen = new Pen(Color.Gray, 3);

                Point[] points =
                {
                     new Point(35, 10),
                     new Point(10, 10),
                     new Point(10, 140),
                     new Point(440, 140),
                     new Point(440, 10),
                     new Point(130, 10)
                };
                g.DrawLines(pen, points);

                font = new Font("Arial", 50);
                drawBrush = new SolidBrush(Color.Red);
                x = 10; 
                y = 50;

                g.DrawString("104,1%", font, drawBrush, x, y);

                font = new Font("Arial", 25);
                drawBrush = new SolidBrush(Color.Gray);
                x = 250;
                y = 30;

                g.DrawString("Ф: 1333725", font, drawBrush, x, y);

                font = new Font("Arial", 25);
                drawBrush = new SolidBrush(Color.Gray);
                x = 250;
                y = 80;

                g.DrawString("П: 1294463", font, drawBrush, x, y);

            }
            b.Save("1.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

        }
    }
}

using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class TradeClientFrameService : ITradeClientFrameService
    {
        private readonly IitExecutionPlanShopRepository _iitExecutionPlanShopRepository;
        private readonly IMapper _mapper;

        public TradeClientFrameService (IitExecutionPlanShopRepository iitExecutionPlanShopRepository, IMapper mapper)
        {
            _iitExecutionPlanShopRepository = iitExecutionPlanShopRepository;
            _mapper = mapper;
        }

        public async Task getImagePerDay(int stockId)
        {
            stockId = FirstShop(stockId);

            ItExecutionPlanShop itExecutionPlanShop = await _iitExecutionPlanShopRepository.getInfoForStockId(stockId);

            ItExecutionPlanShopModel itExecutionPlanShopModel = _mapper.Map<ItExecutionPlanShop, ItExecutionPlanShopModel>(itExecutionPlanShop);
            
            getImagePlanDay(itExecutionPlanShopModel);
        }

        public async Task getImagePerMonth(int stockId)
        {
            stockId = FirstShop(stockId);

            ItExecutionPlanShop itExecutionPlanShop = await _iitExecutionPlanShopRepository.getInfoForStockId(stockId);

            ItExecutionPlanShopModel itExecutionPlanShopModel = _mapper.Map<ItExecutionPlanShop, ItExecutionPlanShopModel>(itExecutionPlanShop);

            getImagePlanMonth(itExecutionPlanShopModel);
        }

        public async Task getImagePerForecast(int stockId)
        {
            stockId = FirstShop(stockId);

            ItExecutionPlanShop itExecutionPlanShop = await _iitExecutionPlanShopRepository.getInfoForStockId(stockId);

            ItExecutionPlanShopModel itExecutionPlanShopModel = _mapper.Map<ItExecutionPlanShop, ItExecutionPlanShopModel>(itExecutionPlanShop);

            getImageForecast(itExecutionPlanShopModel);
        }

        public async Task getAllInOneImage(int stockId)
        {
            stockId = FirstShop(stockId);

            ItExecutionPlanShop itExecutionPlanShop = await _iitExecutionPlanShopRepository.getInfoForStockId(stockId);
            
            ItExecutionPlanShopModel itExecutionPlanShopModel = _mapper.Map<ItExecutionPlanShop, ItExecutionPlanShopModel>(itExecutionPlanShop);

            getAllInOneImage(itExecutionPlanShopModel);
        }

        private Bitmap getAllInOneImage(ItExecutionPlanShopModel itExecutionPlanShopModel)
        {
            Bitmap bitmap = new Bitmap(721, 60);
            using (Graphics graphic = Graphics.FromImage(bitmap))
            {
                // Day

                int nDigitsFactDay = 0;
                int nDigitsPlanDay = 0;

                if (itExecutionPlanShopModel != null)
                {
                    nDigitsFactDay = nDigits(itExecutionPlanShopModel.FactDay);
                    nDigitsPlanDay = nDigits(itExecutionPlanShopModel.PlanDay);
                }

                if (nDigitsFactDay == 0)
                {
                    nDigitsFactDay++;
                }

                if (nDigitsPlanDay == 0)
                {
                    nDigitsPlanDay++;
                }
                Font font = new Font("Verdana", 11);
                SolidBrush drawBrush = new SolidBrush(Color.Gray);

                float x = 11;
                float y = 0;

                graphic.Clear(Color.FromArgb(239, 239, 239));
                graphic.DrawString("Сегодня", font, drawBrush, x, y);

                Pen pen = new Pen(Color.Gray, 3);

                Point[] points =
                {
                     new Point(10, 7),
                     new Point(1, 7),
                     new Point(1, 58),
                     new Point(719, 58),
                     new Point(719, 7),
                     new Point(675, 7)
                };
                graphic.DrawLines(pen, points);

                Point[] points2 =
                {
                       new Point(605, 7),
                       new Point(328, 7)
                };
                graphic.DrawLines(pen, points2);

                Point[] points3=
                {
                       new Point(275, 7),
                       new Point(80, 7)
                };
                graphic.DrawLines(pen, points3);

                Point[] points4 =
                {
                       new Point(263, 7),
                       new Point(263, 57)
                };
                graphic.DrawLines(pen, points4);

                Point[] points5 =
                {
                       new Point(570, 7),
                       new Point(570, 57)
                };
                graphic.DrawLines(pen, points5);

                Decimal decPercentForDay = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decPercentForDay = Convert.ToDecimal(itExecutionPlanShopModel.PercentForDay);
                }

                string percentForDay = $"{Math.Round(decPercentForDay, 1)}%";

                font = new Font("Verdana", 21);

                if (decPercentForDay < 100)
                {
                    drawBrush = new SolidBrush(Color.Red);
                }

                if (decPercentForDay >= 100)
                {
                    drawBrush = new SolidBrush(Color.Green);
                }

                x = 25;
                y = 25;

                graphic.DrawString(percentForDay, font, drawBrush, x, y);

                string text = $"Выполнение плана на сегодня";
                font = new Font("Verdana", 8);
                drawBrush = new SolidBrush(Color.Gray);
                x = 80;
                y = 10;

                graphic.DrawString(text, font, drawBrush, x, y);

                string f = $"Факт:";
                font = new Font("Verdana", 10);
                drawBrush = new SolidBrush(Color.Gray);
                x = 165;
                y = 27;

                graphic.DrawString(f, font, drawBrush, x, y);

                Decimal decFactDay = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decFactDay = Convert.ToDecimal(itExecutionPlanShopModel.FactDay);
                }

                string formatFactDay = formatDecimal(decFactDay);
                string factDay = $"{formatFactDay}";

                font = new Font("Verdana", 10);
                drawBrush = new SolidBrush(Color.Gray);
                x = 250 - (nDigitsFactDay * 5) - 10;
                y = 27;

                graphic.DrawString(factDay, font, drawBrush, x, y);

                string p = $"План:";
                font = new Font("Verdana", 10);
                drawBrush = new SolidBrush(Color.Gray);
                x = 165;
                y = 40;

                graphic.DrawString(p, font, drawBrush, x, y);

                Decimal decPlanDay = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decPlanDay = Convert.ToDecimal(itExecutionPlanShopModel.PlanDay);
                }

                string formatPlanDay = formatDecimal(decPlanDay);
                string planDay = $"{formatPlanDay}";

                font = new Font("Verdana", 10);
                drawBrush = new SolidBrush(Color.Gray);
                x = 250 - (nDigitsPlanDay * 5) - 10;
                y = 40;

                graphic.DrawString(planDay, font, drawBrush, x, y);

                // Month

                int nDigitsFactMonth = 0;
                int nDigitsPlanMonth = 0;

                if (itExecutionPlanShopModel != null)
                {
                    nDigitsFactMonth = nDigits(itExecutionPlanShopModel.FactMonth);
                    nDigitsPlanMonth = nDigits(itExecutionPlanShopModel.PlanMonth);
                }

                if (nDigitsFactMonth == 0)
                {
                    nDigitsFactMonth++;
                }

                if (nDigitsPlanMonth == 0)
                {
                    nDigitsPlanMonth++;
                }

                font = new Font("Verdana", 11);
                drawBrush = new SolidBrush(Color.Gray);

                x = 275;
                y = 0;

                graphic.DrawString("Месяц", font, drawBrush, x, y);

                Decimal decPercentForMonth = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decPercentForMonth = Convert.ToDecimal(itExecutionPlanShopModel.PercentForMonth);
                }

                string percentForMonth = $"{Math.Round(decPercentForMonth, 1)}%";

                font = new Font("Verdana", 21);

                if (decPercentForMonth < 100)
                {
                    drawBrush = new SolidBrush(Color.Red);
                }

                if (decPercentForMonth >= 100)
                {
                    drawBrush = new SolidBrush(Color.Green);
                }

                x = 303;
                y = 25;

                graphic.DrawString(percentForMonth, font, drawBrush, x, y);

                string textMonth = $"Выполнение c начала месяца по сегодня";
                font = new Font("Verdana", 8);
                drawBrush = new SolidBrush(Color.Gray);
                x = 330;
                y = 10;

                graphic.DrawString(textMonth, font, drawBrush, x, y);

                f = $"Факт:";
                font = new Font("Verdana", 10);
                drawBrush = new SolidBrush(Color.Gray);
                x = 458;
                y = 27;

                graphic.DrawString(f, font, drawBrush, x, y);

                Decimal decFactMonth = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decFactMonth = Convert.ToDecimal(itExecutionPlanShopModel.FactMonth);
                }

                string formatFactMonth = formatDecimal(decFactMonth);
                string factMonth = $"{formatFactMonth}";

                font = new Font("Verdana", 10);
                drawBrush = new SolidBrush(Color.Gray);
                x = 545 - (nDigitsFactMonth * 5) - 10;
                y = 27;

                graphic.DrawString(factMonth, font, drawBrush, x, y);

                p = $"План:";
                font = new Font("Verdana", 10);
                drawBrush = new SolidBrush(Color.Gray);
                x = 458;
                y = 40;

                graphic.DrawString(p, font, drawBrush, x, y);

                Decimal decPlanMonth = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decPlanMonth = Convert.ToDecimal(itExecutionPlanShopModel.PlanMonth);
                }

                string formatPlanMonth = formatDecimal(decPlanMonth);
                string planMonth = $"{formatPlanMonth}";

                font = new Font("Verdana", 10);
                drawBrush = new SolidBrush(Color.Gray);
                x = 545 - (nDigitsPlanMonth * 5) - 10;
                y = 40;

                graphic.DrawString(planMonth, font, drawBrush, x, y);

                // Forecast

                font = new Font("Verdana", 11);
                drawBrush = new SolidBrush(Color.Gray);

                x = 607;
                y = 0;

                graphic.DrawString("Прогноз", font, drawBrush, x, y);
               
                pen = new Pen(Color.Gray, 3);

                graphic.DrawLines(pen, points);

                Decimal decPercentForForecast = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decPercentForForecast = Convert.ToDecimal(itExecutionPlanShopModel.PercentForecast);
                }

                string textForecast = $"Возможное выполнение";
                font = new Font("Verdana", 8);
                drawBrush = new SolidBrush(Color.Gray);
                x = 572;
                y = 15;

                graphic.DrawString(textForecast, font, drawBrush, x, y);

                textForecast = $"плана на конец месяца";
                font = new Font("Verdana", 8);
                drawBrush = new SolidBrush(Color.Gray);
                x = 574;
                y = 24;

                graphic.DrawString(textForecast, font, drawBrush, x, y);

                string percentForForecast = $"{Math.Round(decPercentForForecast, 1)}%";

                font = new Font("Verdana", 16);

                if (decPercentForForecast < 100)
                {
                    drawBrush = new SolidBrush(Color.Red);
                }

                if (decPercentForForecast >= 100)
                {
                    drawBrush = new SolidBrush(Color.Green);
                }

                x = 610;
                y = 35;

                graphic.DrawString(percentForForecast, font, drawBrush, x, y);
            }

            bitmap.Save("Plan.png", System.Drawing.Imaging.ImageFormat.Png);

            return bitmap;
            
        }

        private int FirstShop(int stockId)
        {
            if (stockId == 1)
            {
                stockId = 100;
            }
            return stockId;
        }

        private Bitmap getImagePlanDay(ItExecutionPlanShopModel itExecutionPlanShopModel)
        {
            Bitmap bitmap = new Bitmap(273, 60);
            using (Graphics graphic = Graphics.FromImage(bitmap))
            {
                int nDigitsFactDay = 0;
                int nDigitsPlanDay = 0;

                if (itExecutionPlanShopModel != null)
                {
                    nDigitsFactDay = nDigits(itExecutionPlanShopModel.FactDay);
                    nDigitsPlanDay = nDigits(itExecutionPlanShopModel.PlanDay);
                }

                if (nDigitsFactDay == 0)
                {
                    nDigitsFactDay++;
                }

                if (nDigitsPlanDay == 0)
                {
                    nDigitsPlanDay++;
                }
                Font font = new Font("Verdana", 12);
                SolidBrush drawBrush = new SolidBrush(Color.Gray);

                float x = 26;
                float y = 0;

                graphic.Clear(Color.FromArgb(239, 239, 239));
                graphic.DrawString("Сегодня", font, drawBrush, x, y);

                Pen pen = new Pen(Color.Gray, 3);

                Point[] points =
                {
                     new Point(25, 7),
                     new Point(1, 7),
                     new Point(1, 57),
                     new Point(271, 57),
                     new Point(271, 7),
                     new Point(100, 7)
                };
                graphic.DrawLines(pen, points);

                Decimal decPercentForDay = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decPercentForDay = Convert.ToDecimal(itExecutionPlanShopModel.PercentForDay);
                }

                string percentForDay = $"{Math.Round(decPercentForDay, 1)}%";

                font = new Font("Verdana", 25);

                if (decPercentForDay < 100)
                {
                    drawBrush = new SolidBrush(Color.Red);
                }

                if (decPercentForDay >= 100)
                {
                    drawBrush = new SolidBrush(Color.Green);
                }

                x = 10;
                y = 15;

                graphic.DrawString(percentForDay, font, drawBrush, x, y);

                string f = $"Ф:";
                font = new Font("Verdana", 16);
                drawBrush = new SolidBrush(Color.Gray);
                x = 130;
                y = 10;

                graphic.DrawString(f, font, drawBrush, x, y);

                Decimal decFactDay = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decFactDay = Convert.ToDecimal(itExecutionPlanShopModel.FactDay);
                }

                string formatFactDay = formatDecimal(decFactDay);
                string factDay = $"{formatFactDay}";

                font = new Font("Verdana", 16);
                drawBrush = new SolidBrush(Color.Gray);
                x = 270 - (nDigitsFactDay * 15) - 10;
                y = 10;

                graphic.DrawString(factDay, font, drawBrush, x, y);

                string p = $"П:";
                font = new Font("Verdana", 16);
                drawBrush = new SolidBrush(Color.Gray);
                x = 130;
                y = 30;

                graphic.DrawString(p, font, drawBrush, x, y);

                Decimal decPlanDay = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decPlanDay = Convert.ToDecimal(itExecutionPlanShopModel.PlanDay);
                }

                string formatPlanDay = formatDecimal(decPlanDay);
                string planDay = $"{formatPlanDay}";

                font = new Font("Verdana", 16);
                drawBrush = new SolidBrush(Color.Gray);
                x = 270 - (nDigitsPlanDay * 15) - 10;
                y = 30;

                graphic.DrawString(planDay, font, drawBrush, x, y);

            }
            bitmap.Save("PlanDay.png", System.Drawing.Imaging.ImageFormat.Png);

            return bitmap;
        } 

        private void getImagePlanMonth(ItExecutionPlanShopModel itExecutionPlanShopModel)
        {
            Bitmap bitmap = new Bitmap(273, 60);
            using (Graphics graphic = Graphics.FromImage(bitmap))
            {
                int nDigitsFactMonth = 0;
                int nDigitsPlanMonth = 0;

                if (itExecutionPlanShopModel != null)
                {
                    nDigitsFactMonth = nDigits(itExecutionPlanShopModel.FactMonth);
                    nDigitsPlanMonth = nDigits(itExecutionPlanShopModel.PlanMonth);
                }

                if (nDigitsFactMonth == 0)
                {
                    nDigitsFactMonth++;
                }

                if (nDigitsPlanMonth == 0)
                {
                    nDigitsPlanMonth++;
                }

                Font font = new Font("Verdana", 12);
                SolidBrush drawBrush = new SolidBrush(Color.Gray);

                float x = 26;
                float y = 0;

                graphic.Clear(Color.FromArgb(239, 239, 239));
                graphic.DrawString("Месяц", font, drawBrush, x, y);

                Pen pen = new Pen(Color.Gray, 3);

                Point[] points =
                {
                     new Point(25, 7),
                     new Point(1, 7),
                     new Point(1, 57),
                     new Point(271, 57),
                     new Point(271, 7),
                     new Point(100, 7)
                };
                graphic.DrawLines(pen, points);

                Decimal decPercentForMonth = 0;

                if (itExecutionPlanShopModel != null) 
                {
                    decPercentForMonth = Convert.ToDecimal(itExecutionPlanShopModel.PercentForMonth);
                }

                string percentForMonth = $"{Math.Round(decPercentForMonth, 1)}%";

                font = new Font("Verdana", 25);

                if (decPercentForMonth < 100)
                {
                    drawBrush = new SolidBrush(Color.Red);
                }

                if (decPercentForMonth >= 100)
                {
                    drawBrush = new SolidBrush(Color.Green);
                }

                x = 10;
                y = 15;

                graphic.DrawString(percentForMonth, font, drawBrush, x, y);

                string f = $"Ф:";
                font = new Font("Verdana", 16);
                drawBrush = new SolidBrush(Color.Gray);
                x = 130;
                y = 10;

                graphic.DrawString(f, font, drawBrush, x, y);

                Decimal decFactMonth = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decFactMonth = Convert.ToDecimal(itExecutionPlanShopModel.FactMonth);
                }

                string formatFactMonth = formatDecimal(decFactMonth);
                string factMonth = $"{formatFactMonth}";

                font = new Font("Verdana", 16);
                drawBrush = new SolidBrush(Color.Gray);
                x = 270 - (nDigitsFactMonth * 15) - 10;
                y = 10;

                graphic.DrawString(factMonth, font, drawBrush, x, y);

                string p = $"П:";
                font = new Font("Verdana", 16);
                drawBrush = new SolidBrush(Color.Gray);
                x = 130;
                y = 30;

                graphic.DrawString(p, font, drawBrush, x, y);

                Decimal decPlanMonth = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decPlanMonth = Convert.ToDecimal(itExecutionPlanShopModel.PlanMonth);
                }

                string formatPlanMonth = formatDecimal(decPlanMonth);
                string planMonth = $"{formatPlanMonth}";

                font = new Font("Verdana", 16);
                drawBrush = new SolidBrush(Color.Gray);
                x = 270 - (nDigitsPlanMonth * 15) - 10;
                y = 30;

                graphic.DrawString(planMonth, font, drawBrush, x, y);

            }
            bitmap.Save("PlanMonth.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private void getImageForecast(ItExecutionPlanShopModel itExecutionPlanShopModel)
        {

            Bitmap bitmap = new Bitmap(140, 60);
            using (Graphics graphic = Graphics.FromImage(bitmap))
            {
                Font font = new Font("Verdana", 12);
                SolidBrush drawBrush = new SolidBrush(Color.Gray);

                float x = 26;
                float y = 0;

                graphic.Clear(Color.FromArgb(239, 239, 239));
                graphic.DrawString("Прогноз", font, drawBrush, x, y);

                Pen pen = new Pen(Color.Gray, 3);

                Point[] points =
                {
                     new Point(25, 7),
                     new Point(1, 7),
                     new Point(1, 57),
                     new Point(138, 57),
                     new Point(138, 7),
                     new Point(100, 7)
                };
                graphic.DrawLines(pen, points);

                Decimal decPercentForForecast = 0;

                if (itExecutionPlanShopModel != null)
                {
                    decPercentForForecast = Convert.ToDecimal(itExecutionPlanShopModel.PercentForecast);
                }

                string percentForForecast = $"{Math.Round(decPercentForForecast, 1)}%";

                font = new Font("Verdana", 25);

                if (decPercentForForecast < 100)
                {
                    drawBrush = new SolidBrush(Color.Red);
                }

                if (decPercentForForecast >= 100)
                {
                    drawBrush = new SolidBrush(Color.Green);
                }

                x = 10;
                y = 15;

                graphic.DrawString(percentForForecast, font, drawBrush, x, y);

            }
            bitmap.Save("PlanForecast.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private string formatDecimal(decimal value)
        {
            string svalue = "";

            if (value >= 1000)
            {                
                decimal units = value % 1000;

                units = Math.Truncate(units);

                string sunits = nzero(units);

                decimal thousands = value / 1000;

                thousands = Math.Truncate(thousands);

                if (thousands < 1000)
                {
                    svalue = $"{thousands} {sunits}";
                }

                    if (thousands >= 1000)
                {
                    decimal millions = thousands / 1000;

                    millions = Math.Truncate(millions);

                    thousands = thousands % 1000;

                    string sthousands = nzero(thousands);

                    svalue = $"{millions} {sthousands} {sunits}";
                }
            }

            if (value < 1000)
            {
                value = Math.Truncate(value);
                svalue = $"{value}";
            }

            return svalue;
        }

        private string nzero(decimal value)
        {
            string svalue = "000";

            if ((value < 1000) && (value >= 100))
            {
                svalue = $"{value}";
            }
            if ((value < 100) && (value >= 10))
            {
                svalue = $"0{value}";
            }
            if (value < 10)
            {
                svalue = $"00{value}";
            }

            return svalue;
        }

        private int nDigits(decimal? value)
        {
            decimal dec = Convert.ToDecimal(value);
            dec = Math.Truncate(dec);

            int nDigits = 0;

            while(dec > 0)
            {
                dec /= 10;
                dec = Math.Truncate(dec);

                nDigits++;
            }

            return nDigits;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DentalClinic.Shared
{
    internal sealed class ChartBar
    {
        public string Label = "";
        public int Value { get; set; }
        public Color Color = UiTheme.Primary;
    }

    internal sealed class BarChartPanel : Panel
    {
        private readonly List<ChartBar> _bars = new List<ChartBar>();
        private string _title = "";

        public BarChartPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw, true);
            BackColor = Color.White;
        }

        public string ChartTitle
        {
            get { return _title; }
            set { _title = value ?? ""; Invalidate(); }
        }

        public void SetData(IEnumerable<ChartBar> bars)
        {
            _bars.Clear();
            if (bars != null)
            {
                _bars.AddRange(bars);
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.Clear(Color.White);

            using (Pen border = new Pen(UiTheme.CardBorder, 1f))
            {
                g.DrawRectangle(border, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }

            Rectangle titleRect = new Rectangle(20, 14, Math.Max(10, ClientSize.Width - 40), 28);
            using (SolidBrush titleBrush = new SolidBrush(UiTheme.Navy))
            {
                g.DrawString(_title, UiTheme.ChartTitleFont, titleBrush, titleRect);
            }

            int plotLeft = 52;
            int plotTop = 62;
            int plotRight = ClientSize.Width - 24;
            int plotBottom = ClientSize.Height - 46;
            int plotWidth = plotRight - plotLeft;
            int plotHeight = plotBottom - plotTop;

            if (plotWidth < 60 || plotHeight < 40)
            {
                return;
            }

            if (_bars.Count == 0)
            {
                using (SolidBrush emptyBrush = new SolidBrush(UiTheme.TextMuted))
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    g.DrawString("No data available", UiTheme.BodyFont, emptyBrush,
                        new RectangleF(plotLeft, plotTop, plotWidth, plotHeight), format);
                }
                return;
            }

            int maxValue = 1;
            foreach (ChartBar bar in _bars)
            {
                if (bar.Value > maxValue) maxValue = bar.Value;
            }
            maxValue = (int)(Math.Ceiling(maxValue / 4.0) * 4.0);
            if (maxValue < 4) maxValue = 4;

            using (Pen gridPen = new Pen(Color.FromArgb(238, 242, 247), 1f))
            using (SolidBrush axisBrush = new SolidBrush(UiTheme.TextMuted))
            {
                for (int i = 0; i <= 4; i++)
                {
                    float ratio = i / 4f;
                    int y = plotBottom - (int)(plotHeight * ratio);
                    g.DrawLine(gridPen, plotLeft, y, plotRight, y);

                    string label = ((int)(maxValue * ratio)).ToString();
                    SizeF size = g.MeasureString(label, UiTheme.SmallFont);
                    g.DrawString(label, UiTheme.SmallFont, axisBrush,
                        plotLeft - size.Width - 8, y - size.Height / 2f);
                }
            }

            float slot = plotWidth / (float)_bars.Count;
            float barWidth = Math.Min(70f, slot * 0.52f);
            if (barWidth < 18f) barWidth = Math.Min(18f, slot * 0.8f);

            for (int i = 0; i < _bars.Count; i++)
            {
                ChartBar bar = _bars[i];
                float x = plotLeft + slot * i + (slot - barWidth) / 2f;
                float ratio = bar.Value / (float)maxValue;
                float height = Math.Max(bar.Value == 0 ? 2f : 6f, plotHeight * ratio);
                float y = plotBottom - height;
                RectangleF barRect = new RectangleF(x, y, barWidth, height);

                using (GraphicsPath path = RoundedTopRect(barRect, 6f))
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new RectangleF(barRect.X, barRect.Y - 1, barRect.Width, barRect.Height + 2),
                    ControlPaint.Light(bar.Color, 0.10f), ControlPaint.Dark(bar.Color, 0.05f), 90f))
                {
                    g.FillPath(brush, path);
                }

                using (SolidBrush valueBrush = new SolidBrush(UiTheme.Navy))
                {
                    string value = bar.Value.ToString();
                    SizeF valueSize = g.MeasureString(value, UiTheme.ChartValueFont);
                    g.DrawString(value, UiTheme.ChartValueFont, valueBrush,
                        x + (barWidth - valueSize.Width) / 2f, y - valueSize.Height - 3);
                }

                using (SolidBrush labelBrush = new SolidBrush(UiTheme.TextPrimary))
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Near;
                    RectangleF labelRect = new RectangleF(x + (barWidth - slot) / 2f - 10,
                        plotBottom + 8, slot + 20, 30);
                    g.DrawString(bar.Label, UiTheme.ChartLabelFont, labelBrush, labelRect, format);
                }
            }

            using (Pen baseline = new Pen(Color.FromArgb(214, 222, 232), 1.2f))
            {
                g.DrawLine(baseline, plotLeft, plotBottom, plotRight, plotBottom);
            }
        }

        private static GraphicsPath RoundedTopRect(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = Math.Min(radius * 2f, Math.Min(rect.Width, rect.Height));
            if (diameter <= 1f)
            {
                path.AddRectangle(rect);
                path.CloseFigure();
                return path;
            }

            RectangleF arc = new RectangleF(rect.X, rect.Y, diameter, diameter);
            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            path.AddLine(rect.Right, rect.Y + diameter / 2f, rect.Right, rect.Bottom);
            path.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
            path.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Y + diameter / 2f);
            path.CloseFigure();
            return path;
        }
    }
}

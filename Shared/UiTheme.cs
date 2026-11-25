using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DentalClinic.Shared
{
    internal static class UiTheme
    {
        public static readonly Color Navy = Color.FromArgb(35, 75, 130);
        public static readonly Color NavyActive = Color.FromArgb(38, 95, 155);
        public static readonly Color Primary = Color.FromArgb(23, 100, 192);
        public static readonly Color PrimaryHover = Color.FromArgb(21, 88, 167);
        public static readonly Color PrimaryDown = Color.FromArgb(17, 74, 142);
        public static readonly Color Background = Color.FromArgb(245, 247, 250);
        public static readonly Color CardBorder = Color.FromArgb(226, 232, 240);
        public static readonly Color TextPrimary = Color.FromArgb(45, 55, 72);
        public static readonly Color TextMuted = Color.FromArgb(120, 130, 145);
        public static readonly Color RowAlt = Color.FromArgb(248, 250, 252);
        public static readonly Color SelectionBack = Color.FromArgb(220, 232, 245);

        public static readonly Font TitleFont = new Font("Segoe UI", 24F, FontStyle.Bold);
        public static readonly Font SectionFont = new Font("Segoe UI", 14F, FontStyle.Bold);
        public static readonly Font SubtitleFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font BodyFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font BodyBoldFont = new Font("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font SmallFont = new Font("Segoe UI", 9F, FontStyle.Regular);
        public static readonly Font SmallBoldFont = new Font("Segoe UI", 9F, FontStyle.Bold);
        public static readonly Font ButtonFont = new Font("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font ActionFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        public static readonly Font CountFont = new Font("Segoe UI", 24F, FontStyle.Bold);
        public static readonly Font ChartTitleFont = new Font("Segoe UI", 13F, FontStyle.Bold);
        public static readonly Font ChartValueFont = new Font("Segoe UI", 9F, FontStyle.Bold);
        public static readonly Font ChartLabelFont = new Font("Segoe UI", 8.5F, FontStyle.Regular);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        public static void StylePage(Form form)
        {
            form.BackColor = Background;
        }

        public static void StyleHeader(Panel header)
        {
            header.BackColor = Color.White;
            if (header.Tag as string != "dcHeader")
            {
                header.Tag = "dcHeader";
                header.Paint += HeaderPaint;
            }
        }

        private static void HeaderPaint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;
            using (Pen pen = new Pen(CardBorder, 1f))
            {
                e.Graphics.DrawLine(pen, 0, panel.ClientSize.Height - 1,
                    panel.ClientSize.Width, panel.ClientSize.Height - 1);
            }
        }

        public static void StyleCard(Panel panel)
        {
            panel.BackColor = Color.White;
            if (panel.Tag as string != "dcCard")
            {
                panel.Tag = "dcCard";
                panel.Paint += CardPaint;
            }
        }

        private static void CardPaint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(CardBorder, 1f))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, panel.ClientSize.Width - 1, panel.ClientSize.Height - 1);
            }
        }

        public static void StyleTitle(Label label)
        {
            label.AutoSize = true;
            label.Font = TitleFont;
            label.ForeColor = Navy;
            label.BackColor = Color.Transparent;
        }

        public static void StyleSubtitle(Label label)
        {
            label.AutoSize = true;
            label.Font = SubtitleFont;
            label.ForeColor = TextMuted;
            label.BackColor = Color.Transparent;
        }

        public static void StyleSection(Label label)
        {
            label.AutoSize = true;
            label.Font = SectionFont;
            label.ForeColor = Navy;
            label.BackColor = Color.Transparent;
        }

        public static void StylePrimary(Button button, string text)
        {
            StyleFillButton(button, text, Primary, PrimaryHover, PrimaryDown);
        }

        public static void StyleSecondary(Button button, string text)
        {
            button.Text = text;
            button.AutoSize = false;
            button.Font = ButtonFont;
            button.BackColor = Color.White;
            button.ForeColor = Navy;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 245, 251);
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(228, 237, 248);
            button.UseVisualStyleBackColor = false;
            button.Cursor = Cursors.Hand;
        }

        public static void StyleAction(Button button, string text, Color backColor)
        {
            Color hover = ControlPaint.Light(backColor, 0.12f);
            Color down = ControlPaint.Dark(backColor, 0.08f);
            StyleFillButton(button, text, backColor, hover, down);
            button.Font = ActionFont;
        }

        private static void StyleFillButton(Button button, string text, Color back, Color hover, Color down)
        {
            button.Text = text;
            button.AutoSize = false;
            button.Font = ButtonFont;
            button.BackColor = back;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = hover;
            button.FlatAppearance.MouseDownBackColor = down;
            button.UseVisualStyleBackColor = false;
            button.Cursor = Cursors.Hand;
        }

        public static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = Color.FromArgb(236, 240, 245);
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ColumnHeadersHeight = 44;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.RowTemplate.Height = 42;
            grid.ScrollBars = ScrollBars.Vertical;

            DataGridViewCellStyle header = new DataGridViewCellStyle();
            header.BackColor = Navy;
            header.ForeColor = Color.White;
            header.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            header.Alignment = DataGridViewContentAlignment.MiddleLeft;
            header.Padding = new Padding(8, 0, 6, 0);
            header.SelectionBackColor = Navy;
            header.SelectionForeColor = Color.White;
            header.WrapMode = DataGridViewTriState.True;
            grid.ColumnHeadersDefaultCellStyle = header;

            DataGridViewCellStyle cell = new DataGridViewCellStyle();
            cell.BackColor = Color.White;
            cell.ForeColor = TextPrimary;
            cell.Font = BodyFont;
            cell.SelectionBackColor = SelectionBack;
            cell.SelectionForeColor = Navy;
            cell.Padding = new Padding(8, 0, 6, 0);
            cell.WrapMode = DataGridViewTriState.False;
            grid.DefaultCellStyle = cell;

            DataGridViewCellStyle alt = new DataGridViewCellStyle();
            alt.BackColor = RowAlt;
            alt.ForeColor = TextPrimary;
            alt.Font = BodyFont;
            alt.SelectionBackColor = SelectionBack;
            alt.SelectionForeColor = Navy;
            alt.Padding = new Padding(8, 0, 6, 0);
            grid.AlternatingRowsDefaultCellStyle = alt;
        }

        public static void StyleTextBox(TextBox box, string placeholder)
        {
            box.BorderStyle = BorderStyle.FixedSingle;
            box.Font = BodyFont;
            box.BackColor = Color.White;
            box.ForeColor = TextPrimary;
            box.Height = 32;
            SetPlaceholder(box, placeholder);
        }

        public static void StyleSearchBox(TextBox box, string placeholder)
        {
            StyleTextBox(box, placeholder);
            box.BackColor = Color.FromArgb(252, 253, 255);
        }

        public static void SetPlaceholder(TextBox box, string placeholder)
        {
            if (box == null || string.IsNullOrEmpty(placeholder))
            {
                return;
            }
            if (box.IsHandleCreated)
            {
                SendMessage(box.Handle, 0x1501, (IntPtr)1, placeholder);
            }
            else
            {
                EventHandler apply = null;
                apply = (s, e) =>
                {
                    box.HandleCreated -= apply;
                    SendMessage(box.Handle, 0x1501, (IntPtr)1, placeholder);
                };
                box.HandleCreated += apply;
            }
        }

        public static void StyleCombo(ComboBox combo)
        {
            combo.FlatStyle = FlatStyle.Flat;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.Font = BodyFont;
            combo.BackColor = Color.White;
            combo.ForeColor = TextPrimary;
        }

        public static void StyleDate(DateTimePicker picker)
        {
            picker.Font = BodyFont;
            picker.Format = DateTimePickerFormat.Short;
        }

        public static void AddActionCellColors(DataGridView grid, string columnName)
        {
            DataGridViewColumn column = grid.Columns[columnName];
            if (column == null)
            {
                return;
            }

            grid.CellFormatting += (s, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }
                if (grid.Columns[e.ColumnIndex].Name != columnName)
                {
                    return;
                }

                string value = Convert.ToString(e.Value) ?? "";
                Color color = TextPrimary;
                if (value == "Confirmed" || value == "Completed" || value == "Active" || value == "Available")
                {
                    color = Color.FromArgb(22, 128, 78);
                }
                else if (value == "Pending" || value == "Follow-up")
                {
                    color = Color.FromArgb(176, 106, 7);
                }
                else if (value == "Cancelled" || value == "Unavailable")
                {
                    color = Color.FromArgb(190, 48, 48);
                }
                e.CellStyle.ForeColor = color;
                e.CellStyle.Font = BodyBoldFont;
            };
        }
    }
}

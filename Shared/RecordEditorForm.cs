using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace DentalClinic.Shared
{
    internal enum EditorFieldKind
    {
        Text,
        Integer,
        Money,
        Date,
        Choice
    }

    internal sealed class EditorField
    {
        public string Key = "";
        public string Label = "";
        public EditorFieldKind Kind = EditorFieldKind.Text;
        public string[] Options = new string[0];
        public object Value;
        public bool Required = true;
        public int MinInteger = int.MinValue;
        public int MaxInteger = int.MaxValue;
        public decimal MinMoney = decimal.MinValue;
        public decimal MaxMoney = decimal.MaxValue;
        public int MaxLength = 200;
        public string FormatMessage = "";

        public static EditorField Text(string key, string label, string value)
        {
            return new EditorField { Key = key, Label = label, Kind = EditorFieldKind.Text, Value = value, MaxLength = 200 };
        }

        public static EditorField Multiline(string key, string label, string value)
        {
            return new EditorField { Key = key, Label = label, Kind = EditorFieldKind.Text, Value = value, MaxLength = 500 };
        }

        public static EditorField Integer(string key, string label, object value, int min, int max)
        {
            return new EditorField
            {
                Key = key, Label = label, Kind = EditorFieldKind.Integer,
                Value = value, MinInteger = min, MaxInteger = max
            };
        }

        public static EditorField Money(string key, string label, object value)
        {
            return new EditorField
            {
                Key = key, Label = label, Kind = EditorFieldKind.Money,
                Value = value, MinMoney = 0m, MaxMoney = 1000000m
            };
        }

        public static EditorField Date(string key, string label, DateTime value)
        {
            return new EditorField { Key = key, Label = label, Kind = EditorFieldKind.Date, Value = value };
        }

        public static EditorField Choice(string key, string label, string[] options, string selected)
        {
            return new EditorField
            {
                Key = key, Label = label, Kind = EditorFieldKind.Choice,
                Options = options, Value = selected
            };
        }
    }

    internal sealed class RecordEditorForm : Form
    {
        private sealed class FieldRow
        {
            public EditorField Field;
            public Control Input;
        }

        private readonly List<FieldRow> _rows = new List<FieldRow>();
        private readonly Func<Dictionary<string, object>, string> _extraValidator;
        private readonly ErrorProvider _errors;
        private readonly Label _status;

        public RecordEditorForm(string title, IList<EditorField> fields,
            Func<Dictionary<string, object>, string> extraValidator)
        {
            _extraValidator = extraValidator;

            Text = title;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ShowInTaskbar = false;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;
            Font = UiTheme.BodyFont;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(540, 64 + fields.Count * 70 + 82);

            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 64;
            header.BackColor = UiTheme.Navy;
            Controls.Add(header);

            Label titleLabel = new Label();
            titleLabel.AutoSize = false;
            titleLabel.Text = title;
            titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.SetBounds(24, 12, 480, 30);
            header.Controls.Add(titleLabel);

            Label hint = new Label();
            hint.AutoSize = false;
            hint.Text = "Fields marked * are required.";
            hint.Font = UiTheme.SmallFont;
            hint.ForeColor = Color.FromArgb(200, 215, 235);
            hint.SetBounds(24, 40, 400, 20);
            header.Controls.Add(hint);

            Panel footer = new Panel();
            footer.Dock = DockStyle.Bottom;
            footer.Height = 82;
            footer.BackColor = Color.White;
            footer.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(UiTheme.CardBorder))
                {
                    e.Graphics.DrawLine(pen, 0, 0, footer.ClientSize.Width, 0);
                }
            };
            Controls.Add(footer);

            _status = new Label();
            _status.AutoSize = false;
            _status.Font = UiTheme.SmallFont;
            _status.ForeColor = Color.FromArgb(190, 48, 48);
            _status.SetBounds(24, 12, 300, 56);
            footer.Controls.Add(_status);

            Button cancel = new Button();
            UiTheme.StyleSecondary(cancel, "Cancel");
            cancel.SetBounds(540 - 24 - 110, 22, 110, 38);
            cancel.DialogResult = DialogResult.Cancel;
            footer.Controls.Add(cancel);

            Button save = new Button();
            UiTheme.StylePrimary(save, "Save");
            save.SetBounds(540 - 24 - 110 - 8 - 120, 22, 120, 38);
            save.Click += Save_Click;
            footer.Controls.Add(save);

            Panel body = new Panel();
            body.Dock = DockStyle.Fill;
            body.AutoScroll = true;
            body.BackColor = Color.White;
            body.Padding = new Padding(0, 12, 0, 0);
            Controls.Add(body);
            body.BringToFront();

            int y = 10;
            foreach (EditorField field in fields)
            {
                Label label = new Label();
                label.AutoSize = true;
                label.Text = field.Label + (field.Required ? " *" : "");
                label.Font = UiTheme.SmallBoldFont;
                label.ForeColor = UiTheme.TextPrimary;
                label.Location = new Point(24, y);
                body.Controls.Add(label);

                Control input = CreateInput(field);
                input.SetBounds(24, y + 20, 492, 30);
                input.Name = "field_" + field.Key;
                body.Controls.Add(input);

                _rows.Add(new FieldRow { Field = field, Input = input });
                y += 70;
            }

            _errors = new ErrorProvider();
            _errors.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            _errors.ContainerControl = this;

            AcceptButton = save;
            CancelButton = cancel;
            ActiveControl = _rows.Count > 0 ? _rows[0].Input : null;
        }

        private Control CreateInput(EditorField field)
        {
            switch (field.Kind)
            {
                case EditorFieldKind.Choice:
                    {
                        ComboBox combo = new ComboBox();
                        UiTheme.StyleCombo(combo);
                        if (field.Required)
                        {
                            combo.Items.Add("Select...");
                        }
                        foreach (string option in field.Options)
                        {
                            combo.Items.Add(option);
                        }

                        string selected = Convert.ToString(field.Value);
                        int index = string.IsNullOrEmpty(selected) ? -1 : combo.Items.IndexOf(selected);
                        if (index >= 0)
                        {
                            combo.SelectedIndex = index;
                        }
                        else if (field.Required)
                        {
                            combo.SelectedIndex = 0;
                        }
                        return combo;
                    }
                case EditorFieldKind.Date:
                    {
                        DateTimePicker picker = new DateTimePicker();
                        UiTheme.StyleDate(picker);
                        DateTime value = DateTime.Today;
                        if (field.Value is DateTime)
                        {
                            value = (DateTime)field.Value;
                        }
                        picker.Value = value;
                        return picker;
                    }
                case EditorFieldKind.Integer:
                case EditorFieldKind.Money:
                    {
                        TextBox box = new TextBox();
                        UiTheme.StyleTextBox(box, field.Kind == EditorFieldKind.Money ? "0.00" : "0");
                        box.MaxLength = 12;
                        object value = field.Value;
                        if (value != null)
                        {
                            if (value is decimal)
                            {
                                box.Text = ((decimal)value).ToString("0.##", CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                box.Text = Convert.ToString(value, CultureInfo.InvariantCulture);
                            }
                        }
                        return box;
                    }
                default:
                    {
                        TextBox box = new TextBox();
                        UiTheme.StyleTextBox(box, field.Label);
                        box.MaxLength = field.MaxLength;
                        box.Text = Convert.ToString(field.Value) ?? "";
                        return box;
                    }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            _errors.Clear();
            _status.Text = "";

            Dictionary<string, object> values = new Dictionary<string, object>();
            foreach (FieldRow row in _rows)
            {
                string error;
                if (!TryRead(row, out error))
                {
                    _errors.SetError(row.Input, error);
                    _status.Text = error;
                    row.Input.Focus();
                    return;
                }

                values[row.Field.Key] = ReadValue(row);
            }

            if (_extraValidator != null)
            {
                string message = _extraValidator(values);
                if (!string.IsNullOrEmpty(message))
                {
                    _status.Text = message;
                    MessageBox.Show(this, message, "Please check the data",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool TryRead(FieldRow row, out string error)
        {
            error = null;
            EditorField field = row.Field;

            if (field.Kind == EditorFieldKind.Date)
            {
                return true;
            }

            if (field.Kind == EditorFieldKind.Choice)
            {
                ComboBox combo = (ComboBox)row.Input;
                string value = Convert.ToString(combo.SelectedItem);
                if (field.Required && (combo.SelectedIndex <= 0 && (combo.Items.Count == 0 || value == "Select...")))
                {
                    error = "Please select " + field.Label.ToLowerInvariant() + ".";
                    return false;
                }
                if (field.Required && (value == null || value.Length == 0 || value == "Select..."))
                {
                    error = "Please select " + field.Label.ToLowerInvariant() + ".";
                    return false;
                }
                return true;
            }

            string text = row.Input.Text == null ? "" : row.Input.Text.Trim();
            if (field.Required && text.Length == 0)
            {
                error = field.Label + " is required.";
                return false;
            }

            if (text.Length == 0)
            {
                return true;
            }

            if (field.Kind == EditorFieldKind.Integer)
            {
                int number;
                if (!int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out number))
                {
                    error = field.Label + " must be a whole number.";
                    return false;
                }
                if (number < field.MinInteger || number > field.MaxInteger)
                {
                    error = string.Format("{0} must be between {1} and {2}.", field.Label, field.MinInteger, field.MaxInteger);
                    return false;
                }
            }
            else if (field.Kind == EditorFieldKind.Money)
            {
                decimal amount;
                if (!decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out amount) &&
                    !decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out amount))
                {
                    error = field.Label + " must be a valid amount.";
                    return false;
                }
                if (amount < field.MinMoney || amount > field.MaxMoney)
                {
                    error = field.Label + " must be a positive amount.";
                    return false;
                }
            }

            return true;
        }

        private object ReadValue(FieldRow row)
        {
            EditorField field = row.Field;
            switch (field.Kind)
            {
                case EditorFieldKind.Choice:
                    return Convert.ToString(((ComboBox)row.Input).SelectedItem);
                case EditorFieldKind.Date:
                    return ((DateTimePicker)row.Input).Value.Date;
                case EditorFieldKind.Integer:
                    return int.Parse(row.Input.Text.Trim(), CultureInfo.InvariantCulture);
                case EditorFieldKind.Money:
                    {
                        decimal amount;
                        if (!decimal.TryParse(row.Input.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out amount))
                        {
                            decimal.TryParse(row.Input.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out amount);
                        }
                        return amount;
                    }
                default:
                    return row.Input.Text.Trim();
            }
        }

        public string GetText(string key)
        {
            FieldRow row = FindRow(key);
            return row == null ? "" : row.Input.Text.Trim();
        }

        public int GetInteger(string key)
        {
            FieldRow row = FindRow(key);
            if (row == null) return 0;
            int value;
            int.TryParse(row.Input.Text.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out value);
            return value;
        }

        public decimal GetMoney(string key)
        {
            FieldRow row = FindRow(key);
            if (row == null) return 0m;
            decimal value;
            if (!decimal.TryParse(row.Input.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out value))
            {
                decimal.TryParse(row.Input.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out value);
            }
            return value;
        }

        public DateTime GetDate(string key)
        {
            FieldRow row = FindRow(key);
            return row == null ? DateTime.Today : ((DateTimePicker)row.Input).Value.Date;
        }

        public string GetChoice(string key)
        {
            FieldRow row = FindRow(key);
            if (row == null) return "";
            return Convert.ToString(((ComboBox)row.Input).SelectedItem);
        }

        private FieldRow FindRow(string key)
        {
            foreach (FieldRow row in _rows)
            {
                if (string.Equals(row.Field.Key, key, StringComparison.Ordinal))
                {
                    return row;
                }
            }
            return null;
        }
    }
}

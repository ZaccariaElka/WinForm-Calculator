using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace calculator
{
    public partial class ZaccariaCalculator : Form
    {
        public ZaccariaCalculator()
        {
            InitializeComponent();

            KeyPreview = true;
            KeyDown += MainForm_KeyDown;
            int Gui_Height = Size.Height;
            int Gui_Width = Calculator_Default.Size.Width;

            Size = new Size(Gui_Width, Gui_Height); // to edit
            Calculator_Fractions.Location = new Point(0, 80);
            Calculator_NumberSystem.Location = new Point(0, 80);

            //KeyDown += Button_Exponentiation_Click; //random idea
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //TABS AND CALCULATORS

        private void Hide_Calculators()
        {
            Calculator_Default.Visible = false;
            Calculator_Default.Enabled = false;
            Calculator_Fractions.Visible = false;
            Calculator_Fractions.Enabled = false;
            Calculator_NumberSystem.Visible = false;
            Calculator_NumberSystem.Enabled = false;
        }

        private void Tabs_Click(object sender, EventArgs e)
        {
            Button PressedButton = (Button)sender;
            string ButtonName = PressedButton.Name;

            switch (ButtonName)
            {
                case "Tabs_Default":
                    Hide_Calculators();
                    Calculator_Default.Visible = true;
                    Calculator_Default.Enabled = true;
                    break;
                case "Tabs_Fractions":
                    Hide_Calculators();
                    Calculator_Fractions.Visible = true;
                    Calculator_Fractions.Enabled = true;
                    break;
                case "Tabs_NumberSystem":
                    Hide_Calculators();
                    Calculator_NumberSystem.Visible = true;
                    Calculator_NumberSystem.Enabled = true;
                    break;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (Calculator_Default.Enabled == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter: Button_Equals.PerformClick(); break;
                    case Keys.D0: case Keys.NumPad0: Number_0.PerformClick(); break;
                    case Keys.D1: case Keys.NumPad1: Number_1.PerformClick(); break;
                    case Keys.D2: case Keys.NumPad2: Number_2.PerformClick(); break;
                    case Keys.D3: case Keys.NumPad3: Number_3.PerformClick(); break;
                    case Keys.D4: case Keys.NumPad4: Number_4.PerformClick(); break;
                    case Keys.D5: case Keys.NumPad5: Number_5.PerformClick(); break;
                    case Keys.D6: case Keys.NumPad6: Number_6.PerformClick(); break;
                    case Keys.D7: case Keys.NumPad7: Number_7.PerformClick(); break;
                    case Keys.D8: case Keys.NumPad8: Number_8.PerformClick(); break;
                    case Keys.D9: case Keys.NumPad9: Number_9.PerformClick(); break;
                    case Keys.Oemcomma: case Keys.Decimal: Button_Comma.PerformClick(); break;
                    case Keys.Back: Button_Backspace.PerformClick(); break;
                    case Keys.Add: Button_Addition.PerformClick(); break;
                    case Keys.Subtract: Button_Subtraction.PerformClick(); break;
                    case Keys.Multiply: Button_Multiplication.PerformClick(); break;
                    case Keys.Divide: Button_Division.PerformClick(); break;
                }
            }
            else if (Calculator_Fractions.Enabled == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.D0: case Keys.NumPad0: Fraction_Number_Enter("0"); break;
                    case Keys.D1: case Keys.NumPad1: Fraction_Number_Enter("1"); break;
                    case Keys.D2: case Keys.NumPad2: Fraction_Number_Enter("2"); break;
                    case Keys.D3: case Keys.NumPad3: Fraction_Number_Enter("3"); break;
                    case Keys.D4: case Keys.NumPad4: Fraction_Number_Enter("4"); break;
                    case Keys.D5: case Keys.NumPad5: Fraction_Number_Enter("5"); break;
                    case Keys.D6: case Keys.NumPad6: Fraction_Number_Enter("6"); break;
                    case Keys.D7: case Keys.NumPad7: Fraction_Number_Enter("7"); break;
                    case Keys.D8: case Keys.NumPad8: Fraction_Number_Enter("8"); break;
                    case Keys.D9: case Keys.NumPad9: Fraction_Number_Enter("9"); break;
                    case Keys.Back: Fraction_Del(); break;
                    case Keys.Add: Fractions_Addition.PerformClick(); break;
                    case Keys.Subtract: Fractions_Subtraction.PerformClick(); break;
                    case Keys.Multiply: Fractions_Multiplication.PerformClick(); break;
                    case Keys.Divide: Fractions_Division.PerformClick(); break;


                }
            }
            else if (Calculator_NumberSystem.Enabled == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.D0: case Keys.NumPad0: NumberSystem_0.PerformClick(); break;
                    case Keys.D1: case Keys.NumPad1: NumberSystem_1.PerformClick(); break;
                    case Keys.D2: case Keys.NumPad2: NumberSystem_2.PerformClick(); break;
                    case Keys.D3: case Keys.NumPad3: NumberSystem_3.PerformClick(); break;
                    case Keys.D4: case Keys.NumPad4: NumberSystem_4.PerformClick(); break;
                    case Keys.D5: case Keys.NumPad5: NumberSystem_5.PerformClick(); break;
                    case Keys.D6: case Keys.NumPad6: NumberSystem_6.PerformClick(); break;
                    case Keys.D7: case Keys.NumPad7: NumberSystem_7.PerformClick(); break;
                    case Keys.D8: case Keys.NumPad8: NumberSystem_8.PerformClick(); break;
                    case Keys.D9: case Keys.NumPad9: NumberSystem_9.PerformClick(); break;
                    case Keys.A: NumberSystem_A.PerformClick(); break;
                    case Keys.B: NumberSystem_B.PerformClick(); break;
                    case Keys.C: NumberSystem_C.PerformClick(); break;
                    case Keys.D: NumberSystem_D.PerformClick(); break;
                    case Keys.E: NumberSystem_E.PerformClick(); break;
                    case Keys.F: NumberSystem_F.PerformClick(); break;
                    case Keys.Back: BackSpace(); break;
                    case Keys.Add: NumberSystem_Addition.PerformClick(); break;
                    case Keys.Subtract: NumberSystem_Subtraction.PerformClick(); break;
                    case Keys.Multiply: NumberSystem_Multiplication.PerformClick(); break;
                    case Keys.Divide: NumberSystem_Division.PerformClick(); break;
                }
            }

        }
        //
        //DEFAULT CALCULATOR
        //

        private void Del()
        {
            Numbers_Input.Text = "";
            Numbers_Stored.Text = "";
            Symbol_Selected.Text = "";
        }

        private string SN_Check(double Number) //done
        {
            string result = "";
            if (Number.ToString().Length >= 16)
            {
                result = Number.ToString("E0");
            }
            else
            {
                result = Number.ToString("G");
            }

            return result;
        }

        private void Number_Click(object sender, EventArgs e) //done
        {
            Button PressedButton = (Button)sender;
            string ButtonNumber = PressedButton.Text;

            if (Numbers_Input.Text.Length < Numbers_Input.MaxLength)
            {
                Numbers_Input.Text += ButtonNumber;
            }

            //MessageBox.Show($"{Numbers_input.Text.GetType()}"); //test
            //MesageBox.Show($"{ButtonNumber}", "title"); //test
        }

        private void Numbers_Stored_Click(object sender, EventArgs e) //done
        {
            if (Numbers_Stored.Text != "")
            {
                Numbers_Input.Text = Numbers_Stored.Text;
            }
        }

        private void Button_CE_Click(object sender, EventArgs e) //done
        {
            Numbers_Input.Text = "";
            Numbers_Stored.Text = "";
            Symbol_Selected.Text = "";
        }

        private void Button_C_Click(object sender, EventArgs e) //done
        {
            Numbers_Input.Text = "";
        }

        private void Button_Symbol_Click(object sender, EventArgs e) //done
        {

            Button PressedButton = (Button)sender;
            string ButtonSymbol = PressedButton.Text;
            string ButtonName = PressedButton.Name;

            //MessageBox.Show(ButtonName); //test ButtonName

            if (Numbers_Input.Text != "")
            {
                if (Numbers_Stored.Text != "")
                {

                    double Number_A = Convert.ToDouble(Numbers_Stored.Text);
                    double Number_B = Convert.ToDouble(Numbers_Input.Text);

                    //MessageBox.Show($"{Number_A}");

                    switch (Symbol_Selected.Text)
                    {
                        case "+":
                            Del(); double Addition = Number_A + Number_B;
                            Numbers_Stored.Text = SN_Check(Addition);
                            Symbol_Selected.Text = $"{ButtonSymbol}";
                            Numbers_Input.Text = "";
                            break;
                        case "─":
                            Del(); double Subtraction = Number_A - Number_B;
                            Numbers_Stored.Text = SN_Check(Subtraction);
                            Symbol_Selected.Text = $"{ButtonSymbol}";
                            Numbers_Input.Text = "";
                            break;
                        case "✕":
                            Del(); double Multiplication = Number_A * Number_B;
                            Numbers_Stored.Text = SN_Check(Multiplication);
                            Symbol_Selected.Text = $"{ButtonSymbol}";
                            Numbers_Input.Text = "";
                            break;
                        case "÷":
                            Del(); double Division = Number_A / Number_B;
                            Numbers_Stored.Text = SN_Check(Division);
                            Symbol_Selected.Text = $"{ButtonSymbol}";
                            Numbers_Input.Text = "";
                            break;
                    }
                }
                else
                {
                    Numbers_Stored.Text = Numbers_Input.Text;
                    Symbol_Selected.Text = $"{ButtonSymbol}";
                    Numbers_Input.Text = "";
                }
            }
        }

        private void Button_Comma_Click(object sender, EventArgs e) //done
        {
            if (Numbers_Input.Text != "")
            {
                if (!Numbers_Input.Text.Contains(","))
                {
                    Numbers_Input.Text += ",";
                }
            }
        }

        private void Button_Equals_Click(object sender, EventArgs e) //done
        {

            if (Numbers_Input.Text != "")
            {
                if (Numbers_Stored.Text != "")
                {

                    double Number_A = Convert.ToDouble(Numbers_Stored.Text);
                    double Number_B = Convert.ToDouble(Numbers_Input.Text);

                    //MessageBox.Show($"{Number_A}");

                    switch (Symbol_Selected.Text)
                    {
                        case "+":
                            Del(); double Addition = Number_A + Number_B;
                            Numbers_Input.Text = SN_Check(Addition);
                            break;
                        case "─":
                            Del(); double Subtraction = Number_A - Number_B;
                            Numbers_Input.Text = SN_Check(Subtraction);
                            break;
                        case "✕":
                            Del(); double Multiplication = Number_A * Number_B;
                            Numbers_Input.Text = SN_Check(Multiplication);
                            break;
                        case "÷":
                            Del(); double Division = Number_A / Number_B;
                            Numbers_Input.Text = SN_Check(Division);
                            break;
                        case "^":
                            Del(); double Exponentiation = Math.Pow(Number_A, Number_B);
                            Numbers_Input.Text = SN_Check(Exponentiation);
                            if (Old_Number != "" && Old_Symbol != "")
                            {
                                Numbers_Stored.Text = Old_Number;
                                Symbol_Selected.Text = Old_Symbol;
                            }
                            break;
                    }
                }
            }
        }

        //TRIGONOMETRY (degrees)

        private void Trigonometry_Click(object sender, EventArgs e)
        {
            Button PressedButton = (Button)sender;
            string ButtonText = PressedButton.Text;

            if (Numbers_Input.Text != "")
            {
                double Number = Convert.ToDouble(Numbers_Input.Text);
                double Degrees_Converter = Number * (Math.PI / 180); //Radiant to Degrees

                switch (ButtonText)
                {
                    case "sin":
                        double sin = Math.Sin(Degrees_Converter);
                        Numbers_Input.Text = $"{sin}";
                        break;
                    case "cos":
                        double cos = Math.Cos(Degrees_Converter);
                        Numbers_Input.Text = $"{cos}";
                        break;
                    case "tan":
                        double tan = Math.Tan(Degrees_Converter);
                        Numbers_Input.Text = $"{tan}";
                        break;
                }
            }
        }

        //EXPONENTIATION

        string Old_Number = "";
        string Old_Symbol = "";
        private void Button_Exponentiation_Click(object sender, EventArgs e) //done
        {
            if (Numbers_Input.Text != "")
            {
                if (Numbers_Stored.Text != "" && Symbol_Selected.Text != "")
                {
                    Old_Number = Numbers_Stored.Text;
                    Old_Symbol = Symbol_Selected.Text;
                }

                Numbers_Stored.Text = Numbers_Input.Text;
                Symbol_Selected.Text = "^";
                Numbers_Input.Text = "";
            }
        }

        //SQUARE ROOT

        private void Button_Root_Click(object sender, EventArgs e) //done
        {
            if (Numbers_Input.Text != "")
            {
                double Number = Convert.ToDouble(Numbers_Input.Text);
                Numbers_Input.Text = $"{Math.Sqrt(Number)}";
            }
        }

        //LOG (10)

        private void Button_Logarithm_Click(object sender, EventArgs e) //done
        {
            if (Numbers_Input.Text != "")
            {
                double Number = Convert.ToDouble(Numbers_Input.Text);
                Numbers_Input.Text = $"{Math.Log10(Number)}";
            }
        }

        //FACTORIAL

        private void Button_Factorial_Click(object sender, EventArgs e) //done
        {
            if (Numbers_Input.Text != "")
            {
                if (Numbers_Input.Text.Contains(","))
                {
                    string[] Splitted = Numbers_Input.Text.Split(",");
                    Numbers_Input.Text = Splitted[0];
                }

                int Number = Convert.ToInt32(Numbers_Input.Text);

                int result = 1;
                for (int i = Number; i > 0; i--) { result *= i; }

                Numbers_Input.Text = $"{result}";
            }
        }


        //BACKSPACE
        private void Button_Backspace_Click(object sender, EventArgs e) //done
        {
            if (Numbers_Input.Text != "")
            {

                string currenttext = Numbers_Input.Text;
                string editedtext = currenttext.Remove(currenttext.Length - 1);

                Numbers_Input.Text = editedtext;
            }
        }

        //CUSTOM TITLE BAR 

        private void Button_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_Minimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Panel_Drag_Paint(object sender, PaintEventArgs e)
        {

        }

        bool MouseDown;
        private Point offset;

        private void Panel_Drag_Mousedown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            MouseDown = true;
        }

        private void Panel_Drag_Mousemove(object sender, MouseEventArgs e)
        {
            if (MouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);

            }
        }


        private void Panel_Drag_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown = false;

        }

        //
        // FRACTIONS CALCULATOR
        //


        string Fraction_Selected_Button = "Fractions_Addition";

        private void Fractions_TextChanged(object sender, EventArgs e)
        {
            double NumeratorA = (Numerator_A.Text != "") ? Convert.ToDouble(Numerator_A.Text) : 0;
            double DenominatorA = (Denominator_A.Text != "") ? Convert.ToDouble(Denominator_A.Text) : 0;

            double NumeratorB = (Numerator_B.Text != "") ? Convert.ToDouble(Numerator_B.Text) : 0;
            double DenominatorB = (Denominator_B.Text != "") ? Convert.ToDouble(Denominator_B.Text) : 0;

            double NumeratorSingleMode = (Numerator_SingleMode.Text != "") ? Convert.ToDouble(Numerator_SingleMode.Text) : 0;
            double DenominatorSingleMode = (Denominator_SingleMode.Text != "") ? Convert.ToDouble(Denominator_SingleMode.Text) : 0;

            if (Fraction_Selected_Button == "Fractions_Addition")
            {
                Numerator_Result.Text = $"{NumeratorA * DenominatorB + DenominatorA * NumeratorB}";
                Denominator_Result.Text = $"{DenominatorA * DenominatorB}";
            }
            else if (Fraction_Selected_Button == "Fractions_Subtraction")
            {
                Numerator_Result.Text = $"{NumeratorA * DenominatorB - DenominatorA * NumeratorB}";
                Denominator_Result.Text = $"{DenominatorA * DenominatorB}";
            }
            else if (Fraction_Selected_Button == "Fractions_Multiplication")
            {
                Numerator_Result.Text = $"{NumeratorA * NumeratorB}";
                Denominator_Result.Text = $"{DenominatorA * DenominatorB}";
            }
            else if (Fraction_Selected_Button == "Fractions_Exponentiation")
            {
                Numerator_Result.Text = $"{Math.Pow(NumeratorSingleMode, 2)}";
                Denominator_Result.Text = $"{Math.Pow(DenominatorSingleMode, 2)}";
            }
            else if (Fraction_Selected_Button == "Fractions_Root")
            {
                Numerator_Result.Text = $"{Math.Round(Math.Sqrt(NumeratorSingleMode), 2)}";
                Denominator_Result.Text = $"{Math.Round(Math.Sqrt(DenominatorSingleMode), 2)}";
            }
        }

        private void Fractions_Buttons_Click(object sender, EventArgs e) //show new results when updated
        {
            Button PressedButton = (Button)sender;
            string ButtonName = PressedButton.Name;


            Fractions_Addition.BackColor =
            Fractions_Subtraction.BackColor =
            Fractions_Multiplication.BackColor =
            Fractions_Exponentiation.BackColor =
            Fractions_Root.BackColor =
            Fractions_Division.BackColor = Color.FromArgb(50, 50, 50);

            Fractions_Addition.ForeColor =
            Fractions_Subtraction.ForeColor =
            Fractions_Multiplication.ForeColor =
            Fractions_Exponentiation.ForeColor =
            Fractions_Root.ForeColor =
            Fractions_Division.ForeColor = Color.FromArgb(242, 236, 255);

            Fraction_Selected_Button = ButtonName;
            PressedButton.BackColor = Color.FromArgb(0, 200, 150);
            PressedButton.ForeColor = Color.Black;

            if (Fraction_Selected_Button == "Fractions_Exponentiation" || Fraction_Selected_Button == "Fractions_Root")
            {
                Fraction_A.Visible = Fraction_A.Enabled = false;
                Fraction_B.Visible = Fraction_B.Enabled = false;

                Fraction_SingleMode.Visible = Fraction_SingleMode.Enabled = true;
            }
            else
            {
                Fraction_A.Visible = Fraction_A.Enabled = true;
                Fraction_B.Visible = Fraction_B.Enabled = true;

                Fraction_SingleMode.Visible = Fraction_SingleMode.Enabled = false;
            }
        }

        private void Fraction_Number_Enter(string Number)
        {
            if (Numerator_A.Focused)
            {
                if (Numerator_A.Text.Length < Numerator_A.MaxLength)
                {
                    Numerator_A.Text += Number;
                }
            }
            else if (Denominator_A.Focused)
            {
                if (Denominator_A.Text.Length < Denominator_A.MaxLength)
                {
                    Denominator_A.Text += Number;
                }

            }
            else if (Numerator_B.Focused)
            {
                if (Numerator_B.Text.Length < Numerator_B.MaxLength)
                {
                    Numerator_B.Text += Number;
                }

            }
            else if (Denominator_B.Focused)
            {
                if (Denominator_B.Text.Length < Denominator_B.MaxLength)
                {
                    Denominator_B.Text += Number;
                }

            }
            else if (Numerator_SingleMode.Focused)
            {
                if (Numerator_SingleMode.Text.Length < Numerator_SingleMode.MaxLength)
                {
                    Numerator_SingleMode.Text += Number;
                }
            }
            else if (Denominator_SingleMode.Focused)
            {
                if (Denominator_SingleMode.Text.Length < Denominator_SingleMode.MaxLength)
                {
                    Denominator_SingleMode.Text += Number;
                }
            }
        }

        private void Fraction_Del()
        {
            if (Numerator_A.Focused)
            {
                if (Numerator_A.Text != "")
                {
                    string currenttext = Numerator_A.Text;
                    string editedtext = currenttext.Remove(currenttext.Length - 1);

                    Numerator_A.Text = editedtext;
                }
            }
            else if (Denominator_A.Focused)
            {
                if (Denominator_A.Text != "")
                {
                    string currenttext = Denominator_A.Text;
                    string editedtext = currenttext.Remove(currenttext.Length - 1);

                    Denominator_A.Text = editedtext;
                }
            }
            else if (Numerator_B.Focused)
            {
                if (Numerator_B.Text != "")
                {
                    string currenttext = Numerator_B.Text;
                    string editedtext = currenttext.Remove(currenttext.Length - 1);

                    Numerator_B.Text = editedtext;
                }
            }
            else if (Denominator_B.Focused)
            {
                if (Denominator_B.Text != "")
                {
                    string currenttext = Denominator_B.Text;
                    string editedtext = currenttext.Remove(currenttext.Length - 1);

                    Denominator_B.Text = editedtext;
                }
            }
            else if (Numerator_SingleMode.Focused)
            {
                if (Numerator_SingleMode.Text != "")
                {
                    string currenttext = Numerator_SingleMode.Text;
                    string editedtext = currenttext.Remove(currenttext.Length - 1);

                    Numerator_SingleMode.Text = editedtext;
                }
            }
            else if (Denominator_SingleMode.Focused)
            {
                if (Denominator_SingleMode.Text != "")
                {
                    string currenttext = Denominator_SingleMode.Text;
                    string editedtext = currenttext.Remove(currenttext.Length - 1);

                    Denominator_SingleMode.Text = editedtext;
                }
            }
        }


        //
        //// NUMBER SYSTEM
        //

        string Selected_Number = "";
        private void NumberSystem_Buttons_Click(object sender, EventArgs e)
        {
            Button PressedButton = (Button)sender;
            string ButtonNumber = PressedButton.Text;

            if (Selected_Number == "NumberSystem_Hexadecimal")
            {
                if (NumberSystem_Hexadecimal.Text.Length < NumberSystem_Hexadecimal.MaxLength)
                {
                    NumberSystem_Hexadecimal.Text += ButtonNumber;
                }
            }
            else if (Selected_Number == "NumberSystem_Decimal")
            {
                if (NumberSystem_Decimal.Text.Length < NumberSystem_Decimal.MaxLength)
                {
                    NumberSystem_Decimal.Text += ButtonNumber;
                }
            }
            else if (Selected_Number == "NumberSystem_Octal")
            {
                if (NumberSystem_Octal.Text.Length < NumberSystem_Octal.MaxLength)
                {
                    NumberSystem_Octal.Text += ButtonNumber;
                }
            }
            else if (Selected_Number == "NumberSystem_Binary")
            {
                if (NumberSystem_Binary.Text.Length < NumberSystem_Binary.MaxLength)
                {
                    NumberSystem_Binary.Text += ButtonNumber;
                }
            }
        }

        private void BackSpace()
        {
            if (Selected_Number == "NumberSystem_Hexadecimal")
            {
                if (NumberSystem_Hexadecimal.Text != "")
                {
                    string currenttext = NumberSystem_Hexadecimal.Text;
                    string editedtext = currenttext.Remove(currenttext.Length - 1);

                    NumberSystem_Hexadecimal.Text = editedtext;
                }
            }
            if (Selected_Number == "NumberSystem_Decimal")
            {
                if (NumberSystem_Decimal.Text != "")
                {
                    string currenttext = NumberSystem_Decimal.Text;
                    string editedtext = currenttext.Remove(currenttext.Length - 1);

                    NumberSystem_Decimal.Text = editedtext;
                }
            }
            if (Selected_Number == "NumberSystem_Octal")
            {
                if (NumberSystem_Octal.Text != "")
                {
                    string currenttext = NumberSystem_Octal.Text;
                    string editedtext = currenttext.Remove(currenttext.Length - 1);

                    NumberSystem_Octal.Text = editedtext;
                }
            }
            if (Selected_Number == "NumberSystem_Binary")
            {
                if (NumberSystem_Binary.Text != "")
                {
                    string currenttext = NumberSystem_Binary.Text;
                    string editedtext = currenttext.Remove(currenttext.Length - 1);

                    NumberSystem_Binary.Text = editedtext;
                }
            }
        }

        private void Disable_Buttons()
        {
            NumberSystem_0.Enabled =
            NumberSystem_1.Enabled =
            NumberSystem_2.Enabled =
            NumberSystem_3.Enabled =
            NumberSystem_4.Enabled =
            NumberSystem_5.Enabled =
            NumberSystem_6.Enabled =
            NumberSystem_7.Enabled =
            NumberSystem_8.Enabled =
            NumberSystem_9.Enabled =
            NumberSystem_A.Enabled =
            NumberSystem_B.Enabled =
            NumberSystem_C.Enabled =
            NumberSystem_D.Enabled =
            NumberSystem_E.Enabled =
            NumberSystem_F.Enabled = false;
        }

        private void Hexadecimal_Click(object sender, EventArgs e)
        {
            NumberSystem_0.Enabled =
            NumberSystem_1.Enabled =
            NumberSystem_2.Enabled =
            NumberSystem_3.Enabled =
            NumberSystem_4.Enabled =
            NumberSystem_5.Enabled =
            NumberSystem_6.Enabled =
            NumberSystem_7.Enabled =
            NumberSystem_8.Enabled =
            NumberSystem_9.Enabled =
            NumberSystem_A.Enabled =
            NumberSystem_B.Enabled =
            NumberSystem_C.Enabled =
            NumberSystem_D.Enabled =
            NumberSystem_E.Enabled =
            NumberSystem_F.Enabled = true;

            Selected_Number = "NumberSystem_Hexadecimal";
        }

        private void Decimal_Click(object sender, EventArgs e)
        {
            Disable_Buttons();
            NumberSystem_0.Enabled =
            NumberSystem_1.Enabled =
            NumberSystem_2.Enabled =
            NumberSystem_3.Enabled =
            NumberSystem_4.Enabled =
            NumberSystem_5.Enabled =
            NumberSystem_6.Enabled =
            NumberSystem_7.Enabled =
            NumberSystem_8.Enabled =
            NumberSystem_9.Enabled = true;

            Selected_Number = "NumberSystem_Decimal";
        }

        private void Octal_Click(object sender, EventArgs e)
        {
            Disable_Buttons();
            NumberSystem_0.Enabled =
            NumberSystem_1.Enabled =
            NumberSystem_2.Enabled =
            NumberSystem_3.Enabled =
            NumberSystem_4.Enabled =
            NumberSystem_5.Enabled =
            NumberSystem_6.Enabled =
            NumberSystem_7.Enabled = true;

            Selected_Number = "NumberSystem_Octal";
        }

        private void Binary_Click(object sender, EventArgs e)
        {
            Disable_Buttons();
            NumberSystem_0.Enabled =
            NumberSystem_1.Enabled = true;

            Selected_Number = "NumberSystem_Binary";
        }



        private void Hexadecimal_Change(object sender, EventArgs e)
        {
            if (Selected_Number == "NumberSystem_Hexadecimal")
            {
                if (NumberSystem_Hexadecimal.Text != "")
                {
                    BigInteger dec = BigInteger.Parse(NumberSystem_Hexadecimal.Text, System.Globalization.NumberStyles.HexNumber);
                    string oct = Convert.ToString((long)dec, 8);
                    string bin = Convert.ToString((long)dec, 2);

                    NumberSystem_Decimal.Text = dec.ToString();
                    NumberSystem_Octal.Text = oct;
                    NumberSystem_Binary.Text = bin;
                }
                else
                {
                    NumberSystem_Decimal.Text =
                    NumberSystem_Octal.Text =
                    NumberSystem_Binary.Text = "";
                }
            }
        }

        private void Decimal_Change(object sender, EventArgs e)
        {
            if (Selected_Number == "NumberSystem_Decimal")
            {
                if (NumberSystem_Decimal.Text != "")
                {
                    BigInteger dec = BigInteger.Parse(NumberSystem_Decimal.Text);
                    string hex = dec.ToString("X");
                    string oct = Convert.ToString((long)dec, 8);
                    string bin = Convert.ToString((long)dec, 2);

                    NumberSystem_Hexadecimal.Text = hex;
                    NumberSystem_Octal.Text = oct;
                    NumberSystem_Binary.Text = bin;
                }
                else
                {
                    NumberSystem_Hexadecimal.Text =
                    NumberSystem_Octal.Text =
                    NumberSystem_Binary.Text = "";
                }
            }
        }

        private void Octal_Change(object sender, EventArgs e)
        {
            if (Selected_Number == "NumberSystem_Octal")
            {
                if (NumberSystem_Octal.Text != "")
                {
                    BigInteger dec = ConvertFromBase(NumberSystem_Octal.Text, 8);
                    string hex = dec.ToString("X");
                    string bin = Convert.ToString((long)dec, 2);

                    NumberSystem_Decimal.Text = dec.ToString();
                    NumberSystem_Hexadecimal.Text = hex;
                    NumberSystem_Binary.Text = bin;
                }
                else
                {
                    NumberSystem_Decimal.Text =
                    NumberSystem_Hexadecimal.Text =
                    NumberSystem_Binary.Text = "";
                }
            }
        }

        private void Binary_Change(object sender, EventArgs e)
        {
            if (Selected_Number == "NumberSystem_Binary")
            {
                if (NumberSystem_Binary.Text != "")
                {
                    BigInteger dec = ConvertFromBase(NumberSystem_Binary.Text, 2);
                    string hex = dec.ToString("X");
                    string oct = Convert.ToString((long)dec, 8);

                    NumberSystem_Decimal.Text = dec.ToString();
                    NumberSystem_Hexadecimal.Text = hex;
                    NumberSystem_Octal.Text = oct;
                }
                else
                {
                    NumberSystem_Decimal.Text =
                    NumberSystem_Hexadecimal.Text =
                    NumberSystem_Octal.Text = "";
                }
            }
        }


        private BigInteger ConvertFromBase(string number, int fromBase) //From ChatGPT
        {
            BigInteger result = 0;
            foreach (char c in number)
            {
                int value = c >= '0' && c <= '9' ? c - '0' :
                            c >= 'A' && c <= 'F' ? c - 'A' + 10 :
                            c >= 'a' && c <= 'f' ? c - 'a' + 10 : 0;
                result = result * fromBase + value;
            }
            return result;
        }

        BigInteger Stored_Number = 0;
        string Operator_Selected = "";

        private void NumberSystem_Operator_Click(object sender, EventArgs e)
        {
            Button PressedButton = (Button)sender;
            string ButtonName = PressedButton.Name;

            if (NumberSystem_Decimal.Text != "")
            {
                if (Stored_Number != 0)
                {
                    BigInteger New_Number = BigInteger.Parse(NumberSystem_Decimal.Text);


                    switch (Operator_Selected)
                    {
                        case "NumberSystem_Addition":
                            NumberSystem_Decimal.Text = "";
                            BigInteger Addition = Stored_Number + New_Number;
                            string hex = Addition.ToString("X");
                            string oct = Convert.ToString((long)Addition, 8);
                            string bin = Convert.ToString((long)Addition, 2);

                            NumberSystem_Decimal.Text = Addition.ToString();
                            NumberSystem_Hexadecimal.Text = hex;
                            NumberSystem_Octal.Text = oct;
                            NumberSystem_Binary.Text = bin;

                            Stored_Number = 0;
                            Operator_Selected = "";
                            break;
                        case "NumberSystem_Subtraction":
                            NumberSystem_Decimal.Text = "";
                            BigInteger Subtraction = Stored_Number - New_Number;
                            hex = Subtraction.ToString("X");
                            oct = Convert.ToString((long)Subtraction, 8);
                            bin = Convert.ToString((long)Subtraction, 2);

                            NumberSystem_Decimal.Text = Subtraction.ToString();
                            NumberSystem_Hexadecimal.Text = hex;
                            NumberSystem_Octal.Text = oct;
                            NumberSystem_Binary.Text = bin;

                            Stored_Number = 0;
                            Operator_Selected = "";
                            break;
                        case "NumberSystem_Multiplication":
                            NumberSystem_Decimal.Text = "";
                            BigInteger Multiplication = Stored_Number * New_Number;
                            hex = Multiplication.ToString("X");
                            oct = Convert.ToString((long)Multiplication, 8);
                            bin = Convert.ToString((long)Multiplication, 2);

                            NumberSystem_Decimal.Text = Multiplication.ToString();
                            NumberSystem_Hexadecimal.Text = hex;
                            NumberSystem_Octal.Text = oct;
                            NumberSystem_Binary.Text = bin;

                            Stored_Number = 0;
                            Operator_Selected = "";
                            break;
                        case "NumberSystem_Division":
                            NumberSystem_Decimal.Text = "";
                            BigInteger Division = Stored_Number / New_Number;
                            hex = Division.ToString("X");
                            oct = Convert.ToString((long)Division, 8);
                            bin = Convert.ToString((long)Division, 2);

                            NumberSystem_Decimal.Text = Division.ToString();
                            NumberSystem_Hexadecimal.Text = hex;
                            NumberSystem_Octal.Text = oct;
                            NumberSystem_Binary.Text = bin;

                            Stored_Number = 0;
                            Operator_Selected = "";
                            break;

                    }
                }
                else
                {
                    Stored_Number = BigInteger.Parse(NumberSystem_Decimal.Text); ;
                    Operator_Selected = $"{ButtonName}";

                    NumberSystem_Decimal.Text =
                    NumberSystem_Hexadecimal.Text =
                    NumberSystem_Octal.Text =
                    NumberSystem_Binary.Text = "";
                }
            }   
        }
    }
}

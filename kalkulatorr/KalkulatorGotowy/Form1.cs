namespace KalkulatorGotowy
{
    
    public partial class Form1 : Form
    
    {
       
        // Przechowuje bie��c� warto�� podczas oblicze�.
        float buffer = 0;
        // Przechowuje symbol aktualnej operacji (+, -, *, /).
        char operation = ' ';
        // Flaga wskazuj�ca, czy wynik ostatniego dzia�ania zosta� ju� wy�wietlony.
        bool resultShown = false;

        
        public Form1()
        {
            InitializeComponent();
        }

       
        private void ButtonPressed(object sender, EventArgs e)
        
        {
            // Je�li wynik zosta� ju� pokazany, resetuje ekran przed wpisaniem nowej liczby
            if (resultShown)
            {
                displayTextBox.Text = string.Empty;
                resultShown = false;
            }

            int number = int.Parse(((Button)sender).Text);
            displayTextBox.Text += number;
        }

        //  Zeruje ekran, bufor oraz operacj�.
        private void ClearDisplay(object sender, EventArgs e)
       
        {
            displayTextBox.Text = String.Empty;
            buffer = 0;
            operation = ' ';
        }

       
        private void FunctionButtonPressed(object sender, EventArgs e)
       
        {
            // Je�eli nie ma zapisanej operacji, zapisuje operacj�
            if (operation == ' ')
            {
                buffer = float.Parse(displayTextBox.Text);  // Przechowuje liczb� w buforze
                displayTextBox.Text = string.Empty;
                operation = ((Button)sender).Text[0]; // Zapisujemy operacj�
            }
            else
            {
                // Wykonuje operacj� na poprzednim buforze i obecnym wy�wietlaczu 
                PerformOperation();
                // Po wykonaniu operacji, zapisuje now� operacj�
                operation = ((Button)sender).Text[0];
                resultShown = false;
            }
        }

       
        private void ShowResult(object sender, EventArgs e)
       
        {
            // Wykonuje operacje i wy�wietla wynik
            PerformOperation();
            // Resetuje operacje
            operation = ' ';
            resultShown = true;
        }

       
        private void PerformOperation()
        
        {
            // Wykonanie operacji w zale�no�ci od tego, jaki operator jest zapisany w zmiennej 'operation'
            switch (operation)
            {
                case '+':
                    buffer += float.Parse(displayTextBox.Text);
                    break;
                case '-':
                    buffer -= float.Parse(displayTextBox.Text);
                    break;
                case '*':
                    buffer *= float.Parse(displayTextBox.Text);
                    break;
                case '/':
                    // Sprawdza, czy nie dzieli przez 0
                    if (float.Parse(displayTextBox.Text) == 0)
                    {
                        displayTextBox.Text = "B��D: DZIELI�E� PRZEZ 0";
                        return;
                    }
                    buffer /= float.Parse(displayTextBox.Text);
                    break;
                default:
                    break;
            }

            // Wy�wietla wynik w TextBoxie
            displayTextBox.Text = buffer.ToString();
        }

        
        private void button14_Click(object sender, EventArgs e)
        
        {
            // Odejmowanie
            if (operation == ' ')
            {
                buffer = float.Parse(displayTextBox.Text);
                displayTextBox.Text = String.Empty;
                operation = '-';
            }
            else
            {
                PerformOperation();
                operation = '-';
            }
        }

       
        private void button15_Click(object sender, EventArgs e)
        
        {
            // Mno�enie
            if (operation == ' ')
            {
                buffer = float.Parse(displayTextBox.Text);
                displayTextBox.Text = String.Empty;
                operation = '*';
            }
            else
            {
                PerformOperation();
                operation = '*';
            }
        }

        // Dodawanie metody, kt�ra obs�uguje dzielenie
        
        private void button16_Click(object sender, EventArgs e)
        
        {
            // Dzielenie
            if (operation == ' ')
            {
                buffer = float.Parse(displayTextBox.Text);
                displayTextBox.Text = String.Empty;
                operation = '/';
            }
            else
            {
                PerformOperation();
                operation = '/';
            }
        }
    }
}

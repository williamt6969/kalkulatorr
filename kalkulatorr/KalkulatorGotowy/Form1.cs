namespace KalkulatorGotowy
{
    
    public partial class Form1 : Form
    
    {
       
        // Przechowuje bie¿¹c¹ wartoœæ podczas obliczeñ.
        float buffer = 0;
        // Przechowuje symbol aktualnej operacji (+, -, *, /).
        char operation = ' ';
        // Flaga wskazuj¹ca, czy wynik ostatniego dzia³ania zosta³ ju¿ wyœwietlony.
        bool resultShown = false;

        
        public Form1()
        {
            InitializeComponent();
        }

       
        private void ButtonPressed(object sender, EventArgs e)
        
        {
            // Jeœli wynik zosta³ ju¿ pokazany, resetuje ekran przed wpisaniem nowej liczby
            if (resultShown)
            {
                displayTextBox.Text = string.Empty;
                resultShown = false;
            }

            int number = int.Parse(((Button)sender).Text);
            displayTextBox.Text += number;
        }

        //  Zeruje ekran, bufor oraz operacjê.
        private void ClearDisplay(object sender, EventArgs e)
       
        {
            displayTextBox.Text = String.Empty;
            buffer = 0;
            operation = ' ';
        }

       
        private void FunctionButtonPressed(object sender, EventArgs e)
       
        {
            // Je¿eli nie ma zapisanej operacji, zapisuje operacjê
            if (operation == ' ')
            {
                buffer = float.Parse(displayTextBox.Text);  // Przechowuje liczbê w buforze
                displayTextBox.Text = string.Empty;
                operation = ((Button)sender).Text[0]; // Zapisujemy operacjê
            }
            else
            {
                // Wykonuje operacjê na poprzednim buforze i obecnym wyœwietlaczu 
                PerformOperation();
                // Po wykonaniu operacji, zapisuje now¹ operacjê
                operation = ((Button)sender).Text[0];
                resultShown = false;
            }
        }

       
        private void ShowResult(object sender, EventArgs e)
       
        {
            // Wykonuje operacje i wyœwietla wynik
            PerformOperation();
            // Resetuje operacje
            operation = ' ';
            resultShown = true;
        }

       
        private void PerformOperation()
        
        {
            // Wykonanie operacji w zale¿noœci od tego, jaki operator jest zapisany w zmiennej 'operation'
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
                        displayTextBox.Text = "B£¥D: DZIELI£EŒ PRZEZ 0";
                        return;
                    }
                    buffer /= float.Parse(displayTextBox.Text);
                    break;
                default:
                    break;
            }

            // Wyœwietla wynik w TextBoxie
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
            // Mno¿enie
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

        // Dodawanie metody, która obs³uguje dzielenie
        
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

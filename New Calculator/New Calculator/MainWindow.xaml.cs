using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace New_Calculator
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int num1;
        private int num2;
        private string TextBoxSet;
        private string textb1;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SetButtonValueToTextBox(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;//una instancia de la clase button que convierte explicitamente el objeto sender

            if (clickedButton != null)
            {
                texBox1.Text += clickedButton.Content.ToString();//Un operador de suma que añade un elemento a la propiedad Text del texBox1
            }
        }
        private string DeleteFunctionTextSet(string textDeletion)//Toma una lista con el valor del string del texBox1 y elimina el último elemento ingresado de la lista
        {
            List<char> list = textDeletion.ToCharArray().ToList();
            if(list.Count > 0)
            {
            list.RemoveAt(list.Count - 1);
            return new string(list.ToArray());
            }
            return "0";
        }
        private void Delete_Click(object sender, RoutedEventArgs e)//Al darle click al botón Delete, invoca la función DeleteFunctionSetText
        {
            texBox1.Text = DeleteFunctionTextSet(texBox1.Text);
        }
        private char ValidateOperation( string stringToValidate)//Valida si el string ingresado se puede operar
        {
            if(stringToValidate != null)
            {
                foreach(char c in stringToValidate)
                {
                    if (!char.IsDigit(c))
                    {
                        return c;
                    }
                }
                return '0';
            }
            else
            {
                throw new ArgumentNullException(nameof(stringToValidate), "La cadena no puede ser nula.");
            }
        }
        public void OperationManager()//Administra a donde irá cada operación.
        {
            string[] operationSelcted;

            if (ValidateOperation(texBox1.Text) == '+')
            {
                operationSelcted = texBox1.Text.Split('+');
                texBox1.Text =Convert.ToString(OperationSum(operationSelcted));
            }
            if (ValidateOperation(texBox1.Text) == '-')
            {
                operationSelcted = texBox1.Text.Split('-');
                texBox1.Text = Convert.ToString(OperationRest(operationSelcted));
            }
            if (ValidateOperation(texBox1.Text) == '*')
            {
                operationSelcted = texBox1.Text.Split('*');
                texBox1.Text = Convert.ToString(OperationMulti(operationSelcted));
            }
            if (ValidateOperation(texBox1.Text) == '/')
            {
                operationSelcted = texBox1.Text.Split('/');
                texBox1.Text = Convert.ToString(OperationDiv(operationSelcted));
            }
        }
        public int ConversorString(string stringer)//convierte los strings de texBox1 en enteros
        {
            if (int.TryParse(stringer, out int resultado))
            {
                return resultado;
            }
            else
            {
                throw new ArgumentException("El string no es un número válido.", nameof(stringer));
            }
        }
       public int OperationSum(string[] sum)
        {
            int num1;
            int num2;
            if (sum != null && sum.Length < 3)
            {
                num1 = ConversorString(sum[0]);
                num2 = ConversorString(sum[1]);
                return (num1 + num2);
            }
            return 0;
        }
        public int OperationRest(string[] sum)
        {
            int num1;
            int num2;
            if (sum != null && sum.Length < 3)
            {
                num1 = ConversorString(sum[0]);
                num2 = ConversorString(sum[1]);
                return (num1 - num2);
            }
            return 0;
        }
        public int OperationMulti(string[] sum)
        {
            int num1;
            int num2;
            if (sum != null && sum.Length < 3)
            {
                num1 = ConversorString(sum[0]);
                num2 = ConversorString(sum[1]);
                return (num1 * num2);
            }
            return 0;
        }
        public int OperationDiv(string[] sum)
        {
            int num1;
            int num2;
            if (sum != null && sum.Length < 3)
            {
                num1 = ConversorString(sum[0]);
                num2 = ConversorString(sum[1]);
                if (num1 > 0 && num2 >= 0)
                {
                    return num1 / num2;
                }
            }
            return 0;
        }

        public void OperationExecution(object sender, RoutedEventArgs e)
        {
            OperationManager();
        }
    }
}

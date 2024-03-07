using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PiedraPapelTijera
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public ToggleButton[] arras = new ToggleButton[3];
        public Image sourceImagePaper = null;
        public int winCounter = 0;
        public int loseCounter = 0;
        public int empat = 0;
        public string option;
        public MainWindow()
        {
            InitializeComponent();
            arras = SetArraySelectionsButton();
        }

        private ToggleButton[] SetArraySelectionsButton()
        {
            ToggleButton[] buttons = new ToggleButton[3];
            buttons[0] = btn1;
            buttons[1] = btn2;
            buttons[2] = btn3;
            return buttons;
        }

        private void Comprobation(ToggleButton button2)
        {
            foreach (ToggleButton button in arras)
            {
                if (button != button2)
                {
                    button.IsEnabled = true;
                }
                if (button == button2)
                {
                    button.IsEnabled = false;
                }
            }
        }

        public string RandomizeOpositorSelection()
        {
            switch (RandomizeToggleObject())
            {
                case 0:
                    option = "Papel";
                    break;
                case 1:
                    option = "Piedra";
                    break;
                case 2:
                    option = "Tijera";
                    break;
            }
            return option;
        }

        public int RandomizeToggleObject()
        {
            Random rand = new Random();
            return rand.Next(0, 3);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton button = (ToggleButton)sender;
            Comprobation(button);
        }

        public void CheckInData(ToggleButton button)
        {
            string userSelection = button.Content.ToString();
            string opponentSelection = RandomizeOpositorSelection();

            // Realizar acciones basadas en las selecciones
            if (userSelection == "Tijera" && opponentSelection == "Tijera")
            {
                ImageSource.Source = new BitmapImage(new Uri("D:\\Proyectos\\Csharpp\\WebAppPractice\\PiedraPapelTijera\\PiedraPapelTijera\\ImagSources\\Tijera.jpg", UriKind.Absolute));
                MessageBox.Show("Empate");
                empat++;
            }
            else if (userSelection == "Tijera" && opponentSelection == "Piedra")
            {
                ImageSource.Source = new BitmapImage(new Uri("D:\\Proyectos\\Csharpp\\WebAppPractice\\PiedraPapelTijera\\PiedraPapelTijera\\ImagSources\\Piedra.jpg", UriKind.Absolute));
                MessageBox.Show("Perdiste");
                loseCounter++;
            }
            else if (userSelection == "Tijera" && opponentSelection == "Papel")
            {
                ImageSource.Source = new BitmapImage(new Uri("D:\\Proyectos\\Csharpp\\WebAppPractice\\PiedraPapelTijera\\PiedraPapelTijera\\ImagSources\\Papel.jpg", UriKind.Absolute));
                MessageBox.Show("Ganaste");
                winCounter++;
            }
            else if (userSelection == "Papel" && opponentSelection == "Papel")
            {

                ImageSource.Source = new BitmapImage(new Uri("D:\\Proyectos\\Csharpp\\WebAppPractice\\PiedraPapelTijera\\PiedraPapelTijera\\ImagSources\\Papel.jpg", UriKind.Absolute));
                MessageBox.Show("Empate");
                empat++;

            }
            else if (userSelection == "Piedra" && opponentSelection == "Papel")
            {
                ImageSource.Source = new BitmapImage(new Uri("D:\\Proyectos\\Csharpp\\WebAppPractice\\PiedraPapelTijera\\PiedraPapelTijera\\ImagSources\\Papel.jpg", UriKind.Absolute));
                MessageBox.Show("Perdiste");
                loseCounter++;
            }
            else if (userSelection == "Piedra" && opponentSelection == "Tijera")
            {
                ImageSource.Source = new BitmapImage(new Uri("D:\\Proyectos\\Csharpp\\WebAppPractice\\PiedraPapelTijera\\PiedraPapelTijera\\ImagSources\\Tijera.jpg", UriKind.Absolute));
                MessageBox.Show("Ganaste");
                winCounter++;
            }
            else if (userSelection == "Papel" && opponentSelection == "Tijera")
            {
                ImageSource.Source = new BitmapImage(new Uri("D:\\Proyectos\\Csharpp\\WebAppPractice\\PiedraPapelTijera\\PiedraPapelTijera\\ImagSources\\Tijera.jpg", UriKind.Absolute));
                MessageBox.Show("Perdiste");
                loseCounter++;
            }
            else if (userSelection == "Papel" && opponentSelection == "Piedra")
            {
                ImageSource.Source = new BitmapImage(new Uri("D:\\Proyectos\\Csharpp\\WebAppPractice\\PiedraPapelTijera\\PiedraPapelTijera\\ImagSources\\Piedra.jpg", UriKind.Absolute));
                MessageBox.Show("Ganaste");
                winCounter++;
            }
            else if (userSelection == "Piedra" && opponentSelection == "Piedra")
            {
                ImageSource.Source = new BitmapImage(new Uri("D:\\Proyectos\\Csharpp\\WebAppPractice\\PiedraPapelTijera\\PiedraPapelTijera\\ImagSources\\Piedra.jpg", UriKind.Absolute));
                MessageBox.Show("Empate");
                empat++;
            }
            txt1.Text = $"Cantidad de victorias: {winCounter}";
            txt2.Text = $"Cantidad de Derrotas: {loseCounter}";
            txt3.Text = $"Cantidad de Empates: {empat}";
        }

        private void ButtonCheck_Click(object sender, RoutedEventArgs e)
        {
            // Llamas a CheckInData con el botón que está desactivado
            ToggleButton disabledButton = arras.FirstOrDefault(button => !button.IsEnabled);
            if (disabledButton != null)
            {
                CheckInData(disabledButton);
            }
            else
            {
                MessageBox.Show("Por favor, Selecciona una opcion");
            }
        }
    }
}

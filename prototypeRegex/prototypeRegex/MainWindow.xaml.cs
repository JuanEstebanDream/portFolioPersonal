using System;
using System.Collections.Generic;
using System.Linq;
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

namespace prototypeRegex
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Grid grid;
        public List<ToggleButton> toggl;

        public MainWindow()
        {
            InitializeComponent();
            gridBtn1.DataContext = toggl;
            string nomino = inpuText.Text.ToString();
        }

        public ToggleButton generateButton(char un)
        {
            ToggleButton nwButt = new ToggleButton();
            if (char.IsUpper(un))
            {
                nwButt.Content = un.ToString();
            }
            else
            {
                nwButt.Content = un;
            }
            return nwButt;
        }
        public char returnedBinding(string stringer)
        {
            if (stringer != null)
            {
                foreach (char s in stringer)
                {
                    return s;
                }
            }
            return ' ';
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string nomino = inpuText.Text.ToString();

            foreach (char character in nomino)
            {
                if (char.IsUpper(character))
                {

                ToggleButton button = generateButton(character);

                // Crear una nueva columna para cada botón
                ColumnDefinition columnDefinition = new ColumnDefinition();
                gridBtn1.ColumnDefinitions.Add(columnDefinition);

                // Calcular la fila (siempre será 0) y la columna
                int row = 0;
                int column = gridBtn1.ColumnDefinitions.Count - 1;

                // Asignar la fila y la columna al botón
                Grid.SetRow(button, row);
                Grid.SetColumn(button, column);

                gridBtn1.Children.Add(button);
                }
            }
        }
    }
}

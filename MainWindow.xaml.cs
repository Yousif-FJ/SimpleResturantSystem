using SimpleResturantSystem.Model;
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

namespace SimpleResturantSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModel viewModel { get; }
        public MainWindow()
        {
            InitializeComponent();
            var dises =  CodeDishesGenerator.GetDishes();
            viewModel = new ViewModel { Dishes = dises };
            DataContext = viewModel;
            GenerateDishesElement();
        }

        private void GenerateDishesElement()
        {
            foreach (var dish in viewModel.Dishes)
            {
                var stackPanelMain = new StackPanel()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(20, 20, 20, 20)
                };

                var price = new TextBlock()
                {
                    FontSize = 24,
                    Text = dish.Price.ToString()
                };

                var image = new Image()
                {
                    Source = new BitmapImage(new Uri(dish.PhotoUri)),
                    Height = 200,
                    Width = 200
                };

                var stackPanelButtons = new StackPanel()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 10, 0, 10),
                };

                var plusButton = CreateMinusPlusButton(dish, "+");
                plusButton.Click += PlusButton_Click;

                var count = new TextBlock()
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 24,
                    Text = dish.Count.ToString(),
                    DataContext = dish
                };
                count.SetBinding(TextBlock.TextProperty, "Count");

                var minusButton = CreateMinusPlusButton(dish, "-");
                minusButton.Click += MinusButton_Click;

                stackPanelMain.Children.Add(price);
                stackPanelMain.Children.Add(image); 
                stackPanelMain.Children.Add(stackPanelButtons);
                stackPanelButtons.Children.Add(plusButton);
                stackPanelButtons.Children.Add(count);
                stackPanelButtons.Children.Add(minusButton);
                DishesWrapPanel.Children.Add(stackPanelMain);
            }
        }

        private static Button CreateMinusPlusButton(Dish dish,string plusOrMinus )
        {
            return new Button()
            {
                Content = plusOrMinus,
                Width = 40,
                FontSize = 32,
                Margin = new Thickness(20, 0, 20, 0),
                DataContext = dish
            };
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var dish = (Dish)button.DataContext;
            ++dish.Count;
            viewModel.Total +=dish.Price;    
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var dish = (Dish)button.DataContext;
            if (viewModel.Total> 0)
            {
                --dish.Count;
                viewModel.Total -= dish.Price;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Reset();
        }
    }
}
